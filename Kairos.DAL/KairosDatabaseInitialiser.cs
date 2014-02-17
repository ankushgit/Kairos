﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Kairos.MODEL;
namespace Kairos.DAL
{
    public class KairosDatabaseInitialiser : DropCreateDatabaseIfModelChanges<KairosDbContext>
    {
        protected override void Seed(KairosDbContext context)
        {
            addOpportunities(context);
            addProjects(context);
            base.Seed(context); //TIP: This will call save changes on the context
        }

        private void addOpportunities(KairosDbContext context)
        {
            for (int i = 1 ; i <= 10 ; i++)
            {
                Opportunity opp = new Opportunity
                {
                    Description = "Opportunity " + i.ToString(),
                    Client = "Client " + i.ToString(),
                    PrimaryContact = "Contact " + i.ToString(),
                    Telno = (i * 1000).ToString()
                };
                context.Opportunities.Add(opp);
            }
        }

        private void addProjects(KairosDbContext context)
        {
            for(int i=1;i<=10;i++)
            {
                Project prj = new Project
                {
                    Description = "Project " + i.ToString(),
                    Duration = i,
                    StartDate = DateTime.Now.AddDays(i),
                    EndDate = DateTime.Now.AddMonths(i)
                };
                context.Projects.Add(prj);
            }
        }



    }
}