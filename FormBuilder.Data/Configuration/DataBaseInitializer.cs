using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormBuilder.Business.Entities;

namespace FormBuilder.Data.Configuration
{
    public class DataBaseInitializer: CreateDatabaseIfNotExists<FormBuilderContext>
    {
        
        //can put a seed here later... ok ? 
        protected override void Seed(FormBuilderContext context)
        {
            context.Roles.AddOrUpdate(
                                        role => role.RoleName,
                                        new Role
                                        {
                                            RoleName = "Admin"
                                        },
                                        new Role
                                        {
                                            RoleName = "Normal"
                                        });
        }
    }
}
