using PersonalEditor.Commands;
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
        private Action listRefresh;
        private DbModelContainer _ctx;

        public MainWindowViewModel(Action listRefresh)
        {
            _ctx = new DbModelContainer();
            Personal = new ObservableCollection<Person>();
            AddEngineerCommand = new AddEngineerCommand(_ctx, Personal);
            AddWorkerCommand = new AddWorkerCommand(_ctx, Personal);
            EditPersonCommand = new EditPersonCommand(_ctx,listRefresh);
            this.listRefresh = listRefresh;          
        }
        

        public AddEngineerCommand AddEngineerCommand { get; private set; }
        public AddWorkerCommand AddWorkerCommand { get; private set; }
        public EditPersonCommand EditPersonCommand { get; private set; }

        public ObservableCollection<Person> Personal { get; set; }


        public Person SelectedPerson { get; set; }       

        public void LoadPersonal()
        {
            try
            {

                foreach (var person in _ctx.Personal.ToList())
                {
                    Personal.Add(person);
                }
                var posts = _ctx.State.ToList();
                foreach (var person in Personal)
                {
                    person.AvaliablePost = posts.ToList();
                }
            }
            catch(Exception e)
            {
                throw new PersonalLoadingException("Ошибка загрузки списка персонала",e);
            }
        }
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