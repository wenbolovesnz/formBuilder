using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Business.Entities
{
    public class FormDefinitionSet
    {
        private ICollection<FormDefinition> _formDefinition;

        public FormDefinitionSet()
        {
            _formDefinition = new List<FormDefinition>();
        }

        public int Id { get; set; }

        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }


        public virtual ICollection<FormDefinition> FormDefinitions
        {
            get { return _formDefinition; }
            set { _formDefinition = value; }
        } 

    }


}
