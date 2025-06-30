using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAO.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int customerId);
        Customer GetCustomerByUsername(string username);
        void RegisterCustomer(Customer  customerData);
        void UpdateCustomer(Customer customerDate);
        void DeleteCustomer(int customerid);
    }
}
