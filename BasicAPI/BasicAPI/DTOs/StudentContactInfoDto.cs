using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAPI.DTOs
{
    public class StudentContactInfoDto
    {
        public int StudentContactInfoID { get; set; }

        public string StudentPhone { get; set; }

        public string StudentEmail { get; set; }
    }
}