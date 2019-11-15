using System.Collections.ObjectModel;
using STW.UNSK.Personal.Model;
using PersonalEditor.Commands;
using System;
using System.Linq;

namespace PersonalEditor
{
    public class LocalPersonalCollection : ObservableCollection<Person>, ILocalPersonalCollection
    {
        public void Save(Person reloadedPerson)
        {
            OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
        }
    }
}