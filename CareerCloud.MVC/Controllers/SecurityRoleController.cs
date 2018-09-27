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
    public class SecurityRoleController : Controller
    {
        // GET: SecurityRole
        private RestClient _client;

        public SecurityRoleController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new
                RestRequest("api/careercloud/security/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new
                RestRequest("api/careercloud/security/v1/role");

            var response = _client.Execute<SecurityRolePoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var securityRoles =
                JsonConvert.DeserializeObject<IEnumerable<SecurityRolePoco>>(content);

            return View(securityRoles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Role, IsInactive")]
            SecurityRolePoco poco)
        {

            SecurityRolePoco[] pocos = new SecurityRolePoco[]
                { poco };

            var request = new
                RestRequest("api/careercloud/security/v1/role", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<SecurityRolePoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/security/v1/role/{id}");

            var response = _client.Execute<SecurityRolePoco>(request);

            var securityRole =
                JsonConvert.DeserializeObject<SecurityRolePoco>(response.Content);

            return View(securityRole);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Role, IsInactive")]
            SecurityRolePoco poco)
        {

            SecurityRolePoco[] pocos = new SecurityRolePoco[]
             { poco };

            var request = new
                RestRequest("api/careercloud/security/v1/role", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<SecurityRolePoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/security/v1/role/{id}");

            var response = _client.Execute<SecurityRolePoco>(request);

            var securityRole =
                JsonConvert.DeserializeObject<SecurityRolePoco>(response.Content);

            SecurityRolePoco[] pocos = new SecurityRolePoco[]
            { securityRole };

            var deleteRequest = new
                RestRequest("api/careercloud/security/v1/role", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }
    }
}