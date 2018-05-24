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
        List<UserEntity> GetUsers(int studentID);

        void AddUser(UserEntity user);

        void EditUser(UserEntity user);
    }
}
