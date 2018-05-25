using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BasicAPI.Entities;
using BasicAPI.Repositories.Interfaces;

using AutoMapper;

using BasicAPI.Models;
using System.Xml.Serialization;
using System.IO;

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

            try
            {
                using (APITestEntities db = new APITestEntities())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<UserContacts>");

                    foreach (UserContactInfoEntity userContact in user.UserContacts)
                    {
                        sb.Append("<UserContact>");

                        sb.Append("<UserPhone>" + userContact.UserPhone + "</UserPhone>");
                        sb.Append("<UserEmail>" + userContact.UserEmail + "</UserEmail>");

                        sb.Append("</UserContact>");
                    }

                    sb.Append("</UserContacts>");

                    string xmlUserContacts = sb.ToString();

                    db.AddUser(user.StudentID, user.UserFirstName, user.UserLastName, xmlUserContacts);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
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

            throw new NotImplementedException();
        }

        public UserEntity GetUser(int userID)
        {
            if (userID <= 0)
            {
                throw new ArgumentOutOfRangeException("userID", userID, "Invalid UserID");
            }

            UserEntity user = null;

            try
            {
                using (APITestEntities db = new APITestEntities())
                {
                    List<DBUser> dbUsers = db.GetUserByID(userID).ToList();

                    List<UserEntity> users = _mapper.Map<List<UserEntity>>(dbUsers);

                    user = users.FirstOrDefault();

                    if (user != null)
                    {
                        user.UserContacts = new List<UserContactInfoEntity>();

                        List<UserContactInfoEntity> userContacts = _mapper.Map<List<UserContactInfoEntity>>(dbUsers);

                        foreach (UserContactInfoEntity userContact in userContacts.Where(x => x.UserID == user.UserID))
                        {
                            user.UserContacts.Add(userContact);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return user;
        }
    }
}