using System;

class User
{
    private string login;
    private string firstName;
    private string lastName;
    private int age;
    private readonly DateTime registrationDate;

    public User(string login, string firstName, string lastName, int age)
    {
        this.login = login;
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.registrationDate = DateTime.Now;
    }

    public void DisplayUserInfo()
    {
        Console.WriteLine($"User Information:");
        Console.WriteLine($"Login: {login}");
        Console.WriteLine($"First Name: {firstName}");
        Console.WriteLine($"Last Name: {lastName}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Registration Date: {registrationDate}");
    }
}

class Program
{
    static void Main()
    {
        User user = new User("john_doe", "John", "Doe", 25);
        user.DisplayUserInfo();
    }
}
