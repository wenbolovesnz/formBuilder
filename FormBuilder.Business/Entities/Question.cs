using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Business.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }
        public bool IsRequired { get; set; }
        public string Tooltip { get; set; }
        public string Value { get; set; }
        public int Index { get; set; }
        public string AnswerOptions { get; set; }

    }



}
