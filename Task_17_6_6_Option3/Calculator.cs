using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_17_6_6_Option3
{
    public static class Calculator
    {
        public static void CalculateInterest(Account account)
        {
            if (!RatesByAccountType.ratesDictionary.ContainsKey(account.Type))
            {
                Console.WriteLine("No Interest for this account type was found in dictionary");
                return;
            }

            // ВОспроизводим логику алгоритма, предложенного в задаче 17.6.4
            InterestRates rateInfo = RatesByAccountType.ratesDictionary[account.Type];
            double interest = account.Balance * rateInfo.baseRate;
            if (rateInfo.Rates != null && rateInfo.Rates.Count > 0)
            {
                foreach (RateGrade grade in rateInfo.Rates)
                {
                    if (account.Balance >= grade.MinValue && account.Balance < grade.MaxValue)
                    {
                        interest -= account.Balance * grade.Rate;
                    }
                }
            }
            account.Interest = interest;
        }
    }
}
