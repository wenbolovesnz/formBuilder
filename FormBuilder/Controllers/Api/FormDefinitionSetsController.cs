using System;
using System.Collections.Generic;
using System.Web.Http;
using FormBuilder.Business.Entities;
using FormBuilder.Models;
using FormBuilder.Data.Contracts;
using System.Linq;
using WebMatrix.WebData;

namespace FormBuilder.Controllers.Api
{
    public class FormDefinitionSetsController : ApiController
    {
        private IApplicationUnit _applicationUnit;
        private ModelFactory _modelFactory;

        public FormDefinitionSetsController(IApplicationUnit applicationUnit)
        {
            _applicationUnit = applicationUnit;
            _modelFactory = new ModelFactory();
        }

        // GET
        [Authorize]
        public IEnumerable<Object> Get()
        {
            User currentUser = _applicationUnit.UserRepository.GetByID(WebSecurity.CurrentUserId);

            // We can pass includeProperties: "Organization,FormDefinitions" to Get method to load related entities.
            return _applicationUnit.FormDefinitionSetRepository.Get(
                            includeProperties: "Organization,FormDefinitions",
                            orderBy: fd => fd.OrderBy(k => k.OrganizationId),
                            filter: fd => fd.OrganizationId == currentUser.OrganizationId)
                        .Select(f => _modelFactory.Create(f));
        }

        // GET api/formdefinitionsets/5
        public FormDefinitionSet Get(int id)
        {
            return _applicationUnit.FormDefinitionSetRepository.GetByID(id);
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
