using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace JobHunter.DAL
{
    public class JobHunterConfiguration : DbConfiguration
    {
        //Configurator!
        public JobHunterConfiguration()
        {
            //Set the exectution strategy.  To the cloud!
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
        
    }
}