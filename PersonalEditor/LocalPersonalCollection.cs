using System.Collections.ObjectModel;
using STW.UNSK.Personal.Model;
using PersonalEditor.Commands;
using System;

namespace PersonalEditor
{
    public class LocalPersonalCollection : ObservableCollection<Person>, ILocalPersonalCollection
    {
        public void Add(Person engineer)
        {
            base.Add(engineer);
        }
    }
}