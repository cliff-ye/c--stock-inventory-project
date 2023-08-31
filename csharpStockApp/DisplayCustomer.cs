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
    public partial class DisplayCustomer : Form
    {
        public DisplayCustomer()
        {
            InitializeComponent();
            getCustomers();
        }
        configuration config = new configuration();
        SqlCommand cmd;
        SqlDataReader dr;
        string sql = "";

        void getCustomers()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cmd = new SqlCommand("select * from customerTB", config.getCon());
                config.openCon();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("An error occured " + ex.Message);
            }
            finally
            {
                dr.Close();
                config.closeCon();
            }
        }

        void showProdReg()
        {
            customerReg cust = new customerReg();
            cust.btnUpdate.Enabled = false;
            cust.btnDelete.Enabled = false;
            cust.ShowDialog();
            getCustomers();
        }

        void transferValues()
        {
            try
            {
                sql = "select * from customerTB where customerId='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

                cmd = new SqlCommand(sql, config.getCon());
                config.openCon();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    customerReg cust = new customerReg();
                    cust.txtCustomerId.Text = dr.GetValue(0).ToString();
                    cust.txtCustomerName.Text = dr.GetValue(1).ToString();
                    cust.txtCustomerPhone.Text = dr.GetValue(2).ToString();
                    cust.btnAdd.Enabled = false;
                    cust.ShowDialog();

                }   
                dr.Close();
                getCustomers();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("An error occured " + ex.Message);

            }
            finally
            {
                config.closeCon();
            }
        }
       

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            transferValues();
        }

        private void btnAddcustomer_Click(object sender, EventArgs e)
        {
            showProdReg();
        }
    }
}
