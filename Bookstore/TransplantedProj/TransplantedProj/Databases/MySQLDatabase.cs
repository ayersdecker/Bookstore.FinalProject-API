using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace TransplantedProj.Databases;

public class MySQLDatabase : DbContext
{
    public MySQLDatabase(DbContextOptions options) : base(options)  {}
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Patron> Patrons { get; set; }
}