using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4.Model
{
 
    public class Technician
    {
        private int techId;
        private string name;
        private string email;
        private string phone;

        public Technician() {

        }
        public int TechID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
