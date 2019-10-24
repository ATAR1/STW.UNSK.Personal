using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STW.UNSK.Personal.Model
{
    public partial class Person
    {
        public string FullName => $"{Surname} {Name} {Patronymic}";

        public string ShortName => $"{Surname} {Name.First()}.{Patronymic.First()}.";

        public string InitialsFirst => $"{Name.First()}.{Patronymic.First()}. {Surname}";

        public List<Post> AvaliablePost { get; set; }
    }
}
