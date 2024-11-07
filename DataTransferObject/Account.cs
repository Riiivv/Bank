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

        public string Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                return $"Indsat {amount} kr. {GetUpdateMessage()}";
            }
            else
            {
                return "Indsætningsbeløbet skal være positivt.";
            }
        }

        public string Withdraw(decimal amount)
        {
            if (amount > 0)
            {
                if (balance - amount >= MinimumBalance)
                {
                    balance -= amount;
                    return $"Trukket {amount} kr. {GetUpdateMessage()}";
                }
                return "";
            }
            else
            {
                return "Udbetalingsbeløbet skal være positivt.";
            }
        }

        public decimal GetBalance()
        {
            return balance;
        }

    }
}


