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

        public void AddStudent(StudentEntity student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }

            if (String.IsNullOrWhiteSpace(student.StudentFirstName))
            {
                throw new ArgumentNullException("student.StudentFirstName");
            }

            if (String.IsNullOrWhiteSpace(student.StudentFirstName))
            {
                throw new ArgumentNullException("student.StudentFirstName");
            }

            _studentRepository.AddStudent(student);
        }

        public StudentEntity EditStudent(StudentEntity student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }

            if (String.IsNullOrWhiteSpace(student.StudentFirstName))
            {
                throw new ArgumentNullException("student.StudentFirstName");
            }

            if (String.IsNullOrWhiteSpace(student.StudentFirstName))
            {
                throw new ArgumentNullException("student.StudentFirstName");
            }

            return _studentRepository.EditStudent(student);
        }

        public StudentEntity GetStudents(int studentID)
        {
            if (studentID <= 0)
            {
                throw new ArgumentOutOfRangeException("studentID", studentID, "Invalid studentID");
            }

            return _studentRepository.GetStudent(studentID);
        }
    }
}