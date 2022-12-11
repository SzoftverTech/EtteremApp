using System;
using System.Collections.Generic;

public class Menu
{
	public List<Food> foodList = new List<Food>();
	public Menu()
	{

	}
	public void listFood()
    {
		for(int i =0;i< foodList.Count();i++)
        {
            Console.WriteLine(foodList[i].getName());
        }
    }
}
