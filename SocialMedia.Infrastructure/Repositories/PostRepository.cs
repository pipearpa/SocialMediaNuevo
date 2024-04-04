using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;

        public PostRepository(SocialMediaContext context)
        {
            _context = context;
        }

        public async Task<Publicacion> GetPost(int id)
        {
            var posts = await _context.Publicacions.FirstOrDefaultAsync(x => x.IdPublicacion == id);

            return posts;
        }

        public async Task<IEnumerable<Publicacion>> GetPosts()
        {
            var posts = await _context.Publicacions.ToListAsync();

            return posts;
        }

        // metodo para insertar publicaciones

        public async Task InsertPost(Publicacion publicacion)
        {
           
            _context.Publicacions.Add(publicacion);
           await _context.SaveChangesAsync();

           
        }


    }
}
