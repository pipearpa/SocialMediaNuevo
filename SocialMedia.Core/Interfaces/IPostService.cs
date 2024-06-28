using SocialMedia.Core.Entities;
using SocialMedia.Core.Queryfilters;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {

        IEnumerable<Post> GetPosts(PostQueryFilters filters);
        Task<Post> GetPost(int id);
      

        Task InsertPost(Post post);

        Task<bool> DeletePost(int id);

        Task<bool> UpdatePost(Post post);
    }
}