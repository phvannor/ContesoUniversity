using System.Data.Entity;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using ContosoUniversity.Models;
using Microsoft.Azure.Mobile.Server;

namespace ContosoUniversity.DomainManagers
{
    public class InstructorMappedDomainManager : MappedEntityDomainManager<InstructorDTO, Instructor>
    {
        public InstructorMappedDomainManager(DbContext context, HttpRequestMessage request, bool enableSoftDelete)
            : base(context, request, enableSoftDelete)
        { }
        public override SingleResult<InstructorDTO> Lookup(string id)
        {
            return this.LookupEntity(c => c.ID.ToString() == id);
        }
        public override Task<InstructorDTO> UpdateAsync(string id, Delta<InstructorDTO> patch)
        {
            return this.UpdateEntityAsync(patch, id);
        }
        public override Task<bool> DeleteAsync(string id)
        {
            return this.DeleteItemAsync(id);
        }
    }
}