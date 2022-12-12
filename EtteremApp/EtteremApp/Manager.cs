﻿using System;

public class Manager : Person
{
    int privilege = 3;
    public Manager(string name, string email, string password) : base(name, email, password) { }

    public void inputAction()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1 - View the Menu");
        Console.WriteLine("2 - Edit the Menu");
        Console.WriteLine("3 - View the information about the restaurant");
        Console.WriteLine("4 - Show statistics");
        Console.WriteLine("5 - Edit customer data");

        Console.WriteLine("Input the chosen number: ");
        int op=Convert.ToInt32(Console.ReadLine());

        while(op<1&&op>5)
            Choice(op);
        
    }

    public void Choice(int number)
    {
        Menu menu = new Menu();

        switch (number)
        {
            case 1:
                {
                    //Listing the menu
                    menu.listFood();
                    break;
                }

            case 2:
                {
                    //Editing menu
                    menu.editMenu();
                    break;
                }

            case 3:
                {
                    //View res menu
                    getInfo();
                    break;
                }

            case 4:
                {
                    //Show statistics
                    Statistics stat=new Statistics();
                    stat.showAveragePrice();
                    stat.showRegisteredUsers();
                    break;
                }

            case 5:
                {
                    //Edit customer data

                    //...

                    break;
                }

            default:
                {
                    Console.WriteLine("Wrong number, try again.");
                    break;
                }
        }

    }

    public void Login()
    {

    }
}
