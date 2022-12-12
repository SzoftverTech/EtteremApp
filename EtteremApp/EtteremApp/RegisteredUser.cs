using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RegisteredUser : Person
{
    int phoneNumber;
    int cardNumber;
    string address;
    List<Order> orderList = new List<Order>();
    public RegisteredUser(string name, string email, string password) : base(name, email, password) { }

    public void orderFood()
    {
        Order newOrder = new Order();
        Menu currentMenu = new Menu();
        currentMenu.listFood();

        Console.WriteLine("Please type the name of the food you would like to order:");

        string input = Console.ReadLine();
        newOrder.addItem(new Food(input, currentMenu.getPrice(input)));

        do
        {
            Console.WriteLine("Would you like to choose anything else? (1:yes, 2:no)");
            int option = Convert.ToInt32(Console.ReadLine());
            if (option == 1)
            {
                Console.WriteLine("Please type the name of the food you would like to order:");

                input = Console.ReadLine();
                newOrder.addItem(new Food(input, currentMenu.getPrice(input)));
            }
        } while (!input.Equals(2));

        orderList.Add(newOrder);
        // fizetés
        Console.WriteLine("Thank you for your order!");
    }
}

