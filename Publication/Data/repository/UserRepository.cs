using Publication.Data.interfaces;
using Publication.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Data.repository
{
    public class UserRepository : IUser
    {
        private readonly AppDbContext _appDbContent;

        public UserRepository(AppDbContext appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public bool UserExists(string login, string email)
        {
            return _appDbContent.User.FirstOrDefault(i => i.Login == login || i.Email == email) != null;
        }
    }
}
