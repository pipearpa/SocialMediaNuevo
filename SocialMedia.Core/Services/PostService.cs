using SocialMedia.Core.Entities;
using SocialMedia.Core.Exeptions;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Queryfilters;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IunitOfWork _unitOfWork;
       
        public PostService(IunitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public  IEnumerable<Post> GetPosts(PostQueryFilters filters)
        {
            var posts = _unitOfWork.PostRepository.GetAll();

            if(filters.UserId != null)
            {
                posts =  posts.Where(x => x.UserId == filters.UserId);
            }

            if (filters.Date != null)
            {
                posts = posts.Where(x => x.Date.ToShortDateString() == filters.Date?.ToShortDateString());
            }

            if (filters.Description != null)    
            {
                posts = posts.Where(x => x.Description.ToLower().Contains(filters.Description.ToLower()));
            }



            return posts;
        }

        public async Task InsertPost(Post post)
        {
           var user = await _unitOfWork.UserRepository.GetById(post.UserId);
            if (user == null)
            {
                throw new BusinessExeptions("Usuario no existe");
            }
            var userPost = await _unitOfWork.PostRepository.GetPostByUser(post.UserId);
            if (userPost.Count() < 10) 
            { 
               var lastPost = userPost.OrderByDescending(x => x.Date).FirstOrDefault();
                if((DateTime.Now - lastPost.Date).TotalDays < 7)
                {
                    throw new BusinessExeptions("bien bien papa");
                }
            }

            if(post.Description.Contains("sexo"))
            {
                throw new BusinessExeptions("contenido no permitido");
            }
            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }
            
        public async Task<bool> UpdatePost(Post post)
        {
            _unitOfWork.PostRepository.Update(post);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return true;        
        }
    }
}
