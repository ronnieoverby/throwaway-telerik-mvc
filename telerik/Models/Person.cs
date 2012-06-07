using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataAnnotationsExtensions;
using RonnieOverby;
using telerik.Infrastructure;

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

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        private static Lazy<NameGenerator> _ngen = new Lazy<NameGenerator>(() => new NameGenerator {Commonality = .01});
        private static Lazy<Random> _random = new Lazy<Random>(() => new Random());
        public static Person Random(int id)
        {
            var person = new Person
            {
                Id = id,
                FirstName = _ngen.Value.GenerateNames(NameForms.First, false, 1).Single(),
                LastName = _ngen.Value.GenerateNames(NameForms.Last, false, 1).Single(),
                BirthDate = _random.Value.NextDateTime("1/1/1960", "12/31/1999"),
                Phone = _random.Value.NextPhone()
            };

            person.Email = string.Format("{0}{1}@{2}",
                                         person.FirstName[0],
                                         person.LastName,
                                         _random.Value.PickNext("gmail.com", "yahoo.com", "msn.com", "core-techs.net"))
                .ToLower();

            return person;
        }
    }
}