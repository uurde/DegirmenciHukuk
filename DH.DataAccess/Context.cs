using DH.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DH.DataAccess
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: gitignore
            //GoDaddy Production SQL
            optionsBuilder.UseSqlServer(@"Server = 77.245.159.23; Initial Catalog = DegirmenciHukuk; Persist Security Info = False; User ID = uurde; Password =0734ypkEUZ87@; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = True; Connection Timeout = 30;");
        }

        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
