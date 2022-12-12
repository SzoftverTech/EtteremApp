// See https://aka.ms/new-console-template for more information
class main {
    static void Main(string[] args)
    {
        int input = 0;
        int privilege = 0;
        string username = null;
        string password = null;
        string email = null;
        

            Console.WriteLine("Please select an option:");
            Console.WriteLine("1: Login");
            Console.WriteLine("2: Continue as guest");
            Console.WriteLine("99: Exit");
        do
        {
                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            Console.WriteLine("Please give your email:");
                            email = Console.ReadLine();
                            Console.WriteLine("Please give your username:");
                            username = Console.ReadLine();
                            Console.WriteLine("Please give your password:");
                            password = Console.ReadLine();

                            privilege = findUser(username, password, email);

                            break;
                        }
                    case 2:
                        {
                            Guest g1 = new Guest();
                            g1.inputAction();
                            break;
                        }

                }
            break;
        } while (input != 1 || input != 2 || input != 99);


        switch(privilege)
        {
            //registered user
            case 1:
                {
                    RegisteredUser r1 = new RegisteredUser(username, password, email);
                    r1.inputAction();
                    break;
                }
            //worker
            case 2:
                {
                    break;
                }
            //manager
            case 3:
                {
                    Manager m1 = new Manager(username,password, email);
                    m1.inputAction();
                    break;
                }
        }
    }
    static public int findUser(string username,string password, string email)
    {
        try
        {
            FileStream fs = new FileStream("users.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            for (int i = 0; sr.EndOfStream != true; i++)
            {
                string line = sr.ReadLine();
                string[] split = line.Split(',');
                if (split[0] == username && split[1] == email && split[2] == password)
                {
                    Console.WriteLine("Logged in.");
                    sr.Close();
                    return Convert.ToInt32(split[3]);
                }
            }
            Console.WriteLine("User not found");
            return 0;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found!");
            return 0;
        }
    }
}