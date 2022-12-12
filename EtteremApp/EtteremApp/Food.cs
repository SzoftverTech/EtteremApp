using System;

public class Food
{
	private string name;
	private int price;

	public Food(string name, int price)
	{
		this.name = name;
		this.price = price;
	}
	public string getName()
    {
		return name;
    }
	public int getPrice()
	{
		return price;
	}
	public void setPrice(int price)
    {
		this.price = price;
    }
	public void setName(string name)
    {
		this.name = name;
    }
}
