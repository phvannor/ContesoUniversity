using System;
using System.Data.Entity;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using ContosoUniversity.Models;
using Microsoft.Azure.Mobile.Server;

namespace ContosoUniversity.DomainManagers
{
    public class DepartmentMappedDomainManager : MappedEntityDomainManager<DepartmentDTO, Department>
    {
        public DepartmentMappedDomainManager(DbContext context, HttpRequestMessage request, bool enableSoftDelete)
            : base(context, request, enableSoftDelete)
        { }
        public override SingleResult<DepartmentDTO> Lookup(string id)
        {
            return this.LookupEntity(c => c.DepartmentID.ToString() == id);
        }
        public override Task<DepartmentDTO> UpdateAsync(string id, Delta<DepartmentDTO> patch)
        {
            return this.UpdateEntityAsync(patch, Convert.ToInt32(id));
        }
        public override Task<bool> DeleteAsync(string id)
        {
            return this.DeleteItemAsync(id);
        }
    }
}