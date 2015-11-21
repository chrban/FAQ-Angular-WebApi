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
    public class QuestionController : ApiController
    {

        FaqDB faqDb = new FaqDB();

        public HttpResponseMessage Get()
        {
            List<QuestionModel> allQuestions = faqDb.getAllQuestions();

            var Json = new JavaScriptSerializer();
            string JsonStr = Json.Serialize(allQuestions);
            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonStr, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK

            };
        }


        public HttpResponseMessage Post( Question inQuestion)
        {
            if (ModelState.IsValid)
            {
                if(faqDb.saveQuestion(inQuestion))
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };

                }
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("FEIL: Klarte ikke lagre spørsmål..")
            };
        }


        public HttpResponseMessage Delete(int id)
        {
            if (faqDb.deleteQuestion(id))
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK

                };
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("FEIL: Klarte ikke slette spørsmål..")
            };
        }
    }
}
