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

        //Get form definiton by id
        public IEnumerable<Object> Get(int id)
        {

            FormDefinition formDefinition = _applicationUnit.FormDefinationRepository.Get( includeProperties: "Questions", filter: m => m.Id == id).FirstOrDefault();

            IList<QuestionModel> questions = formDefinition.Questions.Select(m => _modelFactory.Create(m)).ToList();

            return questions;
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
                     FormName = formDefinitionModel.Name,
                     User = currentUser,
                     Questions = formDefinitionModel.Questions
                 };

                 formDefinitionSet.FormDefinitions.Add(formDefinition);

                 _applicationUnit.FormDefinitionSetRepository.Update(formDefinitionSet);
                 _applicationUnit.SaveChanges();

             }
            bool success = true;

            return new {success = success};
        }
    }
}
