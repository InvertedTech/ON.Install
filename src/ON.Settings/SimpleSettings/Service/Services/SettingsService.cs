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
    [Authorize(Roles = ONUser.ROLE_ADMIN)]
    public class SettingsService : SettingsInterface.SettingsInterfaceBase
    {
        private readonly OfflineHelper offlineHelper;
        private readonly ILogger<ServiceOpsService> logger;
        private readonly ISettingsDataProvider dataProvider;
        private static readonly HashAlgorithm hasher = SHA256.Create();

        public SettingsService(OfflineHelper offlineHelper, ILogger<ServiceOpsService> logger, ISettingsDataProvider dataProvider)
        {
            this.offlineHelper = offlineHelper;
            this.logger = logger;
            this.dataProvider = dataProvider;

            EnsureStockSettings().Wait();
        }

        public override async Task<GetAllDataResponse> GetAllData(GetAllDataRequest request, ServerCallContext context)
        {
            var record = await dataProvider.Get();

            return new() { Data = record };
        }

        public override async Task<GetAllNewerDataResponse> GetAllNewerData(GetAllNewerDataRequest request, ServerCallContext context)
        {
            var record = await dataProvider.Get();
            if (record.Public.VersionNum == request.VersionNum)
                record = null;

            return new() { Data = record };
        }

        [AllowAnonymous]
        public override async Task<GetPublicDataResponse> GetPublicData(GetPublicDataRequest request, ServerCallContext context)
        {
            var record = await dataProvider.Get();

            return new() { Data = record.Public };
        }

        [AllowAnonymous]
        public override async Task<GetPublicNewerDataResponse> GetPublicNewerData(GetPublicNewerDataRequest request, ServerCallContext context)
        {
            var record = await dataProvider.Get();
            if (record.Public.VersionNum == request.VersionNum)
                record.Public = null;

            return new() { Data = record.Public };
        }

        public override async Task<ModifyCommentsPrivateDataResponse> ModifyCommentsPrivateData(ModifyCommentsPrivateDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var record = await dataProvider.Get();
                record.Private.Comments = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        public override async Task<ModifyCommentsPublicDataResponse> ModifyCommentsPublicData(ModifyCommentsPublicDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var record = await dataProvider.Get();
                record.Public.Comments = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        public override async Task<ModifyPersonalizationPublicDataResponse> ModifyPersonalizationPublicData(ModifyPersonalizationPublicDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var record = await dataProvider.Get();
                record.Public.Personalization = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        public override async Task<ModifyPersonalizationPrivateDataResponse> ModifyPersonalizationPrivateData(ModifyPersonalizationPrivateDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var record = await dataProvider.Get();
                record.Private.Personalization = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        public override async Task<ModifySubscriptionPrivateDataResponse> ModifySubscriptionPrivateData(ModifySubscriptionPrivateDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var record = await dataProvider.Get();
                record.Private.Subscription = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                await dataProvider.Save(record);

                return new() { Error = ModifyResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = ModifyResponseErrorType.UnknownError };
            }
        }

        public override async Task<ModifySubscriptionPublicDataResponse> ModifySubscriptionPublicData(ModifySubscriptionPublicDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Data == null)
                    return new() { Error = ModifyResponseErrorType.UnknownError };

                var record = await dataProvider.Get();
                record.Public.Subscription = request.Data;

                record.Public.VersionNum++;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

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
                Public = new SettingsRecord.Types.PublicData()
                {
                    VersionNum = 1,
                    ModifiedOnUTC = date,
                    Comments = new CommentsPublicRecord()
                    {
                        AllowLinks = false,
                        ExplicitModeEnabled = true,
                        DefaultOrder = Fragments.Comments.CommentOrder.Liked,
                        DefaultRestriction = new Fragments.Comments.CommentRestrictionMinimum()
                        {
                            Minimum = Fragments.Comments.CommentRestrictionMinimumEnum.Subscriber,
                        },
                    },
                    Personalization = new PersonalizationPublicRecord()
                    {
                        Title = "Creator Site",
                        MetaDescription = "My site description",
                        DefaultLayout = Fragments.Content.LayoutEnum.List,
                        DefaultToDarkMode = true,
                    },
                    Subscription = new SubscriptionPublicRecord()
                    {
                    },
                },
                Private = new SettingsRecord.Types.PrivateData()
                {
                    Comments = new CommentsPrivateRecord()
                    {
                    },
                    Subscription = new SubscriptionPrivateRecord()
                    {
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
                        }
                    },
                }
            };

            record.Public.Subscription.Tiers.Add(new SubscriptionTier()
            {
                Name = "Basic",
                Description = "You're basic bro...",
                Color = "orange",
                Amount = 5,
            });
            record.Public.Subscription.Tiers.Add(new SubscriptionTier()
            {
                Name = "Bronze",
                Description = "meh...",
                Color = "bronze",
                Amount = 10,
            });
            record.Public.Subscription.Tiers.Add(new SubscriptionTier()
            {
                Name = "Silver",
                Description = "Nice...",
                Color = "silver",
                Amount = 25,
            });
            record.Public.Subscription.Tiers.Add(new SubscriptionTier()
            {
                Name = "Gold",
                Description = "You rock...",
                Color = "gold",
                Amount = 50,
            });

            record.Private.Comments.BlackList.AddRange(new[] { "fuck", "shit", "cunt" });

            await dataProvider.Save(record);
        }
    }
}
