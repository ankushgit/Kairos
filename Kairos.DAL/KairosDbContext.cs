using Kairos.DAL.Configurations;
using Kairos.MODEL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.DAL
{
    public class KairosDbContext : DbContext
    {
        //Declare DBSets here.
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Project> Projects { get; set; }

        
        public KairosDbContext()
            : base(nameOrConnectionString: "Kairos")
        { }

        static KairosDbContext()
        {
            //TODO: The below line is for Development only and needs to be removed for production
            Database.SetInitializer(new KairosDatabaseInitialiser());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OpportunityConfiguration());
            modelBuilder.Configurations.Add(new ProjectConfiguration());
        }
    }
}
