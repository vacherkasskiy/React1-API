using Reactjs_api.Data;
using Reactjs_api.Data.Models;
using Reactjs_api.Repositories.Interfaces;

namespace Reactjs_api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;
    
    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public int Length => _db.Users.ToArray().Length;

    public async Task<User?> GetUser(long userId)
    {
        return (await _db.Users.FindAsync(userId));
    }

    public User[] GetUsers(int skip, int amount)
    {
        return _db.Users
            .Skip(skip)
            .Take(amount)
            .OrderBy(x => x.Id)
            .ToArray();
    }

    public async Task AddUser(User user)
    {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
    }

    public async Task EditUser(User newUser)
    {
        _db.Users.Update(newUser);
        await _db.SaveChangesAsync();
    }
}