using System;
using System.Collections.Generic;

public class Menu
{
	private List<Food> foodList = new List<Food>();
	public Menu()
	{

	}



	public void listFood()
    {
		for(int i =0;i< foodList.Count();i++)
        {
            Console.Write(foodList[i].getName());
			Console.Write(foodList[i].getPrice());
			Console.Write(foodList[i].getId());
			Console.WriteLine(); 
		}
    }

	public void editMenu()
	{
		Console.WriteLine("How would you like to edit the menu?");
		Console.WriteLine("1 - Adding a new item");
		Console.WriteLine("2 - Updating an existing item");
		Console.WriteLine("3 - Delete an item");

		Console.WriteLine("Chosen number: ");
		int num=Convert.ToInt32(Console.ReadLine());

		while (num < 1 && num > 3)
		{
			switch (num)
			{
				case 1:
					{
						//Add
						addItem();
						break;
					}

				case 2:
					{
						//Update
						updateItem();
						break;
					}

				case 3:
					{
						//Delete
						deleteItem();
						break;
					}

				default:
					{
						//Else
						Console.WriteLine("Wrong choice, try again.");
						break;
					}
			}
		}
	}

	private void addItem()
    {
		Console.WriteLine("Give the name of the new food:");

		string newName = Console.ReadLine();

		Console.WriteLine("Give the price of the new food:");

		int newPrice = Convert.ToInt32(Console.ReadLine());

		Food newFood = new Food(newName, newPrice);
		foodList.Add(newFood);
    }
	private void updateItem()
    {
		Console.WriteLine("Please choose which item would you like to update:");

		listFood();

		int inputId = Convert.ToInt32(Console.ReadLine());

		Console.WriteLine("Please choose what would you like to update:");
		Console.WriteLine("1: Name");
		Console.WriteLine("2: Price");
		Console.WriteLine("3: Both");

		int idx = 0;
		Food myFood = new Food(" ", 0);

		for (int i = 0;i< foodList.Count(); i++)
        {
			if (foodList[i].getId() == inputId)
            {
				myFood = foodList[i];
				idx = i;
			}
				
				
        }

		int option = Convert.ToInt32(Console.ReadLine());

		switch (option)
		{
			case 1:
				{
					Console.WriteLine("Please give the new name:");
					string newName = Console.ReadLine();
					myFood.setName(newName);
					break;
				}
			case 2:
                {
					Console.WriteLine("Please give the new price:");
					int newPrice = Convert.ToInt32(Console.ReadLine());
					myFood.setPrice(newPrice);
					break;
                }
			case 3:
                {
					Console.WriteLine("Please give the new name:");
					string newName = Console.ReadLine();
					myFood.setName(newName);
					Console.WriteLine("Please give the new price:");
					int newPrice = Convert.ToInt32(Console.ReadLine());
					myFood.setPrice(newPrice);
					break;
				}
            default:
                {
					Console.WriteLine("No option has been selected!");
					break;
                }
		}
		foodList[idx] = myFood;
	}
	private void deleteItem()
    {
		Console.WriteLine("Please choose which food to delete:");

		listFood();

		int idx = Convert.ToInt32(Console.ReadLine());
		foodList.RemoveAt(idx);
	}
	public int getPrice(string name)
    {
		for(int i =0;i<foodList.Count;i++)
        {
			if (foodList[i].getName() == name)
				return foodList[i].getPrice();
        }
		return 0;
    }
}
