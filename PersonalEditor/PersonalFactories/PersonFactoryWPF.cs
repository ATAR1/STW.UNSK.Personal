using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STW.UNSK.Personal.Model;
using PersonalEditor.Repositories;
using PersonalEditor.Dialogs;

namespace PersonalEditor.PersonalFactories
{
    public class PersonFactoryWPF : IPersonFactory
    {
        
        IAddPersonDialogFactory _addPersonDialogFactory;

        public PersonFactoryWPF(IAddPersonDialogFactory addPersonDialogFactory)
        {
            _addPersonDialogFactory = addPersonDialogFactory;
        }

        public bool CreateInstanceResult(out Person engineer)
        {            
            IAddPersonDialog addPersonDialog = _addPersonDialogFactory.GetInstance();
            if (addPersonDialog.ShowDialog() == true)
            {
                engineer = (Person)addPersonDialog.Person;
                return true;                
            }
            engineer = null;
            return false;
        }
    }

    
}
