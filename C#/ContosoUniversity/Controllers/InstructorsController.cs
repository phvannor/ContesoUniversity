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
using System.Web.Http.OData;

namespace ContosoUniversity.Controllers
{
    public class InstructorsController : TableController<InstructorDTO>
    {
        private SchoolContext context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new SchoolContext();
            this.DomainManager = new InstructorMappedDomainManager(context, controllerContext.Request, false);
        }

        public SingleResult<InstructorDTO> Get(string id)
        {
            return Lookup(id);
        }

        public IQueryable<InstructorDTO> GetAllInstructors()
        {
            return Query();
        }


        // PATCH tables/Courses/4
        public Task<InstructorDTO> PatchInstructors(string id, Delta<InstructorDTO> patch)
        {
            return UpdateAsync(id, patch);
        }
    }
}