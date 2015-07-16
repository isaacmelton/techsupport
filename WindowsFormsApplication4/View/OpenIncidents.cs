using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication4.Controller;
using WindowsFormsApplication4.Model;
using WindowsFormsApplication4.DAL;
using System.Data.SqlClient;

namespace WindowsFormsApplication4.View
{
    public partial class OpenIncidents : Form
    {
        private IncidentsController incidentController;

        /// <summary>
        /// The form that is filled with values when loaded: MDI child of TechSupport form
        /// </summary>
        public OpenIncidents()
        {
            InitializeComponent();
            incidentController = new IncidentsController();
        }
        /// <summary>
        /// Action Listener for this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Incident> incList;

            try
            {
                incList = this.incidentController.GetIncidents();

                if (incList.Count > 0)
                {
                    Incident incident;

                    for (int i = 0; i < incList.Count; i++)
                    {
                        incident = incList[i];
                        listView1.Items.Add(incident.ProductCode.ToString());
                        listView1.Items[i].SubItems.Add(incident.DateOpened.ToShortDateString());
                        listView1.Items[i].SubItems.Add(incident.CustomerName.ToString());
                        listView1.Items[i].SubItems.Add(incident.TechName);
                        listView1.Items[i].SubItems.Add(incident.Title.ToString());

                    }
                }
                else
                {
                    MessageBox.Show("Empty!");
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                this.BeginInvoke(new MethodInvoker(Close));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                this.Close();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
