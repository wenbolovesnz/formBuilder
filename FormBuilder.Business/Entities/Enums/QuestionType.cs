using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Business.Entities
{
   
    public enum QuestionType
    {
        Integer = 1,

        Money = 2,

        Date = 3,

        Boolean = 4,
        
        String = 5,

        Select = 6,

        MultiSelect = 7
    }
}
