using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using ContosoUniversity.DAL;
using ContosoUniversity.DomainManagers;
using ContosoUniversity.Models;
using Microsoft.Azure.Mobile.Server;
using System.Web.Http.OData;
using System.Threading.Tasks;

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

        public IQueryable<CourseDTO> GetAllCourses()
        {
            return Query();
        }

        public Task<CourseDTO> PatchCourses(string id, Delta<CourseDTO> patch)
        {            
            return UpdateAsync(id, patch);            
        }


        public Task DeleteCourse(string id)
        {
            return DeleteAsync(id);
        }
    }
}