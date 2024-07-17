using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Infrastructure.Data.configurations;

namespace SocialMedia.Infrastructure.Data;

public partial class SocialMediaContext : DbContext
{
    public SocialMediaContext()
    {
    }

    public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
        : base(options)
    {
    }

    public  DbSet<Comment> Comments { get; set; }

    public  DbSet<Post> Posts { get; set; }

    public  DbSet<User> Users { get; set; }

    public DbSet<Security> Securities { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CommentConfiguration());

        modelBuilder.ApplyConfiguration(new PostConfigurations());

        modelBuilder.ApplyConfiguration(new UserConfiguration());

            

    }

}
