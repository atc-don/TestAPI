using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BasicAPI.Entities;

namespace BasicAPI.Managers.Interfaces
{
    public interface IStudentManager
    {
        List<StudentEntity> GetStudents(int studentID);

        List<StudentEntity> AddStudent(StudentEntity user);

        StudentEntity EditStudent(StudentEntity user);
    }
}
