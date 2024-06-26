using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        Task<Post> GetPost(int id);
        Task<IEnumerable<Post>> GetPosts();

        Task InsertPost(Post post);

        Task<bool> DeletePost(int id);

        Task<bool> UpdatePost(Post post);
    }
}