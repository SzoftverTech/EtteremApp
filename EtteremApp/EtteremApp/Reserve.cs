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
            Console.Write((tableList[i].getId()+1).ToString() + " ");
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
        int idx = Convert.ToInt32(Console.ReadLine()) -1;
        if (tableList[idx].isAvailable())
        {
            tableList[idx].setAvailablity(false);
            Console.WriteLine("What date to reserve: (hour minute)");
            string date = Console.ReadLine();
            

            //if already contains
            List<string> hlp = File.ReadAllLines("reserves.txt").ToList();

            if(!hlp.Contains(date))
            {            
            List<string> res = new List<string>();           
            res.Add((idx+1) +$". table is reserved for {date} this date!");
            File.AppendAllLines("reserves.txt",res);
            Console.WriteLine($"Successful reserve for {date} date!");
            }
            else
            {
                Console.WriteLine("Date is already reserved!");
            }
        }
        else
            Console.WriteLine("Already reserved!");
    }
}

