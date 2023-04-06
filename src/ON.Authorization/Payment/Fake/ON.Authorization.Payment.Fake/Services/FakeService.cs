using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Authorization.Payment.Fake.Data;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.Fake;
using ON.Fragments.Authorization.Payment.Paypal;
using ON.Fragments.Generic;
using System;
using System.Data;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Fake.Service
{
    public class FakeService : FakeInterface.FakeInterfaceBase
    {
        private readonly ILogger logger;
        private readonly ISubscriptionRecordProvider subscriptionProvider;

        public FakeService(ILogger<FakeService> logger, ISubscriptionRecordProvider subscriptionProvider)
        {
            this.logger = logger;
            this.subscriptionProvider = subscriptionProvider;
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<FakeCancelOtherSubscriptionResponse> FakeCancelOtherSubscription(FakeCancelOtherSubscriptionRequest request, ServerCallContext context)
        {
            try
            {
                if (request?.UserId == null)
                    return new() { Error = "Bad Request" };

                var userId = request.UserId.ToGuid();
                if (userId == Guid.Empty)
                    return new() { Error = "No UserId specified" };

                var record = await subscriptionProvider.GetById(userId);
                if (record == null)
                    return new() { Error = "Record not found" };

                record.ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.AmountCents = 0;

                await subscriptionProvider.Save(record);

                return new()
                {
                    Record = record
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
                return new() { Error = "Unknown error" };
            }
        }

        public override async Task<FakeCancelOwnSubscriptionResponse> FakeCancelOwnSubscription(FakeCancelOwnSubscriptionRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new() { Error = "No user token specified" };

                var record = await subscriptionProvider.GetById(userToken.Id);
                if (record == null)
                    return new() { Error = "Record not found" };

                record.ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.AmountCents = 0;

                await subscriptionProvider.Save(record);

                return new()
                {
                    Record = record
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
                return new() { Error = "Unknown error" };
            }
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<FakeGetOtherSubscriptionRecordResponse> FakeGetOtherSubscriptionRecord(FakeGetOtherSubscriptionRecordRequest request, ServerCallContext context)
        {
            try
            {
                if (request?.UserId == null)
                    return new();

                var userId = request.UserId.ToGuid();
                if (userId == Guid.Empty)
                    return new();

                return new()
                {
                    Record = await subscriptionProvider.GetById(userId)
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
            }

            return new();
        }

        public override async Task<FakeGetOwnSubscriptionRecordResponse> FakeGetOwnSubscriptionRecord(FakeGetOwnSubscriptionRecordRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new();

                return new()
                {
                    Record = await subscriptionProvider.GetById(userToken.Id)
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
            }

            return new();
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<FakeNewOtherSubscriptionResponse> FakeNewOtherSubscription(FakeNewOtherSubscriptionRequest request, ServerCallContext context)
        {
            try
            {
                if (request?.UserId == null)
                    return new() { Error = "Bad Request" };

                var userId = request.UserId.ToGuid();
                if (userId == Guid.Empty)
                    return new() { Error = "No UserId specified" };

                var record = new FakeSubscriptionRecord()
                {
                    UserID = userId.ToString(),
                    ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
                    AmountCents = request.AmountCents,
                };

                await subscriptionProvider.Save(record);

                return new()
                {
                    Record = record
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
                return new() { Error = "Unknown error" };
            }
        }

        public override async Task<FakeNewOwnSubscriptionResponse> FakeNewOwnSubscription(FakeNewOwnSubscriptionRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new() { Error = "No user token specified" };

                if (request == null)
                    return new() { Error = "Level not valid" };

                var record = new FakeSubscriptionRecord()
                {
                    UserID = userToken.Id.ToString(),
                    ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
                    AmountCents = request.AmountCents,
                };

                await subscriptionProvider.Save(record);

                return new()
                {
                    Record = record
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
                return new() { Error = "Unknown error" };
            }
        }
    }
}
