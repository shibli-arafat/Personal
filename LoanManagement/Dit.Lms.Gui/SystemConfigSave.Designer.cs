namespace Dit.Lms.Gui
{
    partial class SystemConfigSave
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemConfigSave));
            this.grdConfigDetails = new System.Windows.Forms.DataGridView();
            this.clmFiscalYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepositAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMaxLoanPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepositCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddDetails = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCompanyAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompanyRegNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdConfigDetails)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdConfigDetails
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdConfigDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdConfigDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdConfigDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdConfigDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmFiscalYear,
            this.clmDepositAmount,
            this.clmMaxLoanPercent,
            this.clmDepositCharge});
            this.grdConfigDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdConfigDetails.Location = new System.Drawing.Point(12, 21);
            this.grdConfigDetails.Name = "grdConfigDetails";
            this.grdConfigDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdConfigDetails.Size = new System.Drawing.Size(464, 136);
            this.grdConfigDetails.TabIndex = 4;
            this.grdConfigDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdConfigDetails_CellDoubleClick);
            // 
            // clmFiscalYear
            // 
            this.clmFiscalYear.DataPropertyName = "FiscalYear";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clmFiscalYear.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmFiscalYear.HeaderText = "Fiscal Year";
            this.clmFiscalYear.Name = "clmFiscalYear";
            // 
            // clmDepositAmount
            // 
            this.clmDepositAmount.DataPropertyName = "MonthlyDepositAmount";
            this.clmDepositAmount.HeaderText = "Deposit Amount";
            this.clmDepositAmount.Name = "clmDepositAmount";
            // 
            // clmMaxLoanPercent
            // 
            this.clmMaxLoanPercent.DataPropertyName = "MaxLoanAmountInPercent";
            this.clmMaxLoanPercent.HeaderText = "Max Loan in Percent";
            this.clmMaxLoanPercent.Name = "clmMaxLoanPercent";
            // 
            // clmDepositCharge
            // 
            this.clmDepositCharge.DataPropertyName = "DepositCharge";
            this.clmDepositCharge.HeaderText = "Deposit Charge";
            this.clmDepositCharge.Name = "clmDepositCharge";
            // 
            // btnAddDetails
            // 
            this.btnAddDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDetails.Location = new System.Drawing.Point(234, 163);
            this.btnAddDetails.Name = "btnAddDetails";
            this.btnAddDetails.Size = new System.Drawing.Size(157, 25);
            this.btnAddDetails.TabIndex = 5;
            this.btnAddDetails.Text = "Add new Config Details";
            this.btnAddDetails.UseVisualStyleBackColor = true;
            this.btnAddDetails.Click += new System.EventHandler(this.btnAddDetails_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.metal_texture1;
            this.groupBox1.Controls.Add(this.btnAddDetails);
            this.groupBox1.Controls.Add(this.grdConfigDetails);
            this.groupBox1.Location = new System.Drawing.Point(16, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 199);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config Details";
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.metal_texture1;
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.txtCompanyAddress);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCompanyRegNo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtCompanyName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(16, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 197);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Basic Config";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(372, 162);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCompanyAddress
            // 
            this.txtCompanyAddress.Location = new System.Drawing.Point(159, 67);
            this.txtCompanyAddress.MaxLength = 512;
            this.txtCompanyAddress.Multiline = true;
            this.txtCompanyAddress.Name = "txtCompanyAddress";
            this.txtCompanyAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCompanyAddress.Size = new System.Drawing.Size(274, 87);
            this.txtCompanyAddress.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(60, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Company Address";
            // 
            // txtCompanyRegNo
            // 
            this.txtCompanyRegNo.Location = new System.Drawing.Point(159, 42);
            this.txtCompanyRegNo.MaxLength = 64;
            this.txtCompanyRegNo.Name = "txtCompanyRegNo";
            this.txtCompanyRegNo.Size = new System.Drawing.Size(274, 20);
            this.txtCompanyRegNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(55, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Company Reg. No.";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(159, 17);
            this.txtCompanyName.MaxLength = 64;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(274, 20);
            this.txtCompanyName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(70, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Company Name";
            // 
            // SystemConfigSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.metal_texture1;
            this.ClientSize = new System.Drawing.Size(521, 422);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemConfigSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Configuration";
            this.Load += new System.EventHandler(this.SystemConfigSave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdConfigDetails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdConfigDetails;
        private System.Windows.Forms.Button btnAddDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCompanyAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCompanyRegNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFiscalYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepositAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaxLoanPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepositCharge;
    }
}