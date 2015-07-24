using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using ContosoUniversity.DAL;
using ContosoUniversity.DomainManagers;
using ContosoUniversity.Models;
using Microsoft.Azure.Mobile.Server;
using System.Threading.Tasks;
using System.Web.Http.OData;

namespace ContosoUniversity.Controllers
{
    public class DepartmentsController : TableController<DepartmentDTO>
    {
        private SchoolContext context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new SchoolContext();
            this.DomainManager = new DepartmentMappedDomainManager(context, controllerContext.Request, false);
        }

        public SingleResult<DepartmentDTO> Get(string id)
        {
            return Lookup(id);
        }

        public IQueryable<DepartmentDTO> GetAllDepartments()
        {
            return Query();
        }

        public Task<DepartmentDTO> PatchDepartments(string id, Delta<DepartmentDTO> patch)
        {
            return UpdateAsync(id, patch);
        }

        public Task DeleteDepartment(string id)
        {
            return DeleteAsync(id);
        }

        public async Task<IHttpActionResult> PostDepartment(DepartmentDTO item)
        {
            DepartmentDTO current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }
    }
}