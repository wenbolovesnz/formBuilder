using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Business.Entities
{
    public class FormDefinition
    {
        private ICollection<Question> _questions;

        public FormDefinition()
        {
            _questions = new List<Question>();
        }

        public int Id { get; set; }        
        public string FormName { get; set; }        
        public DateTime CreatedDate { get; set; }
        public bool IsPublished { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? PublishedDate { get; set; }
        public virtual User User { get; set; }

        public int FormDefinitionSetId { get; set; }
        public virtual FormDefinitionSet FormDefinitionSet { get; set; }

        public virtual ICollection<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        } 

    }
}
