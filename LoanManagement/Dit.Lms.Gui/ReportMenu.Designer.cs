namespace Dit.Lms.Gui
{
    partial class ReportMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportMenu));
            this.btnMember = new System.Windows.Forms.Button();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnIncomeReport = new System.Windows.Forms.Button();
            this.btnExpenseReport = new System.Windows.Forms.Button();
            this.btnLoanReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMember
            // 
            this.btnMember.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.button;
            this.btnMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMember.Location = new System.Drawing.Point(2, 11);
            this.btnMember.Name = "btnMember";
            this.btnMember.Size = new System.Drawing.Size(96, 36);
            this.btnMember.TabIndex = 0;
            this.btnMember.Text = "Member ";
            this.btnMember.UseVisualStyleBackColor = true;
            this.btnMember.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // btnDeposit
            // 
            this.btnDeposit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeposit.BackgroundImage")));
            this.btnDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeposit.Location = new System.Drawing.Point(2, 53);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(96, 36);
            this.btnDeposit.TabIndex = 1;
            this.btnDeposit.Text = "Deposit ";
            this.btnDeposit.UseVisualStyleBackColor = true;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnIncomeReport
            // 
            this.btnIncomeReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIncomeReport.BackgroundImage")));
            this.btnIncomeReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncomeReport.Location = new System.Drawing.Point(2, 139);
            this.btnIncomeReport.Name = "btnIncomeReport";
            this.btnIncomeReport.Size = new System.Drawing.Size(96, 36);
            this.btnIncomeReport.TabIndex = 3;
            this.btnIncomeReport.Text = "Income ";
            this.btnIncomeReport.UseVisualStyleBackColor = true;
            this.btnIncomeReport.Click += new System.EventHandler(this.btnIncomeReport_Click);
            // 
            // btnExpenseReport
            // 
            this.btnExpenseReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExpenseReport.BackgroundImage")));
            this.btnExpenseReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpenseReport.Location = new System.Drawing.Point(2, 181);
            this.btnExpenseReport.Name = "btnExpenseReport";
            this.btnExpenseReport.Size = new System.Drawing.Size(96, 36);
            this.btnExpenseReport.TabIndex = 4;
            this.btnExpenseReport.Text = "Expense ";
            this.btnExpenseReport.UseVisualStyleBackColor = true;
            this.btnExpenseReport.Click += new System.EventHandler(this.btnExpenseReport_Click);
            // 
            // btnLoanReport
            // 
            this.btnLoanReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoanReport.BackgroundImage")));
            this.btnLoanReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoanReport.Location = new System.Drawing.Point(2, 97);
            this.btnLoanReport.Name = "btnLoanReport";
            this.btnLoanReport.Size = new System.Drawing.Size(96, 36);
            this.btnLoanReport.TabIndex = 2;
            this.btnLoanReport.Text = "Loan ";
            this.btnLoanReport.UseVisualStyleBackColor = true;
            this.btnLoanReport.Click += new System.EventHandler(this.btnLoanReport_Click);
            // 
            // ReportMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.metal_texture1;
            this.ClientSize = new System.Drawing.Size(495, 228);
            this.Controls.Add(this.btnLoanReport);
            this.Controls.Add(this.btnExpenseReport);
            this.Controls.Add(this.btnIncomeReport);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.btnMember);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMember;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnIncomeReport;
        private System.Windows.Forms.Button btnExpenseReport;
        private System.Windows.Forms.Button btnLoanReport;
    }
}