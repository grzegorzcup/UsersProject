using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public PostDto GetPostById(int id)
        {
            var post = _postRepository.GetById(id);
            return _mapper.Map<PostDto>(post);
        }

        public IEnumerable<PostDto> GetPosts()
        {
            var posts = _postRepository.GetAllPosts();
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public PostDto CreatePost(CreatePostDto NewPost)
        {
            if (string.IsNullOrEmpty(NewPost.Title))
            {
                throw new Exception("Post musi zawierać tytuł");
            }

            var post = _mapper.Map<Post>(NewPost);
            _postRepository.Add(post);
            return _mapper.Map<PostDto>(post);
        }

        public void UpdatePost(UpdatePostDto updatePost)
        {
            var existingPost = _postRepository.GetById(updatePost.Id);

            if (existingPost == null)
            {
                throw new Exception("Nie ma takeigo postu");
            }
            _mapper.Map(updatePost, existingPost);

            _postRepository.Update(existingPost);
        }

    }
}
