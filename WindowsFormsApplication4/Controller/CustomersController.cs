using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication4.DAL;
using WindowsFormsApplication4.Model;

namespace WindowsFormsApplication4.Controller
{
    class CustomersController
    {
        public CustomersController()
        {

        }
        /// <summary>
        /// Returns a list of Customers
        /// </summary>
        /// <returns>List of Customers</returns>
        public List<Customer> GetCustomers()
        {
            return CustomerDAL.GetCustomers();
        }

    }
}
