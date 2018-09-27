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
    public class CompanyJobEducationController : Controller
    {
        // GET: CompanyJobEducation
        private RestClient _client;

        public CompanyJobEducationController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new 
                RestRequest("api/careercloud/company/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new
                RestRequest("api/careercloud/company/v1/jobeducation");

            var response = _client.Execute<CompanyJobEducationPoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var companyJobEducations =
                JsonConvert.DeserializeObject<IEnumerable<CompanyJobEducationPoco>>(content);

            return View(companyJobEducations);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Job, Major, Importance")]
            CompanyJobEducationPoco poco)
        {

            CompanyJobEducationPoco[] pocos = new CompanyJobEducationPoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/company/v1/jobeducation", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<CompanyJobEducationPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/company/v1/jobeducation/{id}");

            var response = _client.Execute<CompanyJobEducationPoco>(request);

            var companyJobEducation =
                JsonConvert.DeserializeObject<CompanyJobEducationPoco>(response.Content);

            return View(companyJobEducation);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Job, Major, Importance")]
            CompanyJobEducationPoco poco)
        {

            CompanyJobEducationPoco[] pocos = new CompanyJobEducationPoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/company/v1/jobeducation", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<CompanyJobEducationPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/company/v1/jobeducation/{id}");

            var response = _client.Execute<CompanyJobEducationPoco>(request);

            var companyJobEducation =
                JsonConvert.DeserializeObject<CompanyJobEducationPoco>(response.Content);

            CompanyJobEducationPoco[] pocos = new CompanyJobEducationPoco[]
                { companyJobEducation };

            var deleteRequest = new
                RestRequest("api/careercloud/company/v1/jobeducation", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}