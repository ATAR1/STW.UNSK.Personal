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
            return _ctx.Personal.AsNoTracking().ToList();
        }

        public Person UpdatePerson(Person person)
        {
            _ctx.Entry(person).State = EntityState.Modified;
            _ctx.SaveChanges();
            return _ctx.Entry(person).Entity;
        }
    }
}
