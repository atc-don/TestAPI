using BasicAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAPI.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        List<StudentEntity> GetStudents(int studentID);

        List<StudentEntity> AddStudent(StudentEntity user);

        StudentEntity EditStudent(StudentEntity user);
    }
}
