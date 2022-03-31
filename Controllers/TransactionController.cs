using CustomerTransactions.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTransactions.Controllers
{

    [ApiController]
    [Route("/transaction")]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }


        [HttpGet("/transaction/all")]
        public async Task<IActionResult> Get()
        {   
            try{
                var customers = await transactionRepository.GetAllTransactions();
                return Ok(customers);
            }catch(Exception e){
                return StatusCode(500,e.Message);
            }
        }

        [HttpGet("/transaction/total-amount/user/{id}")]
        public async Task<IActionResult> GetTotalTransactionAmountOfUser(int id){
            try{
                var amount = await transactionRepository.GetTransactionsAmountByCustomerId(id);
                return Ok(amount);
            }catch(Exception e){
                return StatusCode(500,e.Message);
            }
        }

    }
}
