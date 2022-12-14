using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RegisteredUser : Person
{

    static Reserve tableList = new Reserve();
    int privilege = 1;
    string phoneNumber = null;
    string address = null;
    int Discount = 0;
    List<List<Food>> orderList = new List<List<Food>>();
    // rendelések listázása
    public RegisteredUser(string name, string email, string password) : base(name, email, password) { }

    public override void inputAction()
    {
        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1 - View the Menu");
        Console.WriteLine("2 - Change credentials");
        Console.WriteLine("3 - View the Information about the restaurant");
        Console.WriteLine("4 - Order food");
        Console.WriteLine("5 - Reserve table");
        Console.WriteLine("6 - Logout");
        Console.WriteLine("7 - Exit");

        Console.WriteLine("Input the chosen number: ");
        int op = Convert.ToInt32(Console.ReadLine());

        while (op < 1 || op > 7)
            op = Convert.ToInt32(Console.ReadLine());

        Choice(op);
    }

    public void Choice(int number)
    {

        switch (number)
        {
            case 1:
                {
                    //Listing the menu
                    Menu menu = new Menu();
                    Console.WriteLine("-------------------------------------------------------");
                    menu.listFood();
                    break;
                }

            case 2:
                {
                    //Change data
                    Console.WriteLine("-------------------------------------------------------");
                    dataChange();
                    break;
                }

            case 3:
                {
                    //View res info
                    getInfo();
                    break;
                }


            case 4:
                {
                    //order Food
                    if (phoneNumber == null || address == null)
                    {
                        Console.WriteLine("-------------------------------------------------------");
                        Console.WriteLine("Please give your data first!");
                        break;
                    }
                    Console.WriteLine("-------------------------------------------------------");
                    orderFood();
                    break;
                }

            case 5:
                {
                    Console.WriteLine("-------------------------------------------------------");
                    tableList.reserveTable();

                    break;
                }
            case 6:
                {
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                    Environment.Exit(0);
                    break;
                }
            case 7:
                {
                    Environment.Exit(0);
                    break;
                }

            default:
                {
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine("Wrong number, try again.");
                    break;
                }
        }
        inputAction();
    }


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
    public override int getPrivilege()
    {
        return privilege;
    }

    public void setDiscount(int dc)
    {
        this.Discount = dc;
    }

    public int getDiscount()
    {
        return this.Discount;
    }

    public void orderFood()
    {
        List<Food> tmp = new List<Food>();
        Menu currentMenu = new Menu();
        currentMenu.listFood();
        int price = 0;
        Console.WriteLine($"Your Discount is: {UserDiscount()}");
        Console.Write("Please type the id of the food you would like to order: ");

        int input = Convert.ToInt32(Console.ReadLine());
        Food back = currentMenu.getFood(input);
        price += back.getPrice();

        while (back == null)
        {
            Console.Write("Wrong choice, choose again: ");
            input = Convert.ToInt32(Console.ReadLine());
            back = currentMenu.getFood(input);
        }

        tmp.Add(back);

        int option;
        do
        {
            Console.Write("Would you like to choose anything else? (1:yes, 2:no): ");

            option = Convert.ToInt32(Console.ReadLine());

            while (option < 1 || option > 2)
                option = Convert.ToInt32(Console.ReadLine());


            if (option == 1)
            {
                Console.Write("Please type the id of the food you would like to order: ");

                input = Convert.ToInt32(Console.ReadLine());
                back = currentMenu.getFood(option);

                while (back == null)
                {
                    Console.Write("Wrong choice, choose again: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    back = currentMenu.getFood(input);
                }

                price += back.getPrice();
                tmp.Add(back);
            }
        } while (!option.Equals(2));

        orderList.Add(tmp);
        int sum = 0;
        File.AppendAllText("orders.txt", "\n" + getName() + ",");
        for (int i = 0; i < tmp.Count; i++)
        {
            File.AppendAllText("orders.txt", tmp[i].getName() + ",");
            sum += tmp[i].getPrice();
        }

        int disc = useDiscount();
        sum -= disc;

        int dc = sum / 100;
        setDiscount(dc);
        File.AppendAllText("discount.txt", "\n" + this.name + "," + this.Discount);

        setDiscount(dc);
        Console.WriteLine($"\nYou have {UserDiscount()} points as discount!");


        
        File.AppendAllText("orders.txt", Convert.ToString(price-disc));


        Console.WriteLine("Your payment will be: " + (price-disc));
        Console.WriteLine("Delivery address: " + getAddress());
        Console.WriteLine("The delivery guy will call you on this number: " + getPhoneNumber());

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

    private int useDiscount()
    {
        Console.WriteLine("Would you like to use your discounts? (1: yes,2: no)");
        int choice=Convert.ToInt32(Console.ReadLine());
        int used = 0;
        if (choice == 1)
        {
            Console.WriteLine("How many points would you like to use? (Every point is worth 50 Ft)");
            used = Convert.ToInt32(Console.ReadLine());
        }
        setDiscount(getDiscount() - used);
        return used*50;
    }

    public int UserDiscount()
    {
        string[] s = File.ReadAllLines("discount.txt");
        
        for(int i = 0; i < s.Length;i ++)
        {
            string [] splitted = s[i].Split(',');
            if (splitted[0] == getName())
            {
                return getDiscount();
            }          
        }
        return 0;
    }

}

