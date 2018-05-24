using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BasicAPI.Entities;
using BasicAPI.Managers.Interfaces;
using BasicAPI.Repositories.Interfaces;

namespace BasicAPI.Managers.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException("userRepository");
            }

            _userRepository = userRepository;
        }

        public void AddUser(UserEntity user)
        {
            _userRepository.AddUser(user);
        }

        public void EditUser(UserEntity user)
        {
            _userRepository.EditUser(user);
        }

        public List<UserEntity> GetUsers(int studentID)
        {
            return _userRepository.GetUsers(studentID);
        }
    }
}