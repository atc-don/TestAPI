using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAPI.Entities
{
    public class StudentEntity
    {
        public int StudentID { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

        public List<StudentContactInfoEntity> StudentContacts { get; set; }

        public List<UserEntity> StudentUsers { get; set; }
    }
}