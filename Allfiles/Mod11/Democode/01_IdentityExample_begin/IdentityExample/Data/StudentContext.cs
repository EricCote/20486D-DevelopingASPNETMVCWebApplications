using IdentityExample.Models;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityExample.Data;

public class StudentContext : DbContext // IdentityDbContext<Student>
{
    public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
}

