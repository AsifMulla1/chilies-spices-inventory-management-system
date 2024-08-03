namespace Red_cillies
{
    partial class Customer
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
            this.textCemailTb = new System.Windows.Forms.TextBox();
            this.textCmobTb = new System.Windows.Forms.TextBox();
            this.textCaddrTb = new System.Windows.Forms.TextBox();
            this.textCnameTb = new System.Windows.Forms.TextBox();
            this.CemailLabel = new System.Windows.Forms.Label();
            this.CmobnoLabel = new System.Windows.Forms.Label();
            this.CaddrLabel = new System.Windows.Forms.Label();
            this.CNameLabel = new System.Windows.Forms.Label();
            this.textCidTb = new System.Windows.Forms.TextBox();
            this.CidLabel = new System.Windows.Forms.Label();
            this.CustomerDetailsLabel = new System.Windows.Forms.Label();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.textCemailTb);
            this.panel1.Controls.Add(this.textCmobTb);
            this.panel1.Controls.Add(this.textCaddrTb);
            this.panel1.Controls.Add(this.textCnameTb);
            this.panel1.Controls.Add(this.CemailLabel);
            this.panel1.Controls.Add(this.CmobnoLabel);
            this.panel1.Controls.Add(this.CaddrLabel);
            this.panel1.Controls.Add(this.CNameLabel);
            this.panel1.Controls.Add(this.textCidTb);
            this.panel1.Controls.Add(this.CidLabel);
            this.panel1.Location = new System.Drawing.Point(169, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 338);
            this.panel1.TabIndex = 1;
            // 
            // textCemailTb
            // 
            this.textCemailTb.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCemailTb.Location = new System.Drawing.Point(301, 271);
            this.textCemailTb.Name = "textCemailTb";
            this.textCemailTb.Size = new System.Drawing.Size(237, 27);
            this.textCemailTb.TabIndex = 25;
            this.textCemailTb.TextChanged += new System.EventHandler(this.textCemailTb_TextChanged);
            this.textCemailTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CemailTb_KeyDown);
            this.textCemailTb.Validating += new System.ComponentModel.CancelEventHandler(this.textCemailTb_Validating);
            // 
            // textCmobTb
            // 
            this.textCmobTb.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCmobTb.Location = new System.Drawing.Point(301, 211);
            this.textCmobTb.MaxLength = 10;
            this.textCmobTb.Name = "textCmobTb";
            this.textCmobTb.Size = new System.Drawing.Size(237, 27);
            this.textCmobTb.TabIndex = 24;
            this.textCmobTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmobTb_KeyDown);
            this.textCmobTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmobTb_KeyPress);
            // 
            // textCaddrTb
            // 
            this.textCaddrTb.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCaddrTb.Location = new System.Drawing.Point(301, 152);
            this.textCaddrTb.Name = "textCaddrTb";
            this.textCaddrTb.Size = new System.Drawing.Size(237, 27);
            this.textCaddrTb.TabIndex = 23;
            this.textCaddrTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CaddrTb_KeyDown);
            // 
            // textCnameTb
            // 
            this.textCnameTb.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCnameTb.Location = new System.Drawing.Point(301, 96);
            this.textCnameTb.Name = "textCnameTb";
            this.textCnameTb.Size = new System.Drawing.Size(237, 27);
            this.textCnameTb.TabIndex = 22;
            this.textCnameTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CnameTb_KeyDown);
            this.textCnameTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CnameTb_KeyPress);
            // 
            // CemailLabel
            // 
            this.CemailLabel.AutoSize = true;
            this.CemailLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CemailLabel.ForeColor = System.Drawing.Color.Black;
            this.CemailLabel.Location = new System.Drawing.Point(66, 276);
            this.CemailLabel.Name = "CemailLabel";
            this.CemailLabel.Size = new System.Drawing.Size(168, 22);
            this.CemailLabel.TabIndex = 21;
            this.CemailLabel.Text = "Customer Email Id";
            // 
            // CmobnoLabel
            // 
            this.CmobnoLabel.AutoSize = true;
            this.CmobnoLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmobnoLabel.ForeColor = System.Drawing.Color.Black;
            this.CmobnoLabel.Location = new System.Drawing.Point(66, 216);
            this.CmobnoLabel.Name = "CmobnoLabel";
            this.CmobnoLabel.Size = new System.Drawing.Size(204, 22);
            this.CmobnoLabel.TabIndex = 20;
            this.CmobnoLabel.Text = "Customer Contact no ";
            // 
            // CaddrLabel
            // 
            this.CaddrLabel.AutoSize = true;
            this.CaddrLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaddrLabel.ForeColor = System.Drawing.Color.Black;
            this.CaddrLabel.Location = new System.Drawing.Point(66, 157);
            this.CaddrLabel.Name = "CaddrLabel";
            this.CaddrLabel.Size = new System.Drawing.Size(171, 22);
            this.CaddrLabel.TabIndex = 19;
            this.CaddrLabel.Text = "Customer Address";
            // 
            // CNameLabel
            // 
            this.CNameLabel.AutoSize = true;
            this.CNameLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CNameLabel.ForeColor = System.Drawing.Color.Black;
            this.CNameLabel.Location = new System.Drawing.Point(66, 101);
            this.CNameLabel.Name = "CNameLabel";
            this.CNameLabel.Size = new System.Drawing.Size(154, 22);
            this.CNameLabel.TabIndex = 18;
            this.CNameLabel.Text = "Customer Name";
            // 
            // textCidTb
            // 
            this.textCidTb.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCidTb.Location = new System.Drawing.Point(301, 38);
            this.textCidTb.Name = "textCidTb";
            this.textCidTb.Size = new System.Drawing.Size(237, 27);
            this.textCidTb.TabIndex = 11;
            this.textCidTb.TextChanged += new System.EventHandler(this.textCidTb_TextChanged);
            this.textCidTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CidTb_KeyDown);
            this.textCidTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CidTb_KeyPress);
            // 
            // CidLabel
            // 
            this.CidLabel.AutoSize = true;
            this.CidLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CidLabel.ForeColor = System.Drawing.Color.Black;
            this.CidLabel.Location = new System.Drawing.Point(66, 43);
            this.CidLabel.Name = "CidLabel";
            this.CidLabel.Size = new System.Drawing.Size(118, 22);
            this.CidLabel.TabIndex = 1;
            this.CidLabel.Text = "Customer ID";
            // 
            // CustomerDetailsLabel
            // 
            this.CustomerDetailsLabel.AutoSize = true;
            this.CustomerDetailsLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerDetailsLabel.Location = new System.Drawing.Point(192, 23);
            this.CustomerDetailsLabel.Name = "CustomerDetailsLabel";
            this.CustomerDetailsLabel.Size = new System.Drawing.Size(239, 35);
            this.CustomerDetailsLabel.TabIndex = 17;
            this.CustomerDetailsLabel.Text = "Customer Details";
            // 
            // btnPurchase
            // 
            this.btnPurchase.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPurchase.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchase.ForeColor = System.Drawing.Color.Black;
            this.btnPurchase.Location = new System.Drawing.Point(32, 147);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(112, 38);
            this.btnPurchase.TabIndex = 5;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSupplier.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.ForeColor = System.Drawing.Color.Black;
            this.btnSupplier.Location = new System.Drawing.Point(32, 91);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(112, 37);
            this.btnSupplier.TabIndex = 4;
            this.btnSupplier.Text = "Supplier";
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnProduct.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.Black;
            this.btnProduct.Location = new System.Drawing.Point(32, 35);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(112, 35);
            this.btnProduct.TabIndex = 3;
            this.btnProduct.Text = "Product";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.CustomerDetailsLabel);
            this.panel2.Location = new System.Drawing.Point(169, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 86);
            this.panel2.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Location = new System.Drawing.Point(169, 448);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(629, 82);
            this.panel3.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(510, 20);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 36);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(395, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 36);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(270, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 36);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(152, 20);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 36);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(29, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 36);
            this.button4.TabIndex = 0;
            this.button4.Text = "NEW";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button9.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Location = new System.Drawing.Point(32, 480);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(112, 40);
            this.button9.TabIndex = 28;
            this.button9.Text = "Logout";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(32, 199);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 37);
            this.button5.TabIndex = 29;
            this.button5.Text = "Bill";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 552);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.btnSupplier);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.panel1);
            this.Name = "Customer";
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.Customer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CustomerDetailsLabel;
        private System.Windows.Forms.TextBox textCidTb;
        private System.Windows.Forms.Label CidLabel;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.TextBox textCemailTb;
        private System.Windows.Forms.TextBox textCmobTb;
        private System.Windows.Forms.TextBox textCaddrTb;
        private System.Windows.Forms.TextBox textCnameTb;
        private System.Windows.Forms.Label CemailLabel;
        private System.Windows.Forms.Label CmobnoLabel;
        private System.Windows.Forms.Label CaddrLabel;
        private System.Windows.Forms.Label CNameLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button5;
    }
}