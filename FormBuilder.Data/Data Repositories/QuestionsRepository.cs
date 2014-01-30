using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormBuilder.Business.Entities;

namespace FormBuilder.Data.Data_Repositories
{
    public class QuestionsRepository : GenericRepository<Question>
    {
        public QuestionsRepository(FormBuilderContext context)
            : base(context)
        {
            //empty
        }
    }
}
