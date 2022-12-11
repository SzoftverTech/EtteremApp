using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class PersonDatabase
{
    private List<Person> personList = new List<Person>();

    PersonDatabase()
    {
        string[] wholeInput = File.ReadAllLines("person.txt");
        foreach (string input in wholeInput)
        {
            string[] temp = input.Split(',');
            //todo
        }
    }
    ~PersonDatabase()
    {
        //beírni a fájlba?
    }
    //list?
  
}
