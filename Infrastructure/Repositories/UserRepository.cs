using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly ISet<User> _users = new HashSet<User>()
        {
            new User( 1,"User1","user1@user.com","pasword1"),
            new User( 2,"User2","user2@user.com","pasword2"),
            new User( 3,"User3","user3@user.com","pasword3"),
        };
        public IEnumerable<User> GetUsers()
        {
            return _users;
        }
        public User Add(User user)
        {
            user.Id = _users.Count() + 1;
            user.Created= DateTime.Now;
            _users.Add(user);
            return user;
        }
        public void Delete(User user)
        {
            _users.Remove(user);
        }

        public User GetUser(int id)
        {
            return _users.SingleOrDefault(x => x.Id == id);
        }
        public void Update(User user)
        {
            user.LastModified= DateTime.Now;
        }
    }
}
