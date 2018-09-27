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
    public class ApplicantWorkHistoryController : Controller
    {
        // GET: ApplicantWorkHistory
        private RestClient _client;

        public ApplicantWorkHistoryController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new
                RestRequest("api/careercloud/applicant/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new
             RestRequest("api/careercloud/applicant/v1/workhistory");

            var response = _client.Execute<ApplicantWorkHistoryPoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var applicantWorkHistorys =
                JsonConvert.DeserializeObject<IEnumerable<ApplicantWorkHistoryPoco>>(content);

            return View(applicantWorkHistorys);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Applicant, CompanyName, CountryCode, Location, JobTitle, JobDescription, StartMonth, StartYear, EndMonth, EndYear")]
            ApplicantWorkHistoryPoco poco)
        {

            ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/applicant/v1/workhistory", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<ApplicantWorkHistoryPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/applicant/v1/workhistory/{id}");

            var response = _client.Execute<ApplicantWorkHistoryPoco>(request);

            var applicantWorkHistory =
                JsonConvert.DeserializeObject<ApplicantWorkHistoryPoco>(response.Content);

            return View(applicantWorkHistory);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Applicant, CompanyName, CountryCode, Location, JobTitle, JobDescription, StartMonth, StartYear, EndMonth, EndYear")]
            ApplicantWorkHistoryPoco poco)
        {

            ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/applicant/v1/workhistory", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<ApplicantWorkHistoryPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/applicant/v1/workhistory/{id}");

            var response = _client.Execute<ApplicantWorkHistoryPoco>(request);

            var applicantWorkHistory =
                JsonConvert.DeserializeObject<ApplicantWorkHistoryPoco>(response.Content);

            ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[]
            { applicantWorkHistory };

            var deleteRequest = new
                RestRequest("api/careercloud/applicant/v1/workhistory", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}