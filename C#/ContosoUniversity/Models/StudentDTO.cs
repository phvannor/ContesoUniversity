using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace ContosoUniversity.Models
{
    public class StudentDTO : EntityData
    {
        public string Id { get; set; }

        public string LastName { get; set; }

        public string FirstMidName { get; set; }


        public DateTime EnrollmentDate { get; set; }
    }
}