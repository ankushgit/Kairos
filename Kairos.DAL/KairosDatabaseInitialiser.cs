using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace Kairos.DAL
{
    public class KairosDatabaseInitialiser : DropCreateDatabaseIfModelChanges<KairosDbContext>
    {
        protected override void Seed(KairosDbContext context)
        {
            
            base.Seed(context);
        }
    }
}
