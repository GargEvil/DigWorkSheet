using DigWorkSheet.WinUI.Customers;
using DigWorkSheet.WinUI.Employees;
using DigWorkSheet.WinUI.Offers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigWorkSheet.WinUI
{
    public partial class frmDashboard : Form
    {

        static frmDashboard _obj;

        public static frmDashboard Instance
        {
            get
            {
                if(_obj == null)
                {
                    _obj = new frmDashboard();
                }
                return _obj;
            }
        }

        public Panel PnlContainer
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }

       
        public void ShowControl(Control control)
        {
            PnlContainer.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();

            PnlContainer.Controls.Add(control);
        }
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            panelTracker.Height = buttonDashboard.Height;
            panelTracker.Top = buttonDashboard.Top;

            UCDashboard ucd = new UCDashboard();

            ShowControl(ucd);
        }

        private void buttonEmployees_Click(object sender, EventArgs e)
        {
            panelTracker.Height = buttonEmployees.Height;
            panelTracker.Top = buttonEmployees.Top;

            UCEmployee uce = new UCEmployee();

            ShowControl(uce);


        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            panelTracker.Height = buttonCustomers.Height;
            panelTracker.Top = buttonCustomers.Top;

            UCCustomers ucc = new UCCustomers();

            ShowControl(ucc);
        }

        private void buttonOffers_Click(object sender, EventArgs e)
        {
            panelTracker.Height = buttonOffers.Height;
            panelTracker.Top = buttonOffers.Top;

            UCOffers uco = new UCOffers();

            ShowControl(uco);
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            UCDashboard ucd = new UCDashboard();

            ShowControl(ucd);
        }
    }
}
