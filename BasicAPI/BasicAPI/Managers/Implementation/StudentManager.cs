using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicAPI.Entities;
using BasicAPI.Managers.Interfaces;
using BasicAPI.Repositories.Interfaces;

namespace BasicAPI.Managers.Implementation
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            if (studentRepository == null)
            {
                throw new ArgumentNullException("studentRepository");
            }

            _studentRepository = studentRepository;
        }

        public List<StudentEntity> AddStudent(StudentEntity user)
        {
            return _studentRepository.AddStudent(user);
        }

        public StudentEntity EditStudent(StudentEntity user)
        {
            return _studentRepository.EditStudent(user);
        }

        public List<StudentEntity> GetStudents(int studentID)
        {
            return _studentRepository.GetStudents(studentID);
        }
    }
}