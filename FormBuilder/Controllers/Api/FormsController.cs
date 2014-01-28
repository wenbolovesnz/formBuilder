using FormBuilder.Business.Entities;
using FormBuilder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FormBuilder.Controllers.Api
{
    public class FormsController : ApiController
    {
        private IFormBuilderRepository _repo;

        public FormsController(IFormBuilderRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<FormDefinitionSet> Get()
        {
            IQueryable<FormDefinitionSet> results;

            results = _repo.GetAllFormDefinitions();

            var formDefinitionSets = results.OrderByDescending(fd => fd.OrgnizationId);

            return formDefinitionSets;
        }

        public HttpResponseMessage Post([FromBody] FormDefinitionSet newFormDefination)
        {
            if (_repo.AddFormDefinitionSet(newFormDefination) && _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created, newFormDefination);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
