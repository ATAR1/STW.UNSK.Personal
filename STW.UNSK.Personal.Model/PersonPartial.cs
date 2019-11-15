using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace STW.UNSK.Personal.Model
{
    public partial class Person:ICloneable
    {
        public string FullName => $"{Surname} {Name} {Patronymic}";

        public string ShortName => $"{Surname} {Name.First()}.{Patronymic.First()}.";

        public string InitialsFirst => $"{Name.First()}.{Patronymic.First()}. {Surname}";

        public abstract PostCategory Category { get; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public virtual void Update(Person person)
        {
            if (Id != person.Id) throw new WrongPersonIdException();
            Name = person.Name;                                     
            Patronymic = person.Patronymic;                         
            Surname = person.Surname;                               
            Post_Id = person.Post_Id;                               
            Num = person.Num;                                       
            Hidden = person.Hidden;                                         
        }
    }

    [Serializable]
    public class WrongPersonIdException : Exception
    {
    }
}
