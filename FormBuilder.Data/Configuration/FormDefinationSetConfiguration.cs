using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using FormBuilder.Business.Entities;

namespace FormBuilder.Data.Configuration
{
    public class FormDefinationSetConfiguration : EntityTypeConfiguration<FormDefinitionSet>
    {
        public FormDefinationSetConfiguration()
        {
            // Define constraints for all the properties within this table. For e.g.
            // this.Property(p => p.Id)
            //     .IsRequired().HasMaxLength(100);

            // can define any many-many relationships here.. via fluent api
        }
    }
}
