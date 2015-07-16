using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Model
{
    public class Incident
    {
        private int incidentID;
        private string productCode;
        private string productName;
        private DateTime dateOpened;
        private string customerName;
        private int customerID;
        private int? techID;
        private string techName;
        private string title;
        private string description;
        private DateTime? dateClosed;

        public Incident()
        {
        }

        public int IncidentID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public DateTime DateOpened { get; set; }
        public string CustomerName { get; set; }
        public int CustomerID { get; set; }
        public int? TechID { get; set; }
        public string TechName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DateClosed { get; set; }

    }
}