using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Guest : Person
{
    public Guest(string name, string email, string password) : base(name, email, password) { }

    public void register(UserList userList)
    {
        Console.WriteLine("Please choose an username:");
        name = Console.ReadLine();
        Console.WriteLine("Please give your email:");
        email = Console.ReadLine();
        Console.WriteLine("Please give your password:");
        password = Console.ReadLine();
        RegisteredUser r1 = new RegisteredUser(name,email,password);
        //if (!r1.Name.Equals(""))
        {
            userList.addPerson(r1);
        }
    }
}
