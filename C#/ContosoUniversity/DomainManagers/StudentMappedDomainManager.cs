using System.Data.Entity;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using ContosoUniversity.Models;
using Microsoft.Azure.Mobile.Server;
using System;

namespace ContosoUniversity.DomainManagers
{
    public class StudentMappedDomainManager : MappedEntityDomainManager<StudentDTO, Student>
    {
        public StudentMappedDomainManager(DbContext context, HttpRequestMessage request, bool enableSoftDelete)
            : base(context, request,enableSoftDelete)
        { }
        public override SingleResult<StudentDTO> Lookup(string id)
        {
            return this.LookupEntity(p => p.ID.ToString() == id);
        }
        public override Task<StudentDTO> UpdateAsync(string id, Delta<StudentDTO> patch)
        {
            return this.UpdateEntityAsync(patch, Convert.ToInt32(id));
        }
        public override Task<bool> DeleteAsync(string id)
        {
            return this.DeleteItemAsync(Convert.ToInt32(id));
        }
    }
}