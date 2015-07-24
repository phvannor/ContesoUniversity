
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using ContosoUniversity.DAL;
using ContosoUniversity.DomainManagers;
using ContosoUniversity.Models;
using Microsoft.Azure.Mobile.Server;

namespace ContosoUniversity.Controllers
{
    public class CoursesController : TableController<CourseDTO>
    {
        private SchoolContext context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new SchoolContext();
            this.DomainManager = new CourseMappedDomainManager(context, controllerContext.Request, false);
        }

        public SingleResult<CourseDTO> Get(string id)
        {
            return Lookup(id);
        }

        public IQueryable<CourseDTO> GetAllStudents()
        {
            return Query();
        }
    }
}