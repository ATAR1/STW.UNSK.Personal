using PersonalEditor.Commands;
using PersonalEditor.Dialogs;
using PersonalEditor.PersonalFactories;
using PersonalEditor.Repositories;
using STW.UNSK.Personal.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace PersonalEditor
{
    public class MainWindowViewModel
    {
        private DbModelContainer _ctx;

        public MainWindowViewModel(Action listRefresh)
        {
            _ctx = new DbModelContainer();
            var personalEFRepository = new PersonalEFRepository(_ctx);
            var postsEFRepository = new PostsEFRepository(_ctx);
            Personal = new LocalPersonalCollection();            
            LoadPersonalCommand = new LoadPersonalCommand(personalEFRepository, Personal);            
            AddEngineerCommand = new AddPersonCommand(new PersonFactoryWPF(new AddEngineerDialogFactory(postsEFRepository)), personalEFRepository, Personal);
            AddWorkerCommand = new AddPersonCommand(new PersonFactoryWPF(new AddWorkerDialogFactory(postsEFRepository)), personalEFRepository, Personal);
            EditPersonCommand = new EditPersonCommand(personalEFRepository,Personal,postsEFRepository);
            LoadPersonalCommand.Execute();
        }
        
        public LoadPersonalCommand LoadPersonalCommand { get; private set; }
        public AddPersonCommand AddEngineerCommand { get; private set; }
        public AddPersonCommand AddWorkerCommand { get; private set; }
        public EditPersonCommand EditPersonCommand { get; private set; }

        public LocalPersonalCollection Personal { get; set; }


        public Person SelectedPerson { get; set; }       
        
    }

    [Serializable]
    internal class PersonalLoadingException : Exception
    {
        private Exception e;

        public PersonalLoadingException()
        {
        }

        public PersonalLoadingException(string message) : base(message)
        {
        }
        
        public PersonalLoadingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PersonalLoadingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}