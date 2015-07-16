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
using WindowsFormsApplication4.Controller;
using WindowsFormsApplication4.Model;

namespace WindowsFormsApplication4.View
{
    public partial class CreateIncident : Form
    {
        public bool addIncident;
        public Incident incident;
        private List<Customer> custList;
        private CustomersController custCont;
        private IncidentsController incCont;
        private ProductController proCont;
        private List<Product> proList;

        /// <summary>
        /// Initializes Incident form and needed controllers
        /// </summary>
        public CreateIncident()
        {
            InitializeComponent();
            custCont = new CustomersController();
            incCont = new IncidentsController();
            proCont = new ProductController();
        }

       


        private void CreateIncident_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadComboBoxes();
                customerNameBox.SelectedIndex = -1;
                productNameBox.SelectedIndex = -1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                this.BeginInvoke(new MethodInvoker(Close));
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                custList = this.custCont.GetCustomers();
                customerNameBox.DataSource = custList;
                customerNameBox.DisplayMember = "Name";
                customerNameBox.ValueMember = "CustomerID";

                proList = this.proCont.GetProducts();
                productNameBox.DataSource = proList;
                productNameBox.DisplayMember = "ProductCode";
                productNameBox.ValueMember = "ProductCode";
            }
               
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void createIncidentButton_Click(object sender, EventArgs e)
        {
            if (titleBox.Text == "")
            {
               MessageBox.Show("Title cannot be blank.");

            }

            else if (descriptionBox.Text == "") {
                MessageBox.Show("Description Cannot be blank.");
               }
           
            else {
                incident = new Incident();
                this.PutIncidentData(incident);

                try
                {
                    incCont.AddIncidents(incident);
                    MessageBox.Show("Incident Added");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                    this.BeginInvoke(new MethodInvoker(Close));

                }
                finally
                {
                    this.Close();
                }
            }
        }

        private void PutIncidentData(Incident incident)
        {
            incident.CustomerID = (int)customerNameBox.SelectedValue;
            incident.ProductCode = productNameBox.SelectedValue.ToString() ;
            incident.Title = titleBox.Text;
            incident.Description = descriptionBox.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
