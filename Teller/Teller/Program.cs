using System;
using Teller.models;

namespace Teller
{
    class Program
    {
        static void Main(string[] args)
        {
            BankTeller teller = new BankTeller();
            teller.GetInterest();
        }
    }
}
