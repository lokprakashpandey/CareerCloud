using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareerCloud.Pocos;
using RestSharp;
using Newtonsoft.Json;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.MVC.Models;

namespace CareerCloud.MVC.Controllers
{
    public class SecurityLoginController : Controller
    {
        // GET: SecurityLogin
        private RestClient _client;

        public SecurityLoginController()
        {
            _client = new RestClient("http://localhost:60678/");

            var request = new 
                RestRequest("api/careercloud/security/v1/{id}");
        }

        public ActionResult Index()
        {
            var request = new 
                RestRequest("api/careercloud/security/v1/login");

            var response = _client.Execute<SecurityLoginPoco>(request);

            var content = response.Content; //gets content as string

            //deserialize string to json object
            var securityLogins =
                JsonConvert.DeserializeObject<IEnumerable<SecurityLoginPoco>>(content);

            return View(securityLogins);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Login, Password, Created, PasswordUpdate, AgreementAccepted, IsLocked, IsInactive, EmailAddress, PhoneNumber, FullName, ForceChangePassword, PrefferredLanguage")]
            SecurityLoginPoco poco)
        {

            SecurityLoginPoco[] pocos = new SecurityLoginPoco[] 
                { poco };

            var request = new
                RestRequest("api/careercloud/security/v1/login", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<SecurityLoginPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var request = new
                RestRequest($"api/careercloud/security/v1/login/{id}");

            var response = _client.Execute<SecurityLoginPoco>(request);

            var securityLogin =
                JsonConvert.DeserializeObject<SecurityLoginPoco>(response.Content);

            return View(securityLogin);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, Login, Password, Created, PasswordUpdate, AgreementAccepted, IsLocked, IsInactive, EmailAddress, PhoneNumber, FullName, ForceChangePassword, PrefferredLanguage")]
            SecurityLoginPoco poco)
        {

            SecurityLoginPoco[] pocos = new SecurityLoginPoco[] 
             { poco };

            var request = new
                RestRequest("api/careercloud/security/v1/login", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(pocos);

            var response = _client.Execute<SecurityLoginPoco>(request);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            var request = new
                   RestRequest($"api/careercloud/security/v1/login/{id}");

            var response = _client.Execute<SecurityLoginPoco>(request);

            var securityLogin =
                JsonConvert.DeserializeObject<SecurityLoginPoco>(response.Content);

            SecurityLoginPoco[] pocos = new SecurityLoginPoco[] 
            { securityLogin };

            var deleteRequest = new
                RestRequest("api/careercloud/security/v1/login", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };

            deleteRequest.AddBody(pocos);

            _client.Execute(deleteRequest);

            return View("Index");

        }

        public ActionResult ALogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ALogin(
            [Bind(Include = "EmailAddress, Password")]
            AuthenticationModel Auth
            )
        {
            string email = Auth.EmailAddress;
            string pass = Auth.Password;

            if (MiscellaneousLogic.Authenticate(email, pass))
            {
                Session["AEmail"] = email;
                return RedirectToAction("ADashboard");
            }
            else
                return View();
        }


        
        public ActionResult ADashboard()
        {
            string e = (string)Session["AEmail"];

            string []tempString = MiscellaneousLogic.GetJobsApplied(e);

            return View(tempString);
        }
    }
}