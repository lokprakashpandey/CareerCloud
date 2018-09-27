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
    public class CompanyJobController : Controller
    {
        // GET: CompanyJob
        private RestClient _client;

        public CompanyJobController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new RestRequest("api/careercloud/company/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new
                RestRequest("api/careercloud/company/v1/job");

            var response = _client.Execute<CompanyJobPoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var companyJobs =
                JsonConvert.DeserializeObject<IEnumerable<CompanyJobPoco>>(content);

            return View(companyJobs);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Company, ProfileCreated, IsInactive, IsCompanyHidden")]
            CompanyJobPoco poco)
        {

            CompanyJobPoco[] pocos = new CompanyJobPoco[] 
                { poco };

            var request = new
                RestRequest("api/careercloud/company/v1/job", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<CompanyJobPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/company/v1/job/{id}");

            var response = _client.Execute<CompanyJobPoco>(request);

            var companyJob =
                JsonConvert.DeserializeObject<CompanyJobPoco>(response.Content);

            return View(companyJob);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Company, ProfileCreated, IsInactive, IsCompanyHidden")]
            CompanyJobPoco poco)
        {

            CompanyJobPoco[] pocos = new CompanyJobPoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/company/v1/job", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<CompanyJobPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/company/v1/job/{id}");

            var response = _client.Execute<CompanyJobPoco>(request);

            var companyJob =
                JsonConvert.DeserializeObject<CompanyJobPoco>(response.Content);

            CompanyJobPoco[] pocos = new CompanyJobPoco[]
                { companyJob };

            var deleteRequest = new
                RestRequest("api/careercloud/company/v1/job", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}