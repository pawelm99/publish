using Application.Core.Domain;
using Application.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly ISet<User> _user = new HashSet<User>();

        public async Task<User> GetAsync(Guid id)
        {
            return await Task.FromResult<User>(_user.SingleOrDefault(x => x.Id == id));
        }

        public async Task<User> GetAsync(string email)
        {
            return await Task.FromResult<User>(_user.SingleOrDefault(x => x.Email.ToLowerInvariant() == email));
        }

        public async Task AddAsync(User user)
        {
            _user.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(User user)
        {
            _user.Remove(user);
            await Task.CompletedTask;
        }


    }
}
