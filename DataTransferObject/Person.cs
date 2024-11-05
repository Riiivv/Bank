using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataTransferObject
{
    public abstract class Person
    {
        public string Fornavn { get; private set; }
        public string Efternavn { get; private set; }
        public string FuldeNavn => $"{Fornavn} {Efternavn}";

        protected Person(string fornavn, string efternavn)
        {
            Fornavn = fornavn;
            Efternavn = efternavn;
        }
    }
}
