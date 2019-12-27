using Microsoft.EntityFrameworkCore;

namespace DH.DataAccess
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //NetDirekt Production SQL
            optionsBuilder.UseSqlServer(@"Server = 77.223.142.42; Initial Catalog = UgurDegirmenci; Persist Security Info = False; User ID = uurde; Password =0734ypkEUZ87; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = True; Connection Timeout = 30;");
        }
    }
}
