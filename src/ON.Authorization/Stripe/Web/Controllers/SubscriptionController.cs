using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Authorization.Stripe.Web.Models;
using ON.Authorization.Stripe.Web.Services;
using ON.Fragments.Authorization.Payments.Stripe;
using Stripe;
using Stripe.Checkout;

// TODO: Refactor ALL stripe api services to the server side
namespace ON.Authorization.Stripe.Web.Controllers
{
    [Authorize]
    [Route("/subscription/stripe")]
    public class SubscriptionController : Controller
    {
        private readonly ILogger<SubscriptionController> logger;
        private readonly PaymentsService paymentsService;
        private readonly Services.AccountService acctsService;
        private readonly ONUserHelper userHelper;
        private readonly string webhookSecret;

        // Move to Server
        private StripeClient stripeClient;
        private EventService eventService;
        private SubscriptionService subscriptionService;

        public SubscriptionController(ILogger<SubscriptionController> logger, PaymentsService paymentsService, Services.AccountService acctsService, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.paymentsService = paymentsService;
            this.acctsService = acctsService;
            this.userHelper = userHelper;
            this.webhookSecret = "whsec_2df5a0c1b7beebd12d5426c9f9fc99b64f032bd325587ae54659c3031457052e";

            // Move to Server
            this.stripeClient = new StripeClient("sk_test_51KARZjJUpMW7yiO47dnj228fk6q4YKFLAObA9lMSg21R7VTpGwkUTScaD03lKv7oyQpB5lykutwX0PYIja96Y62W00YnJBQHFP");
            this.subscriptionService = new SubscriptionService(stripeClient);
            this.eventService = new EventService(stripeClient);
        }

        [HttpGet("")]
        public async Task<IActionResult> OverviewGet()
        {
            var rec = await paymentsService.GetCurrentRecord();
            if (rec == null)
                return View("Main", null);
            return View("Main", new CurrentViewModel(rec.Level, acctsService, rec.CanceledOnUTC != null));
        }

        [HttpPost("create-checkout-session")]
        public async Task<IActionResult> CreateCheckoutSession(string PriceId)
        {
            try
            {
                var response = await paymentsService.CreateCheckoutSession(PriceId);

                if (response == null)
                    return View("Main", null);

                return Redirect(response.SessionUrl);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-customer-portal")]
        public async Task<IActionResult> CreateCustomerPortal()
        {
            var rec = await paymentsService.GetCurrentRecord();
            if (rec == null)
                return View("Main", null);

            var response = await paymentsService.CreatePortal(rec.CustomerId);

            if (response == null)
                return View("Main", null);

            return Redirect(response.Url);

        }

        [AllowAnonymous]
        [HttpPost("webhook")]
        public async Task<IActionResult> Webhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            Event stripeEvent;

            try
            {
                stripeEvent = EventUtility.ConstructEvent(
                        json,
                        Request.Headers["Stripe-Signature"],
                        this.webhookSecret
                   );


                switch (stripeEvent.Type)
                {
                    case "checkout.session.completed":
                        logger.LogInformation($"### Completed Checkout Session ###");
                        break;
                    case "payment_intent.created":
                        logger.LogInformation($"### Created Payment Intent ###");
                        break;
                    case "customer.subscription.created":
                        var subId = stripeEvent.Data.Object as Subscription;
                        var priceAmount = subId.Items.First().Price.UnitAmount;
                        var customerId = subId.CustomerId;

                        if (string.IsNullOrWhiteSpace(subId.Id))
                            return RedirectToAction(nameof(OverviewGet));

                        await paymentsService.NewSubscription(subId.Id, (int)priceAmount, customerId);
                        logger.LogWarning($"***Completed Subscription Creation");


                        break;
                    case "customer.subscription.updated":
                        var subscription = stripeEvent.Data.Object as Subscription;


                        if (string.IsNullOrWhiteSpace(subscription.Id))
                            return RedirectToAction(nameof(OverviewGet));

                        if (subscription.CancelAt == null)
                        {
                            var price = subscription.Items.First().Price.UnitAmount;
                            var custId = subscription.CustomerId;

                            await paymentsService.NewSubscription(subscription.Id, (int)price, custId);
                            logger.LogInformation($"### Plan was uncancelled ###");
                            break;
                        }

                        await paymentsService.CancelSubscription(subscription.Id);

                        break;
                    default:
                        return BadRequest();
                }

            }
            catch (StripeException ex)
            {
                return BadRequest(new
                {
                    Error = new
                    {
                        Message = ex.Message,
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }
    }
}
