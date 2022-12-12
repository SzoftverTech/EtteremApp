using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UserList
{
    private List<Person> personList = new List<Person>();
    public UserList()
    {
        // beolvassa a fájból az embereket adatokkal együtt
        //StreamReader sr = new StreamReader("users.txt");
        //for (int i = 0;sr.EndOfStream != false; i++)
        //{
        //    
        //}
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

