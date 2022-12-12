// See https://aka.ms/new-console-template for more information
class main {
    static void Main(string[] args)
    {
        UserList userList = new UserList();
        Guest g1 = new Guest("","","");
        int input;
        do
        {
            Console.WriteLine("Please choose a menu item:");
            Console.WriteLine("1: Register");
            Console.WriteLine("2: Login");
            Console.WriteLine("3: View Contacts");
            Console.WriteLine("99: Exit");
            input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    {
                        g1.register(userList);
                        break;
                    }
                case 3:
                    {
                        g1.getInfo();
                        break;
                    }

            }
        } while (input != 99);
    }
}