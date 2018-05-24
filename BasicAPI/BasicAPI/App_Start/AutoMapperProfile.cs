using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BasicAPI.DTOs;
using BasicAPI.Entities;
using BasicAPI.Models;

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
            CreateMap<DBUser, UserEntity>()
                .ForMember(dest=>dest.UserContacts, opt=>opt.Ignore());

            CreateMap<UserDto, UserEntity>().ReverseMap();            
            CreateMap<DBUser, UserContactInfoEntity>();
            CreateMap<UserContactInfoDto, UserContactInfoEntity>().ReverseMap();

            CreateMap<DBStudent, StudentEntity>()
                .ForMember(dest => dest.StudentContacts, opt => opt.Ignore())
                .ForMember(dest => dest.StudentUsers, opt => opt.Ignore());

            CreateMap<StudentDto, StudentEntity>().ReverseMap();
            CreateMap<DBStudent, StudentContactInfoEntity>();
            CreateMap<StudentContactInfoDto, StudentContactInfoEntity>().ReverseMap();
        }
    }
}