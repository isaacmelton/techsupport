using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication4.Controller;
using WindowsFormsApplication4.Model;

namespace WindowsFormsApplication4.View
{
    public partial class OpenIncidentsByTech : Form
    {
        private TechnicianController techController;
        private List<Technician> openTechList;
        private Technician tech;
        private IncidentsController incController;
        private List<Incident> incList;
        private Incident inc;

        public OpenIncidentsByTech()
        {
            InitializeComponent();
            techController = new TechnicianController();
            incController = new IncidentsController();

        }

        private void OpenIncidentsByTech_Load(object sender, EventArgs e)
        {
            this.GetTechList();
        }

        private void GetTechList()
        {
            try
            {
                openTechList = techController.GetTechsWithOpenIncidents();
                technicianNameBox.DataSource = openTechList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void GetTechData()
        {
            int techID = (int)technicianNameBox.SelectedValue;
            try
            {
                tech = techController.GetSpecificTechnician(techID);
                technicianBindingSource.Clear();
                technicianBindingSource.Add(tech);

                incList = incController.GetOpenIncidentsByTech(techID);
                incidentDataGridView.DataSource = incList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

       
        private void technicianNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetTechData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

     

    }
}
