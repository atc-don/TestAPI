using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AutoMapper;

using BasicAPI.Managers.Interfaces;
using BasicAPI.DTOs;
using BasicAPI.Entities;

namespace BasicAPI.Controllers
{
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        private readonly IStudentManager _studentManager;
        private readonly IMapper _mapper;

        public StudentController(IStudentManager studentManager, IMapper mapper)
        {
            if (studentManager == null)
            {
                throw new ArgumentNullException("studentManager");
            }

            if (mapper == null)
            {
                throw new ArgumentNullException("mapper");
            }

            _studentManager = studentManager;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{studentID:int}")]
        public HttpResponseMessage GetStudents(int studentID)
        {
            if (studentID <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Student ID");
            }

            StudentDto student = null;

            try
            {
                StudentEntity studentEntity = _studentManager.GetStudents(studentID);

                student = _mapper.Map<StudentDto>(studentEntity);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, "Processing Error");
            }

            return Request.CreateResponse(HttpStatusCode.OK, student);
        }

        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage AddStudent(StudentDto student)
        {
            if (student == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Student ID");
            }

            try
            {
                StudentEntity studentEntity = _mapper.Map<StudentEntity>(student);

                _studentManager.AddStudent(studentEntity);                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, "Processing Error");
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("Edit/{studentID:int}")]
        public HttpResponseMessage EditStudent(StudentDto student)
        {
            if (student == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Student ID");
            }

            StudentDto updatedStudent = null;

            try
            {
                StudentEntity studentEntity = _mapper.Map<StudentEntity>(student);

                StudentEntity updatedStudentEntity = _studentManager.EditStudent(studentEntity);

                updatedStudent = _mapper.Map<StudentDto>(updatedStudentEntity);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, "Processing Error");
            }

            return Request.CreateResponse(HttpStatusCode.OK, updatedStudent);
        }
    }
}
