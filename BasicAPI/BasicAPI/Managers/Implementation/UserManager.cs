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
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (user.StudentID <= 0)
            {
                throw new ArgumentOutOfRangeException("user.StudentID", user.StudentID, "Invalid Student ID");
            }

            if (String.IsNullOrWhiteSpace(user.UserFirstName))
            {
                throw new ArgumentNullException("user.UserFirstName");
            }

            if (String.IsNullOrWhiteSpace(user.UserLastName))
            {
                throw new ArgumentNullException("user.UserLastName");
            }

            _userRepository.AddUser(user);
        }

        public UserEntity EditUser(UserEntity user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (String.IsNullOrWhiteSpace(user.UserFirstName))
            {
                throw new ArgumentNullException("user.UserFirstName");
            }

            if (String.IsNullOrWhiteSpace(user.UserLastName))
            {
                throw new ArgumentNullException("user.UserLastName");
            }

            return _userRepository.EditUser(user);
        }

        public UserEntity GetUser(int userID)
        {
            if (userID <= 0)
            {
                throw new ArgumentOutOfRangeException("userID", userID, "Invalid UserID");
            }

            return _userRepository.GetUser(userID);
        }
    }
}