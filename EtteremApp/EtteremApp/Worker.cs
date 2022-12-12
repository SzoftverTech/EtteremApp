using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Worker : Person
{
    public Worker(string name, string email, string password) : base(name, email, password) { }
    public  void modifyMenu()
    {
        Menu menu = new Menu();

        Console.WriteLine("Please choose what would you like to do:");
        Console.WriteLine("1: Add new item");
        Console.WriteLine("2: Update existing item");
        Console.WriteLine("3: Delete an item");

        int option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
            case 1:
                {
                    m1.addItem();
                    break;
                }
            case 2:
                {
                    m1.updateItem();
                    break;
                }
            case 3:
                {
                    m1.deleteItem();
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

