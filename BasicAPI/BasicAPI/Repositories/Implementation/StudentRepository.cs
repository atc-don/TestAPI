using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicAPI.Entities;
using BasicAPI.Repositories.Interfaces;

namespace BasicAPI.Repositories.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        public List<StudentEntity> AddStudent(StudentEntity user)
        {
            throw new NotImplementedException();
        }

        public StudentEntity EditStudent(StudentEntity user)
        {
            throw new NotImplementedException();
        }

        public List<StudentEntity> GetStudents(int studentID)
        {
            throw new NotImplementedException();
        }
    }
}