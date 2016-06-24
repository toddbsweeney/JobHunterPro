using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using JobHunter.Models;

namespace JobHunter.DAL
{
    public class HunterInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<JobHunterContext>
    {
        protected override void Seed(JobHunterContext context)
        {
            /*var Companies = new List<Company>
            {
            new Company {CompanyName ="Viewpoint", PortlandHQ=true, City="Portland", Website="http://viewpoint.com/" },
            new Company {CompanyName ="Todd's Co", PortlandHQ = true, City = "Portland" }
            };
            Companies.ForEach(s => context.)
            Companies.ForEach(c => context.Companies.Add(c));
            context.SaveChanges();
            */


        }
    }
}