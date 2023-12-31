﻿using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [SwaggerOperation(Summary ="Zwraca wszystkie posty")]
        [HttpGet]
        public IActionResult Get()
        {
            var posts = _postService.GetPosts();
            return Ok(posts);
        }
        [SwaggerOperation(Summary ="Zwraca użytkownika z podanym id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [SwaggerOperation(Summary ="Dodaje nowy post")]
        [HttpPost]
        public IActionResult CreatePost(CreatePostDto NewPost)
        {
            var post = _postService.CreatePost(NewPost);
            return Created($"api/posts/{post.Id}", post);
        }

        [SwaggerOperation(Summary ="Nadpisuje istniejący post")]
        [HttpPut]
        public IActionResult Update(UpdatePostDto updatePost)
        {
            _postService.UpdatePost(updatePost);
            return NoContent();
        }

        [SwaggerOperation(Summary ="Usuwa post")]
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id) 
        {
            _postService.DeletePost(id);
            return NoContent();
        }
    }
}
