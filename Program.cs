using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
class Bank
{
    decimal balanse;
    string username;
    string nambercheck;
    public Bank() 
    {
        nambercheck = "0000-0000";
        username = "Неизвестный";
        balanse = 0.0m;
    }
    public Bank(string x, string y, decimal z) 
    {
        nambercheck = x;
        username = y;
        balanse = z;
    }
    public decimal CheckBalanse() 
    {
        return balanse;
    }
    public decimal ReplenishmentOfBalance(decimal z) 
    {
        balanse += z;
        return balanse;
    }
    public decimal DebitFromScore(decimal z) 
    {
        balanse -= z;
        return balanse;
    }
    public void MoneyTransfer(Bank a, decimal x) 
    {
        if (x < 0) 
        {
           Console.WriteLine("Сумма должна быть положительной.");
        }
        else if (balanse < x)
        {
            Console.WriteLine("Недостаточно средств для перевода.");
        }
        else if(balanse > x && x > 0)
        {
            balanse -= x;
            a.ReplenishmentOfBalance(x); 
        }
    }
    public void getAccount() 
    {
        Console.WriteLine($"Номер счета: {nambercheck}, Владелец: {username}");
    }

}

class Program 
{
    static void Main() 
    {
        Bank myAccount = new Bank("1234-5678", "Зачиняев Владимир Андреевич", 1000.0m);
            myAccount.getAccount();
        while (true)
        {
            Console.WriteLine("\nВыберите операцию:");
            Console.WriteLine("1. Положить на счет");
            Console.WriteLine("2. Снять со счета");
            Console.WriteLine("3. Узнать баланс");
            Console.WriteLine("4. Перевести на другой счет");
            Console.WriteLine("5. Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите сумму для пополнения: ");
                    decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                    myAccount.ReplenishmentOfBalance(depositAmount);
                    break;

                case "2":
                    Console.Write("Введите сумму для снятия: ");
                    decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                    myAccount.DebitFromScore(withdrawAmount);
                    break;

                case "3":
                    Console.WriteLine($"Текущий баланс: {myAccount.CheckBalanse()}");
                    break;

                case "4":
                    Console.Write("Введите номер счета для перевода: ");
                    string targetAccountNumber = Console.ReadLine();

                    Console.Write("Введите сумму для перевода: ");
                    decimal transferAmount = Convert.ToDecimal(Console.ReadLine());

                    Bank targetAccount = new Bank(targetAccountNumber, "Тимофеев Максим", 500.0m);
                    myAccount.MoneyTransfer(targetAccount, transferAmount);
                    Console.WriteLine($"Перевод на сумму {transferAmount} был выполнен успешно.");
                    break;

                case "5":
                    Console.WriteLine("Выход из программы.");
                    return;

                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, попробуйте снова.");
                    break;


            }
        }
    }   
}