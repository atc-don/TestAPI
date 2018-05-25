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
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public UserController(IUserManager userManager, IMapper mapper)
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
        public HttpResponseMessage GetUser(int userID)
        {
            if (userID <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Student ID");
            }

            UserEntity user = null;

            try
            {
                user = _userManager.GetUser(userID);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, "Processing Error");
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
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

        [HttpPut]
        [Route("Edit/{userID:int}")]
        public HttpResponseMessage EditUser(UserDto user)
        {
            if (user == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Student ID");
            }

            UserDto updatedUser = null;

            try
            {
                UserEntity userEntity = _mapper.Map<UserEntity>(user);

                UserEntity updatedUserEntity = _userManager.EditUser(userEntity);

                updatedUser = _mapper.Map<UserDto>(updatedUserEntity);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, "Processing Error");
            }

            return Request.CreateResponse(HttpStatusCode.OK, updatedUser);
        }
    }
}
