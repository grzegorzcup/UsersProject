using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostDto> GetPosts();

        PostDto GetPostById(int id);
        PostDto CreatePost(CreatePostDto NewPost);
        void UpdatePost(UpdatePostDto UpdatePost);
    }
}
