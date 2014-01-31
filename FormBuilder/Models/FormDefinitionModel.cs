using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormBuilder.Models
{
    public class FormDefinitionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserModel CreatedByUser { get; set; }

        public IList<QuestionModel> QuestionModels { get; set; }


    }
}
