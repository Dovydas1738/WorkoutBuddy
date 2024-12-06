using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutBuddy.Core.Contracts;
using WorkoutBuddy.Core.Models;

namespace WorkoutBuddy.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task AddAsync(User user)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                var user = await context.Users.FindAsync(id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                return await context.Users.ToListAsync();
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                var user = await context.Users.FindAsync(id);
                if (user != null)
                {
                    return user;
                }
                throw new KeyNotFoundException($"User with ID {id} was not found.");
            }
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(x => x.Username == username);
            }
        }

        public async Task UpdateAsync(User user)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
