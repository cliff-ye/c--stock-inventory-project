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
    public partial class DisplayOrder : Form
    {
        public DisplayOrder()
        {
            InitializeComponent();
            getAllOrders();
        }
        configuration config = new configuration();
        SqlCommand cmd;
        string sql = "";
        SqlDataReader dr;

        string oid, cname, pname, price, qty, total;

        Parent p = new Parent();
        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            p.mainPanel.Controls.Add(childForm);
            p.mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frmOrder ord = new frmOrder();
            ord.ShowDialog();
        }

        void getAllOrders()
        {
            try
            {
                dataGridView1.Rows.Clear();
                sql = "SELECT orderID, orderDate, O.productID, P.ProductName, O.customerID, C.customerName,O.Quantity,O.price, O.total  FROM orderTB AS O JOIN customerTB AS C ON O.customerID=C.customerId JOIN productTB AS P ON O.productID=P.ProductID";
                cmd = new SqlCommand(sql, config.getCon());
                config.openCon();
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(),dr[6].ToString(),dr[7].ToString(),dr[8].ToString());
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

        void assignVar()
        {
             lblOrdId.Text=oid;
             lblCustName.Text=cname;
            lblProdName.Text=pname;
            lblPrice.Text=price;
            lblQty.Text=qty;
            lblTotal.Text=total;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            assignVar();

            oid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            pname = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cname = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            qty= dataGridView1.CurrentRow.Cells[6].Value.ToString();
            price= dataGridView1.CurrentRow.Cells[7].Value.ToString();
            total= dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }
    }
}