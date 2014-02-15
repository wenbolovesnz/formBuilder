using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormBuilder.Business.Entities;
using FormBuilder.Business.EntityConfigurations;
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
        public DbSet<Role> Roles { get; set; }       


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
            
        }

        public FormBuilderContext():base(nameOrConnectionString: FormBuilderContext.ConnectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<FormBuilderContext, FormBuilderMigrationsConfiguration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MembershipConfig());
            modelBuilder.Configurations.Add(new OAuthMemebershipConfig());
            modelBuilder.Configurations.Add(new RoleConfig());
            modelBuilder.Configurations.Add(new UserConfig());            
        }
    }
}
