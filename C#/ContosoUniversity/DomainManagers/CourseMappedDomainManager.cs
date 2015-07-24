using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using ContosoUniversity.Models;
using Microsoft.Azure.Mobile.Server;

namespace ContosoUniversity.DomainManagers
{
    public class CourseMappedDomainManager : MappedEntityDomainManager<CourseDTO, Course>
    {
        public CourseMappedDomainManager(DbContext context, HttpRequestMessage request, bool enableSoftDelete)
            : base(context, request, enableSoftDelete)
        { }
        public override SingleResult<CourseDTO> Lookup(string id)
        {
            return this.LookupEntity(c => c.CourseID.ToString() == id);
        }
        public override Task<CourseDTO> UpdateAsync(string id, Delta<CourseDTO> patch)
        {
            return this.UpdateEntityAsync(patch, id);
        }
        public override Task<bool> DeleteAsync(string id)
        {
            return this.DeleteItemAsync(id);
        }
    }
}