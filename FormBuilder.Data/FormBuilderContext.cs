using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormBuilder.Business.Entities;

namespace FormBuilder.Data
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, add the following
    // code to the Application_Start method in your Global.asax file.
    // Note: this will destroy and re-create your database with every model change.
    // 
    // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<FormBuilder.Models.TodoItemContext>());
    public class FormBuilderContext : DbContext
    {
        public FormBuilderContext() : base("name=DefaultConnection")
        {
            //Database.SetInitializer<FormBuilderContext>(null);
        }

        public DbSet<Question> QuestionSet { get; set; }
        public DbSet<FormDefination> FormDefinationSet { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormDefination>()
                .HasMany(fd => fd.UsedByQuestions)
                .WithMany(q => q.FormDefinations)
                .Map(
                        m =>
                        {
                            m.MapLeftKey("FormDefinationId");
                            m.MapRightKey("QuestionId");
                            m.ToTable("FormDefinationQuestions");
                        }
                );

        }
    }
}
