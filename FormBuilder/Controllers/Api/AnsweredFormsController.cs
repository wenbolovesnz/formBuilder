using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FormBuilder.Business.Entities;
using FormBuilder.Data;
using FormBuilder.Models;
using Microsoft.Azure;
using Microsoft.ServiceBus.Messaging;
using WebMatrix.WebData;

namespace FormBuilder.Controllers.Api
{
    
    public class AnsweredFormsController : ApiController
    {
        private ApplicationUnit _applicationUnit;
        private ModelFactory _modelFactory;

       
        public AnsweredFormsController(ApplicationUnit applicationUnit)
        {
            _applicationUnit = applicationUnit;
            _modelFactory = new ModelFactory();
        }

         [Authorize]
        public IEnumerable<AnsweredForm> Get(int formDefinitionId, int answeredFormId)
        {
            User currentUser = _applicationUnit.UserRepository.GetByID(WebSecurity.CurrentUserId);
            
            if (answeredFormId == 0)
            {
                IList<AnsweredForm> answeredForms =
                    _applicationUnit.AnsweredFormRepository.Get(filter: m => m.FormDefinitionId == formDefinitionId && m.OrganizationId == currentUser.OrganizationId).ToList();
                return answeredForms;
            }
            else
            {
                IList<AnsweredForm> answeredForms =
                    _applicationUnit.AnsweredFormRepository.Get(filter: m => m.Id == answeredFormId && m.OrganizationId == currentUser.OrganizationId, includeProperties: "Questions").ToList();
                return answeredForms;
            }              
        }

        public AnsweredForm Post([FromBody] AnsweredForm answeredForm)
        {
            FormDefinition formDefinition =
                _applicationUnit.FormDefinationRepository.Get(includeProperties: "Questions,FormDefinitionSet,User", filter: m => m.Id == answeredForm.FormDefinitionId).First();

            //security check, maybe need more robust than this.
            if (!formDefinition.IsPublished || formDefinition.Questions.Count != answeredForm.Questions.Count ||
                formDefinition.FormName != answeredForm.FormName)
            {
                return null;
            }

            AnsweredForm newAnseredForm = new AnsweredForm()
                {
                    AnsweredDate = System.DateTime.Now,
                    OrganizationId = formDefinition.FormDefinitionSet.OrganizationId,
                    FormDefinitionId = answeredForm.FormDefinitionId,
                    FormName = answeredForm.FormName,

                };

            foreach (var question in answeredForm.Questions)
            {
                Question questionDefinition =
                    formDefinition.Questions.Single(m => m.QuestionText == question.QuestionText);

                Question newQuestion = new Question()
                    {
                        AnswerOptions = questionDefinition.AnswerOptions,
                        IsRequired = questionDefinition.IsRequired,
                        QuestionText = questionDefinition.QuestionText,
                        QuestionType = questionDefinition.QuestionType,
                        Tooltip = questionDefinition.Tooltip,
                        Value = question.Value
                    };

                newAnseredForm.Questions.Add(newQuestion);
            }

            _applicationUnit.AnsweredFormRepository.Insert(newAnseredForm);
            _applicationUnit.SaveChanges();

            // Create the queue if it does not exist already
            string connectionString =
                CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");

            QueueClient client = QueueClient.CreateFromConnectionString(connectionString, "formengine");

            // Create message, passing a string message for the body
            BrokeredMessage message = new BrokeredMessage("Answered Form Received.");

            // Set some addtional custom app-specific properties
            message.Properties["FormName"] = formDefinition.FormName;
            message.Properties["ReceivedDateTime"] = DateTime.Now.ToShortTimeString();
            message.Properties["To"] = formDefinition.User.UserName;            

            // Send message to the queue
            client.Send(message);
            

            return newAnseredForm;
        }


    }
}
