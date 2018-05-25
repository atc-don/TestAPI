using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;
using AutoMapper;

using BasicAPI.Entities;
using BasicAPI.Models;
using BasicAPI.Repositories.Interfaces;

namespace BasicAPI.Repositories.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IMapper _mapper;

        public StudentRepository(IMapper mapper)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException("mapper");
            }

            _mapper = mapper;
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

            try
            {
                using (APITestEntities db = new APITestEntities())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<StudentContacts>");

                    foreach (StudentContactInfoEntity studentContact in student.StudentContacts)
                    {
                        sb.Append("<StudentContact>");

                        sb.Append("<StudentPhone>" + studentContact.StudentPhone + "</StudentPhone>");
                        sb.Append("<StudentEmail>" + studentContact.StudentEmail + "</StudentEmail>");

                        sb.Append("</StudentContact>");
                    }

                    sb.Append("</StudentContacts>");

                    string xmlStudentContacts = sb.ToString();

                    db.AddStudent(student.StudentFirstName, student.StudentLastName, xmlStudentContacts);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
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

            throw new NotImplementedException();
        }

        public StudentEntity GetStudent(int studentID)
        {
            if (studentID <= 0)
            {
                throw new ArgumentOutOfRangeException("studentID", studentID, "Invalid studentID");
            }

            StudentEntity student = null;
            try
            {
                using (APITestEntities db = new APITestEntities())
                {
                    List<DBStudent> dbStudents = db.GetStudentsByID(studentID).ToList();

                    List<StudentEntity> students = _mapper.Map<List<StudentEntity>>(dbStudents);

                    student = students.FirstOrDefault();

                    if (student != null)
                    {
                        student.StudentContacts = new List<StudentContactInfoEntity>();

                        List<StudentContactInfoEntity> studentContacts = _mapper.Map<List<StudentContactInfoEntity>>(dbStudents);                        

                        foreach (StudentContactInfoEntity studentContact in studentContacts.Where(x => x.StudentID == student.StudentID))
                        {
                            student.StudentContacts.Add(studentContact);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return student;
        }
    }
}