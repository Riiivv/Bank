using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Bank.DataTransferObject
{
    public class Account
    {
        private decimal balance;
        private const decimal MinimumBalance = 100.0m;

        public AccountOwner Owner { get; private set; }
        public AccountAdmin Admin { get; private set; }

        public Account(AccountOwner owner, AccountAdmin admin, decimal initialDeposit)
        {
            if (initialDeposit >= MinimumBalance)
            {
                Owner = owner;
                Admin = admin;
                balance = initialDeposit;
            }
            else
            {
                throw new ArgumentException($"Startbalancen skal være mindst {MinimumBalance} kr.");
            }
        }

        private string GetUpdateMessage()
        {
            return $"Din konto er blevet opdateret. Der står nu kr. {balance}";
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Indsat {amount} kr. {GetUpdateMessage()}");
            }
            else
            {
                Console.WriteLine("Indsætningsbeløbet skal være positivt.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0)
            {
                if (balance - amount >= MinimumBalance)
                {
                    balance -= amount;
                    Console.WriteLine($"Trukket {amount} kr. {GetUpdateMessage()}");
                }
                else
                {
                    Console.WriteLine("Ikke tilstrækkelig saldo til denne transaktion.");
                }
            }
            else
            {
                Console.WriteLine("Udbetalingsbeløbet skal være positivt.");
            }
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }
}


