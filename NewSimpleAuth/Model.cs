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

        public void Add(string addFirstName, string addLastName, string addPassword)
        {
            foreach (var user in users)
            {
                if (user.firstName == null)
                {
                    user.firstName = addFirstName;
                    user.lastName = addLastName;
                    user.password = addPassword;

                }
            }

            /*for (int i = 0; i < firstName.Length; i++)
            {
                if (firstName[i] == null)
                {
                    firstName[i] = addFirstName;
                    lastName[i] = addLastName;
                    password[i] = addPassword;
                    break;
                }
            }*/
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
                foreach(var user in users)
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
                /*for (int i = 0; i < users.Count; i++)
                {
                    if (i == (firstName.Length - 1))
                    {
                        users = null;
                    }
                    else
                    {
                        users = users;
                    }
                }*/
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
            /*for (int i = 0; i < this.firstName.Length; i++)
            {
                this.firstName[id - 1] = firstName;
                this.lastName[id - 1] = lastName;
                this.password[id - 1] = password;
            }
            return true;*/
        }
    }
}
