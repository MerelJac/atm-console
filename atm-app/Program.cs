// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Console.WriteLine("The current time is " + DateTime.Now);
// Console.WriteLine("\n\n Press Enter to continue\n");
// Console.ReadLine();

using System;
using System.Globalization;
using System.Net;
using System.Xml.Serialization;
// object oriented programming
public class CardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    // constructor
    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    // getters
    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    // setters
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit? ");
            // TODO: put in a try catch
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit + currentUser.balance);
            Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.getBalance())
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw? ");
            double withdraw = Double.Parse(Console.ReadLine());
            // check if user has enough money
            if (currentUser.getBalance() > withdraw)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("You are good to go! Thank you :) ");
            }
        }

        void balance(CardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        // list of CardHolders - database
        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("1234567890", 1234, "John", "Griffith", 255.32));
        cardHolders.Add(new CardHolder("5746372894", 2344, "Mimi", "Jacobs", 345.41));
        cardHolders.Add(new CardHolder("6584920583", 2345, "Reagan", "Wallis", 876.54));
        cardHolders.Add(new CardHolder("1989878973", 9876, "Dylan", "Scott", 52645.23));

        // Promp user
        Console.WriteLine("Welcome to your piggy bank");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        CardHolder currentUser;
        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // check against "database"
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again.")};
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again.");
            }
        }
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // check against "database"
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again.")};
            }
            catch
            {
                Console.WriteLine("Incorrect pin. Please try again.");
            }

        }
        Console.Write("Welcome " + currentUser.getFirstName() + ":)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        } while (option != 4);
        Console.WriteLine("Thank you! Have a nice day.");

    }

}

