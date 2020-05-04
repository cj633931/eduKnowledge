using System;
using System.Collections.Generic;
using System.Text;
using eduKnowledge.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eduKnowledge.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaggedArticle> TaggedArticles { get; set; }
        public DbSet<eduKnowledge.Models.ArticleViewModel> ArticleViewModel { get; set; }
        public DbSet<eduKnowledge.Models.TagViewModel> TagViewModel { get; set; }
    }
}
