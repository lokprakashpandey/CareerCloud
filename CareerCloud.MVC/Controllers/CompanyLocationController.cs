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
    public class CompanyLocationController : Controller
    {
        // GET: CompanyLocation
        private RestClient _client;

        public CompanyLocationController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new
                RestRequest("api/careercloud/company/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new
                RestRequest("api/careercloud/company/v1/location");

            var response = _client.Execute<CompanyLocationPoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var companyLocations =
                JsonConvert.DeserializeObject<IEnumerable<CompanyLocationPoco>>(content);

            return View(companyLocations);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Company, CountryCode, Province, Street, City, PostalCode")]
            CompanyLocationPoco poco)
        {

            CompanyLocationPoco[] pocos = new CompanyLocationPoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/company/v1/location", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<CompanyLocationPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/company/v1/location/{id}");

            var response = _client.Execute<CompanyLocationPoco>(request);

            var companyLocation =
                JsonConvert.DeserializeObject<CompanyLocationPoco>(response.Content);

            return View(companyLocation);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Company, CountryCode, Province, Street, City, PostalCode")]
            CompanyLocationPoco poco)
        {

            CompanyLocationPoco[] pocos = new CompanyLocationPoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/company/v1/location", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<CompanyLocationPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/company/v1/location/{id}");

            var response = _client.Execute<CompanyLocationPoco>(request);

            var companyLocation =
                JsonConvert.DeserializeObject<CompanyLocationPoco>(response.Content);

            CompanyLocationPoco[] pocos = new CompanyLocationPoco[]
                { companyLocation };

            var deleteRequest = new
                RestRequest("api/careercloud/company/v1/location", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}