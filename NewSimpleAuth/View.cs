using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewSimpleAuth
{
    public class View
    {
        Model model = new Model();
        List<User> users = new List<User>();
        public void Add(string firstName, string lastName, string password)
        {
            model.Store(firstName, lastName, password);
        }
        public void Show()
        {
            var i = 0;

            foreach (var user in users)
            {
                if (user.firstName != null)
                {
                    Console.WriteLine("=========================");
                    Console.WriteLine("ID : " + i++);
                    Console.WriteLine("First Name : " + user.firstName);
                    Console.WriteLine("Last Name : " + user.lastName);
                    Console.WriteLine("User Name : " + user.firstName[0..2] + user.lastName[0..2]);
                    Console.WriteLine("Password: " + user.password);
                    Console.WriteLine("=========================");
                }
            }
            /*FirstName[] firstName = model.getAllFirstName();
            LastName[] lastName = model.getAllLastName();
            Password[] password = model.getAllPassword();

            Console.WriteLine("== Show User's Data ==");
            for (int i = 0; i < firstName.Length; i++)
            {
                if (firstName[i] != null)
                {
                    Console.WriteLine("=========================");
                    Console.WriteLine("ID : " + (i + 1));
                    Console.WriteLine("First Name : " + firstName[i].firstName);
                    Console.WriteLine("Last Name : " + lastName[i].lastName);
                    Console.WriteLine("User Name : " + firstName[i].firstName[0..2] + lastName[i].lastName[0..2]);
                    Console.WriteLine("Password: " + password[i].password);
                    Console.WriteLine("=========================");
                }
            }
    */
            OtherMenu();
        }
        public void Search()
        {
            Console.WriteLine("nothing to see here XD");
        }
        public void Login()
        {
            /*        FirstName[] firstName = model.getAllFirstName();
                    LastName[] lastName = model.getAllLastName();
                    Password[] password = model.getAllPassword();*/

            Console.WriteLine("==LOGIN==");
            Console.Write("USERNAME : ");
            var inputUserName = Input();
            Console.Write("PASSWORD: ");
            var inputPassword = Input();

            foreach (var user in users)
            {
                if (inputUserName == (user.firstName[..2] + user.lastName[..2]) && inputPassword == user.password)
                {
                    Console.WriteLine("Login Berhasil");
                    Menu();
                }
                else
                {
                    Console.WriteLine("Login Gagal");
                    Menu();
                }
            }

            /*for (int i = 0; i < firstName.Length; i++)
            {
                var userName = firstName[i].firstName[0..2] + lastName[i].lastName[0..2];

                if (inputUserName == userName && inputPassword == password[i].password)
                {
                    Console.WriteLine("Login Berhasil");
                    Menu();
                }
                else
                {
                    Console.WriteLine("Login Gagal");
                    Menu();
                }
            }*/
        }

        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== Basic Authentication ==");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Show User");
                Console.WriteLine("3. Search User");
                Console.WriteLine("4. Login User");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Input : ");

                var input = Input();

                Console.Clear();

                if (input.Equals("1"))
                {
                    Console.Write("first name : ");
                    var fN = Input();
                    Console.Write("last name : ");
                    var lN = Input();
                    Console.Write("password : ");
                    var pW = Input();

                    Validate(fN, lN, pW);

                    Console.Clear();
                }
                else if (input.Equals("2"))
                {
                    Show();
                }
                else if (input.Equals("3"))
                {
                    Search();
                }
                else if (input.Equals("4"))
                {
                    Login();
                }
                else if (input.Equals("5"))
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Inputan tidak dimengerti");
                }
            }

        }

        public string Input()
        {
            var data = Console.ReadLine();
            return data;
        }
        public void Validate(string firstName, string lastName, string password)
        {

            var validate = Convert.ToString(password);

            if ((validate.Length >= 8) && (validate.Any(char.IsUpper)) && (validate.Any(char.IsLower)) && (validate.Any(char.IsNumber)))
            {
                Add(firstName, lastName, password);
            }
            else
            {
                Console.WriteLine("\nPassword must have at least 8 characters\r\n with at least one Capital letter, at least one lower case letter and at least one number.\n");
                Console.WriteLine("Password : ");
                var setPass = Input();

                Validate(firstName, lastName, setPass);
            }
        }

        public void OtherMenu()
        {
            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1. Edit User");
                Console.WriteLine("2. Delete User");
                Console.WriteLine("3. Back");

                var pilih = Input();
                if (pilih.Equals("1"))
                {
                    Console.Write("Id Yang Ingin Diubah : ");
                    var id = Convert.ToInt16(Input());
                    Console.Write("First Name : ");
                    var firstName = Input();
                    Console.Write("Last Name : ");
                    var lastName = Input();
                    Console.Write("Password : ");
                    var password = Input();

                    Edit(id, firstName, lastName, password);

                }
                else if (pilih.Equals("2"))
                {
                    Delete();
                }
                else if (pilih.Equals("3"))
                {
                    Menu();
                }
            }
        }

        public void Delete()
        {
            Console.WriteLine("Nothing to see here");
        }

        public void Edit(int id, string firstName, string lastName, string password)
        {

            foreach (var user in users)
            {
                if (users.Count() - 1 != null)
                {
                    model.Edit(id, user.firstName, user.lastName, user.password);
                }
            }
            /*        FirstName[] setFirstName = model.getAllFirstName();
                    LastName[] setLastName = model.getAllLastName();
                    Password[] setPassword = model.getAllPassword();

                    for (int i = 0; i < setFirstName.Length; i++)
                    {
                        var a = setFirstName[i];
                        var b = setLastName[i];
                        var c = setPassword[i];
                        if (setFirstName[id - 1] != null)
                        {
                            model.Edit(id, a, b, c);
                        }
                    }*/
        }
    }
}
