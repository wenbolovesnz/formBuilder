using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormBuilder.Models
{
    public class FormDefinitionSetModel
    {
        public int Id { get; set; }
        public IEnumerable<FormDefinitionModel> FormDefinitionModels { get; set; }
        public OrganizationModel OrganizationModel { get; set; }

    }
}
