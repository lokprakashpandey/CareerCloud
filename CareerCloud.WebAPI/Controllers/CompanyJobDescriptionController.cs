using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyJobDescriptionController : ApiController
    {
        private CompanyJobDescriptionLogic _logic;

        public CompanyJobDescriptionController()
        {
            var repo =
                new EFGenericRepository<CompanyJobDescriptionPoco>(false);

            _logic = new CompanyJobDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("jobdescription/{companyJobDescriptionId}")]
        [ResponseType(typeof(CompanyJobDescriptionPoco))]
        public IHttpActionResult GetCompanyJobDescription(Guid companyJobDescriptionId)
        {
            CompanyJobDescriptionPoco poco = _logic.Get(companyJobDescriptionId);

            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("jobdescription")]
        [ResponseType(typeof(List<CompanyJobDescriptionPoco>))]
        public IHttpActionResult GetAllCompanyJobDescription()
        {
            List<CompanyJobDescriptionPoco> result = _logic.GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("jobdescription")]
        public IHttpActionResult PostCompanyJobDescription
            ([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobdescription")]
        public IHttpActionResult PutCompanyJobDescription
            ([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }


        [HttpDelete]
        [Route("jobdescription")]
        public IHttpActionResult DeleteCompanyJobDescription
            ([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
