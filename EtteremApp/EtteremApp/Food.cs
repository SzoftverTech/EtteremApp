using System;

public class Food
{
	private string name;

	 int price {  get;  set; }

	public Food(string name, int price)
	{
		this.name = name;
		this.price = price;
	}
	public string getName()
    {
		return name;
    }
}
