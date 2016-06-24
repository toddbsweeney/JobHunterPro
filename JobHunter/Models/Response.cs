using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobHunter.Models
{
    public class Response
    {
        public int ResponseID { get; set; }
        public DateTime ResponseDate { get; set; }
        public int ResponseTypeID { get; set; }
        public bool FollowUpRequired { get; set; }
        public string ResponseNotes { get; set; }
        public DateTime ResponseDue { get; set; }

    }
}