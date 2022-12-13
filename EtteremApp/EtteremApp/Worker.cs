using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Worker : Person
{
    int privilege = 2;
    public Worker(string name, string email, string password) : base(name, email, password) { }

    public override int getPrivilege()
    {
        return privilege;
    }
    public override void inputAction()
    {
        Menu currentMenu = new Menu();

        Console.WriteLine("Please choose what would you like to do:");
        Console.WriteLine("1: Display menu");
        Console.WriteLine("2: Edit menu");
        Console.WriteLine("3: Show orders");
        Console.WriteLine("4: Show reservations");
        //ide amiket kell neki
        int option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
            case 1:
                {
                    currentMenu.listFood();
                    break;
                }
            case 2:
                {
                    currentMenu.editMenu();
                    break;
                }
            case 3:
                {
                    showOrders();
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

    private void showOrders()
    {
        FileStream fs = new FileStream("orders.txt", FileMode.Open);
        StreamReader sr = new StreamReader(fs);

        while(!sr.EndOfStream)
        {
            string input = sr.ReadLine();
            string[] split = input.Split(",");
            Console.Write("Name of customer: " + split[0] + " ");
            for (int i = 1; i< split.Length-1;i++)
            {
                Console.Write(split[i] + " ");
            }
            Console.WriteLine("Total price:" + split[split.Length-1]);
        }



        string[] wholeInput = File.ReadAllLines("menu.txt");
        foreach (string input in wholeInput)
        {
            string[] temp = input.Split(',');
            string username = temp[0];
            int price = Convert.ToInt32(temp[1]);

            Food tmp = new Food(name, price);
        }
    }
}

