using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcApplication6.Models
{
    public class Student
    {
        public string Id { get; set; }
        [Required]
        //[StringLength(10, ErrorMessage = "Your String is too long!")]
        [DisplayName("Student No.")]
        public string StudentNumber { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Course")]
        public string Course { get; set; }
    }
}