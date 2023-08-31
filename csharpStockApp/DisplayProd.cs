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
    public partial class DisplayProd : Form
    {
        public DisplayProd()
        {
            InitializeComponent();
            getProducts();
        }

        configuration config = new configuration();
        SqlCommand cmd;
        SqlDataReader dr;
        string sql = "";

        void getProducts()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cmd = new SqlCommand("select * from productTB", config.getCon());
                config.openCon();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[1].ToString(), dr[2].ToString(),dr[3].ToString(),dr[4].ToString(),dr[5].ToString(),dr[6].ToString());
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
            productReg pr = new productReg();
            pr.btnUpdate.Enabled = false;
            pr.btnDelete.Enabled = false;
            pr.ShowDialog();
            getProducts();
        }

        void transferValues()
        {
            try
            {
                sql = "select * from productTB where productId='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

                cmd = new SqlCommand(sql, config.getCon());
                config.openCon();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    productReg pr = new productReg();
                    pr.txtProdId.Text = dr.GetValue(1).ToString();
                    pr.txtProdName.Text = dr.GetValue(2).ToString();
                    pr.txtQuantity.Text = dr.GetValue(3).ToString();
                    pr.txtPrice.Text = dr.GetValue(4).ToString();
                    pr.txtDescription.Text = dr.GetValue(5).ToString();
                   // pr.cboCategory.Text= dr.GetValue(6).ToString();
                    pr.btnAdd.Enabled = false;
                    pr.ShowDialog();

                }
                dr.Close();
                getProducts();
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

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            showProdReg();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            transferValues();
        }
    }
}
