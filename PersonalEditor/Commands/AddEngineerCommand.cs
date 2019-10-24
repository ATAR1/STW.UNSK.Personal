using PersonalEditor.Dialogs;
using STW.UNSK.Personal.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PersonalEditor.Commands
{
    public class AddEngineerCommand : ICommand
    {
        private DbModelContainer _ctx;
        private ObservableCollection<Person> _personal;

        public AddEngineerCommand(DbModelContainer _ctx, ObservableCollection<Person> personal)
        {
            this._ctx = _ctx;
            this._personal = personal;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            List<Post> avaliablePosts = GetAvaliablePosts();
            AddPersonDialog addWorkerDialog = new AddPersonDialog(new Engineer(), avaliablePosts);
            if (addWorkerDialog.ShowDialog() == true)
            {
                var addedWorker = _ctx.Personal.Add(addWorkerDialog.Person);
                _ctx.SaveChanges();
                _personal.Add(addedWorker);
            }
        }

        private List<Post> GetAvaliablePosts()
        {
            return _ctx.State.Where(p => p.CategoryId == (int)PostCategory.Engineer).ToList();
        }
    }
}
