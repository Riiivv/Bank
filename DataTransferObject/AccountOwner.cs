using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataTransferObject
{
    public sealed class AccountOwner : Person
    {
        public int KundeId { get; private set; }

        public AccountOwner(int kundeId, string fornavn, string efternavn) : base(fornavn, efternavn)
        {
            if (kundeId.ToString().Length == 6)
            {
                KundeId = kundeId;
            }
            else
            {
                throw new ArgumentException("KundeId skal være et 6-cifret tal.");
            }
        }
    }

    public sealed class AccountAdmin : Person
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

