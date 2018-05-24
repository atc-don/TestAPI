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

            List<UserEntity> users = null;

            try
            {
                users = _userManager.GetUser(userID);
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

            List<UserDto> users = null;

            try
            {
                UserEntity userEntity = _mapper.Map<UserEntity>(user);

                List<UserEntity> userEntities = _userManager.AddUser(userEntity);

                users = _mapper.Map<List<UserDto>>(userEntities);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, "Processing Error");
            }

            return Request.CreateResponse(HttpStatusCode.OK, users);
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
