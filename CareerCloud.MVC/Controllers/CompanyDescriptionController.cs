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
    public class CompanyDescriptionController : Controller
    {
        // GET: CompanyDescription
        private RestClient _client;

        public CompanyDescriptionController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new RestRequest("api/careercloud/company/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new 
                RestRequest("api/careercloud/company/v1/description");

            var response = _client.Execute<CompanyDescriptionPoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var companyDescriptions =
                JsonConvert.DeserializeObject<IEnumerable<CompanyDescriptionPoco>>(content);

            return View(companyDescriptions);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Company, LanguageId, CompanyName, CompanyDescription")]
            CompanyDescriptionPoco poco)
        {

            CompanyDescriptionPoco[] pocos = new CompanyDescriptionPoco[] { poco };

            var request = new
                RestRequest("api/careercloud/company/v1/description", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<CompanyDescriptionPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/company/v1/description/{id}");

            var response = _client.Execute<CompanyDescriptionPoco>(request);

            var companyDescription =
                JsonConvert.DeserializeObject<CompanyDescriptionPoco>(response.Content);

            return View(companyDescription);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Company, LanguageId, CompanyName, CompanyDescription")]
            CompanyDescriptionPoco poco)
        {

            CompanyDescriptionPoco[] pocos = new CompanyDescriptionPoco[] 
                { poco };

            var request = new
                RestRequest("api/careercloud/company/v1/description", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<CompanyDescriptionPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/company/v1/description/{id}");

            var response = _client.Execute<CompanyDescriptionPoco>(request);

            var companyDescription =
                JsonConvert.DeserializeObject<CompanyDescriptionPoco>(response.Content);

            CompanyDescriptionPoco[] pocos = new CompanyDescriptionPoco[]
                { companyDescription };

            var deleteRequest = new
                RestRequest("api/careercloud/company/v1/description", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }

    }
}