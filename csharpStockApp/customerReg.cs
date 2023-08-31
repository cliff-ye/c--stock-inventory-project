using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace csharpStockApp
{
    public partial class customerReg : Form
    {
        public customerReg()
        {
            InitializeComponent();
        }

        configuration config = new configuration();
        string sql = "";
        SqlCommand cmd;

        void addCustomer()
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to add this customer?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    sql = "insert into customerTB(customerName,phone) values('" + txtCustomerName.Text + "','" + txtCustomerPhone.Text + "')";
                    cmd = new SqlCommand(sql, config.getCon());
                    config.openCon();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Customer added successfully", "SUCCESSFUL", 0, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to add customer", "FAILED", 0, MessageBoxIcon.Error);
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("An error occur " + e.Message);
                }
                finally
                {
                    config.closeCon();
                }
            }
            else
            {
                MessageBox.Show("Adding customer terminated", "TERMINATED", 0, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addCustomer();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
