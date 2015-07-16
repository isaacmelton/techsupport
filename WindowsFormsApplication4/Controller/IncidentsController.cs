using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication4.Model;
using WindowsFormsApplication4.DAL;

namespace WindowsFormsApplication4.Controller
{
    class IncidentsController
    {
        public IncidentsController()
        {

        }
        /// <summary>
        /// Returns a list of Incidents
        /// </summary>
        /// <returns>List of Incidents</returns>
        public List<Incident> GetIncidents()
        {
            return IncidentDAL.GetIncidents();
        }

        /// <summary>
        /// Adds an Incident to the Incident database
        /// </summary>
        /// <param name="inc">inc the incident object to be added to the database</param>
        public void AddIncidents(Incident inc)
        {
            IncidentDAL.AddIncident(inc);
        }

        public void UpdateIncidents(Incident oldInc, Incident newInc)
        {
            IncidentDAL.UpdateIncident(oldInc, newInc);
        }

        public List<int> GetIncidentIDs()
        {
            return IncidentDAL.GetIncidentIDs();
        }

        public Incident ReturnIncident(int incidentID)
        {
            return IncidentDAL.ReturnIncident(incidentID);
        }

        public void CloseIncident(Incident inc)
        {
            IncidentDAL.CloseIncident(inc);
        }

        public List<Incident> GetOpenIncidentsByTech(int techID)
        {
            return IncidentDAL.GetOpenIncidentsByTech(techID);
        }
    }
}
