using FormBuilder.Business.Entities;
using FormBuilder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Data
{
    // Move interface to Data Contracts folder
    public interface IFormBuilderRepository
    {
        IQueryable<FormDefinitionSet> GetAllFormDefinitions();

        FormDefination GetFormDefination(int formDefinationId);

        bool Save();

        bool AddQuestionToFormDefination(Question newQuestion, int formDefinationId);

        bool AddFormDefinitionSet(FormDefinitionSet newFormDefinationSet);

        IQueryable<Question> GetAllQuestionsForFormDefination(int formDefinationId);

        Question GetQuestion(int questionId);
    }

    public class FormBuilderRepository : IFormBuilderRepository
    {
        FormBuilderContext _ctx;

        public FormBuilderRepository(FormBuilderContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<FormDefinitionSet> GetAllFormDefinitions()
        {
            return _ctx.FormDefinitionSets;
        }

        public FormDefination GetFormDefination(int formDefinationId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                //TODO: proper logging
                return false;
            }
        }

        public bool AddQuestionToFormDefination(Question newQuestion, int formDefinationId)
        {
            throw new NotImplementedException();
        }

        public bool AddFormDefinitionSet(FormDefinitionSet newFormDefinitionSet)
        {
            try
            {
                _ctx.FormDefinitionSets.Add(newFormDefinitionSet);
                return true;
            }
            catch (Exception ex)
            {
                //TODO: proper logging
                return false;
            }
        }

        public IQueryable<Question> GetAllQuestionsForFormDefination(int formDefinationId)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion(int questionId)
        {
            throw new NotImplementedException();
        }
    }
}