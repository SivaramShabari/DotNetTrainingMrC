// create a class Transactionrepository implementing ITransactionRepository
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerTransactions.Models;
using Dapper;
namespace CustomerTransactions.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly Context context;
        public TransactionRepository(Context context){
            this.context = context;
        }

        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            var query = "INSERT INTO transactions (transaction_id, amount, date, customer_id) VALUES(@transaction_id, @Amount, @Date, @customer_id)";
            using(var connection = context.CreateConnection()){
                var result = await connection.ExecuteAsync(query,transaction);
                return transaction;
            }
        }

        public Task<Transaction> DeleteTransaction(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            throw new System.NotImplementedException();
        }

        public Task<Transaction> GetTransaction(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> GetTransactionsAmountByCustomerId(int id)
        {
            var query = "SELECT * FROM transactions WHERE customer_id = @id";
            using(var connection = context.CreateConnection()){
                int amount = 0;
                var res = await connection.QueryAsync<Transaction>(query,new{id});
                System.Diagnostics.Debug.WriteLine("Amount:",res);
                foreach(var t in res)
                {
                    amount+=t.Amount;
                }
                return amount;
            }
        }

        public Task<Transaction> UpdateTransaction(Transaction Transaction)
        {
            throw new System.NotImplementedException();
        }
    }
}