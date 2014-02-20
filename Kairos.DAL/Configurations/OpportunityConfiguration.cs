using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Kairos.MODEL;

namespace Kairos.DAL.Configurations
{
    public class OpportunityConfiguration : EntityTypeConfiguration<Opportunity>
    {
        public OpportunityConfiguration()
        {
            this.Property(t => t.Description).HasMaxLength(5000).IsRequired();
            this.Property(t => t.Client).HasMaxLength(200).IsRequired();
            this.Property(t => t.Sector).HasMaxLength(100).IsRequired();
            this.Property(t => t.PrimaryContact).HasMaxLength(100).IsRequired();
            this.Property(t => t.Telno).HasMaxLength(20).IsRequired();
        }

    }
}
