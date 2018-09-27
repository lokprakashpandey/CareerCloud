using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using CareerCloud.Pocos;
using RestSharp;

namespace CareerCloud.MVC.Controllers
{
    public class CompanyJobDescriptionController : Controller
    {
        // GET: CompanyJobDescription
        private RestClient _client;

        public CompanyJobDescriptionController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new RestRequest("api/careercloud/company/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new
                RestRequest("api/careercloud/company/v1/jobsdescription");

            var response = _client.Execute<CompanyJobDescriptionPoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var companyJobDescriptions =
                JsonConvert.DeserializeObject<IEnumerable<CompanyJobDescriptionPoco>>(content);

            return View(companyJobDescriptions);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Job, JobName, JobDescriptions")]
            CompanyJobDescriptionPoco poco)
        {

            CompanyJobDescriptionPoco[] pocos = new CompanyJobDescriptionPoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/company/v1/jobsdescription", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<CompanyJobDescriptionPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/company/v1/jobsdescription/{id}");

            var response = _client.Execute<CompanyJobDescriptionPoco>(request);

            var companyJobDescription =
                JsonConvert.DeserializeObject<CompanyJobDescriptionPoco>(response.Content);

            return View(companyJobDescription);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Job, JobName, JobDescriptions")]
            CompanyJobDescriptionPoco poco)
        {

            CompanyJobDescriptionPoco[] pocos = new CompanyJobDescriptionPoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/company/v1/jobsdescription", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<CompanyJobDescriptionPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/company/v1/jobsdescription/{id}");

            var response = _client.Execute<CompanyJobDescriptionPoco>(request);

            var companyJobDescription =
                JsonConvert.DeserializeObject<CompanyJobDescriptionPoco>(response.Content);

            CompanyJobDescriptionPoco[] pocos = new CompanyJobDescriptionPoco[]
                { companyJobDescription };

            var deleteRequest = new
                RestRequest("api/careercloud/company/v1/jobsdescription", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}