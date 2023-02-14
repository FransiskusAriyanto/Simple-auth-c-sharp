using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSimpleAuth
{
    public class Model : User
    {
        List<User> users = new List<User>();

        public void Store(string firstName, string lastName, string password)
        {
            foreach (var user in users)
            {
                if (user.firstName == null)
                {
                    user.firstName = firstName;
                    user.lastName = lastName;
                    user.password = password;

                }
            }
        }

        public bool Destroy(int id)
        {

            id -= 1;
            var i = 0;

            if (id >= users.Count())
            {
                return false;
            }
            else
            {
                foreach (var user in users)
                {
                    if (i == (users.Count() - 1))
                    {
                        users = null;
                    }
                    else
                    {
                        users = users;
                    }
                }
                return true;
            }
        }

        public bool Edit(int id, string firstName, string lastName, string password)
        {
            foreach (var user in users)
            {
                user.firstName = firstName;
                user.lastName = lastName;
                user.password = password;
            }
            return true;
        }
    }
}
