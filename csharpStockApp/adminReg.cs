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
    public partial class adminReg : Form
    {
        public adminReg()
        {
            InitializeComponent();
        }

        configuration config = new configuration();
        string sql = "";
        SqlCommand cmd;
        SqlDataReader dr;

        string fn, username, pass, phone, role;

        #region ALL FUNCTIONS

        void validate()
        {
            bool isError=false; 

            if(txtFullname.Text == string.Empty)
            {
                MessageBox.Show("Fullname required", "DATA REQUIRED!", 0, MessageBoxIcon.Error);
                txtFullname.Focus();
                isError = true;
            }
            else if(txtUsername.Text =="")
            {
                MessageBox.Show("Username required", "DATA REQUIRED!", 0, MessageBoxIcon.Error);
                txtUsername.Focus();
                isError = true;
            }
            else if(txtPassword.Text =="")
            {
                MessageBox.Show("Password required", "DATA REQUIRED!", 0, MessageBoxIcon.Error);
                txtPassword.Focus();
                isError = true;
            }
            else if(txtPhone.Text=="")
            {
                MessageBox.Show("Phone number required", "DATA REQUIRED!", 0, MessageBoxIcon.Error);
                txtPhone.Focus();
                isError = true;
            }
            else if(cboRole.Text =="")
            {
                MessageBox.Show("Select role number required", "DATA REQUIRED!", 0, MessageBoxIcon.Error);
                isError = true;
            }

            if(!isError)
            {
                addAdmin();
            }
        }

        void mapControls()
        {
            fn = txtFullname.Text;
            username = txtUsername.Text;
            pass = txtPassword.Text;
            phone = txtPhone.Text;
            role = cboRole.Text;
        }

        private void adminReg_Load(object sender, EventArgs e)
        {
            getAdminId();
        }

        void addAdmin()
        {
            mapControls();

          
            DialogResult ASK = MessageBox.Show("Are you sure you want to add admin?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (ASK == DialogResult.Yes)
            {
                try
                {
                    cmd = new SqlCommand("addAdmin", config.getCon()) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@fn", fn);
                    cmd.Parameters.AddWithValue("@usn", username);
                    cmd.Parameters.AddWithValue("@uspass", pass);
                    cmd.Parameters.AddWithValue("@tel", phone);
                    cmd.Parameters.AddWithValue("@usrole", role);

                    config.openCon();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Admin added successfully", "SUCCESSFUL", 0, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Failed to add admin", "FAILED!", 0, MessageBoxIcon.Error);
                    }
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
            else
            {
                MessageBox.Show("Adding admin terminated", "TERMINATED", 0, MessageBoxIcon.Information);
            }
        }

        void getAdminId()
        {
            try
            {
                sql = "select * from adminTB ";
                cmd = new SqlCommand(sql, config.getCon());
                config.openCon();

                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    cboSearch.Items.Add(dr[0].ToString());
                }       
            }
            catch(System.Exception e)
            {
                MessageBox.Show("An error occured " + e.ToString());
            }
            finally
            {
                config.closeCon();
            }
        }

        private void btnUpdateadmin_Click(object sender, EventArgs e)
        {
            update();
        }

        void fillControls()
        {
            //mapControls();

            string getid = cboSearch.SelectedItem.ToString();

            try
            {
                sql = "select * from adminTB where adminId='"+ getid + "'";
                cmd = new SqlCommand(sql, config.getCon());
                config.openCon();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   txtFullname.Text = dr[1].ToString();
                    txtUsername.Text = dr[2].ToString();
                    txtPassword.Text = dr[3].ToString();
                    txtPhone.Text = dr[4].ToString();
                    cboRole.Text = dr[5].ToString();
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show("An error occured " + e.ToString());
            }
            finally
            {
                config.closeCon();
            }
        }

        void update()
        {
            mapControls();
            string getid = cboSearch.Text;

            if(cboSearch.Text =="")
            {
                MessageBox.Show("ID required in the search box", "DATA REQUIRED", 0, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    sql = "update adminTB set fullName ='" + fn + "',userName='" + username + "',userPassword='" + pass + "',phone='" + phone + "',userRole='" + role + "' where adminId='" + getid + "'";
                    cmd = new SqlCommand(sql, config.getCon());

                    config.openCon();
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Successfully updated", "SUCCESSFUL", 0, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update", "FAILED", 0, MessageBoxIcon.Error);

                    }

                }
                catch(System.Exception e)
                {
                    MessageBox.Show("An error occured " + e.Message);
                }

            }



        }

        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            fillControls();
        }

        private void btnAddadmin_Click(object sender, EventArgs e)
        {
            validate();
        }
    }
}
