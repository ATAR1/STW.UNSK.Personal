using STW.UNSK.Personal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalEditor.Dialogs
{
    public interface IEditPersonDialog
    {
        Person Person { get; }

        bool? ShowDialog();
    }
}
