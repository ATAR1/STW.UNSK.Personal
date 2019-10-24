using PersonalEditor.Dialogs;
using STW.UNSK.Personal.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;

namespace PersonalEditor.Commands
{
    public class EditPersonCommand : ICommand
    {
        private Action _refresh;
        private DbModelContainer _ctx;
        
        public EditPersonCommand(DbModelContainer ctx, Action refresh)
        {
            this._ctx = ctx;
            this._refresh = refresh;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            List<Post> avaliablePosts = GetAvaliablePosts();
            Person person = (Person)parameter;
            EditPersonDialog dialog = new EditPersonDialog(person, avaliablePosts);
            if (dialog.ShowDialog()==true)
            {
                _ctx.SaveChanges();                
            }
            else
            {
                _ctx.Entry(person).State = EntityState.Unchanged;
            }
            _refresh();
        }

        private List<Post> GetAvaliablePosts()
        {
            return _ctx.State.ToList();
        }
    }
}