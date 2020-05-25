using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Data.interfaces
{
    public interface IUser
    {
        bool UserExists(string login, string email);
    }
}
