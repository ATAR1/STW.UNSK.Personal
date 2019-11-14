using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STW.UNSK.Personal.Model;

namespace PersonalEditor.Repositories
{
    public interface IPostsRepository
    {
        ICollection<Post> GetAvaliablePosts(PostCategory category);
    }
}
