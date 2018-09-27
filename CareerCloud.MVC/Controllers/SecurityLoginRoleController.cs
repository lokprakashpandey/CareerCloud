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
    public class SecurityLoginRoleController : Controller
    {
        // GET: SecurityLoginRole
        private RestClient _client;

        public SecurityLoginRoleController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new
                RestRequest("api/careercloud/security/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new
                RestRequest("api/careercloud/security/v1/loginsrole");

            var response = _client.Execute<SecurityLoginsRolePoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var securityLoginsRole =
                JsonConvert.DeserializeObject<IEnumerable<SecurityLoginsRolePoco>>(content);

            return View(securityLoginsRole);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Login, Role")]
            SecurityLoginsRolePoco poco)
        {

            SecurityLoginsRolePoco[] pocos = new SecurityLoginsRolePoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/security/v1/loginsrole", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<SecurityLoginsRolePoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/security/v1/loginsrole/{id}");

            var response = _client.Execute<SecurityLoginsRolePoco>(request);

            var securityLoginsRole =
                JsonConvert.DeserializeObject<SecurityLoginsRolePoco>(response.Content);

            return View(securityLoginsRole);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Login, Role")]
            SecurityLoginsRolePoco poco)
        {

            SecurityLoginsRolePoco[] pocos = new SecurityLoginsRolePoco[]
             { poco };

            var request = new
                RestRequest("api/careercloud/security/v1/loginsrole", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<SecurityLoginsRolePoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/security/v1/loginsrole/{id}");

            var response = _client.Execute<SecurityLoginsRolePoco>(request);

            var securityLoginsRole =
                JsonConvert.DeserializeObject<SecurityLoginsRolePoco>(response.Content);

            SecurityLoginsRolePoco[] pocos = new SecurityLoginsRolePoco[]
            { securityLoginsRole };

            var deleteRequest = new
                RestRequest("api/careercloud/security/v1/loginsrole", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}