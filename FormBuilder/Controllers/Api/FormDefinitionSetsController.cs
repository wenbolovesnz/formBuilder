using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FormBuilder.Business.Entities;
using FormBuilder.Data.Data_Repositories;
using FormBuilder.Models;

namespace FormBuilder.Controllers.Api
{
    public class FormDefinitionSetsController : ApiController
    {
        private ApplicationUnit _applicationUnit;
        private ModelFactory _modelFactory;

        public FormDefinitionSetsController(ApplicationUnit applicationUnit)
        {
            _applicationUnit = applicationUnit;
            _modelFactory = new ModelFactory();
        }

        // GET
        public IEnumerable<Object> Get()
        {
            var formDefinitionSets = _applicationUnit.FormDefinitionSets
                                                     .GetAll()
                                                     .Include(m => m.Organization)
                                                     .Include(m => m.FormDefinations)
                                                     .OrderByDescending(fd => fd.OrganizationId).ToList()
                                                     .Select(f => _modelFactory.Create(f));
            return formDefinitionSets;
        }

        // GET api/formdefinitionsets/5
        public FormDefinitionSet Get(int id)
        {
            return _applicationUnit.FormDefinitionSets.GetById(id);
        }

        // POST api/formdefinitionsets
        public void Post([FromBody]string value)
        {
        }

        // PUT api/formdefinitionsets/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/formdefinitionsets/5
        public void Delete(int id)
        {
        }
    }
}
