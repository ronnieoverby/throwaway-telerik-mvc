using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DataAnnotationsExtensions;
using RonnieOverby;
using telerik.Infrastructure;

namespace telerik.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Phone { get; set; }

        [Email]
        public string Email { get; set; }

        [Display(Name = "Birth Date"),UIHint("Date")]
        public DateTime? BirthDate { get; set; }

        private static readonly Lazy<NameGenerator> Ngen = new Lazy<NameGenerator>(() => new NameGenerator { Commonality = .1 });
        private static readonly Lazy<Random> _random = new Lazy<Random>(() => new Random());
        public static Person Random(int id)
        {
            var ngen = Ngen.Value;
            var r = _random.Value;

            var person = new Person
            {
                Id = id,
                FirstName = ngen.GenerateNames(NameForms.First, false, 1).Single(),
                LastName = ngen.GenerateNames(NameForms.Last, false, 1).Single(),
                BirthDate = r.NextDateTime("1/1/1960", "12/31/1999"),
                Phone = r.NextPhone()
            };

            person.Email = string.Format("{0}{1}@{2}",
                                         person.FirstName[0],
                                         person.LastName,
                                         r.PickNext("gmail.com", "yahoo.com", "msn.com", "core-techs.net", "aol.com", "hotmail.com"))
                .ToLower();

            return person;
        }
    }
}