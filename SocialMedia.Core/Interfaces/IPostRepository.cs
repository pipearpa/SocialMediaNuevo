using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<Post> GetPost(int id);
        Task<IEnumerable<Post>> GetPosts();

        Task InsertPost(Post post);

        Task<bool> DeletePost(int id);

        Task<bool> UpdatePost(Post post);
    }
}
