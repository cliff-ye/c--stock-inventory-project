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
    public partial class productReg : Form
    {
        public productReg()
        {
            InitializeComponent();
        }
        configuration config = new configuration();
        string sql = "";
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;

        void loadCategory()
        {
            try
            {
                cmd = new SqlCommand("select * from categoryTB", config.getCon());
                config.openCon();

                dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    cboCategory.Items.Add(dr[2].ToString());
                }
            }
            catch(System.Exception e)
            {
                MessageBox.Show("An error occured " + e.Message);
            }
            finally
            {
                config.closeCon();
            }
        }

        void addProduct()
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to add this product?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(confirm == DialogResult.Yes)
            {
                try
                {
                    sql = "insert into productTB(ProductName,Quantity,Price,Descriptions,Category) values('" + txtProdName.Text + "','" + txtQuantity.Text + "','" + txtPrice.Text + "','" + txtDescription.Text + "','" + cboCategory.Text + "')";
                    cmd = new SqlCommand(sql, config.getCon());
                    config.openCon();

                    if(cmd.ExecuteNonQuery()>0)
                    {
                        MessageBox.Show("Product added successfully", "SUCCESSFUL", 0, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to add product", "FAILED", 0, MessageBoxIcon.Error);
                    }
                }
                catch(System.Exception e)
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
                MessageBox.Show("Adding product terminated", "TERMINATED", 0, MessageBoxIcon.Information);
            }
        }

        private void productReg_Load(object sender, EventArgs e)
        {
            loadCategory();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addProduct();
        }
    }
}
