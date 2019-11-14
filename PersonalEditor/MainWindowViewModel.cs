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
            Personal = new LocalPersonalCollection();
            var personalEFRepository = new PersonalEFRepository(_ctx);
            LoadPersonalCommand = new LoadPersonalCommand(personalEFRepository, Personal);
            var postsEFRepository = new PostsEFRepository(_ctx);
            AddEngineerCommand = new AddPersonCommand(new PersonFactoryWPF(new AddEngineerDialogFactory(postsEFRepository)), personalEFRepository, Personal);
            AddWorkerCommand = new AddPersonCommand(new PersonFactoryWPF(new AddWorkerDialogFactory(postsEFRepository)), personalEFRepository, Personal);
            EditPersonCommand = new EditPersonCommand(_ctx,listRefresh);
            LoadPersonalCommand.Execute();
        }
        
        public LoadPersonalCommand LoadPersonalCommand { get; private set; }
        public AddPersonCommand AddEngineerCommand { get; private set; }
        public AddPersonCommand AddWorkerCommand { get; private set; }
        public EditPersonCommand EditPersonCommand { get; private set; }

        public LocalPersonalCollection Personal { get; set; }


        public Person SelectedPerson { get; set; }       

        //public void LoadPersonal()
        //{
        //    try
        //    {

        //        foreach (var person in _ctx.Personal.ToList())
        //        {
        //            Personal.Add(person);
        //        }
        //        var posts = _ctx.State.ToList();                
        //    }
        //    catch(Exception e)
        //    {
        //        throw new PersonalLoadingException("Ошибка загрузки списка персонала",e);
        //    }
        //}
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