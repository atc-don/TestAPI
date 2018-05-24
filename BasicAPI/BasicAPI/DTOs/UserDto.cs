using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAPI.DTOs
{
    public class UserDto
    {
        public int UserID { get; set; }

        public int StudentID { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        List<UserContactInfoDto> UserContacts { get; set; }
    }
}