using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_17_6_6_Option3
{
    public class InterestRates
    {
        public double baseRate;
        public List<RateGrade> Rates;
    }

    public class RateGrade
    {
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double Rate { get; set; }
        public RateGrade(double minValue, double maxValue, double rate)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Rate = rate;
        }
    }

    public static class RatesByAccountType
    {
        public static Dictionary<string, InterestRates> ratesDictionary;
        static RatesByAccountType()     
        {
            ReadRatesFromSomewhere();
        }

        private static void ReadRatesFromSomewhere()    // Этот список нужно где-то хранить и обеспечивать его загрузку при старте и добавление/удаление, 
                                                        // чтобы можно было добавлять новые типы счетов и процентные ставки; 
                                                        // тогда для изменения параметров калькулятора не потребуется изменять код приложения  
        {
            ratesDictionary = new();
            ratesDictionary.Add("Зарплатный", new InterestRates());
            ratesDictionary["Зарплатный"].baseRate = 0.5;
            // для Зарплатного счета список можно оставить пустым - проwент не зависит от суммы на счете
            ratesDictionary.Add("Обычный", new InterestRates());
            ratesDictionary["Обычный"].baseRate = 0.4;
            ratesDictionary["Обычный"].Rates = new();
            ratesDictionary["Обычный"].Rates.Add(new RateGrade(0, 1000, 0.2));
            ratesDictionary["Обычный"].Rates.Add(new RateGrade(0, 50000, 0.4));

        }
    }

}
