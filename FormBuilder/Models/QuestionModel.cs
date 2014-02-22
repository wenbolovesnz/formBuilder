using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormBuilder.Business.Entities;
using FormBuilder.Business.Entities.Enums;

namespace FormBuilder.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int QuestionType { get; set; }
        public bool IsRequired { get; set; }
        public string Tooltip { get; set; }
        public string Value { get; set; }
        public int Index { get; set; }
        public string AnswerOptions { get; set; }
    }
}
