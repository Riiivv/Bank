using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataTransferObject
{
    public class AccountAdmin : Person
    {

        public int MedarbejderId { get; private set; }

        public AccountAdmin(int medarbejderId, string fornavn, string efternavn) : base(fornavn, efternavn)
        {
            if (medarbejderId.ToString().Length == 6)
            {
                MedarbejderId = medarbejderId;
            }
            else
            {
                throw new ArgumentException("MedarbejderId skal være et 6-cifret tal.");
            }
        }
    }
}