using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobHunter.Models
{
    public class JobHunterTask
    {
        public int JobHunterTaskID { get; set; }
        public int ContactID { get; set; }
        public int JobID { get; set; }
        public int ResponseID { get; set; }
        public DateTime DueDate { get; set; }
        public string Notes { get; set; }
        public bool TaskComplete { get; set; }

    }
}