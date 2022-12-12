﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Guest : Person
{
    int privilege = 0;
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
    public void inputAction(Menu m1)
    {
        Console.WriteLine("Please choose a menu item:");
        Console.WriteLine("1: Register");
        Console.WriteLine("2: Show menu");
        Console.WriteLine("3: View Contacts");
        Console.WriteLine("4: Exit");

        Console.WriteLine("Input the chosen number: ");
        int op = Convert.ToInt32(Console.ReadLine());

        while (op < 1 && op > 4)
            Choice(op);
    }

    public void Choice(int number)
    {
        Menu menu = new Menu();
        switch (number)
        {
            case 1:
                {
                    //Register
                    register();
                    break;
                }

            case 2:
                {
                    //Editing menu
                    menu.listFood();
                    break;
                }

            case 3:
                {
                    //View res menu
                    getInfo();
                    break;
                }

            default:
                {
                    Console.WriteLine("Wrong number, try again.");
                    break;
                }
        }

    }

    private void register()
    {
        Console.WriteLine("Please give your username");
        string name = Console.ReadLine();
        Console.WriteLine("Please give your email");
        string email = Console.ReadLine();
        Console.WriteLine("Please give your password");
        string password = Console.ReadLine();

        RegisteredUser r1 = new RegisteredUser(name, email, password);
        File.AppendAllText("users.txt", name + ',' + email + ',' + password);
    }
}
