﻿using System;
using System.Collections.Generic;

public class Menu
{
	private Dictionary<int,Food> foodDict= new Dictionary<int,Food>();
	public Menu()
	{
		input();
	}

	public void listFood()
    {
		int i = 1;
		foreach (Food food in foodDict.Values)
		{
			Console.WriteLine(i + " " + food.getName() + " " + food.getPrice());
			i++;
		}
    }

	public void editMenu()
	{
        Console.WriteLine("How would you like to edit the menu?");
		Console.WriteLine("1 - Adding a new item");
		Console.WriteLine("2 - Updating an existing item");
		Console.WriteLine("3 - Delete an item");

		Console.Write("Chosen number: ");

		int num = Convert.ToInt32(Console.ReadLine());

		while (num < 1 || num > 3)
			num = Convert.ToInt32(Console.ReadLine());


		switch (num)
			{
				case 1:
					{
                    //Add
                    Console.WriteLine("-------------------------------------------------------");
                    addItem();
						break;
					}

				case 2:
					{
                    //Update
                    Console.WriteLine("-------------------------------------------------------");
                    updateItem();
						break;
					}

				case 3:
					{
                    //Delete
                    Console.WriteLine("-------------------------------------------------------");
                    deleteItem();
						break;
					}

				default:
					{
                    //Else
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine("Wrong choice, try again.");
						break;
					}
			}
		
	}



	private void updateItem()
    {
        Console.WriteLine("-------------------------------------------------------");
		listFood();
        Console.WriteLine("-------------------------------------------------------");
        Console.Write("Please choose which item would you like to change: ");
        int inputId = Convert.ToInt32(Console.ReadLine());
		
		while(!foodDict.ContainsKey(inputId))
		{
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Wrong number, please choose one thats in the list!");

            Console.Write("Please choose which item would you like to update: ");
            inputId = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("Please choose what would you like to update:");
		Console.WriteLine("1: Name");
		Console.WriteLine("2: Price");
		Console.WriteLine("3: Both");

		
		
		Food myFood = foodDict[inputId];

		int option = Convert.ToInt32(Console.ReadLine());

		switch (option)
		{
			case 1:
				{
                    Console.WriteLine("-------------------------------------------------------");
                    Console.Write("Please give the new name: ");
					string newName = Console.ReadLine();
					myFood.setName(newName);
					break;
				}
			case 2:
                {
                    Console.WriteLine("-------------------------------------------------------");
                    Console.Write("Please give the new price: ");
					int newPrice = Convert.ToInt32(Console.ReadLine());
					myFood.setPrice(newPrice);
					break;
                }
			case 3:
                {
                    Console.WriteLine("-------------------------------------------------------");
                    Console.Write("Please give the new name: ");
					string newName = Console.ReadLine();
					myFood.setName(newName);
					Console.Write("Please give the new price: ");
					int newPrice = Convert.ToInt32(Console.ReadLine());
					myFood.setPrice(newPrice);
					break;
				}
            default:
                {
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine("No option has been selected!");
					break;
                }
		}

		foodDict[inputId] = myFood;
		listFood();
		output();
	}

	private void addItem()
	{
		Console.WriteLine("Give the name of the new food:");

		string newName = Console.ReadLine();

		Console.WriteLine("Give the price of the new food:");

		int newPrice = Convert.ToInt32(Console.ReadLine());

		Food newFood = new Food(newName, newPrice);

		foodDict.Add(foodDict.Count() + 1, newFood);
		listFood();
		output();
	}
	private void deleteItem()
    {
		Console.WriteLine("Please choose which food to delete:");

		listFood();

		int idx = Convert.ToInt32(Console.ReadLine());
		foodDict.Remove(idx);
		listFood();
		output();
	}

	public Food getFood(int id)
    {
		if(foodDict.ContainsKey(id))
			return foodDict[id];
		return null;
    }
	public void input()
    {
		string[] wholeInput = File.ReadAllLines("menu.txt");
		foreach (string input in wholeInput)
		{
			string[] temp = input.Split(',');
			string name = temp[0];
			int price = Convert.ToInt32(temp[1]);

			Food tmp = new Food(name, price);
			foodDict.Add(foodDict.Count + 1, tmp);
		}
	}
	public void output()
    {
		File.Delete("menu.txt");
		foreach (Food food in foodDict.Values)
		{
			File.AppendAllText("menu.txt", food.getName() + "," + food.getPrice() + "\n");
		}
	}
}
