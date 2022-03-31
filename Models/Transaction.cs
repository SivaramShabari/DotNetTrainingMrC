using System;

namespace CustomerTransactions.Models
{
    public class Transaction
    {
        public int transaction_id { get; set; }
        public int Amount { get; set; }
        public string Date { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}