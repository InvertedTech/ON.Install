using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Authorization.Stripe.Web.Models;
using ON.Authorization.Stripe.Web.Services;
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
        private readonly ONUserHelper userHelper;
        private StripeClient stripeClient;
        private readonly string webhookSecret;

        public SubscriptionController(ILogger<SubscriptionController> logger, PaymentsService paymentsService, Services.AccountService acctsService, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.paymentsService = paymentsService;
            this.acctsService = acctsService;
            this.userHelper = userHelper;
            this.stripeClient = new StripeClient("sk_test_51KARZjJUpMW7yiO47dnj228fk6q4YKFLAObA9lMSg21R7VTpGwkUTScaD03lKv7oyQpB5lykutwX0PYIja96Y62W00YnJBQHFP");
            this.webhookSecret = "whsec_IVtmC7qjbf0554YgVM5Ue17QlRZsH4Zm";
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
        public async Task<IActionResult> Cancel(string reason = null)
        {
            await paymentsService.CancelSubscription(reason ?? "No reason");

            return RedirectToAction(nameof(OverviewGet));
        }

        [HttpPost("create-checkout-session")]
        public async Task<IActionResult> CreateCheckoutSession(string PriceId)
        {
            StripeConfiguration.ApiKey = this.stripeClient.ApiKey;
            PriceService priceService = new PriceService();
            ProductService productService = new ProductService();
            var options = new SessionCreateOptions
            {
                SuccessUrl = "https://localhost/subscription/",
                CancelUrl = "https://localhost/subscription/",
                Mode = "subscription",
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Name = priceService.Get(PriceId).Product.Name,
                        Currency = "USD",
                        Amount = priceService.Get(PriceId).UnitAmount,
                        Quantity = 1,
                    },
                },
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            Response.Headers.Add("Location", session.Url);
            return Redirect(session.Url);
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
            

            if (stripeEvent.Type == "payment_intent.created")
            {
                var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
            }

            return Ok();
        }
    }
}
