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
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
            getProduct();
            getCustomer();
        }
        configuration config = new configuration();
        SqlCommand cmd;
        string sql = "";
        SqlDataReader dr;
        int qty;

      void getProduct()
        {
            try
            {
                dataGridView2.Rows.Clear();
                sql = "select * from productTB";
                cmd = new SqlCommand(sql, config.getCon());
                config.openCon();
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    dataGridView2.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show("An error occured " + ex.Message);
            }
            finally
            {
                dr.Close();
                config.closeCon();
            }
        }

        void getCustomer()
        {
            try
            {
                dataGridView1.Rows.Clear();
                sql = "select * from customerTB";
                cmd = new SqlCommand(sql, config.getCon());
                config.openCon();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString());
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

        void searchProduct()
        {
            try
            {
                sql = "select * from productTB where prodName like '"+txtSearchP.Text+"%'";
                cmd = new SqlCommand(sql, config.getCon());
                config.openCon();
               
                dr = cmd.ExecuteReader();
                dataGridView2.Rows.Clear();
                while (dr.Read())
                {
                    dataGridView2.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
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

        void fillProducts()
        {
            
            try
            {
                sql = "select * from productTB where ProductId = '"+ dataGridView2.CurrentRow.Cells[0].Value.ToString() + "'";
                cmd = new SqlCommand(sql, config.getCon());
                config.openCon();
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    txtPid.Text = dr.GetValue(1).ToString();
                    txtPname.Text = dr.GetValue(2).ToString();
                    txtPrice.Text = dr.GetValue(4).ToString();
                    txtTotal.Text = dr.GetValue(4).ToString();
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

        void fillCustomer()
        {
           
            try
            {
                sql = "select * from customerTB where customerId = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                cmd = new SqlCommand(sql, config.getCon());
                config.openCon();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtCustId.Text = dr.GetValue(0).ToString();
                    txtCustName.Text = dr.GetValue(1).ToString();

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

        void getQuantity()
        {
            try
            {
                cmd = new SqlCommand("SELECT Quantity from productTB where ProductID='" + txtPid.Text + "'", config.getCon());
                config.openCon();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    qty= Convert.ToInt32(dr.GetValue(0));
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

        void calc()
        {
            getQuantity();
            bool isAbove = false;
            try
            {
               if(Convert.ToInt32(numQty.Value)>qty)
                {
                    MessageBox.Show("Quantity should not exceed quantity instock -> " + qty, "ERROR", 0, MessageBoxIcon.Error);
                    numQty.Value -= 1;
                    isAbove =true;
                }
                if(Convert.ToInt32(numQty.Value) <= qty)
                {
                    txtTotal.Text = (Convert.ToDouble(txtPrice.Text) * Convert.ToInt32(numQty.Value)).ToString("N2");
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("An error occured " + ex.Message);
            }
        }

        private bool isValid()
        {
            if(txtPid.Text == string.Empty)
            {
                MessageBox.Show("select product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if(string.IsNullOrEmpty(txtCustId.Text))
            {
                MessageBox.Show("select customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

            void insertOrder()
        {

            try
            {
                sql = "insert into orderTB(orderDate,productID,customerID,quantity,price,total) values('" + dateTimePicker1.Text + "','" + txtPid.Text + "','" + txtCustId.Text + "','" + numQty.Value + "','" + Convert.ToDouble(txtPrice.Text) + "','" + Convert.ToDouble(txtTotal.Text) + "') ";
                cmd = new SqlCommand(sql, config.getCon());
                config.openCon();
                if(cmd.ExecuteNonQuery()>0)
                {
                    MessageBox.Show("Order successful", "SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Order Failed", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                config.closeCon();

                cmd = new SqlCommand("SELECT Quantity from productTB where ProductID='" + txtPid.Text + "'", config.getCon());
                config.openCon();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    qty = Convert.ToInt32(dr.GetValue(0)) - Convert.ToInt32(numQty.Value);
                }
                dr.Close();
                config.closeCon();

                sql = "update productTB set Quantity='"+qty+"' where ProductId ='" + txtPid.Text + "'";
                cmd = new SqlCommand(sql, config.getCon());
                config.openCon();

                cmd.ExecuteNonQuery();
                config.closeCon();
                clear();
                getProduct();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("An error occured " + ex.Message);
            }
        }
            
        void clear()
        {
            txtCustId.Clear();
            txtCustName.Clear();
            txtPid.Clear();
            txtPname.Clear();
            txtPrice.Clear();
            txtTotal.Clear();
            numQty.Value = 1;
        }

        private void txtSearchP_TextChanged(object sender, EventArgs e)
        {
            searchProduct();
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dataGridView2.CurrentRow.Cells[e.ColumnIndex].Style.BackColor = Color.Gold;
            fillProducts();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            fillCustomer();
        }

        private void numQty_ValueChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if(isValid())
            {
                insertOrder();
            }
        }

        private void dataGridView2_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
