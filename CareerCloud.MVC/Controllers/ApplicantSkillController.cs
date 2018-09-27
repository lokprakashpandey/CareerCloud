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
    public class ApplicantSkillController : Controller
    {
        // GET: ApplicantSkill
        private RestClient _client;

        public ApplicantSkillController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new
                RestRequest("api/careercloud/applicant/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new
             RestRequest("api/careercloud/applicant/v1/skill");

            var response = _client.Execute<ApplicantSkillPoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var applicantSkills =
                JsonConvert.DeserializeObject<IEnumerable<ApplicantSkillPoco>>(content);

            return View(applicantSkills);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Applicant, Skill, SkillLevel, StartMonth, StartYear, EndMonth, EndYear")]
            ApplicantSkillPoco poco)
        {

            ApplicantSkillPoco[] pocos = new ApplicantSkillPoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/applicant/v1/skill", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<ApplicantSkillPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/applicant/v1/skill/{id}");

            var response = _client.Execute<ApplicantSkillPoco>(request);

            var applicantSkill =
                JsonConvert.DeserializeObject<ApplicantSkillPoco>(response.Content);

            return View(applicantSkill);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Applicant, Skill, SkillLevel, StartMonth, StartYear, EndMonth, EndYear")]
            ApplicantSkillPoco poco)
        {

            ApplicantSkillPoco[] pocos = new ApplicantSkillPoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/applicant/v1/skill", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<ApplicantSkillPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/applicant/v1/skill/{id}");

            var response = _client.Execute<ApplicantSkillPoco>(request);

            var applicantSkill =
                JsonConvert.DeserializeObject<ApplicantSkillPoco>(response.Content);

            ApplicantSkillPoco[] pocos = new ApplicantSkillPoco[]
            { applicantSkill };

            var deleteRequest = new
                RestRequest("api/careercloud/applicant/v1/skill", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}