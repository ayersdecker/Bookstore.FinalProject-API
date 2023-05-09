using TransplantedProj.Databases;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using TransplantedProj.Databases;

namespace TransplantedProj.Repositories;

public class TransactionRepository
{
    public DbSet<Transaction> Trans;
    public DbSet<Book> Books;
    public DbContext Context;
    public TransactionRepository(MySQLDatabase context)
    {
        this.Context = context;
        this.Trans = context.Transactions;
        this.Books = context.Books;
    }
    public async Task<IEnumerable<Transaction>> GetAll() { return await this.Trans.ToArrayAsync(); }
    public async Task<Transaction> Get(int id)
    {
        foreach (var VARIABLE in Trans) { if (VARIABLE.ID == id) { return VARIABLE; } }
        throw new Exception("No Book with ID Found");
    }
    public async Task<Transaction> Create(Transaction transaction)
    {
        if (double.IsNaN(transaction.Price) ||
            int.IsPositive(transaction.BuyerID) || int.IsPositive(transaction.SellerID))
        {
            throw new Exception("One or More Fields are Missing");
        }

        Book book = Books.FirstOrDefault(b => b.ID == transaction.BookID);
        Item item = new Item()
        {
            Name = book.Title, Description = book.Description, Quantity = 1, CurrencyCode = "USD",
            UnitPrice = transaction.Price
        };
        // Calls Prof. API with this Item for reference
        // https://localhost:44304/payment/order/success
        
        await this.Trans.AddAsync(transaction);
        await this.Context.SaveChangesAsync();
        return transaction;
    }

}