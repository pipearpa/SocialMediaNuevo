﻿using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IunitOfWork : IDisposable
    {
      IRepository<Post> PostRepository { get; }
      IRepository<User> UserRepository { get; }
      IRepository<Comment> Comment { get; }

        Task SaveChangesAsync();
    }
}
