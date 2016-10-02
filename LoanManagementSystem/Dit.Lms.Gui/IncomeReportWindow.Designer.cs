namespace Dit.Lms.Gui
{
    partial class IncomeReportWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncomeReportWindow));
            this.cmbIncomeHeads = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoDateWise = new System.Windows.Forms.RadioButton();
            this.rdoHeadWise = new System.Windows.Forms.RadioButton();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbIncomeHeads
            // 
            this.cmbIncomeHeads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIncomeHeads.FormattingEnabled = true;
            this.cmbIncomeHeads.Location = new System.Drawing.Point(64, 77);
            this.cmbIncomeHeads.Name = "cmbIncomeHeads";
            this.cmbIncomeHeads.Size = new System.Drawing.Size(190, 21);
            this.cmbIncomeHeads.TabIndex = 4;
            this.cmbIncomeHeads.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbIncomeHeads_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(26, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Head:";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(172, 50);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(82, 20);
            this.dtpDateTo.TabIndex = 3;
            this.dtpDateTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpDateTo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(148, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "To:";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(64, 51);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(82, 20);
            this.dtpDateFrom.TabIndex = 2;
            this.dtpDateFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpDateFrom_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(29, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "From:";
            // 
            // rdoDateWise
            // 
            this.rdoDateWise.AutoSize = true;
            this.rdoDateWise.BackColor = System.Drawing.Color.Transparent;
            this.rdoDateWise.Checked = true;
            this.rdoDateWise.Location = new System.Drawing.Point(33, 18);
            this.rdoDateWise.Name = "rdoDateWise";
            this.rdoDateWise.Size = new System.Drawing.Size(75, 17);
            this.rdoDateWise.TabIndex = 0;
            this.rdoDateWise.TabStop = true;
            this.rdoDateWise.Text = "Date Wise";
            this.rdoDateWise.UseVisualStyleBackColor = false;
            this.rdoDateWise.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdoDateWise_KeyPress);
            // 
            // rdoHeadWise
            // 
            this.rdoHeadWise.AutoSize = true;
            this.rdoHeadWise.BackColor = System.Drawing.Color.Transparent;
            this.rdoHeadWise.Location = new System.Drawing.Point(133, 18);
            this.rdoHeadWise.Name = "rdoHeadWise";
            this.rdoHeadWise.Size = new System.Drawing.Size(116, 17);
            this.rdoHeadWise.TabIndex = 1;
            this.rdoHeadWise.Text = "Income Head Wise";
            this.rdoHeadWise.UseVisualStyleBackColor = false;
            this.rdoHeadWise.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdoHeadWise_KeyPress);
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(97, 113);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(86, 22);
            this.btnShowReport.TabIndex = 5;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // IncomeReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.metal_texture1;
            this.ClientSize = new System.Drawing.Size(281, 154);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.rdoHeadWise);
            this.Controls.Add(this.rdoDateWise);
            this.Controls.Add(this.cmbIncomeHeads);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDateTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncomeReportWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Income Report";
            this.Load += new System.EventHandler(this.IncomeReportWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbIncomeHeads;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoDateWise;
        private System.Windows.Forms.RadioButton rdoHeadWise;
        private System.Windows.Forms.Button btnShowReport;
    }
}