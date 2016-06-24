using System;
using System.Collections.Generic;

namespace JobHunter.Models
{
    public class Contact
    {
        public int ContactID { get; set; }
        public int Company_ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string ContactNotes { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
       
    }
}