using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_Net2024_DemoEntity.Entities
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public decimal Amount { get; set; }
        public int TitularId { get; set; }
        public Person Titular { get; set; }
    }
}
