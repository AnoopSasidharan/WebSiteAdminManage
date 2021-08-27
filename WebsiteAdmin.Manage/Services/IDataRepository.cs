using System.Collections.Generic;
using System.Threading.Tasks;
using WebsiteAdmin.Manage.Data.Entities;

namespace WebsiteAdmin.Manage.Services
{
    public interface IDataRepository
    {
        void AddGroup(Group group);
        void AddUser(User user);
        Task<Group> GetGroupByIdAsync(int Id);
        Task<IEnumerable<Group>> GetGroupsAsync();
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUsersByIdAsync(int Id);
        void RemoveGroup(Group group);
        void RemoveUser(User user);
        Task<bool> SaveRepositoryAsync();
    }
}