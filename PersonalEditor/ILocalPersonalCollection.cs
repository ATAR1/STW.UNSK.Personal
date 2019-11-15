using STW.UNSK.Personal.Model;

namespace PersonalEditor.Commands
{
    public interface ILocalPersonalCollection
    {
        void Add(Person engineer);
        void Save(Person reloadedPerson);
    }
}