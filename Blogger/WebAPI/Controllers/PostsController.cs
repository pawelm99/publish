using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostServices _postServices;
        public PostsController(IPostServices postServices)
        {
            _postServices = postServices;
        }
        [SwaggerOperation(Summary ="Retrivers all post")]
        [HttpGet]
        public IActionResult Get()
        {
            var posts = _postServices.GetAllPost();
            return Ok(posts);
        }
        [SwaggerOperation(Summary = "Retrivers a specific post by unique id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postServices.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);

        }
        [SwaggerOperation(Summary ="Create a new post")]
        [HttpPost]
        public IActionResult Create(CreatePostDto newPost)
        {
            var post = _postServices.AddNewPost(newPost);
            return Created($"api/posts/{post.Id}", post);
        }
        [SwaggerOperation(Summary ="Update a exiting post")]
        [HttpPut]
        public IActionResult Update(UpdatePostDto updatePostDto)
        {
            _postServices.UpdatePost(updatePostDto);
            return NoContent();
        }

        [SwaggerOperation(Summary ="Delete a specyfict post")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postServices.DeletePost(id);
            return NoContent();
        }
    }
}
