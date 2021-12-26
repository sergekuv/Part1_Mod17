using System;

namespace Task_17_6_6_Option1
{
    class Program
    {
        /// <summary>
        /// Труlно предложить оптимальное решение только на основе информации, представленной в 17.6.4
        /// Из того, что дано, я бы сделал вывод, что статический калькулятор вообще не нужен, и расчет суммы процентов вполне можно 
        /// перенести непостедственно в класс "конкретный счет". В этом примере сделано именно так
        /// Чтобы не хранить коэффициенты, стоит сделать либо общий справочник (как в варианте 3), либо свой для каждого типа счета
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Account salAcct = new SalaryTypeAccount(999);
            salAcct.ShowInfo();
            GeneralTypeAccount genAcct = new(999);
            genAcct.ShowInfo();

            Console.WriteLine("-- end --");
        }
    }
    public abstract class Account
    {
        // баланс счета
        public double Balance { get; set; }
        // сумма начисленных процентов (исходя из того, что написано в 17.6.4)
        public abstract double Interest { get; }    // Если пытаться использовать логику, приведенную в 17.6.4, set тут вообще не нужен, 
                                                    // а в get дочерних классов можно поместить логику рассчета этого значения
                                                    // но с реальной жизнью такая схема, конечно, не имеет ничего общего  
        protected Account(double initBalance) => Balance = initBalance;
        public void ShowInfo() => Console.WriteLine($"Balance: {Balance}; Interest: {Interest}");
    }

    public class GeneralTypeAccount : Account
    {
        public GeneralTypeAccount(double initBalance) : base(initBalance) { }
        public override double Interest         // воспроизможу странную логику, реализованную в 17.6.4
        {
            get
            {
                double _interest = Balance * 0.4;
                if (Balance < 1000)
                    _interest -= Balance * 0.2;

                if (Balance < 50000)
                    _interest -= Balance * 0.4;

                return _interest;
            }
        }
    }

    public class SalaryTypeAccount : Account
    {
        public SalaryTypeAccount(double initBalance) : base(initBalance) { }
        public override double Interest { get => Balance * 0.5; }
    }
}
