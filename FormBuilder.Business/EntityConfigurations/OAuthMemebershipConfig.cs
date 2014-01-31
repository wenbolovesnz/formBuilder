using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormBuilder.Business.Entities;

namespace FormBuilder.Business.EntityConfigurations
{
    public class OAuthMemebershipConfig : EntityTypeConfiguration<OAuthMembership>
    {
        public OAuthMemebershipConfig()
        {
            this.ToTable("webpages_OAuthMembership");

            this.HasKey(k => new { k.Provider, k.ProviderUserId });

            this.Property(p => p.Provider)
                .HasColumnType("nvarchar")
                .HasMaxLength(30).IsRequired();

            this.Property(p => p.ProviderUserId)
                .HasColumnType("nvarchar")
                .HasMaxLength(100).IsRequired();

            this.Property(p => p.UserId).IsRequired();

        }
    }
}
