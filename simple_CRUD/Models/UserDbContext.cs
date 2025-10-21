using Microsoft.EntityFrameworkCore;

namespace simple_CRUD.Models
{
    public class UserDbContext:DbContext
    {
            public DbSet<User> Users { get; set; }
       public UserDbContext( DbContextOptions<UserDbContext> options)
            :base (options)
        { 

        }
    }
}
