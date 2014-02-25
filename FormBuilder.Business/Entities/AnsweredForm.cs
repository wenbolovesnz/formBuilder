using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Business.Entities
{
    public class AnsweredForm
    {
        private ICollection<Question> _questions;

        public AnsweredForm()
        {
            _questions = new List<Question>();
        }

        public int Id { get; set; }        
        
        public DateTime AnsweredDate { get; set; }
                
        public int? CreatedBy { get; set; }
        public virtual User User { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        
        public int FormDefinitionId { get; set; }
        public string FormName { get; set; }
        public virtual ICollection<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        } 
    }
}
