namespace Dit.Lms.Gui
{
    partial class LoanRepaymentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoanRepaymentList));
            this.btnAddNew = new System.Windows.Forms.Button();
            this.grdLoanRepaymentList = new System.Windows.Forms.DataGridView();
            this.clmMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRepaidBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRepaidOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoanRepaymentList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(569, 412);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 5;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // grdLoanRepaymentList
            // 
            this.grdLoanRepaymentList.AllowUserToAddRows = false;
            this.grdLoanRepaymentList.AllowUserToDeleteRows = false;
            this.grdLoanRepaymentList.AllowUserToOrderColumns = true;
            this.grdLoanRepaymentList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdLoanRepaymentList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLoanRepaymentList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdLoanRepaymentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLoanRepaymentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMemberId,
            this.clmRepaidBy,
            this.clmMonth,
            this.clmYear,
            this.clmAmount,
            this.clmRepaidOn});
            this.grdLoanRepaymentList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdLoanRepaymentList.Location = new System.Drawing.Point(27, 52);
            this.grdLoanRepaymentList.Name = "grdLoanRepaymentList";
            this.grdLoanRepaymentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLoanRepaymentList.Size = new System.Drawing.Size(617, 347);
            this.grdLoanRepaymentList.TabIndex = 10;
            this.grdLoanRepaymentList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLoanRepaymentList_CellDoubleClick);
            // 
            // clmMemberId
            // 
            this.clmMemberId.DataPropertyName = "MemberId";
            this.clmMemberId.HeaderText = "Member ID";
            this.clmMemberId.Name = "clmMemberId";
            this.clmMemberId.Width = 70;
            // 
            // clmRepaidBy
            // 
            this.clmRepaidBy.DataPropertyName = "MemberName";
            this.clmRepaidBy.HeaderText = "Member Name";
            this.clmRepaidBy.Name = "clmRepaidBy";
            this.clmRepaidBy.Width = 200;
            // 
            // clmMonth
            // 
            this.clmMonth.DataPropertyName = "Month";
            this.clmMonth.HeaderText = "Month";
            this.clmMonth.Name = "clmMonth";
            // 
            // clmYear
            // 
            this.clmYear.DataPropertyName = "Year";
            this.clmYear.HeaderText = "Year";
            this.clmYear.Name = "clmYear";
            this.clmYear.Width = 75;
            // 
            // clmAmount
            // 
            this.clmAmount.DataPropertyName = "Amount";
            this.clmAmount.HeaderText = "Amount";
            this.clmAmount.Name = "clmAmount";
            this.clmAmount.Width = 75;
            // 
            // clmRepaidOn
            // 
            this.clmRepaidOn.DataPropertyName = "CollectedOn";
            this.clmRepaidOn.HeaderText = "Repaid On";
            this.clmRepaidOn.Name = "clmRepaidOn";
            // 
            // LoanRepaymentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.metal_texture1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(670, 447);
            this.Controls.Add(this.grdLoanRepaymentList);
            this.Controls.Add(this.btnAddNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoanRepaymentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan Repayment List";
            this.Load += new System.EventHandler(this.LoanRepaymentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoanRepaymentList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.DataGridView grdLoanRepaymentList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRepaidBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRepaidOn;
    }
}