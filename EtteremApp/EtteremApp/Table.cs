using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Table
{
    private int Id;
    private bool available;
    public Table(int id, bool available)
    {
        this.Id = id;
        this.available = available;
    }

    public int getId()
    {
        return Id;
    }
    public bool isAvailable()
    {
        return available;
    }
    public void setAvailablity(bool isit)
    {
        available = isit;
    }
}

