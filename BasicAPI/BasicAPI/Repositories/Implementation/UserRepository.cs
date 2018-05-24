using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicAPI.Entities;
using BasicAPI.Repositories.Interfaces;

using AutoMapper;

using BasicAPI.Models;

namespace BasicAPI.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(IMapper mapper)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException("mapper");
            }

            _mapper = mapper;
        }

        public List<UserEntity> AddUser(UserEntity user)
        {
            List<UserEntity> users = null;

            using (APITestEntities db = new APITestEntities())
            {
                try
                {
                    db.AddUser(user.StudentID, user.UserFirstName, user.UserLastName);

                    List<DBUser> dbUsers = db.GetUsersByStudentID(user.StudentID).ToList();

                    users = _mapper.Map<List<UserEntity>>(dbUsers);
                }
                catch (Exception ex)
                {

                }
            }

            return users;
        }

        public UserEntity EditUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public List<UserEntity> GetUsers(int userID)
        {
            List<UserEntity> users = null;

            using (APITestEntities db = new APITestEntities())
            {
                try
                {
                    List<DBUser> dbUsers = db.GetUsersByID(userID).ToList();

                    users = _mapper.Map<List<UserEntity>>(dbUsers);
                }
                catch (Exception ex)
                {

                }
            }

            return users;
        }
    }
}