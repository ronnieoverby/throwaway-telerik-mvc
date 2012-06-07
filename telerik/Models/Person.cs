using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataAnnotationsExtensions;

namespace telerik.Models
{
    public class Person
    {
        [ScaffoldColumn(true)]
        [UIHint("Integer")]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public string Phone { get; set; }
        
        [Email]
        public string Email { get; set; }

        [Display(Name="Birth Date")]
        public DateTime BirthDate { get; set; }

    }
}