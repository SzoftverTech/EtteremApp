// See https://aka.ms/new-console-template for more information
class main {
    static void Main(string[] args)
    {
        int input;
        int privilege = 0;
        

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
                        Console.WriteLine("Please give your username");
                        string username = Console.ReadLine();
                        Console.WriteLine("Please give your password");
                        string password = Console.ReadLine();
                        privilege = findUser(username, password);

                        break;
                    }
                case 2:
                    {
                        Guest g1 = new Guest();
                        g1.inputAction();
                        break;
                    }

            }
        } while (input != 1 || input != 2 || input != 99);
    }
    static public int findUser(string username,string password)
    {
        try
        {
            FileStream fs = new FileStream("users.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            for (int i = 0; sr.EndOfStream != false; i++)
            {
                string line = sr.ReadLine();
                string[] split = line.Split(',');
                if (split[0] == username && split[1] == password)
                {
                    return Convert.ToInt32(split[2]);
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