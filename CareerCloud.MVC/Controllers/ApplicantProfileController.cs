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
    public class ApplicantProfileController : Controller
    {
        // GET: ApplicantProfile
        private RestClient _client;

        public ApplicantProfileController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new 
                RestRequest("api/careercloud/applicant/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new
             RestRequest("api/careercloud/applicant/v1/profile");

            var response = _client.Execute<ApplicantProfilePoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var applicantProfiles =
                JsonConvert.DeserializeObject<IEnumerable<ApplicantProfilePoco>>(content);

            return View(applicantProfiles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Login, CurrentSalary, CurrentRate, Currency, Country, Province, Street, City, PostalCode")]
            ApplicantProfilePoco poco)
        {

            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[] 
                { poco };

            var request = new
                RestRequest("api/careercloud/applicant/v1/profile", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<ApplicantProfilePoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/applicant/v1/profile/{id}");

            var response = _client.Execute<ApplicantProfilePoco>(request);

            var applicantProfile =
                JsonConvert.DeserializeObject<ApplicantProfilePoco>(response.Content);

            return View(applicantProfile);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Login, CurrentSalary, CurrentRate, Currency, Country, Province, Street, City, PostalCode")]
            ApplicantProfilePoco poco)
        {

            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[] 
                { poco };

            var request = new
                RestRequest("api/careercloud/applicant/v1/profile", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<ApplicantProfilePoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/applicant/v1/profile/{id}");

            var response = _client.Execute<ApplicantProfilePoco>(request);

            var applicantProfile =
                JsonConvert.DeserializeObject<ApplicantProfilePoco>(response.Content);

            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[]
            { applicantProfile };

            var deleteRequest = new
                RestRequest("api/careercloud/applicant/v1/profile", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}