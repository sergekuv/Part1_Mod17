using System;

namespace Task_17_6_6_Option3
{
    class Program
    {
        static void Main(string[] args)
        {
            Account salaryAccount = new("Зарплатный", 999);
            Calculator.CalculateInterest(salaryAccount);
            salaryAccount.ShowInfo();

            Account generalAccount = new("Обычный", 999);
            Calculator.CalculateInterest(generalAccount);
            generalAccount.ShowInfo();


            Console.WriteLine("-- end --");
        }
    }
    public class Account
    {
        public string Type { get; set; }
        public double Balance { get; set; }
        public double Interest { get; set; }
         public Account(string type, double initBalance)
        {
            Type = type;
            Balance = initBalance;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Type: {Type}; Balance: {Balance}; Interest: {Interest}");
        }
    }
}
