namespace csharpStockApp
{
    partial class categoryReg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCatId = new System.Windows.Forms.TextBox();
            this.btnAddcat = new System.Windows.Forms.Button();
            this.btnUpdateCat = new System.Windows.Forms.Button();
            this.btnClearCat = new System.Windows.Forms.Button();
            this.btnDeleteCat = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 5);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 70);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Image = global::csharpStockApp.Properties.Resources.icons8_close_20px;
            this.btnClose.Location = new System.Drawing.Point(494, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(19, 20);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category";
            // 
            // txtCatName
            // 
            this.txtCatName.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatName.Location = new System.Drawing.Point(198, 167);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(220, 23);
            this.txtCatName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(79, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Category name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(93, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Category ID";
            // 
            // txtCatId
            // 
            this.txtCatId.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatId.Location = new System.Drawing.Point(198, 122);
            this.txtCatId.Name = "txtCatId";
            this.txtCatId.ReadOnly = true;
            this.txtCatId.Size = new System.Drawing.Size(220, 23);
            this.txtCatId.TabIndex = 4;
            // 
            // btnAddcat
            // 
            this.btnAddcat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnAddcat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddcat.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddcat.ForeColor = System.Drawing.Color.White;
            this.btnAddcat.Location = new System.Drawing.Point(97, 218);
            this.btnAddcat.Name = "btnAddcat";
            this.btnAddcat.Size = new System.Drawing.Size(75, 29);
            this.btnAddcat.TabIndex = 5;
            this.btnAddcat.Text = "Add";
            this.btnAddcat.UseVisualStyleBackColor = true;
            this.btnAddcat.Click += new System.EventHandler(this.btnAddcat_Click);
            // 
            // btnUpdateCat
            // 
            this.btnUpdateCat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnUpdateCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateCat.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCat.ForeColor = System.Drawing.Color.White;
            this.btnUpdateCat.Location = new System.Drawing.Point(179, 218);
            this.btnUpdateCat.Name = "btnUpdateCat";
            this.btnUpdateCat.Size = new System.Drawing.Size(75, 29);
            this.btnUpdateCat.TabIndex = 6;
            this.btnUpdateCat.Text = "Update";
            this.btnUpdateCat.UseVisualStyleBackColor = true;
            this.btnUpdateCat.Click += new System.EventHandler(this.btnUpdateCat_Click);
            // 
            // btnClearCat
            // 
            this.btnClearCat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnClearCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCat.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCat.ForeColor = System.Drawing.Color.White;
            this.btnClearCat.Location = new System.Drawing.Point(261, 218);
            this.btnClearCat.Name = "btnClearCat";
            this.btnClearCat.Size = new System.Drawing.Size(75, 29);
            this.btnClearCat.TabIndex = 7;
            this.btnClearCat.Text = "Clear";
            this.btnClearCat.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCat
            // 
            this.btnDeleteCat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnDeleteCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCat.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCat.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCat.Location = new System.Drawing.Point(343, 218);
            this.btnDeleteCat.Name = "btnDeleteCat";
            this.btnDeleteCat.Size = new System.Drawing.Size(75, 29);
            this.btnDeleteCat.TabIndex = 8;
            this.btnDeleteCat.Text = "Delete";
            this.btnDeleteCat.UseVisualStyleBackColor = true;
            this.btnDeleteCat.Click += new System.EventHandler(this.btnDeleteCat_Click);
            // 
            // categoryReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(515, 290);
            this.Controls.Add(this.btnDeleteCat);
            this.Controls.Add(this.btnClearCat);
            this.Controls.Add(this.btnUpdateCat);
            this.Controls.Add(this.btnAddcat);
            this.Controls.Add(this.txtCatId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCatName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "categoryReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "categoryReg";
            this.Load += new System.EventHandler(this.categoryReg_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnAddcat;
        public System.Windows.Forms.Button btnUpdateCat;
        public System.Windows.Forms.Button btnClearCat;
        public System.Windows.Forms.Button btnDeleteCat;
        public System.Windows.Forms.TextBox txtCatName;
        public System.Windows.Forms.TextBox txtCatId;
        private System.Windows.Forms.Button btnClose;
    }
}