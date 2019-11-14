using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonalEditor.Repositories;
using STW.UNSK.Personal.Model;

namespace PersonalEditor.Dialogs
{
    public class AddWorkerDialogFactory:IAddPersonDialogFactory
    {
        private IPostsRepository _postsRepository;

        public AddWorkerDialogFactory(IPostsRepository postsEFRepository)
        {
            this._postsRepository = postsEFRepository;
        }

        public IAddPersonDialog GetInstance()
        {
            ICollection<Post> avaliablePosts = _postsRepository.GetAvaliablePosts(PostCategory.Worker);
            return new AddPersonDialog(new Worker(), avaliablePosts);
        }
    }
}
