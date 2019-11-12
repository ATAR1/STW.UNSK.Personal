using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonalEditor.Repositories;

namespace PersonalEditor.Commands
{
    public class LoadPersonalCommand
    {
        private IPersonalRepository repository;

        public LoadPersonalCommand(IPersonalRepository repository)
        {
            this.repository = repository;
        }
    }
}
