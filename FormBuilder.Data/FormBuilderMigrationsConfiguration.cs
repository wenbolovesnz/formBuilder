using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using FormBuilder.Business.Entities;

namespace FormBuilder.Data
{
    public class FormBuilderMigrationsConfiguration : DbMigrationsConfiguration<FormBuilderContext>
    {
        public FormBuilderMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FormBuilderContext context)
        {
            base.Seed(context);

            //context.Roles.AddOrUpdate(
            //                role => role.RoleName,
            //                new Role
            //                {
            //                    RoleName = "Admin"
            //                },
            //                new Role
            //                {
            //                    RoleName = "Normal"
            //                });

            //TODO: Seed with sample database on dev environment via #if DEBUG switch
            //I have commented this out, as the seed got wrong key, and it creates some conflicts while initial database.
            #if DEBUG

            //context.Roles.AddOrUpdate(
            //                role => role.RoleName,
            //                new Role
            //                {
            //                    RoleName = "Admin"
            //                },
            //                new Role
            //                {
            //                    RoleName = "Normal"
            //                });
            if (context.FormDefinitionSets.Count() == 0)
            {
                var sampleFormDefinationData = SampleDataBuilder.SeedDbWithSampleFormDefinations();

                sampleFormDefinationData.ForEach(fd => context.FormDefinitionSets.Add(fd));

                

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }
            #endif
        }
    }
}
