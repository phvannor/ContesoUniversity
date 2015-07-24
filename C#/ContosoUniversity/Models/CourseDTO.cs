using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Azure.Mobile.Server;

namespace ContosoUniversity.Models
{
    public class CourseDTO : EntityData
    {
        public string Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        // public virtual Department Department { get; set; }
        // public virtual ICollection<Enrollment> Enrollments { get; set; }
        // public virtual ICollection<Instructor> Instructors { get; set; }
    }
}