using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormBuilder.Business.Entities;
using FormBuilder.Data.Configuration;

namespace FormBuilder.Data
{  
    public class FormBuilderContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<FormDefinition> FormDefinations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FormDefinitionSet> FormDefinitionSets { get; set; }
        public DbSet<Organization> Organizations { get; set; }       


        public static string ConnectionStringName
        {
            get
            {
                if(ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {
                    return ConfigurationManager.AppSettings["ConnectionStringName"];
                }

                return "FormBuilderDev";
            }
        }

        static FormBuilderContext()
        {
            Database.SetInitializer(new DataBaseInitializer());
        }

        public FormBuilderContext():base(nameOrConnectionString: FormBuilderContext.ConnectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FormDefinationSetConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
