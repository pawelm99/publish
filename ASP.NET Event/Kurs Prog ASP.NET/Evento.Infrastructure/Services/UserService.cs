using Evento.Core.Domain;
using Evento.Core.Repositories;
using Evento.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

     
        public async Task RegisterAsync(Guid userId, string email, string name, string password, string role = "user")
        {
            var user = await _userRepository.GetAsync(userId);
            if (user != null)
            {
                throw new Exception($"User with email: '{email}' alredy exists.");
            }
            user = new User(userId, role, name, email, password);
            await _userRepository.AddAsync(user);

        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception($"Invalid creditionals.");
            }
            if (user.Password != password)
            {
                throw new Exception($"Invalid creditionals.");
            }
        }

    }
}
