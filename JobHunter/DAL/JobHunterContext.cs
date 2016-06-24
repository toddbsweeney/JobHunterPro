using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobHunter.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace JobHunter.DAL
{
    public class JobHunterContext : DbContext
    {
        public JobHunterContext(): base("JobHunterContext")
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Response> Responses { get; set; }

        public DbSet<JobHunterTask> JobHunterTasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<JobHunter.Models.Company> Companies { get; set; }
    }


}