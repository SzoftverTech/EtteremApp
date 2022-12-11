// See https://aka.ms/new-console-template for more information
class main {
    static void Main(string[] args)
    {
        int input = 0;
        Console.WriteLine("Please choose a menu item:");
        input = Convert.ToInt32(Console.ReadLine);
        while(input != 99)
        {
            Console.WriteLine("1: Register");
            Console.WriteLine("");
        }
    }
}