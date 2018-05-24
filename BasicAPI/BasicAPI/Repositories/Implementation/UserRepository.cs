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
            int? insertedUserID = null;

            try
            {
                using (APITestEntities db = new APITestEntities())
                {
                    insertedUserID = db.AddUser(user.StudentID, user.UserFirstName, user.UserLastName);
                }

                if (insertedUserID.HasValue)
                {
                    users = GetUser(insertedUserID.Value);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return users;
        }

        public UserEntity EditUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public List<UserEntity> GetUser(int userID)
        {
            List<UserEntity> users = null;

            try
            {
                using (APITestEntities db = new APITestEntities())
                {
                    List<DBUser> dbUsers = db.GetUsersByID(userID).ToList();

                    users = _mapper.Map<List<UserEntity>>(dbUsers);

                    List<UserContactInfoEntity> userContacts = _mapper.Map<List<UserContactInfoEntity>>(dbUsers);

                    foreach (UserEntity userItem in users)
                    {
                        userItem.UserContacts = new List<UserContactInfoEntity>();

                        foreach (UserContactInfoEntity userContact in userContacts.Where(x => x.UserID == userItem.UserID))
                        {
                            userItem.UserContacts.Add(userContact);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }


            return users;
        }
    }
}