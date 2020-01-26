using MemoryLeak.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryLeak.Managers
{
    public class MemoryLeakManager : IMemoryLeakManager
    {
        private ConcurrentBag<MemoryModel> memoryLeakBank = new ConcurrentBag<MemoryModel>();
        private static Processor p = new Processor();

        public Task GenerateMemoryLeakObjectViaConcurentBag()
        {

            var memoryLeak = new MemoryModel()
            {
                Value = new string('x', 1000 * 1024),
                Number = 1
            };

            memoryLeakBank.Add(memoryLeak);

            return Task.CompletedTask;
        }      

        public Task GenerateMemoryLeak()
        {
            //Based on https://github.com/dotnet/samples/tree/master/core/diagnostics/DiagnosticScenarios
            int it = (20000 * 1000) / 100;
            for (int i = 0; i < it; i++)
            {
                p.ProcessTransaction(new Customer(Guid.NewGuid().ToString()));
            }

            return Task.CompletedTask;
        }     
    }


    #region Based on https://github.com/dotnet/samples/tree/master/core/diagnostics/DiagnosticScenarios
    class Customer
    {
        private string id;

        public Customer(string id)
        {
            this.id = id;
        }
    }

    class CustomerCache
    {
        private List<Customer> cache = new List<Customer>();

        public void AddCustomer(Customer c)
        {
            cache.Add(c);
        }
    }

    class Processor
    {
        private CustomerCache cache = new CustomerCache();

        public void ProcessTransaction(Customer customer)
        {
            cache.AddCustomer(customer);
        }
    }
    #endregion
}
