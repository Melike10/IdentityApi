using IdentityApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Context
{
    public class UserIdentityContext:DbContext
    {
        public UserIdentityContext(DbContextOptions<UserIdentityContext> options):base(options)
        {
            
        }
        public DbSet<UserEntitiy> Users => Set<UserEntitiy>();
    }
}
