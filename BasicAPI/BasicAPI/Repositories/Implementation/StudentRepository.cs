using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public List<StudentEntity> AddStudent(StudentEntity student)
        {
            List<StudentEntity> students = null;
            int? insertedStudentID = null;

            try
            {
                using (APITestEntities db = new APITestEntities())
                {
                    /*****PERFORM INSERT******/
                    insertedStudentID= db.AddStudent(student.StudentFirstName, student.StudentLastName);
                }

                if (insertedStudentID.HasValue)
                {
                    students = GetStudents(insertedStudentID.Value);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return students;
        }

        public StudentEntity EditStudent(StudentEntity user)
        {
            throw new NotImplementedException();
        }

        public List<StudentEntity> GetStudents(int studentID)
        {
            List<StudentEntity> students = null;
            try
            {
                using (APITestEntities db = new APITestEntities())
                {
                    List<DBUser> dbStudents = db.GetUsersByStudentID(studentID).ToList();

                    students = _mapper.Map<List<StudentEntity>>(dbStudents);

                    List<StudentContactInfoEntity> userContacts = _mapper.Map<List<StudentContactInfoEntity>>(dbStudents);

                    foreach (StudentEntity studentItem in students)
                    {
                        studentItem.StudentContacts = new List<StudentContactInfoEntity>();

                        foreach (StudentContactInfoEntity studentContact in userContacts.Where(x => x.StudentID == studentItem.StudentID))
                        {
                            studentItem.StudentContacts.Add(studentContact);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return students;
        }
    }
}