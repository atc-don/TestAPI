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

            List<StudentEntity> students = null;

            try
            {
                students = _studentManager.GetStudents(studentID);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, "Processing Error");
            }

            return Request.CreateResponse(HttpStatusCode.OK, students);
        }

        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage AddStudent(StudentDto student)
        {
            if (student == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Student ID");
            }

            List<StudentDto> students = null;

            try
            {
                StudentEntity studentEntity = _mapper.Map<StudentEntity>(student);

                List<StudentEntity> studentEntities = _studentManager.AddStudent(studentEntity);

                students = _mapper.Map<List<StudentDto>>(studentEntities);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, "Processing Error");
            }

            return Request.CreateResponse(HttpStatusCode.OK, students);
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
