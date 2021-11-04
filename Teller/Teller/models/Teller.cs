using System;
using System.Collections.Generic;
using System.Text;

namespace Teller.models
{
    class BankTeller
    {
        private string CustomerName { get; set; }
        private double Balance { get; set; }

        private int GetCustomerDetails()
        {
            Console.WriteLine($"Welcome to Toyin's Bank!! \nMay we please know your name?");
            this.CustomerName = Console.ReadLine();

            Console.WriteLine($"Ok {this.CustomerName}, How much would you like to deposit?");
            this.Balance = double.Parse(Console.ReadLine());

            Console.WriteLine($"\nThanks for your cooperation {this.CustomerName}, What kind of account would you like to open?");
            Console.WriteLine($"Enter the number corresponsing to your preferred account type.\n1. Savings account\n2. Coorperate account\n" +
                $"3. Fixed deposit account\n4. Kids account\n5. Current account\n6. Joint account\n");
            int userResponse = int.Parse(Console.ReadLine());

            return userResponse;
        }

        private string AccountSelector(int userChoice)
        {
            string accountType;
            switch (userChoice)
            {
                case 1:
                    accountType = "savings";
                    break;
                case 2:
                    accountType = "Coorperate";
                    break;
                case 3:
                    accountType = "fixed deposit";
                    break;
                case 4:
                    accountType = "kids";
                    break;
                case 5:
                    accountType = "current";
                    break;
                case 6:
                    accountType = "joint";
                    break;
                default:
                    accountType =  "invalid number";
                    break;

            }
            return accountType;
        }

        private double GetRate(string response)
        {
            double rate;
            switch (response.ToLower())
            {
                case "savings":
                    rate = 0.08;
                    break;
                case "Coorperate":
                    rate = 0.1;
                    break;
                case "fixed deposit":
                    rate = 0.2;
                    break;
                case "kids":
                    rate = 0.03;
                    break;
                case "current":
                    rate = 0.07;
                    break;
                case "joint":
                    rate = 0.06;
                    break;
                default:
                    rate = 0.0;
                    break;

            }
            return rate;
        }

        private double CalculateVat(double cummulativeSum)
        {
            double vat = 0.075 * cummulativeSum;
            return vat;
        }

        private double CalculateInterest(double rate, int month)
        {
            double amount =  Math.Pow(1 + rate, month) - 1.0;
            return this.Balance * amount;
        }

        public void GetInterest()
        {
            double rate = GetRate(AccountSelector(GetCustomerDetails()));
            int[] months = { 6, 9, 12, 24, 60 };

            Console.WriteLine($"Ok {this.CustomerName}, after putting your account preferences into " +
                    $"consideration\n");

            foreach (int month in months)
            {
                double sum = CalculateInterest(rate, month);
                double finalSum = this.Balance + (sum - CalculateVat(sum));

                Console.WriteLine($"You would have accrued {finalSum} at the end of the {month}th month");
            }
        }

    }
}
