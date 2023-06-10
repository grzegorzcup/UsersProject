using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private static ISet<Post> _posts = new HashSet<Post>()
        {
            new Post (1,"tytuł 1","treść 1"),
            new Post(2, "tytuł 2", "treść 2"),
            new Post(3, "tytuł 3", "treść 3"),
        };
        public IEnumerable<Post> GetAllPosts()
        {
            return _posts;
        }

        public Post Add(Post post)
        {
            post.Id = _posts.Count() + 1;
            post.Created = DateTime.Now;
            _posts.Add(post);
            return post;
        }

        public void Delete(Post post)
        {
            _posts.Remove(post);
        }

        public Post GetById(int id)
        {
            return _posts.SingleOrDefault(p => p.Id == id);
        }

        public Post Update(Post post)
        {
            post.LastModified = DateTime.Now;
            return post;
        }
    }
}
