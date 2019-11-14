using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STW.UNSK.Personal.Model;

namespace PersonalEditor.Dialogs
{
    public interface IAddPersonDialog
    {
        Person Person { get;}

        bool? ShowDialog();
    }
}
