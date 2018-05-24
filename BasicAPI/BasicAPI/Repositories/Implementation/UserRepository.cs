using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicAPI.Entities;
using BasicAPI.Repositories.Interfaces;

namespace BasicAPI.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        public void AddUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public void EditUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public List<UserEntity> GetUsers(int studentID)
        {
            throw new NotImplementedException();
        }
    }
}