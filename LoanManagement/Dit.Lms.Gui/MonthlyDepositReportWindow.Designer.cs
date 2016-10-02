namespace Dit.Lms.Gui
{
    partial class MonthlyDepositReportWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlyDepositReportWindow));
            this.btnShowReport = new System.Windows.Forms.Button();
            this.txtYearTo = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtYearFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(54, 93);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(83, 23);
            this.btnShowReport.TabIndex = 2;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // txtYearTo
            // 
            this.txtYearTo.BackColor = System.Drawing.SystemColors.Window;
            this.txtYearTo.Location = new System.Drawing.Point(137, 52);
            this.txtYearTo.MaxLength = 5;
            this.txtYearTo.Name = "txtYearTo";
            this.txtYearTo.ReadOnly = true;
            this.txtYearTo.Size = new System.Drawing.Size(32, 20);
            this.txtYearTo.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(128, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(10, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "-";
            // 
            // txtYearFrom
            // 
            this.txtYearFrom.Location = new System.Drawing.Point(97, 52);
            this.txtYearFrom.MaxLength = 4;
            this.txtYearFrom.Name = "txtYearFrom";
            this.txtYearFrom.Size = new System.Drawing.Size(32, 20);
            this.txtYearFrom.TabIndex = 1;
            this.txtYearFrom.TextChanged += new System.EventHandler(this.txtYearFrom_TextChanged);
            this.txtYearFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYearFrom_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Fiscal Year:";
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(97, 24);
            this.txtMemberId.MaxLength = 6;
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(72, 20);
            this.txtMemberId.TabIndex = 0;
            this.txtMemberId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMemberId_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Member ID:";
            // 
            // MonthlyDepositReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.metal_texture1;
            this.ClientSize = new System.Drawing.Size(190, 129);
            this.Controls.Add(this.txtYearTo);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtYearFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMemberId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShowReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonthlyDepositReportWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Deposit Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.TextBox txtYearTo;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtYearFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Label label1;
    }
}