//using Google.Protobuf;
//using Grpc.Core;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.Extensions.Logging;
//using ON.Authentication;
//using ON.Authorization.Payment.Stripe.Data;
//using ON.Crypto;
//using ON.Fragments.Authorization.Payment.Stripe;
//using ON.Fragments.Generic;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Threading.Tasks;

//namespace ON.Content.SimpleCMS.Service.Services
//{
//    [Authorize(Roles = ONUser.ROLE_CAN_BACKUP)]
//    public class BackupService : BackupInterface.BackupInterfaceBase
//    {
//        private readonly ILogger<BackupService> logger;
//        private readonly DataMergeService dataMerger;
//        private readonly ISubscriptionRecordProvider subscriptionProvider;
//        private readonly IPaymentRecordProvider paymentProvider;

//        public BackupService(DataMergeService dataMerger, ISubscriptionRecordProvider subscriptionProvider, IPaymentRecordProvider paymentProvider, ILogger<BackupService> logger)
//        {
//            this.dataMerger = dataMerger;
//            this.subscriptionProvider = subscriptionProvider;
//            this.paymentProvider = paymentProvider;
//            this.logger = logger;
//        }

//        public override async Task BackupAllData(BackupAllDataRequest request, IServerStreamWriter<BackupAllDataResponse> responseStream, ServerCallContext context)
//        {
//            try
//            {
//                var encKey = EcdhHelper.DeriveKeyServer(request.ClientPublicJwk.DecodeJsonWebKey(), out string serverPubKey);
//                await responseStream.WriteAsync(new BackupAllDataResponse() { ServerPublicJwk = serverPubKey });

//                await foreach (var r in subscriptionProvider.GetAll())
//                {
//                    var dr = new SubscriptionBackupDataRecord()
//                    {
//                        SubscriptionFullRecord = new ()
//                        {
//                            Subscription = r,
//                        }
//                    };

//                    dr.SubscriptionFullRecord.Payments.AddRange(await paymentProvider.GetAllBySubscriptionId(r.UserID.ToGuid(), r.SubscriptionID.ToGuid()));

//                    AesHelper.Encrypt(encKey, out var iv, dr.ToByteString().ToByteArray(), out var encData);

//                    await responseStream.WriteAsync(new BackupAllDataResponse()
//                    {
//                        EncryptedRecord = new EncryptedSubscriptionBackupDataRecord()
//                        {
//                            EncryptionIV = ByteString.CopyFrom(iv),
//                            Data = ByteString.CopyFrom(encData)
//                        }
//                    });
//                }
//            }
//            catch
//            {
//            }
//        }

//        public override async Task<RestoreAllDataResponse> RestoreAllData(IAsyncStreamReader<RestoreAllDataRequest> requestStream, ServerCallContext context)
//        {
//            RestoreAllDataResponse res = new RestoreAllDataResponse();
//            HashSet<Guid> idsLoaded = new HashSet<Guid>();

//            await requestStream.MoveNext();
//            if (requestStream.Current.RequestOneofCase != RestoreAllDataRequest.RequestOneofOneofCase.Mode)
//                return res;

//            var restoreMode = requestStream.Current.Mode;

//            try
//            {
//                await foreach (var r in requestStream.ReadAllAsync())
//                {
//                    Guid userId = r.Record.SubscriptionFullRecord.Subscription.UserID.ToGuid();
//                    Guid subscriptionId = r.Record.SubscriptionFullRecord.Subscription.SubscriptionID.ToGuid();
//                    idsLoaded.Add(subscriptionId);

//                    try
//                    {
//                        if (await subscriptionProvider.Exists(userId, subscriptionId))
//                        {
//                            if (restoreMode == RestoreAllDataRequest.Types.RestoreMode.MissingOnly)
//                            {
//                                res.NumSubscriptionsSkipped++;
//                                continue;
//                            }

//                            await subscriptionProvider.Save(r.Record.SubscriptionFullRecord.Subscription);
//                            res.NumSubscriptionsOverwriten++;

//                            await paymentProvider.DeleteAll(userId, subscriptionId);
//                            await paymentProvider.SaveAll(r.Record.SubscriptionFullRecord.Payments);
//                        }
//                        else
//                        {
//                            await subscriptionProvider.Save(r.Record.SubscriptionFullRecord.Subscription);
//                            res.NumSubscriptionsRestored++;

//                            await paymentProvider.DeleteAll(userId, subscriptionId);
//                            await paymentProvider.SaveAll(r.Record.SubscriptionFullRecord.Payments);
//                        }
//                    }
//                    catch { }
//                }

//                if (restoreMode == RestoreAllDataRequest.Types.RestoreMode.Wipe)
//                {
//                    await foreach (var r in subscriptionProvider.GetAll())
//                    {
//                        Guid userId = r.UserID.ToGuid();
//                        Guid subscriptionId = r.SubscriptionID.ToGuid();
//                        if (!idsLoaded.Contains(subscriptionId))
//                        {
//                            await subscriptionProvider.Delete(userId, subscriptionId);
//                            res.NumSubscriptionsWiped++;

//                            await paymentProvider.DeleteAll(userId, subscriptionId);
//                        }
//                    }
//                }
//            }
//            catch
//            {
//            }

//            return res;
//        }
//    }
//}
