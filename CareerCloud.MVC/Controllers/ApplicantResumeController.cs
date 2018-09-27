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
    public class ApplicantResumeController : Controller
    {
        // GET: ApplicantResume
        private RestClient _client;

        public ApplicantResumeController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new
                RestRequest("api/careercloud/applicant/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new
             RestRequest("api/careercloud/applicant/v1/resume");

            var response = _client.Execute<ApplicantResumePoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var applicantResumes =
                JsonConvert.DeserializeObject<IEnumerable<ApplicantResumePoco>>(content);

            return View(applicantResumes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Applicant, Resume, LastUpdated")]
            ApplicantResumePoco poco)
        {

            ApplicantResumePoco[] pocos = new ApplicantResumePoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/applicant/v1/resume", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<ApplicantResumePoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/applicant/v1/resume/{id}");

            var response = _client.Execute<ApplicantResumePoco>(request);

            var applicantResume =
                JsonConvert.DeserializeObject<ApplicantResumePoco>(response.Content);

            return View(applicantResume);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Applicant, Resume, LastUpdated")]
            ApplicantResumePoco poco)
        {

            ApplicantResumePoco[] pocos = new ApplicantResumePoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/applicant/v1/resume", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<ApplicantResumePoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/applicant/v1/resume/{id}");

            var response = _client.Execute<ApplicantResumePoco>(request);

            var applicantResume =
                JsonConvert.DeserializeObject<ApplicantResumePoco>(response.Content);

            ApplicantResumePoco[] pocos = new ApplicantResumePoco[]
            { applicantResume };

            var deleteRequest = new
                RestRequest("api/careercloud/applicant/v1/resume", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}