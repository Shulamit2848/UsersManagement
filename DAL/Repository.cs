﻿// Assuming you have a DbContext class for your database
using DAL;
using Microsoft.EntityFrameworkCore;
using UsersManagement.Data;
using UsersManagement.Entities;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context)
    {
        _context = context;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();


        return user;
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<User> GetUserByCredentialsAsync(string userName, string password)
    {
        var user = await _context.Users
            .Where(u => u.UserName == userName && u.UserPassword == password)
            .Select(u => new User { UserId = u.UserId, UserName = u.UserName, UserPassword = u.UserPassword })
            .FirstOrDefaultAsync();
        if (user != null)
        {
            return user;
        }
        return null;
    }
}
