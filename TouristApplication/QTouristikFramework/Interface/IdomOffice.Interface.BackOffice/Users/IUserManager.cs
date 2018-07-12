using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Interface.BackOffice.Users
{
    public interface IUserManager
    {
        //TODO: Ovdje definisi metode koje trebas za Login
        void AddUser(QApplikationUser user);
        QApplikationUser GetUser(string username);
    }
}
