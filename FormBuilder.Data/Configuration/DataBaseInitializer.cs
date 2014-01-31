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
        protected override void Seed(FormBuilderContext context)
        {
            base.Seed(context);

            //TODO: Seed with sample database on dev environment via #if DEBUG switch
            //I have commented this out, as the seed got wrong key, and it creates some conflicts while initial database.
            //#if DEBUG
            //if (context.FormDefinitionSets.Count() == 0)
            //{
            //    var sampleFormDefinationData = SampleDataBuilder.SeedDbWithSampleFormDefinations();

            //    sampleFormDefinationData.ForEach(fd => context.FormDefinitionSets.Add(fd));

            //    try
            //    {
            //        context.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        var msg = ex.Message;
            //    }
            //}
            //#endif
        }
    }
}
