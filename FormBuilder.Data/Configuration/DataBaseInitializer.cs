using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Data.Configuration
{
    public class DataBaseInitializer: CreateDatabaseIfNotExists<FormBuilderContext>
    {
        //can put a seed here later... ok ? 
    }
}
