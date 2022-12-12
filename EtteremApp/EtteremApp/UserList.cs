using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class UserList
{
    private List<Person> personList = new List<Person>();
    public UserList()
    {
        // beolvassa a fájból az embereket adatokkal együtt
        FileStream f = new FileStream("users.txt", FileMode.Append);
        StreamReader sr = new StreamReader(f);
        while(!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            string[] spl = line.Split(",");
            //Person tmp=new Person(spl[0], spl[0], spl[0]);
            //personList.Add(tmp);
        }
            
    }
    ~UserList()
    {
        //kiírja őket ha vége a progamnak
        FileStream fs = new FileStream("users.txt", FileMode.Create);
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

