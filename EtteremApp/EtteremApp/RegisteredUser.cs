using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RegisteredUser : Person
{
    string phoneNumber;
    string address;
    List<List<Food>> orderList = new List<List<Food>>();
    public RegisteredUser(string name, string email, string password) : base(name, email, password) { }


    private string getAddress()
    {
        return address;
    }

    private void setAddress()
    {
        Console.Write("Please add your address: ");
        address = Console.ReadLine();
    }

    private string getPhoneNumber()
    {
        return phoneNumber;
    }

    private void setPhoneNumber()
    {
        Console.Write("Please add your phone number: ");
        phoneNumber = Console.ReadLine();
    }



    public void orderFood()
    {
        List<Food> tmp=new List<Food>();
        Menu currentMenu = new Menu();
        currentMenu.listFood();

        Console.Write("Please type the id of the food you would like to order: ");

        int input = Convert.ToInt32(Console.ReadLine());
        Food back = currentMenu.getFood(input);

        while(back == null)
        {
            Console.Write("Wrong choice, choose again: ");
            input = Convert.ToInt32(Console.ReadLine());
            back = currentMenu.getFood(input);
        }

        tmp.Add(back);


        do
        {
            Console.Write("Would you like to choose anything else? (1:yes, 2:no): ");
            int option = Convert.ToInt32(Console.ReadLine());
            if (option == 1)
            {
                Console.Write("Please type the id of the food you would like to order: ");

                input = Convert.ToInt32(Console.ReadLine());
                back = currentMenu.getFood(input);

                while (back == null)
                {
                    Console.Write("Wrong choice, choose again: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    back = currentMenu.getFood(input);
                }

                tmp.Add(back);
            }
        } while (!input.Equals(2));

        orderList.Add(tmp);


        Console.WriteLine("Delivery address: "+getAddress());
        Console.WriteLine("The delivery guy will call you on this number: "+getPhoneNumber());
        
        Console.WriteLine("Thank you for your order!");
    }

    public void dataChange()
    {
        Console.Write("Would you like to change your phone number? (y or n) ");
        char res = Convert.ToChar(Console.ReadLine());
        if (res == 'y')
            setPhoneNumber();

        Console.Write("Would you like to change your address? (y or n) ");
        res = Convert.ToChar(Console.ReadLine());
        if (res == 'y')
            setAddress();
    }
}

