using FormBuilder.Business.Entities;
using FormBuilder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FormBuilder.Data.Data_Repositories;

namespace FormBuilder.Controllers.Api
{
    public class FormsController : ApiController
    {
        private ApplicationUnit _applicationUnit;

        public FormsController(ApplicationUnit applicationUnit)
        {
            _applicationUnit = applicationUnit;
        }

        public IEnumerable<FormDefinitionSet> Get()
        {


            var results = _applicationUnit.FormDefinitionSets.GetAll();

            var formDefinitionSets = results.OrderByDescending(fd => fd.OrganizationId);

            return formDefinitionSets;
        }

        //public HttpResponseMessage Post([FromBody] FormDefinitionSet newFormDefination)
        //{
        //    if (_applicationUnit.FormDefinitionSets.a(newFormDefination) && _repo.Save())
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Created, newFormDefination);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.BadRequest);
        //}
    }
}
