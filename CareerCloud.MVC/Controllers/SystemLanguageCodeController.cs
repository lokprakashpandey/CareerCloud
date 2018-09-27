using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareerCloud.Pocos;
using RestSharp;
using Newtonsoft.Json;
namespace CareerCloud.MVC.Controllers
{
    public class SystemLanguageCodeController : Controller
    {
        // GET: SystemLanguageCode
        private RestClient _client;

        public SystemLanguageCodeController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new
                RestRequest("api/careercloud/system/v1/{code}");
        }

        public ActionResult Index()
        {
            var request = new
                RestRequest("api/careercloud/system/v1/languagecode");

            var response = _client.Execute<SystemLanguageCodePoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var systemLanguageCodes =
                JsonConvert.DeserializeObject<IEnumerable<SystemLanguageCodePoco>>(content);

            return View(systemLanguageCodes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Name, NativeName")]
            SystemLanguageCodePoco poco)
        {

            SystemLanguageCodePoco[] pocos = new SystemLanguageCodePoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/system/v1/languagecode", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<SystemLanguageCodePoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(string id)
        {
            var request = new
                RestRequest($"api/careercloud/system/v1/languagecode/{id}");

            var response = _client.Execute<SystemLanguageCodePoco>(request);

            var systemLanguageCode =
                JsonConvert.DeserializeObject<SystemLanguageCodePoco>(response.Content);

            return View(systemLanguageCode);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "LanguageID, Name, NativeName")]
            SystemLanguageCodePoco poco)
        {

            SystemLanguageCodePoco[] pocos = new SystemLanguageCodePoco[]
             { poco };

            var request = new
                RestRequest("api/careercloud/system/v1/languagecode", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<SystemLanguageCodePoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(string id)
        {
            var request = new
                   RestRequest($"api/careercloud/system/v1/languagecode/{id}");

            var response = _client.Execute<SystemLanguageCodePoco>(request);

            var systemCountryCode =
                JsonConvert.DeserializeObject<SystemLanguageCodePoco>(response.Content);

            SystemLanguageCodePoco[] pocos = new SystemLanguageCodePoco[]
            { systemCountryCode };

            var deleteRequest = new
                RestRequest("api/careercloud/system/v1/languagecode", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}