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
        StudentEntity GetStudents(int studentID);

        void AddStudent(StudentEntity user);

        StudentEntity EditStudent(StudentEntity user);
    }
}
