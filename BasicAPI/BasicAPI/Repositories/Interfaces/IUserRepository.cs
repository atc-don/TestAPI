using BasicAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        UserEntity GetUser(int userID);

        void AddUser(UserEntity user);

        UserEntity EditUser(UserEntity user);
    }
}
