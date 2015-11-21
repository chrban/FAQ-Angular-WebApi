using FAQ_Web_Api_Angular.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace FAQ_Web_Api_Angular.Controllers
{
    public class FaqController : ApiController
    {

        FaqDB faqDb = new FaqDB();

        public HttpResponseMessage Get()
        {
            List<Faqs> allFaqus = faqDb.getAllFaqs();

            var Json = new JavaScriptSerializer();
            string JsonStr = Json.Serialize(allFaqus);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonStr, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK

            };
        }



        public HttpResponseMessage Put(int id)
        {
            if (faqDb.voteUp(id))
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK

                };

            }
            else
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Kunne ikke vote opp")
                };
            }
        }

    }
}
