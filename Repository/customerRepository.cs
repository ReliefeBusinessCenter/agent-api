using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using broker.Models;
using Microsoft.EntityFrameworkCore;

namespace broker.Data
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteData(Customer customer)
        {
           Console.WriteLine("Delete method invoked");
            _context.Users.Remove(customer.User);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Customer> GetByEmail(string phone) 
        {
             // FirstOrDefaultAsync(x => x.BrokerId == id);
            var data = await _context.Customers
             .Include(e => e.User)
             
             .Include(e => e.Reviews)
            
             .Include(e => e.Deals).ThenInclude(e=>e.Broker).ThenInclude(e=>e.User)
             
             
            .Include(e => e.Delivery).ThenInclude(e=>e.Broker).ThenInclude(e=>e.User)
             .Include(e => e.Delivery).ThenInclude(e=>e.Broker).ThenInclude(e=>e.Category)
              .Include(e => e.Delivery).ThenInclude(e=>e.Broker).ThenInclude(e=>e.Skills)
            
// .Include(e => e.User
            //  .ThenInclude(e => e.Portfolio)
            //  .ThenInclude(e => e.Review)
            //  .ThenInclude(e=>e.Category)
            //  .ThenInclude(e => e.Skills)
             .ToListAsync();

            return data.FirstOrDefault(x => x.User.Phone.Contains(phone));


            


        }

        public async Task<List<Customer>> GetData()
        {
            //   var model = await _context.Brokers.ToListAsync();
            // return model;wewewe

            var data = await _context.Customers
             .Include(e => e.User)
             
             .Include(e => e.Reviews)
            
             .Include(e => e.Deals).ThenInclude(e=>e.Broker).ThenInclude(e=>e.User)
             
             .Include(e => e.Delivery).ThenInclude(e=>e.Broker).ThenInclude(e=>e.User)
             .ToListAsync();
            return data;
        }

        public async Task<Customer> GetDataById(int id)
        {
            // return await _context.Brokers
            //  .Include(e => e.User)
            // .Where(x => x.BrokerId.Equals(id));
            // FirstOrDefaultAsync(x => x.BrokerId == id);
            var data = await _context.Customers
             .Include(e => e.User)
             
             .Include(e => e.Reviews)
            
             .Include(e => e.Deals).ThenInclude(e=>e.Broker).ThenInclude(e=>e.User)
             
            .Include(e => e.Delivery).ThenInclude(e=>e.Broker).ThenInclude(e=>e.User)
             
             .ToListAsync();

            return data.FirstOrDefault(x => x.User.UserId == id);
             
        }



        public  Task<List<Customer>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
          throw new System.NotImplementedException();
        }

        public async Task<int> GetTotalPage(int pageSize, string search)
        {
            if(search!="0"){
                // 
                   var count = await _context.Brokers.Where(b => b.User.FullName.Contains(search)).CountAsync();
                   var totalPages = (int)Math.Ceiling(count / (float)pageSize);
                    return totalPages;

            }else{
                // 
                var count = await _context.Brokers.CountAsync();
                var totalPages = (int)Math.Ceiling(count / (float)pageSize);
                return totalPages;
            }
             
             
        }

        public async Task<Customer> InsertData(Customer customer)
        {
              Console.WriteLine("Create data  method invoked");
            _context.Customers.Add(customer);

            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateData(Customer customer)
        {
             Console.WriteLine("Update method  invoked");
                _context.Update(customer).Property(x => x.CustomerId).IsModified = false;
            _context.SaveChanges();
             return customer;
        }

    }
}
