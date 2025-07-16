using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DataDbContext;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Employee> Employees => Set<Employee>();
}
