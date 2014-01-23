using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Business.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }
        public QuestionBehaviour QuestionBehaviour { get; set; }
        public string Tooltip { get; set; }

        public virtual List<FormDefination> FormDefinations { get; set; }

        public Question()
        {
            FormDefinations = new List<FormDefination>();
        }
    }

    //TODO: move to some common place.
    public enum QuestionType
    {
        Integer,

        String,

        Date,

        Money,

        Boolean,

        Select,

        MultiSelect
    }

    public enum QuestionBehaviour
    {
        MandatoryVisible,
        
        MandatoryHidden,

        OptionalVisible,

        OptionalHidden

    }
}
