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
    public partial class DisplayCat : Form
    {
        public DisplayCat()
        {
            InitializeComponent();
            getCategory();
        }

        configuration config = new configuration();
        SqlCommand cmd;
        SqlDataReader dr;
        string sql = "";

        void getCategory()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cmd = new SqlCommand("select * from categoryTB", config.getCon());
                config.openCon();
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    dataGridView1.Rows.Add(dr[1].ToString(), dr[2].ToString());
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

       void showCatReg()
        {
            categoryReg cr = new categoryReg();
            cr.btnUpdateCat.Enabled = false;
            cr.btnDeleteCat.Enabled = false;
            cr.ShowDialog();
           getCategory();
        }

        void transferValues()
        {
            try
            {
                sql = "select * from categoryTB where categoryId='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
    
                cmd = new SqlCommand(sql,config.getCon());
                config.openCon();
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    categoryReg cr = new categoryReg();
                    cr.txtCatId.Text = dr.GetValue(1).ToString();
                    cr.txtCatName.Text = dr.GetValue(2).ToString();
                    cr.btnAddcat.Enabled = false;
                    cr.ShowDialog();
                   
                }
               dr.Close();
                getCategory();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show("An error occured " + ex.Message);

            }
            finally
            {
                config.closeCon();
            }
        }

        void searchCat()
        {
            try
            {
                cmd = new SqlCommand("select * from categoryTB where categoryName like '" + txtSearch.Text + "%'", config.getCon());
                config.openCon();
                dr = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                while(dr.Read())
                {
                    dataGridView1.Rows.Add(dr[1].ToString(), dr[2].ToString());
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show("An error ocured " + ex.Message);
            }
            finally
            {
                config.closeCon();
            }
        }

        private void btnAddCat_Click(object sender, EventArgs e)
        {
            showCatReg();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            transferValues();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchCat();
        }
    }
}
