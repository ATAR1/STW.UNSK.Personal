using STW.UNSK.Personal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalEditor.Repositories
{
    public interface IPersonalRepository
    {
        ICollection<Person> GetPersonal();
        Person AddPerson(Person newPerson);
        Person Save(Person person);
    }
}
