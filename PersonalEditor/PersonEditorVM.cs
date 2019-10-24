using System.Collections.Generic;
using STW.UNSK.Personal.Model;

namespace PersonalEditor
{
    public class PersonEditorVM
    {
        public PersonEditorVM(Person person, ICollection<Post> avaliablePosts)
        {
            Person = person;
            AvaliablePosts = avaliablePosts;
        }

        public Person Person { get; private set; }

        public int Num
        {
            get { return Person.Num; }
            set { Person.Num = value; }
        }

        public string Name
        {
            get { return Person.Name; }
            set { Person.Name = value; }
        }

        public string Surname
        {
            get { return Person.Surname; }
            set { Person.Surname = value; }
        }

        public string Patronymic
        {
            get { return Person.Patronymic; }
            set { Person.Patronymic = value; }
        }

        public int PostId
        {
            get { return Person.Post_Id; }
            set { Person.Post_Id = value; }
        }

        public bool Hidden
        {
            get { return Person.Hidden; }
            set { Person.Hidden = value; }
        }

        public ICollection<Post> AvaliablePosts { get; private set; }
    }
}