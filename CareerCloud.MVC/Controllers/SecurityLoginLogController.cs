using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareerCloud.Pocos;
using RestSharp;
using Newtonsoft.Json;

namespace CareerCloud.MVC.Controllers
{
    public class SecurityLoginLogController : Controller
    {
        // GET: SecurityLoginLog
        private RestClient _client;

        public SecurityLoginLogController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new
                RestRequest("api/careercloud/security/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new
                RestRequest("api/careercloud/security/v1/loginslog");

            var response = _client.Execute<SecurityLoginsLogPoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var securityLoginsLog =
                JsonConvert.DeserializeObject<IEnumerable<SecurityLoginsLogPoco>>(content);

            return View(securityLoginsLog);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Login, SourceIP, LogonDate, IsSuccessful")]
            SecurityLoginsLogPoco poco)
        {

            SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/security/v1/loginslog", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<SecurityLoginsLogPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/security/v1/loginslog/{id}");

            var response = _client.Execute<SecurityLoginsLogPoco>(request);

            var securityLoginsLog =
                JsonConvert.DeserializeObject<SecurityLoginsLogPoco>(response.Content);

            return View(securityLoginsLog);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Login, SourceIP, LogonDate, IsSuccessful")]
            SecurityLoginsLogPoco poco)
        {

            SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[]
             { poco };

            var request = new
                RestRequest("api/careercloud/security/v1/loginslog", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<SecurityLoginsLogPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/security/v1/loginslog/{id}");

            var response = _client.Execute<SecurityLoginsLogPoco>(request);

            var securityLoginsLog =
                JsonConvert.DeserializeObject<SecurityLoginsLogPoco>(response.Content);

            SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[]
            { securityLoginsLog };

            var deleteRequest = new
                RestRequest("api/careercloud/security/v1/loginslog", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}