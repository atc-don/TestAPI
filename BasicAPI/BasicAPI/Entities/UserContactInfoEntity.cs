using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAPI.Entities
{
    public class UserContactInfoEntity
    {
        public int UserContactInfoID { get; set; }

        public int UserID { get; set; }

        public string UserPhone { get; set; }

        public string UserEmail { get; set; }
    }
}