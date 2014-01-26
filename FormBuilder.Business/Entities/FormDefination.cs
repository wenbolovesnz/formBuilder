﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Business.Entities
{
    public class FormDefination
    {
        private ICollection<Question> _questions;

        public FormDefination()
        {
            _questions = new List<Question>();
        }

        public int Id { get; set; }        
        public string FormName { get; set; }        
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        

        public virtual ICollection<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        } 

    }
}
