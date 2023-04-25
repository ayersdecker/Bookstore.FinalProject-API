using System.Data;
using BookStoreAPI.Databases;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories;

public class UserRepository
{
    public DbSet<User> Users;
    public DbContext Context;
    public UserRepository(MySQLDatabase context) { this.Context = context; this.Users = context.Users; }
    public async Task<IEnumerable<User>> GetAll() { return await this.Users.ToArrayAsync(); }
    public async Task<User> Get(int id)
    {
        foreach (var VARIABLE in Users) { if (VARIABLE.ID == id) { return VARIABLE; } }
        throw new Exception("No User with ID Found");
    }
    public async Task<User> Create(User user)
    {
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.FirstName) ||
            string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.Email))
        {
            throw new Exception("One or More Fields are Missing");
        }
        await this.Users.AddAsync(user);
        await this.Context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Update(int id, User user)
    {
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.FirstName) ||
            string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.Email))
        {
            throw new Exception("One or More Fields are Missing");
        }

        foreach (var VARIABLE in Users)
        {
            if (VARIABLE.ID == id)
            {
                VARIABLE.Username = user.Username;
                VARIABLE.FirstName = user.FirstName;
                VARIABLE.LastName = user.LastName;
                VARIABLE.Email = user.Email;
                VARIABLE.ProfilePicture = user.ProfilePicture;
                await this.Context.SaveChangesAsync();
                return user;
            }
        }
        throw new Exception("There are no matching users to update");
    }

    public async Task<User> Delete(int id)
    {
        foreach (var VARIABLE in Users)
        {
            if (VARIABLE.ID == id)
            {
                Users.Remove(VARIABLE);
                await this.Context.SaveChangesAsync();
                return VARIABLE;
            }
        }
        throw new Exception("There are no matching users to delete");
    }
}