using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostServices : IPostServices
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostServices(IPostRepository postRepository,IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;

        }

        

        public IEnumerable<PostDto> GetAllPost()
        {
            var posts = _postRepository.GetAll();
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

      
        public PostDto GetPostById(int id)
        {
            var post = _postRepository.GetById(id);

            return _mapper.Map<PostDto>(post);
        }


        public PostDto AddNewPost(CreatePostDto newPost)
        {
            if(string.IsNullOrEmpty(newPost.Title))
            {
                throw new Exception("Post is null");
            }
            var post = _mapper.Map<Post>(newPost);
            _postRepository.Add(post);
            return _mapper.Map<PostDto>(post);
        }

      

        public void UpdatePost(UpdatePostDto updatePostDto)
        {
            var existingPost = _postRepository.GetById(updatePostDto.Id);
            var post = _mapper.Map(updatePostDto, existingPost);
            _postRepository.Update(post);
        }

        public void DeletePost(int id)
        {
            var post = _postRepository.GetById(id);
            _postRepository.Delete(post);
        }

       
    }
}
