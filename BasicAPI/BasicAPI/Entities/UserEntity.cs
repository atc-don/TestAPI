using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAPI.Entities
{
    public class UserEntity
    {
        public int UserID { get; set; }

        public int StudentID { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public List<UserContactInfoEntity> UserContacts { get; set; }
    }
}