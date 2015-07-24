using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Server.Config;
using AutoMapper;
using ContosoUniversity.Models;
using ContosoUniversity.Utilities;

namespace ContosoUniversity.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            /*
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            */

            // Web API routes
            config.MapHttpAttributeRoutes();            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            Mapper.Initialize(c =>
            {
                c.CreateMap<Student, StudentDTO>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(db => MySqlFunctions.LTRIM(MySqlFunctions.StringConvert(db.ID))));
                c.CreateMap<StudentDTO, Student>()
                    .ForMember(db => db.ID, map => map.MapFrom(dto => MySqlFunctions.LongParse(dto.Id)));

                c.CreateMap<Course, CourseDTO>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(db => MySqlFunctions.LTRIM(MySqlFunctions.StringConvert(db.CourseID))));
                c.CreateMap<CourseDTO, Course>()
                    .ForMember(db => db.CourseID, map => map.MapFrom(dto => MySqlFunctions.LongParse(dto.Id)));

                c.CreateMap<Department, DepartmentDTO>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(db => MySqlFunctions.LTRIM(MySqlFunctions.StringConvert(db.DepartmentID))));
                c.CreateMap<DepartmentDTO, Department>()
                    .ForMember(db => db.DepartmentID, map => map.MapFrom(dto => MySqlFunctions.LongParse(dto.Id)));


                c.CreateMap<Instructor, InstructorDTO>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(db => MySqlFunctions.LTRIM(MySqlFunctions.StringConvert(db.ID))));
                c.CreateMap<InstructorDTO, Instructor>()
                    .ForMember(db => db.ID, map => map.MapFrom(dto => MySqlFunctions.LongParse(dto.Id)));

            });

            new MobileAppConfiguration()
                //.UseDefaultConfiguration()
                .AddTablesWithEntityFramework()
                //.UseDefaultConfiguration()
                //.AddAppServiceAuthentication()
                //.MapApiControllers()
                .ApplyTo(config);                       
        }
    }
}
