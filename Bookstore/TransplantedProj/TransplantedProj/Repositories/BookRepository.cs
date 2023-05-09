using TransplantedProj.Databases;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using TransplantedProj.Databases;

namespace TransplantedProj.Repositories;

public class BookRepository
{
    public DbSet<Book> Books;
    public DbSet<User> Users;
    public DbContext Context;
    public BookRepository(MySQLDatabase context)
    {
        this.Context = context;
        this.Books = context.Books;
        this.Users = context.Users;
    }
    public async Task<IEnumerable<Book>> GetAll() { return await this.Books.ToArrayAsync(); }
    public async Task<Book> Get(int id)
    {
        foreach (var VARIABLE in Books) { if (VARIABLE.ID == id) { return VARIABLE; } }
        throw new Exception("No Book with ID Found");
    }
    public async Task<List<Patron>> GetPatrons(int id)
    {
        foreach (var VARIABLE in Books) { if (VARIABLE.ID == id) { return VARIABLE.Interested; } }
        throw new Exception("No Book with ID Found");
    }
    public async Task<User> GetSeller(int id)
    {
        int idee = 0;
        foreach (var VARIABLE in Books)
        {
            if (VARIABLE.ID == id)
            {
                idee = VARIABLE.SellerID;
            }
        }

        foreach (var VARIABLE in Users)
        {
            if (VARIABLE.ID == idee)
            {
                return VARIABLE;
            }
        }
        throw new Exception("No Book with ID Found");
    }

    public async Task<Patron> RemovePatron(int id, int pId)
    {
        foreach (var VARIABLE in Books)
        {
            if (VARIABLE.ID == id)
            {
                foreach (var brr in VARIABLE.Interested)
                {
                    if (brr.ID == pId)
                    {
                        VARIABLE.Interested.Remove(brr);
                        return brr;
                    }
                }
            }
        }

        throw new Exception("No Patron in Waiting List");
    }
    public async Task<Patron> AddPatron(int id, Patron pid)
    {
        foreach (var VARIABLE in Books)
        {
            if (VARIABLE.ID == id)
            {
                if (!VARIABLE.Interested.Contains(pid))
                {
                    VARIABLE.Interested.Add(pid);
                }
                else
                {
                    throw new Exception("Patron Already Added");
                }
            }
        }
        throw new Exception("No Waiting List Found");
    }

    public async Task<Book> Create(Book book)
    {
        if ( string.IsNullOrEmpty(book.ISBN))
        {
            throw new Exception("One or More Fields are Missing");
        }
        // Connect to OpenLibrary API to tie ISBN and Book detail together
        // Omitted Implementation
        // Connect to Azure Blob to store Image and assign Link to book
        // Omitted Implementation
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


    public async Task<object?> GetImages(int id)
    {
        //This is where the Azure Blob connection would search for images regarding a book
        throw new NotImplementedException();
    }
}