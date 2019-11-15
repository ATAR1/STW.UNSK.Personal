using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STW.UNSK.Personal.Model;
using System.Data.Entity;

namespace PersonalEditor.Repositories
{
    public class PersonalEFRepository : IPersonalRepository
    {
        DbModelContainer _ctx;

        public PersonalEFRepository(DbModelContainer ctx)
        {
            _ctx = ctx;
        }

        public Person AddPerson(Person newPerson)
        {
            var addedPerson =_ctx.Personal.Add(newPerson);
            _ctx.SaveChanges();
            return addedPerson;
        }

        public ICollection<Person> GetPersonal()
        {
            _ctx.State.Load();
            return _ctx.Personal.ToList();
        }

        public Person Save(Person person)
        {
            var person1 = _ctx.Personal.Single(p => p.Id == person.Id);
            person1.Update(person);
            _ctx.SaveChanges();
            return person1;
        }
    }
}
