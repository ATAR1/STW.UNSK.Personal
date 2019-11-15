using PersonalEditor.Dialogs;
using PersonalEditor.PersonalFactories;
using PersonalEditor.Repositories;
using STW.UNSK.Personal.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PersonalEditor.Commands
{
    public class AddPersonCommand : ICommand
    {
        IPersonFactory _personFactory;
        IPersonalRepository _personalRepository;
        ILocalPersonalCollection _localPersonalCollection;
        public AddPersonCommand(IPersonFactory personFactory, IPersonalRepository repository, ILocalPersonalCollection localPersonalCollection)
        {
            _personFactory = personFactory;
            _personalRepository = repository;
            _localPersonalCollection = localPersonalCollection;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Person person;
            if(_personFactory.CreateInstanceResult(out person))
            {
                var reloadedPerson = _personalRepository.AddPerson(person);
                _localPersonalCollection.Add(reloadedPerson);
            }

            
        }
    }
}
