using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ON.Settings.SimpleSettings.Service.Data;
using ON.Settings.SimpleSettings.Service.Helpers;
using ON.Fragments.Authentication;
using ON.Fragments.Authorization;
using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ON.Authentication;
using ON.Fragments.Settings;

namespace ON.Settings.SimpleSettings.Service.Services
{
    public class SettingsService : SettingsInterface.SettingsInterfaceBase
    {
        private readonly OfflineHelper offlineHelper;
        private readonly ILogger<ServiceOpsService> logger;
        private readonly ISettingsDataProvider dataProvider;

        public SettingsService(OfflineHelper offlineHelper, ILogger<ServiceOpsService> logger, ISettingsDataProvider dataProvider)
        {
            this.offlineHelper = offlineHelper;
            this.logger = logger;
            this.dataProvider = dataProvider;

            EnsureStockSettings().Wait();
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER_OR_SERVICE)]
        public override async Task<GetAdminDataResponse> GetAdminData(GetAdminDataRequest request, ServerCallContext context)
        {
            var record = await dataProvider.Get();
            if (record == null)
                return new() { };

            return new()
            {
                Public = record.Public,
                Private = record.Private,
            };
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER_OR_SERVICE)]
        public override async Task<GetAdminNewerDataResponse> GetAdminNewerData(GetAdminNewerDataRequest request, ServerCallContext context)
        {
            var record = await dataProvider.Get();
            if (record == null)
                return new() { };

            if (record?.Public?.VersionNum == request.VersionNum)
                record = null;

            return new()
            {
                Public = record?.Public,
                Private = record?.Private,
            };
        }

        [Authorize(Roles = ONUser.ROLE_IS_OWNER_OR_SERVICE)]
        public override async Task<GetOwnerDataResponse> GetOwnerData(GetOwnerDataRequest request, ServerCallContext context)
        {
            var record = await dataProvider.Get();
            if (record == null)
                return new() { };

            return new()
            {
                Public = record?.Public,
                Private = record?.Private,
                Owner = record?.Owner,
            };
        }

        [Authorize(Roles = ONUser.ROLE_IS_OWNER_OR_SERVICE)]
        public override async Task<GetOwnerNewerDataResponse> GetOwnerNewerData(GetOwnerNewerDataRequest request, ServerCallContext context)
        {
            var record = await dataProvider.Get();
            if (record == null)
                return new() { };

            if (record?.Public?.VersionNum == request.VersionNum)
                record = null;

            return new()
            {
                Public = record?.Public,
                Private = record?.Private,
                Owner = record?.Owner,
            };
        }

        [AllowAnonymous]
        public override async Task<GetPublicDataResponse> GetPublicData(GetPublicDataRequest request, ServerCallContext context)
        {
            var record = await dataProvider.Get();
            if (record == null)
                return new() { };

            return new() { Public = record?.Public };
        }

        [AllowAnonymous]
        public override async Task<GetPublicNewerDataResponse> GetPublicNewerData(GetPublicNewerDataRequest request, ServerCallContext context)
        {
            var record = await dataProvider.Get();
            if (record == null)
                return new() { };

            if (record?.Public?.VersionNum == request.VersionNum)
                record.Public = null;

            return new() { Public = record?.Public };
        }

        [Authorize(Roles = ONUser.ROLE_OWNER)]
        public override async Task<ModifyCMSOwnerDataResponse> ModifyCMSOwnerData(ModifyCMSOwnerDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.Get();
                record.Owner.CMS = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<ModifyCMSPrivateDataResponse> ModifyCMSPrivateData(ModifyCMSPrivateDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.Get();
                record.Private.CMS = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<ModifyCMSPublicDataResponse> ModifyCMSPublicData(ModifyCMSPublicDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.Get();
                record.Public.CMS = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        [Authorize(Roles = ONUser.ROLE_OWNER)]
        public override async Task<ModifyCommentsOwnerDataResponse> ModifyCommentsOwnerData(ModifyCommentsOwnerDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.Get();
                record.Owner.Comments = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<ModifyCommentsPrivateDataResponse> ModifyCommentsPrivateData(ModifyCommentsPrivateDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.Get();
                record.Private.Comments = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<ModifyCommentsPublicDataResponse> ModifyCommentsPublicData(ModifyCommentsPublicDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.Get();
                record.Public.Comments = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        [Authorize(Roles = ONUser.ROLE_OWNER)]
        public override async Task<ModifyPersonalizationOwnerDataResponse> ModifyPersonalizationOwnerData(ModifyPersonalizationOwnerDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.Get();
                record.Owner.Personalization = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<ModifyPersonalizationPrivateDataResponse> ModifyPersonalizationPrivateData(ModifyPersonalizationPrivateDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.Get();
                record.Private.Personalization = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<ModifyPersonalizationPublicDataResponse> ModifyPersonalizationPublicData(ModifyPersonalizationPublicDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.Get();
                record.Public.Personalization = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        [Authorize(Roles = ONUser.ROLE_OWNER)]
        public override async Task<ModifySubscriptionOwnerDataResponse> ModifySubscriptionOwnerData(ModifySubscriptionOwnerDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.Get();
                record.Owner.Subscription = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<ModifySubscriptionPrivateDataResponse> ModifySubscriptionPrivateData(ModifySubscriptionPrivateDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.Get();
                record.Private.Subscription = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<ModifySubscriptionPublicDataResponse> ModifySubscriptionPublicData(ModifySubscriptionPublicDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.Get();
                record.Public.Subscription = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        private async Task EnsureStockSettings()
        {
            if (await dataProvider.Get() != null)
                return;

            var date = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

            var record = new SettingsRecord()
            {
                Public = new()
                {
                    VersionNum = 1,
                    ModifiedOnUTC = date,
                    Comments = new()
                    {
                        AllowLinks = false,
                        ExplicitModeEnabled = true,
                        DefaultOrder = Fragments.Comments.CommentOrder.Liked,
                        DefaultRestriction = new()
                        {
                            Minimum = Fragments.Comments.CommentRestrictionMinimumEnum.Subscriber,
                        },
                    },
                    Personalization = new()
                    {
                        Title = "Creator Site",
                        MetaDescription = "My site description",
                        DefaultToDarkMode = true,
                    },
                    Subscription = new()
                    {
                        AllowOther = true,
                        ParallelEconomy = new()
                        {
                            Enabled = false,
                        },
                        Stripe = new()
                        {
                            Enabled = false,
                        },
                        Paypal = new()
                        {
                            Enabled = false,
                        },
                        Crypto = new()
                        {
                            Enabled = false,
                        },
                        Fake = new()
                        {
                            Enabled = true,
                        }
                    },
                    CMS = new()
                    {
                        DefaultLayout = Fragments.Content.LayoutEnum.List,
                        Menu = new()
                        {
                            AudioMenuLinkName = "Listen",
                            PictureMenuLinkName = "Photos",
                            VideoMenuLinkName = "Watch",
                            WrittenMenuLinkName = "Read",
                        },
                    }
                },
                Private = new()
                {
                    Comments = new() { },
                    Personalization = new() { },
                    Subscription = new() { },
                },
                Owner = new()
                {
                    Comments = new() { },
                    Personalization = new() { },
                    Subscription = new()
                    {
                        ParallelEconomy = new(),
                        Stripe = new(),
                        Paypal = new(),
                    },
                }
            };

            record.Public.Subscription.Tiers.Add(new SubscriptionTier()
            {
                Name = "Basic",
                Description = "You're basic bro...",
                Color = "orange",
                AmountCents = 500,
            });
            record.Public.Subscription.Tiers.Add(new SubscriptionTier()
            {
                Name = "Bronze",
                Description = "meh...",
                Color = "bronze",
                AmountCents = 1000,
            });
            record.Public.Subscription.Tiers.Add(new SubscriptionTier()
            {
                Name = "Silver",
                Description = "Nice...",
                Color = "silver",
                AmountCents = 2500,
            });
            record.Public.Subscription.Tiers.Add(new SubscriptionTier()
            {
                Name = "Gold",
                Description = "You rock...",
                Color = "gold",
                AmountCents = 5000,
            });

            record.Private.Comments.BlackList.AddRange(new[] { "fuck", "shit", "cunt" });

            await dataProvider.Save(record);
        }
    }
}
