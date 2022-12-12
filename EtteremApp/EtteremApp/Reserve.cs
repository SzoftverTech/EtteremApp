using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Reserve
{
    private List<Table> tableList = new List<Table>(10);

    public Reserve()
    {
        for (int i  =0;i < 10;i++)
        {
            tableList.Add(new Table(i, true));
        }
    }

    public void listTable()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(tableList[i].getId());
            if (tableList[i].isAvailable() == true)
                Console.WriteLine("available");
            else
                Console.WriteLine("reserved");
        }
    }
    public void reserveTable()
    {
        Console.WriteLine("Please give which table to reserve:");
        listTable();
        int idx = Convert.ToInt32(Console.ReadLine());
        if (tableList[idx].isAvailable())
        {
            tableList[idx].setAvailablity(false);
            Console.WriteLine("Sikeres foglalás!");
        }
        else
            Console.WriteLine("Már foglalt az asztal!");
    }
}

