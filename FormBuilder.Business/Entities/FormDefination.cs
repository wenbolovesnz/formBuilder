using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Business.Entities
{
    public class FormDefination
    {
        public int FormDefinationId { get; set; }
        public string FormType { get; set; }
        public string FormName { get; set; }
        public string FormVersion { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }

        public virtual List<Question> UsedByQuestions { get; set; }

        public FormDefination()
        {
            UsedByQuestions = new List<Question>();
        }
    }
}
