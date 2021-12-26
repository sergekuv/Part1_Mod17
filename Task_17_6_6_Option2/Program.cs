using System;

namespace Task_17_6_6_Option2
{
    class Program
    {
        /// <summary>
        /// Труlно предложить оптимальное решение только на основе информации, представленной в 17.6.4
        /// В этом варианте есть статический калькулятор, принимающий интерфейс, но я не уверен, что это лучшее решение из приведенных
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Account salAcct = new SalaryTypeAccount(999);
            Calculator.CalculateInterest(salAcct);
            salAcct.ShowInfo();

            GeneralTypeAccount genAcct = new(999);
            Calculator.CalculateInterest(genAcct);
            genAcct.ShowInfo();

            Console.WriteLine("-- end --");
        }
    }

    public interface ICalculateInterest
    {
        void CalculateInterest();
    }

    public abstract class Account : ICalculateInterest
    {
        public double Balance { get; set; }
        public double Interest { get; set; }    
        protected Account(double initBalance) => Balance = initBalance;
        public void ShowInfo() => Console.WriteLine($"Balance: {Balance}; Interest: {Interest}");
        public abstract void CalculateInterest();
    }

    public class GeneralTypeAccount : Account
    {
        public GeneralTypeAccount(double initBalance) : base(initBalance) { }
        public override void CalculateInterest()
        {
            Interest = Balance * 0.4;
            if (Balance < 1000)
                Interest -= Balance * 0.2;

            if (Balance < 50000)
                Interest -= Balance * 0.4;
        }

    }

    public class SalaryTypeAccount : Account
    {
        public SalaryTypeAccount(double initBalance) : base(initBalance) { }
        public override void CalculateInterest()  => Interest = Balance * 0.5;
    }

    public static class Calculator
    {
        public static void CalculateInterest (ICalculateInterest acct) => acct.CalculateInterest();
    }
}
