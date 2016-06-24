using System;
using System.Collections.Generic;

namespace JobHunter.Models
{
    public class Company
    {
        
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool PortlandHQ { get; set; }
        public string Website { get; set; }
        public int Employees { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
        public virtual ICollection<JobHunterTask> JobHunterTasks { get; set; }


    }  //Company
}