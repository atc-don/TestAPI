using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BasicAPI.Entities;

namespace BasicAPI.Managers.Interfaces
{
    public interface IUserManager
    {
        List<UserEntity> GetUsers(int studentID);

        void AddUser(UserEntity user);

        void EditUser(UserEntity user);
    }
}
