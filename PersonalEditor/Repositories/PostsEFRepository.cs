using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STW.UNSK.Personal.Model;

namespace PersonalEditor.Repositories
{
    public class PostsEFRepository : IPostsRepository
    {
        DbModelContainer _ctx;

        public PostsEFRepository(DbModelContainer ctx)
        {
            _ctx = ctx;
        }

        public ICollection<Post> GetAvaliablePosts(PostCategory category)
        {
            return _ctx.State.Where(p => p.CategoryId == (int)category).ToList();
        }
    }
}
