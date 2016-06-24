using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobHunter.Models
{
    public class Job
    {
        public int JobID { get; set; }
        public int CompanyID { get; set; }
        public string PostionTitle { get; set; }
        public string PostionDescription { get; set; }
        public string URL { get; set; }
        public string source { get; set; }
        public int salary { get; set; }
        public string notes { get; set; }
        public DateTime DateFound { get; set; }
        public DateTime DateApplied { get; set; }
        public int ResumeID { get; set; }
        public int CoverLetterID { get; set; }

    }
}