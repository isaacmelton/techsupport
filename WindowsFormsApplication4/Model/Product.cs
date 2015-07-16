using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4.Model
{
   public class Product
    {
        private string productCode;
        private string name;

        public Product()
        {

        }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}
