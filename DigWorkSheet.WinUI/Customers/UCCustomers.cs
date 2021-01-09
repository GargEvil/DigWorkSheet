using DigWorkSheet.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigWorkSheet.WinUI.Customers
{
    public partial class UCCustomers : UserControl
    {
        private readonly APIService _apiService = new APIService("customer");

        public UCCustomers()
        {
            InitializeComponent();
        }

        private async void UCCustomers_Load(object sender, EventArgs e)
        {
            string search= null;
            //calling API
            var result = await _apiService.Get<List<Model.Customer>>(search);

            dgvCustomers.DataSource = result;

            txtSearch.Text = "Search by Name, City, Adress..";

            txtSearch.GotFocus += RemoveText;
            txtSearch.LostFocus += AddText;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search by Name, City, Adress..")
            {
                txtSearch.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                txtSearch.Text = "Enter text here...";
        }

        private async void btnShow_ClickAsync(object sender, EventArgs e)
        {
            var search = new CustomerSearchRequest()
            {
                Search = txtSearch.Text
            };


            //calling API
            var result = await _apiService.Get<List<Model.Customer>>(search);

            dgvCustomers.DataSource = result;
        }
    }
}
