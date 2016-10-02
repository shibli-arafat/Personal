namespace Dit.Lms.Gui
{
    partial class MainContainer
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
            System.Windows.Forms.Application.Exit();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainContainer));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnMember = new System.Windows.Forms.Button();
            this.btnExpenseHead = new System.Windows.Forms.Button();
            this.btnIncomeHead = new System.Windows.Forms.Button();
            this.btnExpense = new System.Windows.Forms.Button();
            this.btnIncome = new System.Windows.Forms.Button();
            this.btnRepayment = new System.Windows.Forms.Button();
            this.btnLoan = new System.Windows.Forms.Button();
            this.btnAboutUs = new System.Windows.Forms.Button();
            this.btnBackupDatabase = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 716);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(990, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // btnDeposit
            // 
            this.btnDeposit.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeposit.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.button;
            this.btnDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeposit.Location = new System.Drawing.Point(0, 110);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(94, 36);
            this.btnDeposit.TabIndex = 0;
            this.btnDeposit.Text = "Deposit";
            this.btnDeposit.UseVisualStyleBackColor = false;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnUser
            // 
            this.btnUser.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.button;
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.Location = new System.Drawing.Point(1, 398);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(94, 36);
            this.btnUser.TabIndex = 8;
            this.btnUser.Text = "User";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnMember
            // 
            this.btnMember.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.button;
            this.btnMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMember.Location = new System.Drawing.Point(1, 350);
            this.btnMember.Name = "btnMember";
            this.btnMember.Size = new System.Drawing.Size(94, 36);
            this.btnMember.TabIndex = 7;
            this.btnMember.Text = "Member";
            this.btnMember.UseVisualStyleBackColor = true;
            this.btnMember.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // btnExpenseHead
            // 
            this.btnExpenseHead.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.button;
            this.btnExpenseHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpenseHead.Location = new System.Drawing.Point(1, 302);
            this.btnExpenseHead.Name = "btnExpenseHead";
            this.btnExpenseHead.Size = new System.Drawing.Size(94, 36);
            this.btnExpenseHead.TabIndex = 6;
            this.btnExpenseHead.Text = "Expense Head";
            this.btnExpenseHead.UseVisualStyleBackColor = true;
            this.btnExpenseHead.Click += new System.EventHandler(this.btnExpenseHead_Click);
            // 
            // btnIncomeHead
            // 
            this.btnIncomeHead.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.button;
            this.btnIncomeHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncomeHead.Location = new System.Drawing.Point(1, 254);
            this.btnIncomeHead.Name = "btnIncomeHead";
            this.btnIncomeHead.Size = new System.Drawing.Size(94, 36);
            this.btnIncomeHead.TabIndex = 5;
            this.btnIncomeHead.Text = "Income Head";
            this.btnIncomeHead.UseVisualStyleBackColor = true;
            this.btnIncomeHead.Click += new System.EventHandler(this.btnIncomeHead_Click);
            // 
            // btnExpense
            // 
            this.btnExpense.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.button;
            this.btnExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpense.Location = new System.Drawing.Point(1, 206);
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.Size = new System.Drawing.Size(94, 36);
            this.btnExpense.TabIndex = 4;
            this.btnExpense.Text = "Expense";
            this.btnExpense.UseVisualStyleBackColor = true;
            this.btnExpense.Click += new System.EventHandler(this.btnExpense_Click);
            // 
            // btnIncome
            // 
            this.btnIncome.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.button;
            this.btnIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncome.Location = new System.Drawing.Point(1, 158);
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(94, 36);
            this.btnIncome.TabIndex = 3;
            this.btnIncome.Text = "Income";
            this.btnIncome.UseVisualStyleBackColor = true;
            this.btnIncome.Click += new System.EventHandler(this.btnIncome_Click);
            // 
            // btnRepayment
            // 
            this.btnRepayment.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.button;
            this.btnRepayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepayment.Location = new System.Drawing.Point(183, 192);
            this.btnRepayment.Name = "btnRepayment";
            this.btnRepayment.Size = new System.Drawing.Size(94, 36);
            this.btnRepayment.TabIndex = 2;
            this.btnRepayment.Text = "Repayment";
            this.btnRepayment.UseVisualStyleBackColor = true;
            this.btnRepayment.Visible = false;
            this.btnRepayment.Click += new System.EventHandler(this.btnRepayment_Click);
            // 
            // btnLoan
            // 
            this.btnLoan.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.button;
            this.btnLoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoan.Location = new System.Drawing.Point(182, 152);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Size = new System.Drawing.Size(94, 36);
            this.btnLoan.TabIndex = 1;
            this.btnLoan.Text = "Loan";
            this.btnLoan.UseVisualStyleBackColor = true;
            this.btnLoan.Visible = false;
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);
            // 
            // btnAboutUs
            // 
            this.btnAboutUs.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.button;
            this.btnAboutUs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAboutUs.Location = new System.Drawing.Point(0, 542);
            this.btnAboutUs.Name = "btnAboutUs";
            this.btnAboutUs.Size = new System.Drawing.Size(94, 36);
            this.btnAboutUs.TabIndex = 11;
            this.btnAboutUs.Text = "About Us";
            this.btnAboutUs.UseVisualStyleBackColor = true;
            this.btnAboutUs.Click += new System.EventHandler(this.btnAboutUs_Click);
            // 
            // btnBackupDatabase
            // 
            this.btnBackupDatabase.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.button;
            this.btnBackupDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackupDatabase.Location = new System.Drawing.Point(0, 494);
            this.btnBackupDatabase.Name = "btnBackupDatabase";
            this.btnBackupDatabase.Size = new System.Drawing.Size(94, 36);
            this.btnBackupDatabase.TabIndex = 10;
            this.btnBackupDatabase.Text = "Control Panel";
            this.btnBackupDatabase.UseVisualStyleBackColor = true;
            this.btnBackupDatabase.Click += new System.EventHandler(this.btnBackupDatabase_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.button;
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(1, 446);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(94, 36);
            this.btnReports.TabIndex = 9;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // MainContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(990, 738);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnBackupDatabase);
            this.Controls.Add(this.btnAboutUs);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.btnMember);
            this.Controls.Add(this.btnExpenseHead);
            this.Controls.Add(this.btnIncomeHead);
            this.Controls.Add(this.btnExpense);
            this.Controls.Add(this.btnIncome);
            this.Controls.Add(this.btnRepayment);
            this.Controls.Add(this.btnLoan);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainContainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnMember;
        private System.Windows.Forms.Button btnExpenseHead;
        private System.Windows.Forms.Button btnIncomeHead;
        private System.Windows.Forms.Button btnExpense;
        private System.Windows.Forms.Button btnIncome;
        private System.Windows.Forms.Button btnRepayment;
        private System.Windows.Forms.Button btnLoan;
        private System.Windows.Forms.Button btnAboutUs;
        private System.Windows.Forms.Button btnBackupDatabase;
        private System.Windows.Forms.Button btnReports;
    }
}



