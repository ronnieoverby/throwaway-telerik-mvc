using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using telerik.Models;

namespace telerik.Infrastructure
{
    public class PeopleRepository
    {
        private static List<Person> _people;

        public PeopleRepository()
        {
            if (_people == null)
            {
                _people = CreatePeople(100).ToList();
            }
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _people;
        }

        private IEnumerable<Person> CreatePeople(int n)
        {
            var r = new Random();
            for (int i = 0; i < n; i++)
                yield return Person.Random(i);
        }

        public Person Find(int id)
        {
            return _people.Single(x => x.Id == id);
        }

        public void Add(Person person)
        {
            person.Id = _people.Max(x => x.Id) + 1;
            _people.Add(person);
        }

        public void RemoveById(int id)
        {
            _people.Remove(Find(id));
        }
    }
}