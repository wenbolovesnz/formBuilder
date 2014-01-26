using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Business.Entities
{
    public class FormDefinitionSet
    {
        private ICollection<FormDefination> _formDefinition;

        public FormDefinitionSet()
        {
            _formDefinition = new List<FormDefination>();
        }

        public int Id { get; set; }
        public int OrgnizationId { get; set; }
        public Organization Organization { get; set; }


        public virtual ICollection<FormDefination> FormDefinations
        {
            get { return _formDefinition; }
            set { _formDefinition = value; }
        } 

    }


}
