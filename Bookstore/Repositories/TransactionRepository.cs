using Bookstore.Databases;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Repositories;

public class TransactionRepository
{
    public DbSet<Transaction> Trans;
    public DbContext Context;
    public TransactionRepository(MySQLDatabase context)
    {
        this.Context = context;
        this.Trans = context.Transactions;
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
        await this.Trans.AddAsync(transaction);
        await this.Context.SaveChangesAsync();
        return transaction;
    }

}