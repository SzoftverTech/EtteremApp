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
		Console.WriteLine("Üdvözöljük az étteremben!");
		Console.WriteLine("Elérhetőségek:");
    }
}
