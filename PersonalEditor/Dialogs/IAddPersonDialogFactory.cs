using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalEditor.Dialogs
{
    public interface IAddPersonDialogFactory
    {
        IAddPersonDialog GetInstance();
    }
}
