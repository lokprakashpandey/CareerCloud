using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareerCloud.Pocos;
using Newtonsoft.Json;
using RestSharp;

namespace CareerCloud.MVC.Controllers
{
    public class SystemCountryCodeController : Controller
    {
        // GET: SystemCountryCode
        private RestClient _client;

        public SystemCountryCodeController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new
                RestRequest("api/careercloud/system/v1/{code}");
        }

        public ActionResult Index()
        {
            var request = new
                RestRequest("api/careercloud/system/v1/countrycode");

            var response = _client.Execute<SystemCountryCodePoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var systemCountryCodes =
                JsonConvert.DeserializeObject<IEnumerable<SystemCountryCodePoco>>(content);

            return View(systemCountryCodes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Name")]
            SystemCountryCodePoco poco)
        {

            SystemCountryCodePoco[] pocos = new SystemCountryCodePoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/system/v1/countrycode", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<SystemCountryCodePoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(string id)
        {
            var request = new
                RestRequest($"api/careercloud/system/v1/countrycode/{id}");

            var response = _client.Execute<SystemCountryCodePoco>(request);

            var systemCountryCode =
                JsonConvert.DeserializeObject<SystemCountryCodePoco>(response.Content);

            return View(systemCountryCode);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Code, Name")]
            SystemCountryCodePoco poco)
        {

            SystemCountryCodePoco[] pocos = new SystemCountryCodePoco[]
             { poco };

            var request = new
                RestRequest("api/careercloud/system/v1/countrycode", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<SystemCountryCodePoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(string id)
        {
            var request = new
                   RestRequest($"api/careercloud/system/v1/countrycode/{id}");

            var response = _client.Execute<SystemCountryCodePoco>(request);

            var systemCountryCode =
                JsonConvert.DeserializeObject<SystemCountryCodePoco>(response.Content);

            SystemCountryCodePoco[] pocos = new SystemCountryCodePoco[]
            { systemCountryCode };

            var deleteRequest = new
                RestRequest("api/careercloud/system/v1/countrycode", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}