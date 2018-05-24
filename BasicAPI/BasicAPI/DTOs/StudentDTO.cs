using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAPI.DTOs
{
    public class StudentDto
    {
        public int StudentID { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

        List<StudentContactInfoDto> StudentContacts { get; set; }

        public List<UserDto> StudentUsers { get; set; }
    }
}