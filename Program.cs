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

            myAccount.Deposit(50);
            Console.WriteLine(myAccount.Withdraw(100));
            Console.WriteLine(myAccount.Withdraw(100));

            Console.WriteLine($"Slutsaldo: {myAccount.GetBalance()} kr.");
        }
    }
}
