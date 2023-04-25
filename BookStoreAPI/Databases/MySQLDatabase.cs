using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Models;

namespace BookStoreAPI.Databases;

public class MySQLDatabase : DbContext
{
    public MySQLDatabase(DbContextOptions options){}
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Course> Courses { get; set; }
}