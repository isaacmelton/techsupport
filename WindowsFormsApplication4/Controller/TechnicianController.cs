using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication4.DAL;
using WindowsFormsApplication4.Model;

namespace WindowsFormsApplication4.Controller
{
    class TechnicianController
    {
        public TechnicianController()
        {

        }

        public List<Technician> GetTechnicians()
        {
            return TechnicianDAL.GetTechnician();
        }

        public List<Technician> GetTechsWithOpenIncidents()
        {
            return TechnicianDAL.GetTechsWithOpenIncidents();
        }

        public Technician GetSpecificTechnician(int techID)
        {
            return TechnicianDAL.GetSpecificTech(techID);
        }

    }
}
