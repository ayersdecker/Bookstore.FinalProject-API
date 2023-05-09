using Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using TransplantedProj.Databases;

namespace TransplantedProj.Repositories;

public class PatronRepository
{
    private readonly List<Patron> _patrons;
    private readonly List<Book> _books;
    public DbContext Context;
    public PatronRepository(MySQLDatabase context)
    {
        this.Context = context;
        this._patrons = context.Patrons.ToList();
        this._books= context.Books.ToList();
    }
    
    public void Add(Patron patron, int id)
    {
        try
        {
            Book book = _books.FirstOrDefault(b => b.ID == id);
            book.Interested.Add(_patrons.FirstOrDefault(p => p.ID == patron.ID));

        }
        catch (Exception e)
        {
            throw new Exception("There are no matching books to delete");
            
        }
    }

    public void Delete(int id)
    {
        var patron = _patrons.FirstOrDefault(p => p.ID == id);
        if (patron != null)
        {
            _patrons.Remove(patron);
        }
    }

    public Patron Get(int id)
    {
        return _patrons.FirstOrDefault(p => p.ID == id);
    }

    public IEnumerable<Patron> GetAll()
    {
        return _patrons;
    }

    public void Update(int id, Patron patron)
    {
        var paatron = _patrons.FirstOrDefault(p => p.ID == id);
    }

}