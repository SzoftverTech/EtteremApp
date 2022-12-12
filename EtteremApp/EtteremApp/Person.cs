using System;

public abstract class Person
{
	protected string name;
	protected string email;
	protected string password;
	protected int privilege;
	public Person(string name, string email, string password)
	{
		this.name = name;
		this.email = email;
		this.password = password;
	}
	public Person() { }
	public string getName()
    {
		return name;
    }
	public string getPassword()
    {
		return password;
    }
	public string getEmail()
    {
		return email;
    }
	public void setName(string name)
    {
		this.name = name;
    }
	public void setPassword(string password)
	{
		this.password = password;
	}
	public void setEmail(string email)
	{
		this.email = email;
	}
	public abstract int getPrivilege();
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
	public abstract void inputAction();
}
