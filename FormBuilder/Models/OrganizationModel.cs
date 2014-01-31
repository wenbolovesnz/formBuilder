using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormBuilder.Models
{
    public class OrganizationModel
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }

        public IList<UserModel> UserModel { get; set; }
        public IList<FormDefinitionSetModel> FormDefinitionSetModels { get; set; }

    }
}
