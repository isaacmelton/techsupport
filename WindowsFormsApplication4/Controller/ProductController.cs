using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication4.Model;
using WindowsFormsApplication4.DAL;


namespace WindowsFormsApplication4.Controller
{
    class ProductController
    {
        public ProductController()
        {

        }

        /// <summary>
        /// Returns a list of Products
        /// </summary>
        /// <returns>A list of products</returns>
        public List<Product> GetProducts()
        {
            return ProductDAL.GetProduct();
        }

    }
}
