using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Order
{
    private string user;
    private string type;
    private int price;
    private List<Food> itemList = new List<Food>();

    public int getPrice()
    {
        return price;
    }
}
