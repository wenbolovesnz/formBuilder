using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormBuilder.Business.Entities;

namespace FormBuilder.Models
{
    public class FormDefinitionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FormDefinitionSetId { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserModel CreatedByUser { get; set; }
        public bool IsPublished { get; set; }

        public IList<Question> Questions { get; set; }


    }
}
