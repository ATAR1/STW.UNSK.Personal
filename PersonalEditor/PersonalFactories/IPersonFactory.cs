using STW.UNSK.Personal.Model;

namespace PersonalEditor.PersonalFactories
{
    public interface IPersonFactory
    {
        bool CreateInstanceResult(out Person engineer);
    }
}