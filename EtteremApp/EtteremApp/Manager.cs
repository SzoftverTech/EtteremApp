using System;

public class Manager : Person
{
    public Manager(string name, string email, string password) : base(name, email, password) { }

    void modifyMenu()
    {
        Console.WriteLine("Choose a menu item to edit");
        string food = Console.ReadLine();
    }
}
