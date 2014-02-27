using System.Web;
using System.Web.Http.Controllers;
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
using WebMatrix.WebData;

namespace FormBuilder.Controllers.Api
{
    public class FormDefinitionsController : ApiController
    {
        private ApplicationUnit _applicationUnit;
        private ModelFactory _modelFactory;

        public FormDefinitionsController(ApplicationUnit applicationUnit)
        {
            _applicationUnit = applicationUnit;
            _modelFactory = new ModelFactory();
        }

        //Get 
        public Object Get(int id, int orgId, string formName)
        {
            if (id != 0)
            {
                FormDefinition formDefinition =
                    _applicationUnit.FormDefinationRepository.Get(includeProperties: "Questions",
                                                                  filter: m => m.Id == id).FirstOrDefault();

                FormDefinitionModel formDefinitionModel = new FormDefinitionModel()
                    {
                        Name = formDefinition.FormName,
                        Id = formDefinition.Id,
                        FormDefinitionSetId = formDefinition.FormDefinitionSetId,
                        Questions = formDefinition.Questions.ToList()
                    };

                return formDefinitionModel;
            }
            else
            {
                FormDefinition formDefinition =
                    _applicationUnit.FormDefinationRepository.Get(includeProperties: "Questions",
                                                                  filter: m => m.FormName == formName 
                                                                          && m.FormDefinitionSet.OrganizationId == orgId
                                                                          && m.IsPublished).FirstOrDefault();

                FormDefinitionModel formDefinitionModel = new FormDefinitionModel()
                    {
                        Name = formDefinition.FormName,
                        Id = formDefinition.Id,
                        FormDefinitionSetId = formDefinition.FormDefinitionSetId,
                        Questions = formDefinition.Questions.ToList()
                    };

                return formDefinitionModel;
            }

        }

        [HttpPost]
        public HttpResponseMessage  Publish(int id)
        {
            User currentUser = _applicationUnit.UserRepository.GetByID(WebSecurity.CurrentUserId);
            FormDefinition formDefinition = _applicationUnit.FormDefinationRepository.Get(filter: m => m.Id == id, includeProperties: "FormDefinitionSet").First();

            if (formDefinition.FormDefinitionSet.OrganizationId == currentUser.OrganizationId)
            {
                if (formDefinition.IsPublished)
                {
                    formDefinition.IsPublished = false;
                }
                else
                {
                    formDefinition.IsPublished = true;
                    formDefinition.PublishedDate = System.DateTime.Now;
                }
                _applicationUnit.FormDefinationRepository.Update(formDefinition);
                _applicationUnit.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.Forbidden);            
        }

        //post, save a form definition, create a new form definition set if new, or just add form definition to its parent
        [Authorize]
        public Object Post([FromBody] FormDefinitionModel formDefinitionModel)
        {
             User currentUser = _applicationUnit.UserRepository.GetByID(WebSecurity.CurrentUserId);

             if (formDefinitionModel.FormDefinitionSetId == 0)
            {
                //create new formDefinitionSet
                FormDefinitionSet formDefinitionSet = new FormDefinitionSet()
                                                          {
                                                              Organization = currentUser.Organization,
                                                              OrganizationId = currentUser.OrganizationId.Value
                                                          };

                FormDefinition formDefinition = new FormDefinition()
                                                    {
                                                        CreatedBy = currentUser.Id,
                                                        CreatedDate = System.DateTime.Now,
                                                        FormDefinitionSet = formDefinitionSet,
                                                        FormName = formDefinitionModel.Name,
                                                        User = currentUser,
                                                        Questions = formDefinitionModel.Questions
                                                    };

                formDefinitionSet.FormDefinitions.Add(formDefinition);

                _applicationUnit.FormDefinitionSetRepository.Insert(formDefinitionSet);
                _applicationUnit.SaveChanges();
            }
             else
             {
                 FormDefinitionSet formDefinitionSet =
                     _applicationUnit.FormDefinitionSetRepository.GetByID(formDefinitionModel.FormDefinitionSetId);

                 FormDefinition formDefinition = new FormDefinition()
                 {
                     CreatedBy = currentUser.Id,
                     CreatedDate = System.DateTime.Now,
                     FormDefinitionSet = formDefinitionSet,
                     FormDefinitionSetId = formDefinitionSet.Id,
                     FormName = formDefinitionModel.Name,
                     User = currentUser,
                     Questions = formDefinitionModel.Questions
                 };

                 //formDefinitionSet.FormDefinitions.Add(formDefinition);

                 _applicationUnit.FormDefinationRepository.Insert(formDefinition);
                 _applicationUnit.SaveChanges();

             }
            bool success = true;

            return new {success = success};
        }
    }
}
