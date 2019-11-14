using PersonalEditor.Repositories;
using STW.UNSK.Personal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalEditor.Dialogs
{
    public class AddEngineerDialogFactory : IAddPersonDialogFactory
    {
        IPostsRepository _postsRepository;

        public AddEngineerDialogFactory(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public IAddPersonDialog GetInstance()
        {
            ICollection<Post> avaliablePosts = _postsRepository.GetAvaliablePosts(PostCategory.Engineer);
            return new AddPersonDialog(new Engineer(), avaliablePosts);
        }
    }
}
