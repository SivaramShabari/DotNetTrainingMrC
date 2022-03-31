using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerTransactions.Models;

namespace CustomerTransactions.Repositories
{
    public interface ITransactionRepository
    {
        public Task<IEnumerable<Transaction>> GetAllTransactions();
        public Task<Transaction> GetTransaction(int id);
        public Task<Transaction> AddTransaction(Transaction Transaction);
        public Task<Transaction> DeleteTransaction(int id);
        public Task<Transaction> UpdateTransaction(Transaction Transaction);
        public Task<int> GetTransactionsAmountByCustomerId(int id);

    }
}