using Domain.Entities;
using Domain.Interfaction;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {

        private readonly BlogggerContext _context;

        public PostRepository(BlogggerContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;
        }

        public Post GetById(int id)
        {
            return _context.Posts.SingleOrDefault(x => x.Id == id);
        }
        public Post Add(Post post)
        { 
            post.Created = DateTime.UtcNow;
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }
        public void Update(Post post)
        {
            post.LastModifed = DateTime.UtcNow;
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

       
    }
}
