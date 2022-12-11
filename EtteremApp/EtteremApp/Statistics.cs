using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Statistics
{
    private List<Order> orders = new List<Order>();

    public void showAveragePrice()
    {
        int sum = 0;
        foreach (Order order in orders)
        {
            sum += order.getPrice();
        }
        sum = sum / orders.Count;
        Console.WriteLine("The average cost of orders are:" + sum);
    }
    public void showRegisteredUsers()
    {
        //todo
        Console.WriteLine("The number of registered users are: ");
    }
}
