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
    public class ApplicantJobApplicationController : Controller
    {
        // GET: ApplicantJobApplication
        private RestClient _client;

        public ApplicantJobApplicationController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new RestRequest("api/careercloud/applicant/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new
                RestRequest("api/careercloud/applicant/v1/jobapplication");

            var response = _client.Execute<ApplicantJobApplicationPoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var applicantJobApplications =
                JsonConvert.DeserializeObject<IEnumerable<ApplicantJobApplicationPoco>>(content);

            return View(applicantJobApplications);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Applicant, Job, ApplicationDate")]
            ApplicantJobApplicationPoco poco)
        {

            ApplicantJobApplicationPoco[] pocos = new ApplicantJobApplicationPoco[] { poco };

            var request = new
                RestRequest("api/careercloud/applicant/v1/jobapplication", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<ApplicantJobApplicationPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/applicant/v1/jobapplication/{id}");

            var response = _client.Execute<ApplicantJobApplicationPoco>(request);

            var applicantJobApplication =
                JsonConvert.DeserializeObject<ApplicantJobApplicationPoco>(response.Content);

            return View(applicantJobApplication);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Applicant, Job, ApplicationDate")]
            ApplicantJobApplicationPoco poco)
        {

            ApplicantJobApplicationPoco[] pocos = new ApplicantJobApplicationPoco[] { poco };

            var request = new
                RestRequest("api/careercloud/applicant/v1/jobapplication", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<ApplicantJobApplicationPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/applicant/v1/jobapplication/{id}");

            var response = _client.Execute<ApplicantJobApplicationPoco>(request);

            var applicantJobApplication =
                JsonConvert.DeserializeObject<ApplicantJobApplicationPoco>(response.Content);

            ApplicantJobApplicationPoco[] pocos = new ApplicantJobApplicationPoco[] 
            { applicantJobApplication };

            var deleteRequest = new
                RestRequest("api/careercloud/applicant/v1/jobapplication", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}