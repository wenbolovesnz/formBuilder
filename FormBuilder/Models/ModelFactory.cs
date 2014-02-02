using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FormBuilder.Business.Entities;

namespace FormBuilder.Models
{
    public class ModelFactory
    {
        public FormDefinitionSetModel Create(FormDefinitionSet formDefinitionSet)
        {
            var formDefinitionSetModel = new FormDefinitionSetModel();

            formDefinitionSetModel.Id = formDefinitionSet.Id;
            
            if (formDefinitionSet.FormDefinitions != null)
            {
                formDefinitionSetModel.FromDefinitionModels = formDefinitionSet.FormDefinitions
                .Select(f => Create(f));
            }

            if (formDefinitionSet.Organization != null)
            {
                formDefinitionSetModel.OrganizationModel = new OrganizationModel
                    {
                        Id = formDefinitionSet.OrganizationId,
                        OrganizationName = formDefinitionSet.Organization.OrganizationName
                    };
            }

            return formDefinitionSetModel;
        }
        
        public QuestionModel Create(Question question)
        {
            return new QuestionModel()
            {
                Id = question.Id,
                QuestionText = question.QuestionText,
                QuestionType = question.QuestionType, 
            };
        }

        //public OrganizationModel Create(Organization organization)
        //{

        //}

        public FormDefinitionModel Create(FormDefinition formDefinition)
        {
            var formDefinitionModel = new FormDefinitionModel();

            formDefinitionModel.Id = formDefinition.Id;
            formDefinitionModel.Name = formDefinition.FormName;
            formDefinitionModel.CreatedDate = formDefinition.CreatedDate;

            if (formDefinition.Questions != null)
            {
                formDefinitionModel.QuestionModels = formDefinition.Questions
                    .Select(f => Create(f)).ToList();
            }

            if (formDefinition.User != null)
            {
                formDefinitionModel.CreatedByUser = new UserModel
                {
                    Id = formDefinition.User.Id,
                    UserName = formDefinition.User.UserName
                };
            }

            return formDefinitionModel;
        }

    }
}