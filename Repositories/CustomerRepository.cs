// create CustomerRepository class implementing IRepository interface
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerTransactions.Models;
using Dapper;
namespace CustomerTransactions.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context context;

        public CustomerRepository(Context context)
        {
            this.context = context;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var sql = "INSERT INTO Customers (customer_id, name, phone, email,address) VALUES (@customer_id, @Name, @Phone, @Email,@Address);";
            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(sql, customer);
                return customer;
            }

        }

        public async Task<dynamic> DeleteCustomer(int id)
        {
            var sql = "DELETE FROM Customers WHERE customer_id = @Id";
            using (var connection = context.CreateConnection())
            {
                return await connection.QueryFirstAsync<Customer>(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers_Eager()
        {
            var query = "SELECT * from customers c " +
                        "LEFT JOIN transactions t ON c.customer_id = t.customer_id";
            using (var connection = context.CreateConnection())
            {
                // var customers = await connection.
                // return customers.ToList();
                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers_Lazy()
        {
            var query = "SELECT * from customers";
            using (var connection = context.CreateConnection())
            {
                var customers = await connection.QueryAsync<Customer>(query);
                return customers.ToList();
            }
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var sql = "SELECT * FROM customers WHERE customer_id = @Id";
            using (var connection = context.CreateConnection())
            {
                var res = await connection.QueryFirstAsync<Customer>(sql, new { Id = id });
                return res;
            }
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var query = "UPDATE customers SET name = @name,  address=@address, phone = @phone, email = @email WHERE customer_id = @customer_id";
                using (var connection = context.CreateConnection())
                {
                    var res = await connection.QueryAsync<Customer>(query, customer);
                    return res.FirstOrDefault();
                }
        }
    }
}


