﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicAPI.Entities;
using BasicAPI.Repositories.Interfaces;

namespace BasicAPI.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        public List<UserEntity> AddUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public UserEntity EditUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public List<UserEntity> GetUsers(int userID)
        {
            throw new NotImplementedException();
        }
    }
}