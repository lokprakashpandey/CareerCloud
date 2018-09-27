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
    public class CompanyProfileController : Controller
    {
        // GET: CompanyProfile

        private RestClient _client;

        public CompanyProfileController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new RestRequest("api/careercloud/company/v1/{id}");
        }
        
        public ActionResult Index()
        {
            var request = new RestRequest("api/careercloud/company/v1/profile");

            var response = _client.Execute<CompanyProfilePoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var companyProfiles = 
                JsonConvert.DeserializeObject<IEnumerable<CompanyProfilePoco>>(content);

            return View(companyProfiles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "RegistrationDate, CompanyWebsite, ContactPhone, ContactName")]
            CompanyProfilePoco poco)
        {
            
            CompanyProfilePoco[] pocos = new CompanyProfilePoco[] { poco };

            var request = new
                RestRequest("api/careercloud/company/v1/profile", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<CompanyProfilePoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/company/v1/profile/{id}");

            var response = _client.Execute<CompanyProfilePoco>(request);

            var companyProfile =
                JsonConvert.DeserializeObject<CompanyProfilePoco>(response.Content);

            return View(companyProfile);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, RegistrationDate, CompanyWebsite, ContactPhone, ContactName, CompanyLogo")]
            CompanyProfilePoco poco)
        {
            
            CompanyProfilePoco[] pocos = new CompanyProfilePoco[] { poco };

            var request = new
                RestRequest("api/careercloud/company/v1/profile", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<CompanyProfilePoco>(request);

            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/company/v1/profile/{id}");

            var response = _client.Execute<CompanyProfilePoco>(request);

            var companyProfile =
                JsonConvert.DeserializeObject<CompanyProfilePoco>(response.Content);

            CompanyProfilePoco[] pocos = new CompanyProfilePoco[] { companyProfile };

            var deleteRequest = new
                RestRequest("api/careercloud/company/v1/profile", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }

    }
}