using System;

public class Manager : Person
{
    int privilege = 3;
    public Manager(string name, string email, string password) : base(name, email, password) { }

    public override void inputAction()
    {
        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1 - View the Menu");
        Console.WriteLine("2 - Edit the Menu");
        Console.WriteLine("3 - View the information about the restaurant");
        Console.WriteLine("4 - Show statistics");
        Console.WriteLine("5 - Edit customer data");
        Console.WriteLine("6 - Logout");
        Console.WriteLine("7 - Exit");

        Console.Write("Input the chosen number: ");
        int op = Convert.ToInt32(Console.ReadLine());

        while (op < 1 || op > 7)
            op = Convert.ToInt32(Console.ReadLine());

        Choice(op);
    }

    public override int getPrivilege()
    {
        return privilege;
    }
    public void Choice(int number)
    {
        //read the current menu
        Menu menu = new Menu();

        switch (number)
        {
            case 1:
                {
                    //Listing the menu
                    Console.WriteLine("-------------------------------------------------------");
                    menu.listFood();
                    break;
                }

            case 2:
                {
                    //Editing menu
                    Console.WriteLine("-------------------------------------------------------");
                    menu.editMenu();
                    break;
                }

            case 3:
                {
                    //View restaurant info
                    getInfo();
                    break;
                }

            case 4:
                {
                    //Show statistics
                    Console.WriteLine("-------------------------------------------------------");
                    Statistics stat=new Statistics();
                    stat.showAveragePrice();
                    stat.showRegisteredUsers();
                    break;
                }

            case 5:
                {
                    Console.WriteLine("-------------------------------------------------------");
                    List<Person> tmp = Process();
                    Console.Write("Select a customer by ID: ");
                    ListUsersForChoose(tmp);
                    Console.Write($"Selected id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    if (id < 0 || id > tmp.Count)
                    {
                        Console.WriteLine("Invalid ID!");
                    }
                    else
                    {
                        Console.WriteLine("What data to edit? (name,email,password)");
                        string hlp = Console.ReadLine();
                        switch (hlp)
                        {
                            case "name":
                                {
                                    Console.WriteLine("What is the new name?");
                                    string hname = Console.ReadLine();
                                    tmp[id].setName(hname);
                                    break;
                                }
                            case "email":
                                {
                                    Console.WriteLine("What is the new email?");
                                    string hemail = Console.ReadLine();
                                    tmp[id].setEmail(hemail);
                                    break;
                                }
                            case "password":
                                {
                                    Console.WriteLine("What is the new password?");
                                    string hpass = Console.ReadLine();
                                    tmp[id].setPassword(hpass);
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Invalid property!");
                                    break;
                                }
                        }
                        WriteNewUsers(tmp);
                        Console.WriteLine("Name property has been set for the user!");
                    }
                    break;
                }

            case 6:
                {
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                    Environment.Exit(0);
                    break;
                }

            case 7:
                {
                    Environment.Exit(0);
                    break;
                }

            default:
                {
                    Console.WriteLine("Wrong number, try again.");
                    break;
                }
        }
        inputAction();
    }


    private List<Person> Process()
    {
        List<Person> tmp = new List<Person>();
        string[] read = File.ReadAllLines("users.txt");
        for (int i = 0; i < read.Length; i++)
        {
            string[] splitted = read[i].Split(',');
            //name,email,pass 
            int privilege = 0;
            string name, mail, pass;
            name = splitted[0];
            mail = splitted[1];
            pass = splitted[2];
            privilege = Convert.ToInt32(splitted[3]);
            switch (privilege)
            {
                case 1:
                    {
                        tmp.Add(new RegisteredUser(name, mail, pass));
                        break;
                    }
                case 2:
                    {
                        tmp.Add(new Worker(name, mail, pass));
                        break;
                    }
                case 3:
                    {
                        tmp.Add(new Manager(name, mail, pass));
                        break;
                    }

            }
            
        }
        return tmp;


    }
    private void ListUsersForChoose(List<Person> tmp)
    {
        for (int i = 0; i < tmp.Count(); i++)
        {
            Console.WriteLine($"{i}. {tmp[i].getName()}");
        }
    }

    private void WriteNewUsers(List<Person> hlper)
    {
        string[] tofile = new string[hlper.Count];

        for (int i = 0; i < hlper.Count; i++)
            tofile[i] = hlper[i].getName() + "," + hlper[i].getEmail() + "," + hlper[i].getPassword() + "," + hlper[i].getPrivilege();

        File.WriteAllLines("users.txt", tofile);
    }
}
