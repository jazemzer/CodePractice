using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CrossOver.Models
{
    public class CrossOverContext : DbContext
    {
        public CrossOverContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
    }
}
