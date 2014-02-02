using FormBuilder.Business.Entities;
using FormBuilder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FormBuilder.Data.Data_Repositories;
using FormBuilder.Models;

namespace FormBuilder.Controllers.Api
{
    public class FormsController : ApiController
    {
        private ApplicationUnit _applicationUnit;
        private ModelFactory _modelFactory;

        public FormsController(ApplicationUnit applicationUnit)
        {
            _applicationUnit = applicationUnit;
            _modelFactory = new ModelFactory();
        }

        public IEnumerable<Object> Get()
        {
            return _applicationUnit.QuestionRepository.Get(orderBy: q => q.OrderBy(k => k.QuestionType))
                                    .Select(f => _modelFactory.Create(f));
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
