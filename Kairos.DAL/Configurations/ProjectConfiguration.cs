using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Kairos.MODEL;

namespace Kairos.DAL.Configurations
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            this.Property(t => t.Description).HasMaxLength(1000).IsRequired();
            this.Property(t => t.Duration).IsRequired();
            this.Property(t => t.StartDate).IsRequired();
        }
    }
}
