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
    public partial class categoryReg : Form
    {
        public categoryReg()
        {
            InitializeComponent();
        }

        configuration config = new configuration();
        string sql = "";
        SqlCommand cmd;


        void addCat()
        {
            DialogResult ask = MessageBox.Show("Are you sure want to add this category?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ask == DialogResult.Yes)
            {
                try
                {
                    sql = "insert into categoryTB(categoryName) values('" + txtCatName.Text + "')";
                    cmd = new SqlCommand(sql, config.getCon());
                    config.openCon();

                    if(cmd.ExecuteNonQuery()>0)
                    {
                        MessageBox.Show("Category added successfully", "SUCCESSFUL", 0, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to add category", "FAILED", 0, MessageBoxIcon.Information);

                    }
                }
                catch(System.Exception e)
                {
                    MessageBox.Show("An error occured " + e);
                }
                finally
                {
                    config.closeCon();
                }
            }
            else
            {
                MessageBox.Show("Adding category terminated", "TERMINATED", 0, MessageBoxIcon.Warning);
            }
        }

        void updateCat()
        {
            if (txtCatId.Text == "")
            {
                MessageBox.Show("Category Id required", "DATA REQUIRED", 0, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    sql = "update categoryTB set categoryName='" + txtCatName.Text + "' where categoryId='" + txtCatId.Text + "'";
                    cmd = new SqlCommand(sql, config.getCon());
                    config.openCon();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Updated successfully", "SUCCESSFUL", 0, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Failed to update", "FAILED", 0, MessageBoxIcon.Error);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("An error occured " + ex);
                }
                finally
                {
                    config.closeCon();
                }
            }
        }

        void deleteCat()
        {
            if (txtCatId.Text == "")
            {
                MessageBox.Show("Category Id required", "DATA REQUIRED", 0, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    sql = "delete from categoryTB where categoryId='" + txtCatId.Text + "'";
                    cmd = new SqlCommand(sql, config.getCon());
                    config.openCon();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Deleted successfully", "SUCCESSFUL", 0, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Failed to Delete", "FAILED", 0, MessageBoxIcon.Error);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("An error occured " + ex);
                }
                finally
                {
                    config.closeCon();
                }
            }
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void categoryReg_Load(object sender, EventArgs e)
        {

        }

        private void btnAddcat_Click(object sender, EventArgs e)
        {
            addCat();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdateCat_Click(object sender, EventArgs e)
        {
            updateCat();
        }

        private void btnDeleteCat_Click(object sender, EventArgs e)
        {
            deleteCat();
        }
    }
}
