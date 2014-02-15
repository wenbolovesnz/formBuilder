using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormBuilder.Business.Entities;

namespace FormBuilder.Business.EntityConfigurations
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            this.HasKey(m => m.Id);
            this.Property(p => p.UserName).IsRequired().HasMaxLength(300);
            this.Property(p => p.ForceChangePassword).IsRequired();

            this.HasOptional(m => m.Organization);
            this.Property(p => p.OrganizationId).IsOptional();


            this.HasMany(p => p.Roles).WithMany(b => b.Users).Map(m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("RoleId");
                m.ToTable("webpages_UsersInRoles");
            });
        }
    }
}
