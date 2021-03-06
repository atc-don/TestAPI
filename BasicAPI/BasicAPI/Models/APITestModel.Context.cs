﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace BasicAPI.Models
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class APITestEntities : DbContext
{
    public APITestEntities()
        : base("name=APITestEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }



    internal virtual ObjectResult<DBStudent> GetStudentByID(Nullable<int> studentID)
    {

        var studentIDParameter = studentID.HasValue ?
            new ObjectParameter("StudentID", studentID) :
            new ObjectParameter("StudentID", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DBStudent>("GetStudentByID", studentIDParameter);
    }


    internal virtual int AddStudent(string studentFirstName, string studentLastName, string studentContactsXML)
    {

        var studentFirstNameParameter = studentFirstName != null ?
            new ObjectParameter("StudentFirstName", studentFirstName) :
            new ObjectParameter("StudentFirstName", typeof(string));


        var studentLastNameParameter = studentLastName != null ?
            new ObjectParameter("StudentLastName", studentLastName) :
            new ObjectParameter("StudentLastName", typeof(string));


        var studentContactsXMLParameter = studentContactsXML != null ?
            new ObjectParameter("StudentContactsXML", studentContactsXML) :
            new ObjectParameter("StudentContactsXML", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddStudent", studentFirstNameParameter, studentLastNameParameter, studentContactsXMLParameter);
    }


    internal virtual ObjectResult<DBUser> GetUserByID(Nullable<int> userID)
    {

        var userIDParameter = userID.HasValue ?
            new ObjectParameter("UserID", userID) :
            new ObjectParameter("UserID", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DBUser>("GetUserByID", userIDParameter);
    }


    internal virtual ObjectResult<DBUser> GetUsersByStudentID(Nullable<int> studentID)
    {

        var studentIDParameter = studentID.HasValue ?
            new ObjectParameter("StudentID", studentID) :
            new ObjectParameter("StudentID", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DBUser>("GetUsersByStudentID", studentIDParameter);
    }


    internal virtual int AddUser(Nullable<int> studentID, string userFirstName, string userLastName, string userContactsXML)
    {

        var studentIDParameter = studentID.HasValue ?
            new ObjectParameter("StudentID", studentID) :
            new ObjectParameter("StudentID", typeof(int));


        var userFirstNameParameter = userFirstName != null ?
            new ObjectParameter("UserFirstName", userFirstName) :
            new ObjectParameter("UserFirstName", typeof(string));


        var userLastNameParameter = userLastName != null ?
            new ObjectParameter("UserLastName", userLastName) :
            new ObjectParameter("UserLastName", typeof(string));


        var userContactsXMLParameter = userContactsXML != null ?
            new ObjectParameter("UserContactsXML", userContactsXML) :
            new ObjectParameter("UserContactsXML", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddUser", studentIDParameter, userFirstNameParameter, userLastNameParameter, userContactsXMLParameter);
    }

}

}

