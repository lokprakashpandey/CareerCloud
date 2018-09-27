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
    public class CompanyJobSkillController : Controller
    {
        // GET: CompanyJobSkill
        private RestClient _client;

        public CompanyJobSkillController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new
                RestRequest("api/careercloud/company/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new
                RestRequest("api/careercloud/company/v1/jobskill");

            var response = _client.Execute<CompanyJobSkillPoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var companyJobSkills =
                JsonConvert.DeserializeObject<IEnumerable<CompanyJobSkillPoco>>(content);

            return View(companyJobSkills);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Job, Skill, SkillLevel, Importance")]
            CompanyJobSkillPoco poco)
        {

            CompanyJobSkillPoco[] pocos = new CompanyJobSkillPoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/company/v1/jobskill", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<CompanyJobSkillPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/company/v1/jobskill/{id}");

            var response = _client.Execute<CompanyJobSkillPoco>(request);

            var companyJobSkill =
                JsonConvert.DeserializeObject<CompanyJobSkillPoco>(response.Content);

            return View(companyJobSkill);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Job, Skill, SkillLevel, Importance")]
            CompanyJobSkillPoco poco)
        {

            CompanyJobSkillPoco[] pocos = new CompanyJobSkillPoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/company/v1/jobskill", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<CompanyJobSkillPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/company/v1/jobskill/{id}");

            var response = _client.Execute<CompanyJobSkillPoco>(request);

            var companyJobSkill =
                JsonConvert.DeserializeObject<CompanyJobSkillPoco>(response.Content);

            CompanyJobSkillPoco[] pocos = new CompanyJobSkillPoco[]
                { companyJobSkill };

            var deleteRequest = new
                RestRequest("api/careercloud/company/v1/jobskill", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}