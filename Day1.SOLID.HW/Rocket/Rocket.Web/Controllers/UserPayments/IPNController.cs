using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using Rocket.BL.Common.Models.User;
using Rocket.BL.Common.Services.User;
using Rocket.BL.Common.Services.UserPayment;

namespace Rocket.Web.Controllers.UserPayments
{
    [RoutePrefix("ipn")]
    public class IPNController : ApiController
    {
        private readonly IUserPaymentService _userPaymentService;
        private readonly IUserAccountLevelService _userAccountLevelService;

        public IPNController(IUserPaymentService userPaymentService, IUserAccountLevelService userAccountLevelService)
        {
            _userPaymentService = userPaymentService;
            _userAccountLevelService = userAccountLevelService;
        }

        [HttpPost]
        [Route("receive")]
        public IHttpActionResult Receive()
        {
            IPNContext ipnContext = new IPNContext()
            {
                IPNRequest = Request
            };
            string jsonContent = ipnContext.IPNRequest.Content.ReadAsStringAsync().Result;
            ipnContext.RequestBody = jsonContent;

            //Store the IPN received from PayPal
            LogRequest(ipnContext);

            //Fire and forget verification task
            Task.Run(() => VerifyTask(ipnContext));

            //Reply back a 200 code
            return StatusCode(HttpStatusCode.OK);
        }

        private void VerifyTask(IPNContext ipnContext)
        {
            try
            {
                var verificationRequest = WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr");

                //Set values for the verification request
                verificationRequest.Method = "POST";
                verificationRequest.ContentType = "application/x-www-form-urlencoded";

                //Add cmd=_notify-validate to the payload
                string strRequest = "cmd=_notify-validate&" + ipnContext.RequestBody;
                verificationRequest.ContentLength = strRequest.Length;

                //Attach payload to the verification request
                using (StreamWriter writer = new StreamWriter(verificationRequest.GetRequestStream(), Encoding.ASCII))
                {
                    writer.Write(strRequest);
                }

                //Send the request to PayPal and get the response
                using (StreamReader reader = new StreamReader(verificationRequest.GetResponse().GetResponseStream()))
                {
                    ipnContext.Verification = reader.ReadToEnd();
                }
            }
            catch (Exception exception)
            {
                //Capture exception for manual investigation
            }

            ProcessVerificationResponse(ipnContext);
        }

        private void LogRequest(IPNContext ipnContext)
        {
            // Persist the request values into a database or temporary data store
        }

        private string GetFromSpam(string incFind, string sourceSpam)
        {
            var match = new Regex(incFind + @"=([^&]*)(&|$)").Match(sourceSpam);
            return match?.Groups[1].Value.Trim();
        }

        private void ProcessVerificationResponse(IPNContext ipnContext)
        {
            if (ipnContext.Verification.Equals("VERIFIED"))
            {
                var paymentInfo = ipnContext.RequestBody;
                var payment = new BL.Common.Models.UserPayment();
                payment.Summ = decimal.Parse(GetFromSpam("mc_gross", paymentInfo).Replace(".", ","));
                payment.PaymentID = GetFromSpam("payer_id", paymentInfo);
                payment.Result = GetFromSpam("payment_status", paymentInfo);
                payment.FirstName = GetFromSpam("first_name", paymentInfo);
                payment.CustomString = GetFromSpam("custom", paymentInfo);
                payment.Email = GetFromSpam("payer_email", paymentInfo);
                payment.LastName = GetFromSpam("last_name", paymentInfo);
                payment.Currentcy = GetFromSpam("mc_currency", paymentInfo);
                payment.UserId = GetFromSpam("custom", paymentInfo);

                _userPaymentService.AddUserPayment(payment);

                if ((payment.Result == "Completed") && (payment.Summ == 3))
                {
                    var accountLevel = new AccountLevel();
                    accountLevel.Id = 2;
                    accountLevel.Name = "Премиум";
                    _userAccountLevelService.SetUserAccountLevel(int.Parse(payment.UserId), accountLevel);
                }
            }
            else if (ipnContext.Verification.Equals("INVALID"))
            {
                //Log for manual investigation
            }
            else
            {
                //Log error
            }
        }
        private class IPNContext
        {
            public HttpRequestMessage IPNRequest { get; set; }

            public string RequestBody { get; set; }

            public string Verification { get; set; } = String.Empty;
        }
    }
}
