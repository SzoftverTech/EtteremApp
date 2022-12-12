using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Worker : Person
{
    int privilege = 2;
    public Worker(string name, string email, string password) : base(name, email, password) { }
    public  void modifyMenu()
    {
        Menu currentMenu = new Menu();

        Console.WriteLine("Please choose what would you like to do:");
        Console.WriteLine("1: Add new item");
        Console.WriteLine("2: Update existing item");
        Console.WriteLine("3: Delete an item");

        int option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
            case 1:
                {
                    //currentMenu.addItem();
                    break;
                }
            case 2:
                {
                    //currentMenu.updateItem();
                    break;
                }
            case 3:
                {
                    //currentMenu.deleteItem();
                    break;
                }
            default:
                {
                    Console.WriteLine("No proper option has been selected!");
                    break;
                }
        }

        Console.WriteLine("Your request has been processed.");
    }
}

