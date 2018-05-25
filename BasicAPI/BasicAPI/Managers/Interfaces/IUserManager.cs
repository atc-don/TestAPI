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
        UserEntity GetUser(int userID);

        void AddUser(UserEntity user);

        UserEntity EditUser(UserEntity user);
    }
}
