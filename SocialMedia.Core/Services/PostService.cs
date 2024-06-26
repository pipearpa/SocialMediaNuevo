using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
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

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _unitOfWork.PostRepository.GetAll();
        }

        public async Task InsertPost(Post post)
        {
           var user = await _unitOfWork.UserRepository.GetById(post.UserId);
            if (user == null)
            {
                throw new Exception("Usuario no existe");
            }

            if(post.Description.Contains("sexo"))
            {
                throw new Exception("contenido no permitido");
            }
           await _unitOfWork.PostRepository.Add(post);
        }
            
        public async Task<bool> UpdatePost(Post post)
        {
            await _unitOfWork.PostRepository.Update(post);
            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return true;        
        }
    }
}
