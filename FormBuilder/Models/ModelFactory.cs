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
            return new FormDefinitionSetModel()
                {
                   Id = formDefinitionSet.Id,
                   FromDefinitionModels = formDefinitionSet.FormDefinations.Select(m => new FormDefinitionModel()
                       {
                           Id = m.Id,
                           Name = m.FormName
                       })
                };
        }
    }
}