using CustomerTransactions.Models;
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
    [Route("/customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }


        [HttpGet("/customer/all/eager")]
        public async Task<IActionResult> GetAll_Eager()
        {   
            try{
                var customers = await customerRepository.GetAllCustomers_Eager();
                return Ok(customers);
            }catch(Exception e){
                return StatusCode(500,e.Message);
            }
        }
        [HttpGet("/customer/all/lazy")]
        public async Task<IActionResult> GetAll_Lazy()
        {   
            try{
                var customers = await customerRepository.GetAllCustomers_Lazy();
                return Ok(customers);
            }catch(Exception e){
                return StatusCode(500,e.Message);
            }
        }

        [HttpPut("/customer/update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                var updatedCustomer = await customerRepository.UpdateCustomer(customer);
                return Ok(updatedCustomer);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("/customer/add")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            try
            {
                var newCustomer = await customerRepository.AddCustomer(customer);
                return Ok(newCustomer);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("/customer/delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await customerRepository.DeleteCustomer(id);
                return Ok("Deleted Customer record");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("/customer/one/{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            try
            {
                var customer = await customerRepository.GetCustomer(id);
                return Ok(customer);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
