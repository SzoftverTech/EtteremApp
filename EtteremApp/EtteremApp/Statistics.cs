using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Statistics
{
    private List<Food> orders = new List<Food>();

    public Statistics() {
        string[] wholeInput = File.ReadAllLines("menu.txt");
        foreach (string input in wholeInput)
        {
            string[] temp = input.Split(',');
            string name = temp[0];
            int price = Convert.ToInt32(temp[1]);

            Food tmp = new Food(name, price);
            orders.Add(tmp);
        }
    }

    public void showAveragePrice()
    {
        double sum = 0;
        foreach(var order in orders)
        {
            sum += order.getPrice();
        }
        double avg = sum / orders.Count;

        Console.WriteLine($"The average price is: {avg}");
    }
    public void showRegisteredUsers()
    {
        List<string> users = File.ReadAllLines("users.txt").ToList();
        Console.WriteLine($"The number of registered users are: {users.Count} ");       
    }

    public void HighestPrice()
    {
        int max = 0;
        foreach(var order in orders)
        {
            if(order.getPrice() > max)
            {
                max = order.getPrice();
            }
        }
        Console.WriteLine($"Highest price on the menu: {max}");
    }

    public void LowestPrice()
    {
        int min = orders[0].getPrice();
        foreach (var order in orders)
        {
            if (order.getPrice() < min)
            {
                min = order.getPrice();
            }
        }
        Console.WriteLine($"Highest price on the menu: {min}");


    }
}
