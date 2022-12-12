using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class UserList
{
    //Kell-e?
    /*a mainben bejelentkezésnél behúzni, hogy tartalmazza-e*/
    private List<Person> personList = new List<Person>();
    public UserList()
    {
        // beolvassa a fájból az embereket adatokkal együtt
        FileStream f = new FileStream("users.txt", FileMode.Open);
        StreamReader sr = new StreamReader(f);
        while(!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            string[] spl = line.Split(",");

            //Boti old meg  thx :)
            //Person tmp=new Person();
            //personList.Add(tmp);
        }
        sr.Close();
        f.Close();
    }
    ~UserList()
    {
        //kiírja őket ha vége a progamnak
        FileStream fs = new FileStream("users.txt", FileMode.Append);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(personList[0].Name);
        sw.Close();
        fs.Close();
    }
    public void addPerson(Person p1)
    {
        personList.Add(p1);
    }
}

