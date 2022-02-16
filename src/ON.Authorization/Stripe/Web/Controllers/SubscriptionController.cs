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

// TODO: Refactor Intents To Server
namespace ON.Authorization.Stripe.Web.Controllers
{
    [Authorize]
    [Route("/subscription/stripe")]
    public class SubscriptionController : Controller
    {
        private readonly ILogger<SubscriptionController> logger;
        private readonly PaymentsService paymentsService;
        private readonly Services.AccountService acctsService;
        private CustomerService customerService;
        private readonly ONUserHelper userHelper;
        private StripeClient stripeClient;
        private EventService eventService;
        private SubscriptionService subscriptionService;
        private readonly string webhookSecret;

        public SubscriptionController(ILogger<SubscriptionController> logger, PaymentsService paymentsService, Services.AccountService acctsService, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.paymentsService = paymentsService;
            this.acctsService = acctsService;
            this.eventService = new EventService(stripeClient);
            this.userHelper = userHelper;
            this.stripeClient = new StripeClient("sk_test_51KARZjJUpMW7yiO47dnj228fk6q4YKFLAObA9lMSg21R7VTpGwkUTScaD03lKv7oyQpB5lykutwX0PYIja96Y62W00YnJBQHFP");
            this.webhookSecret = "whsec_2df5a0c1b7beebd12d5426c9f9fc99b64f032bd325587ae54659c3031457052e";
            this.customerService = new CustomerService(stripeClient);
            this.subscriptionService = new SubscriptionService(stripeClient);
        }

        [HttpGet("")]
        public async Task<IActionResult> OverviewGet()
        {
            var rec = await paymentsService.GetCurrentRecord();
            if (rec == null)
                return View("Main", null);
            return View("Main", new CurrentViewModel(rec.Level, acctsService, rec.CanceledOnUTC != null));
        }

        [HttpGet("cancel")]
        // TODO: figure out how to not display cancel sub in menu after cancellation
        public async Task<IActionResult> Cancel(string reason = null)
        {
            
            var res = await paymentsService.CancelSubscription(reason ?? "No reason");
            SubscriptionRecord record = res.Record;
            logger.LogWarning($"***HIT: {record.SubscriptionId}***");
            this.subscriptionService.Cancel(record.SubscriptionId);

            return RedirectToAction(nameof(OverviewGet));
        }

        [HttpPost("create-checkout-session")]
        public async Task<IActionResult> CreateCheckoutSession(string PriceId)
        {
            try
            {
                StripeConfiguration.ApiKey = this.stripeClient.ApiKey;
                PriceService priceService = new PriceService();
                ProductService productService = new ProductService();
                Price price = priceService.Get(PriceId);
                Product product = productService.Get(price.ProductId);
                // TODO: Fix redirect links
                SessionCreateOptions options = new SessionCreateOptions
                {
                    SuccessUrl = "http://localhost/subscription/",
                    CancelUrl = "https://localhost/subscription/",
                    Mode = "subscription",
                    LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = PriceId,
                        Quantity = 1,

                    },
                },
                };

                SessionService service = new SessionService();
                Session session = await service.CreateAsync(options);


                logger.LogWarning($"****Link: {session}");
                return Redirect(session.Url);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost("create-payment-intent")]
        public async Task<IActionResult> CreatePaymentIntent()
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = 1999,
                Currency = "USD",
                PaymentMethodTypes = new List<string>
                {
                    "card"
                }
            };
            var service = new PaymentIntentService(this.stripeClient);

            try
            {
                var paymentIntent = await service.CreateAsync(options);
                return Ok(new { clientSecret = paymentIntent.ClientSecret });
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

                logger.LogWarning($"***STRIPE EVENT: {stripeEvent.Type}***");

                switch (stripeEvent.Type)
                {
                    case "checkout.session.completed":
                        logger.LogWarning($"***Completed Checkout Session");
                        break;
                    case "payment_intent.created":
                        logger.LogWarning($"***Payment Intent Created");
                        break;
                    case "customer.subscription.created":
                        var subId = stripeEvent.Data.Object as Subscription;
                        var priceAmount = subId.Items.First().Price.UnitAmount;
                        logger.LogWarning($"******SUBID: {subId}");
                        logger.LogWarning($"******Price: {priceAmount}");
                        logger.LogWarning($"******TIMESTAMP: {DateTime.Now.ToLongTimeString()}");
                        if (string.IsNullOrWhiteSpace(subId.Id))
                            return RedirectToAction(nameof(OverviewGet));

                        await paymentsService.NewSubscription(subId.Id, (int)priceAmount);

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


            //if (stripeEvent.Type == "payment_intent.created")
            //{
            //    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
            //}

            
            return Ok();
        }
    }
}
