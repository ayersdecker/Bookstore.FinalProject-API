using Bookstore.Databases;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Repositories;

public class BookRepository
{
    public DbSet<Book> Books;
    public DbContext Context;
    public BookRepository(MySQLDatabase context)
    {
        this.Context = context;
        this.Books = context.Books;
    }
    public async Task<IEnumerable<Book>> GetAll() { return await this.Books.ToArrayAsync(); }
    public async Task<Book> Get(int id)
    {
        foreach (var VARIABLE in Books) { if (VARIABLE.ID == id) { return VARIABLE; } }
        throw new Exception("No Book with ID Found");
    }
    public async Task<Book> Create(Book book)
    {
        if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author) ||
            string.IsNullOrEmpty(book.Description) || string.IsNullOrEmpty(book.ISBN))
        {
            throw new Exception("One or More Fields are Missing");
        }
        await this.Books.AddAsync(book);
        await this.Context.SaveChangesAsync();
        return book;
    }
    public async Task<Book> Update(int id, Book book)
    {
        if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author) ||
            string.IsNullOrEmpty(book.Description) || string.IsNullOrEmpty(book.ISBN))
        {
            throw new Exception("One or More Fields are Missing");
        }
        foreach (var VARIABLE in Books)
        {
            if (VARIABLE.ID == id)
            {
                VARIABLE.Title = book.Title;
                VARIABLE.Author = book.Author;
                VARIABLE.Description = book.Description;
                VARIABLE.Condition = book.Condition;
                VARIABLE.ISBN = book.ISBN;
                VARIABLE.Edition = book.Edition;
                VARIABLE.Price = book.Price;
                VARIABLE.CourseID = book.CourseID;
                VARIABLE.SellerID = book.SellerID;
                VARIABLE.Image = book.Image;
                await this.Context.SaveChangesAsync();
                return book;
            }
        }
        throw new Exception("There are no matching books to update");
    }
    public async Task<Book> Delete(int id)
    {
        foreach (var VARIABLE in Books)
        {
            if (VARIABLE.ID == id)
            {
                Books.Remove(VARIABLE);
                await this.Context.SaveChangesAsync();
                return VARIABLE;
            }
        }
        throw new Exception("There are no matching books to delete");
    }
    
    

}