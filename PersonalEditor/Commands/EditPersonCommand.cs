using PersonalEditor.Dialogs;
using STW.UNSK.Personal.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using PersonalEditor.Repositories;

namespace PersonalEditor.Commands
{
    public class EditPersonCommand : ICommand
    {
        private IPersonalRepository _personalRepository;
        private ILocalPersonalCollection _personalLocalCollection;
        private IPostsRepository _postsEFRepository;

       

        public EditPersonCommand(IPersonalRepository personalRepository, ILocalPersonalCollection personalLocalCollection, IPostsRepository postsEFRepository)
        {
            _personalRepository = personalRepository;
            _personalLocalCollection = personalLocalCollection;
            _postsEFRepository = postsEFRepository;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Person person = (Person)parameter;
            var personForEdit = (Person)person.Clone();
            ICollection<Post> avaliablePosts = _postsEFRepository.GetAvaliablePosts(personForEdit.Category);            
            IEditPersonDialog dialog = new EditPersonDialog(personForEdit, avaliablePosts);
            if(dialog.ShowDialog() == true)
            {
                var reloadedPerson = _personalRepository.Save(dialog.Person);
                _personalLocalCollection.Save(reloadedPerson); 
            }
           
        }

    }
}