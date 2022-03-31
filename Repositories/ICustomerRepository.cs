using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerTransactions.Models;

namespace CustomerTransactions.Repositories
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetAllCustomers_Eager();

        public Task<IEnumerable<Customer>> GetAllCustomers_Lazy();

        public Task<Customer> GetCustomer(int id);

        //add and delete customers
        public Task<Customer> AddCustomer(Customer customer);
        public Task<dynamic> DeleteCustomer(int id);
        public Task<Customer> UpdateCustomer(Customer customer);
    }
}