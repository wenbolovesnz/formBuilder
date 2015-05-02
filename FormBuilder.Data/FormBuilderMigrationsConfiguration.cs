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

//        protected override void Seed(FormBuilderContext context)
//        {
//            base.Seed(context);
//        }
    }
}
