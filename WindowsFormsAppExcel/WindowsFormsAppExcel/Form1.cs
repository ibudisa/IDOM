using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using BLL;

namespace WindowsFormsAppExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlg = new OpenFileDialog();
            odlg.InitialDirectory = "C:\\";
            odlg.Filter = "xlsx files (*.xlsx)|*.xlsx";




            if (odlg.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = odlg.FileName;
                
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            (new Thread(() => {
                GetRecords();
                MessageBox.Show("Long Running Work Finished!","Message",MessageBoxButtons.OK);
            })).Start();

          
        }

       private void GetRecords()
        {
            FileData.GetRecords(txtFile.Text);
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            DBData.SaveTouristUnits();
            MessageBox.Show("TouristUnit import Finished!", "Message", MessageBoxButtons.OK);
        }

        private void btnSite_Click(object sender, EventArgs e)
        {
            DBData.SaveTouristSites();
            MessageBox.Show("TouristSite import Finished!", "Message", MessageBoxButtons.OK);
        }

        private void btnBookingCustomer_Click(object sender, EventArgs e)
        {
            DBData.SaveCustomers();
            MessageBox.Show("Customers from booking import Finished!", "Message", MessageBoxButtons.OK);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            DBData.SaveBookingData("2",DateTime.Now,DateTime.Now,false);
            MessageBox.Show("Booking import Finished!", "Message", MessageBoxButtons.OK);
        }

        private void btnPlaces_Click(object sender, EventArgs e)
        {
            DBData.SavePlaces();
            MessageBox.Show("Places import Finished!", "Message", MessageBoxButtons.OK);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DBData.UpdateCustomers();
            MessageBox.Show(String.Format("Customers update is done,numbers of updated is {0}",DBData.counter), "Message", MessageBoxButtons.OK);
        }
    }
}
