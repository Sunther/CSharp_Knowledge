using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<MyUser>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}