using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AutoMapper;

using BasicAPI.DTOs;
using BasicAPI.Entities;
using BasicAPI.Managers.Interfaces;

namespace BasicAPI.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public UsersController(IUserManager userManager, IMapper mapper)
        {
            if (userManager == null)
            {
                throw new ArgumentNullException("userManager");
            }

            if (mapper == null)
            {
                throw new ArgumentNullException("mapper");
            }

            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{userID:int}")]
        public HttpResponseMessage GetUsers(int userID)
        {
            if (userID <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Student ID");
            }

            List<UserEntity> users = null;

            try
            {
                users = _userManager.GetUsers(userID);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, "Processing Error");
            }

            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage AddUser(UserDto user)
        {
            if (user == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Student ID");
            }

            try
            {
                UserEntity userEntity = _mapper.Map<UserEntity>(user);

                _userManager.AddUser(userEntity);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, "Processing Error");
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
