using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;

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


            try
            {
                if (amount <= 0)
                {

                    throw new ArgumentException("Indsætning af beløbet kan ikke være negativt");
                }
                balance += amount;
                return $"Indsat {amount} kr. {GetUpdateMessage()}";
            }
            catch (ArgumentException ex)
            {
                return $"fejl ved Indsætning: {ex.Message}";
            }
            finally
            {
                // Denne kode vil altid køre, uanset om der opstod en fejl eller ej. 
                //det er ikke muligt at ''return'' en finally block
                Console.WriteLine($"Aktuel saldo: {GetBalance()} kr.");
            }
        }

        public string Withdraw(decimal amount)
        {
            try
            {
                if (amount <= 0)
                {
                    // Kast en exception, hvis beløbet er 0 eller negativt
                    throw new ArgumentException("Udbetaling af beløbet kan ikke være 0 eller negativt.");
                }

                if (balance - amount < MinimumBalance)
                {
                    throw new InvalidOperationException("Ikke tilstrækkelig saldo til at gennemføre hævningen.");
                }

                balance -= amount;
                return $"Trukket {amount} kr. {GetUpdateMessage()}";
            }
            catch (ArgumentException ex)
            {
                return $"Fejl ved hævning: {ex.Message}";
            }
            catch (InvalidOperationException ex)
            {
                    return $"Fejl ved hævning: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Der opstod en fejl: {ex.Message}";
            }
            finally
            {
                // Denne kode vil altid køre, uanset om der opstod en fejl eller ej.
                Console.WriteLine($"Aktuel saldo: {GetBalance()} kr.");
            }
        }
        public decimal GetBalance()
        {
            return balance;
        }

    }
}


