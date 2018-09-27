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
    public class ApplicantEducationController : Controller
    {
        private RestClient _client;

        public ApplicantEducationController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new RestRequest("api/careercloud/applicant/v1/{id}");
        }

        // GET: ApplicantEducation
        public ActionResult Index()
        {
            var request = new 
                RestRequest("api/careercloud/applicant/v1/education");

            var response = _client.Execute<ApplicantEducationPoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var applicantEducations =
                JsonConvert.DeserializeObject<IEnumerable<ApplicantEducationPoco>>(content);

            return View(applicantEducations);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Applicant, Major, CertificateDiploma, StartDate, CompletionDate, CompletionPercent")]
            ApplicantEducationPoco poco)
        {

            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[] { poco };

            var request = new
                RestRequest("api/careercloud/applicant/v1/education", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<ApplicantEducationPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/applicant/v1/education/{id}");

            var response = _client.Execute<ApplicantEducationPoco>(request);

            var applicantEducation =
                JsonConvert.DeserializeObject<ApplicantEducationPoco>(response.Content);

            return View(applicantEducation);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Applicant, Major, CertificateDiploma, StartDate, CompletionDate, CompletionPercent")]
            ApplicantEducationPoco poco)
        {

            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[] { poco };

            var request = new
                RestRequest("api/careercloud/applicant/v1/education", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<ApplicantEducationPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/applicant/v1/education/{id}");

            var response = _client.Execute<ApplicantEducationPoco>(request);

            var applicantEducation =
                JsonConvert.DeserializeObject<ApplicantEducationPoco>(response.Content);

            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[] { applicantEducation };

            var deleteRequest = new
                RestRequest("api/careercloud/applicant/v1/education", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}