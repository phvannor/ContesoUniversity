using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Azure.Mobile.Server;

namespace ContosoUniversity.Models
{
    public class InstructorDTO : EntityData
    {
        public string LastName { get; set; }

        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        public ICollection<CourseDTO> Courses { get; set; }

        // public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}