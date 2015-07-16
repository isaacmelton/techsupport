using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication4.View;
using WindowsFormsApplication4.View;

namespace WindowsFormsApplication4
{
    public partial class TechSupportView : Form
    {
        public TechSupportView()
        {
            InitializeComponent();
        }

        OpenIncidents oi;
        CreateIncident ci;
        UpdateIncident ui;
        OpenIncidentsByTech oibt;
        IncidentReport ir;
        /// <summary>
        /// Initial window that opens when the program runs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayOpenIncidentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oi == null)
            {
                oi = new OpenIncidents();
                oi.MdiParent = this;
                oi.FormClosed += new FormClosedEventHandler(oi_FormClosed);
                oi.Show();
            }

            else oi.Activate();
        }

        void oi_FormClosed(object sender, FormClosedEventArgs e)
        {
            oi = null;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void createIncidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ci == null)
            {
                ci = new CreateIncident();
                ci.MdiParent = this;
                ci.FormClosed += new FormClosedEventHandler(ci_FormClosed);
                ci.Show();
            }
            else ci.Activate();
        }

        private void ci_FormClosed(object sender, FormClosedEventArgs e)
        {
            ci = null;
        }

        private void updateIncidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ui == null)
            {
                ui = new UpdateIncident();
                ui.MdiParent = this;
                ui.FormClosed += new FormClosedEventHandler(ui_FormClosed);
                ui.Show();
            }
            else ui.Activate();
        }

        private void ui_FormClosed(object sender, FormClosedEventArgs e)
        {
            ui = null;
        }

        private void viewOpenIncidentByTechnicianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oibt == null)
            {
                oibt = new OpenIncidentsByTech();
                oibt.MdiParent = this;
                oibt.FormClosed += new FormClosedEventHandler(oibt_FormClosed);
                oibt.Show();
            }
            else oibt.Activate();
           
        }

        private void oibt_FormClosed(object sender, FormClosedEventArgs e)
        {
            oibt = null;
        }

        private void displayIncidentsByProductsAndTechnicianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ir == null)
            {
                ir = new IncidentReport();
                ir.MdiParent = this;
                ir.FormClosed += new FormClosedEventHandler(ir_FormClosed);
                ir.Show();
            }
            else ir.Activate();
        }

        private void ir_FormClosed(object sender, FormClosedEventArgs e)
        {
            ir = null;
        }

       
    }
}
