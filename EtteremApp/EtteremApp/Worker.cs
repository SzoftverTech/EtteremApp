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

        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("Please choose what would you like to do:");
        Console.WriteLine("1: Display menu");
        Console.WriteLine("2: Edit menu");
        Console.WriteLine("3: Show orders");
        Console.WriteLine("4: Show reservations");
        Console.WriteLine("5: Logout");
        Console.WriteLine("6: Exit");

        //ide amiket kell neki
        int option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
            case 1:
                {
                    Console.WriteLine("-------------------------------------------------------");
                    currentMenu.listFood();
                    break;
                }
            case 2:
                {
                    Console.WriteLine("-------------------------------------------------------");
                    currentMenu.editMenu();
                    break;
                }
            case 3:
                {
                    Console.WriteLine("-------------------------------------------------------");
                    showOrders();
                    break;
                }
            case 4:
                {
                    Console.WriteLine("-------------------------------------------------------");
                    ReservationList();
                    break;
                }

            case 5:
                {
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                    Environment.Exit(0);
                    break;
                }
            case 6:
                {
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine("No proper option has been selected!");
                    break;
                }
        }

        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("Your request has been processed.");
        inputAction();
    }

    private void ReservationList()
    {
        string[] reservs = File.ReadAllLines("reserves.txt");
        foreach (string reservation in reservs)
        {
            Console.WriteLine(reservation);
        }
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

