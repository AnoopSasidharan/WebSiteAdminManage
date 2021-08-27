using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebsiteAdmin.Manage.Data;
using WebsiteAdmin.Manage.Data.Entities;

namespace WebsiteAdmin.Manage.Services
{
    public class DataRepository : IDataRepository
    {
        private readonly ManageDbContext _dbContext;

        public DataRepository(ManageDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            return await _dbContext.Groups.ToListAsync();
        }
        public async Task<Group> GetGroupByIdAsync(int Id)
        {
            return await _dbContext.Groups.FindAsync(Id);
        }
        public void AddGroup(Group group)
        {
            _dbContext.Add(group);
        }
        public void RemoveGroup(Group group)
        {
            _dbContext.Groups.Remove(group);
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<User> GetUsersByIdAsync(int Id)
        {
            return await _dbContext.Users.FindAsync(Id);
        }
        public void AddUser(User user)
        {
            _dbContext.Add(user);
        }
        public void RemoveUser(User user)
        {
            _dbContext.Users.Remove(user);
        }
        public async Task<bool> SaveRepositoryAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
