using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpStockApp
{
    public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
       

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DisplayProd());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DisplayOrder());
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            adminReg ar = new adminReg();
            ar.ShowDialog();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DisplayCat());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DisplayCustomer());
        }
    }
}
