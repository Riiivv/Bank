using Bank.DataTransferObject;
using System;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountOwner owner = new AccountOwner(123456, "Jens", "Hansen");
            AccountAdmin admin = new AccountAdmin(654321, "Anna", "Larsen");

            Console.WriteLine($"Hej {owner.FuldeNavn}. Din konto er oprettet med {admin.FuldeNavn} som admin.");
            Account myAccount = new Account(owner, admin, 200);

            Console.WriteLine($"Kontoindehaver: {myAccount.Owner.FuldeNavn}");
            Console.WriteLine($"Administrator: {myAccount.Admin.FuldeNavn}");
            Console.WriteLine($"Startsaldo: {myAccount.GetBalance()} kr.");

            // Indtast beløb til indbetaling
            Console.WriteLine("Indtast beløb for indbetaling:");
            string depositInput = Console.ReadLine();
            if (decimal.TryParse(depositInput, out decimal depositAmount))
            {
                Console.WriteLine(myAccount.Deposit(depositAmount));
            }
            else
            {
                Console.WriteLine("Ugyldigt beløb for indbetaling. Prøv igen med et gyldigt tal.");
            }

            // Indtast beløb for hævning
            Console.WriteLine("Indtast beløb for hævning:");
            string withdrawInput = Console.ReadLine();
            if (decimal.TryParse(withdrawInput, out decimal withdrawAmount))
            {
                Console.WriteLine(myAccount.Withdraw(withdrawAmount));
            }
            else
            {
                Console.WriteLine("Ugyldigt beløb for hævning. Prøv igen med et gyldigt tal.");
            }

            Console.WriteLine($"Slutsaldo: {myAccount.GetBalance()} kr.");
        }
    }
}
