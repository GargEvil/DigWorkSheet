using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;

namespace DigWorkSheet.WinUI.Customers
{
    public partial class frmCustomers : Form
    {
        private readonly APIService _apiService = new APIService("customer");

        public frmCustomers()
        {
            InitializeComponent();
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            //calling API
            var result = await _apiService.Get<List<Model.Customer>>();

            dgvCustomers.DataSource = result;
        }


    }
}
