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
    public class StudentsController : TableController<StudentDTO>
    {
        private SchoolContext context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new SchoolContext();
            this.DomainManager = new StudentMappedDomainManager(context, controllerContext.Request, false);
        }

        public SingleResult<StudentDTO> Get(string id)
        {
            return Lookup(id);
        }

        public IQueryable<StudentDTO> GetAllStudents()
        {
            return Query();
        }

        // PATCH tables/Courses/4
        public Task<StudentDTO> PatchStudents(string id, Delta<StudentDTO> patch)
        {
            return UpdateAsync(id, patch);
        }

        public Task DeleteStudent(string id)
        {
            return DeleteAsync(id);
        }

        public async Task<IHttpActionResult> PostStudents(StudentDTO item)
        {
            StudentDTO current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }
        /*
        // GET: api/Students
        [HttpGet, Route("api/students")]
        public IQueryable<StudentDTO> GetPeople()
        {
            var people = from p in db.People
                         select new StudentDTO()
                        {
                            Id = p.ID,
                            LastName = p.LastName
                        };

            return people;
        }

        // GET: api/Students/5
        [ResponseType(typeof(StudentDTO))]
        public async Task<IHttpActionResult> GetStudent(int id)
        {
            StudentDTO student = await db.People.Select(p =>
               new StudentDTO() {
                   Id = p.ID,
                   LastName = p.LastName
               }).SingleOrDefaultAsync(p => p.Id == id);

            // db.People.FindAsync(id).
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.ID)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(student);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = student.ID }, student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            Student student = await db.People.FindAsync(id) as Student;
            if (student == null)
            {
                return NotFound();
            }

            db.People.Remove(student);
            await db.SaveChangesAsync();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.People.Count(e => e.ID == id) > 0;
        }
         * */
    }
}