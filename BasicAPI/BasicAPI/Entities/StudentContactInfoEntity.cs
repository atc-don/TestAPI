using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAPI.Entities
{
    public class StudentContactInfoEntity
    {
        public int StudentContactInfoID { get; set; }

        public int StudentID { get; set; }

        public string StudentPhone { get; set; }

        public string StudentEmail { get; set; }
    }
}