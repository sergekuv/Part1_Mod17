using System;

namespace Task_17_6_4_SF
{
    // Это код, предложенный изначально в задаче 17.6.4 
    // На мой взгляд, калькулятор выглядит странновато: 
    // попробуйте посчитать проценты для обычного вклада менее 1000 - Interest получится отрицательным, 
    // и пользователь теряет тем больше, чем больше сумма вклада. Авторы примера действительно это имели в виду??
    // кроме того, Interest в описании класса описан как "процентная ставка", но на самом деле это не ставка, а что-то похожее не сумму начисленных процентов
    class Program
    {
        static void Main(string[] args)
        {

            Account salaryAcct = new();
            salaryAcct.Balance = 999;
            salaryAcct.Type = "Зарплатный";
            Calculator.CalculateInterest(salaryAcct);
            Console.WriteLine($"Type: {salaryAcct.Type}; Balance = {salaryAcct.Balance};  Interest = {salaryAcct.Interest}");

            Account generalAcct = new();
            generalAcct.Balance = 999;
            generalAcct.Type = "Обычный";
            Calculator.CalculateInterest(generalAcct);
            Console.WriteLine($"Type: {generalAcct.Type}; Balance = {generalAcct.Balance};  Interest = {generalAcct.Interest}");

            Console.WriteLine("-- end --");

        }
    }

    public class Account
    {
        // тип учетной записи
        public string Type { get; set; }

        // баланс учетной записи
        public double Balance { get; set; }

        // процентная ставка
        public double Interest { get; set; }
    }
    public static class Calculator
    {
        // Метод для расчета процентной ставки
        public static void CalculateInterest(Account account)
        {
            if (account.Type == "Обычный")
            {
                // расчет процентной ставки обычного аккаунта по правилам банка
                account.Interest = account.Balance * 0.4;

                if (account.Balance < 1000)
                    account.Interest -= account.Balance * 0.2;

                if (account.Balance < 50000)
                    account.Interest -= account.Balance * 0.4;
            }
            else if (account.Type == "Зарплатный")
            {
                // расчет процентной ставк зарплатного аккаунта по правилам банка
                account.Interest = account.Balance * 0.5;
            }
        }
    }
}
