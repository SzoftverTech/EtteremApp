using System;

public abstract class Person
{
	protected string name;
	protected string email;
	protected string password;
	public Person(string name, string email, string password)
	{
		this.name = name;
		this.email = email;
		this.password = password;
	}
	public string Name { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }

	public void login()
	{
		//...
	}
	public void getInfo()
    {
		Console.WriteLine("Welcome to our restaurant!");
		Console.WriteLine("Contacts:");
		Console.WriteLine("Email: restaurant@gmail.com");
		Console.WriteLine("Mobile: 062012345679");
    }
	public void modifyMenu(Menu m1) { }
}
