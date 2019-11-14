using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonalEditor.Repositories;

namespace PersonalEditor.Commands
{
    public class LoadPersonalCommand
    {
        private ILocalPersonalCollection _personalCollection;
        private IPersonalRepository _repository;

        public LoadPersonalCommand(IPersonalRepository repository, ILocalPersonalCollection personalCollection)
        {
            this._repository = repository;
            _personalCollection = personalCollection;
        }

        public void Execute()
        {
            foreach(var person in _repository.GetPersonal())
            {
                _personalCollection.Add(person);
            }

        }
    }
}
