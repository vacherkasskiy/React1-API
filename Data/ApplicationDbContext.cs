using Microsoft.EntityFrameworkCore;
using Reactjs_api.Data.Models;

namespace Reactjs_api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
}