using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerTransactions.Models
{
    public class Customer
    {
        public int customer_id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
