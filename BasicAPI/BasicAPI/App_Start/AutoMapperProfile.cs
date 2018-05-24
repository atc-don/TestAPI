using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BasicAPI.DTOs;
using BasicAPI.Entities;

namespace BasicAPI.App_Start
{
    /// <summary>
    /// Sets up automapper registrations
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Registers the configuration as of AutoMapper version 5. Prior versions used an overridden Configure() method
        /// </summary>
        public AutoMapperProfile()
        {
            //CreateMap<DBUser, UserEntity>();
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserContactInfoDto, UserContactInfoEntity>().ReverseMap();

            //CreateMap<DBStudent, StudentEntity>();
            CreateMap<StudentDto, StudentEntity>().ReverseMap();            
            CreateMap<StudentContactInfoDto, StudentContactInfoEntity>().ReverseMap();
        }
    }
}