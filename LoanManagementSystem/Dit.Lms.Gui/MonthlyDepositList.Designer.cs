namespace Dit.Lms.Gui
{
    partial class MonthlyDepositList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlyDepositList));
            this.grdDepositList = new System.Windows.Forms.DataGridView();
            this.clmMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepositedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmForYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmlForMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepositedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCollectedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYearTo = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtYearFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepositList)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDepositList
            // 
            this.grdDepositList.AllowUserToAddRows = false;
            this.grdDepositList.AllowUserToDeleteRows = false;
            this.grdDepositList.AllowUserToOrderColumns = true;
            this.grdDepositList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdDepositList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDepositList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdDepositList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDepositList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMemberId,
            this.clmDepositedBy,
            this.clmForYear,
            this.cmlForMonth,
            this.clmAmount,
            this.clmDepositedOn,
            this.clmCollectedBy});
            this.grdDepositList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdDepositList.Location = new System.Drawing.Point(29, 57);
            this.grdDepositList.Name = "grdDepositList";
            this.grdDepositList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDepositList.Size = new System.Drawing.Size(696, 335);
            this.grdDepositList.TabIndex = 3;
            this.grdDepositList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDepositList_CellDoubleClick);
            // 
            // clmMemberId
            // 
            this.clmMemberId.DataPropertyName = "MemberId";
            this.clmMemberId.HeaderText = "Member ID";
            this.clmMemberId.Name = "clmMemberId";
            this.clmMemberId.Width = 60;
            // 
            // clmDepositedBy
            // 
            this.clmDepositedBy.DataPropertyName = "MemberName";
            this.clmDepositedBy.HeaderText = "Member Name";
            this.clmDepositedBy.Name = "clmDepositedBy";
            this.clmDepositedBy.Width = 200;
            // 
            // clmForYear
            // 
            this.clmForYear.DataPropertyName = "Year";
            this.clmForYear.HeaderText = "For Year";
            this.clmForYear.Name = "clmForYear";
            this.clmForYear.Width = 75;
            // 
            // cmlForMonth
            // 
            this.cmlForMonth.DataPropertyName = "Month";
            this.cmlForMonth.HeaderText = "For Month";
            this.cmlForMonth.Name = "cmlForMonth";
            this.cmlForMonth.Width = 75;
            // 
            // clmAmount
            // 
            this.clmAmount.DataPropertyName = "Amount";
            this.clmAmount.HeaderText = "Amount";
            this.clmAmount.Name = "clmAmount";
            this.clmAmount.Width = 75;
            // 
            // clmDepositedOn
            // 
            this.clmDepositedOn.DataPropertyName = "DepositedOn";
            this.clmDepositedOn.HeaderText = "Deposited On";
            this.clmDepositedOn.Name = "clmDepositedOn";
            this.clmDepositedOn.Width = 90;
            // 
            // clmCollectedBy
            // 
            this.clmCollectedBy.DataPropertyName = "CollectedBy";
            this.clmCollectedBy.HeaderText = "Collected By";
            this.clmCollectedBy.Name = "clmCollectedBy";
            this.clmCollectedBy.Width = 200;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(650, 405);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 4;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(338, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(99, 20);
            this.txtMemberId.MaxLength = 6;
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(67, 20);
            this.txtMemberId.TabIndex = 0;
            this.txtMemberId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMemberId_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Member ID:";
            // 
            // txtYearTo
            // 
            this.txtYearTo.BackColor = System.Drawing.SystemColors.Window;
            this.txtYearTo.Location = new System.Drawing.Point(296, 20);
            this.txtYearTo.MaxLength = 5;
            this.txtYearTo.Name = "txtYearTo";
            this.txtYearTo.ReadOnly = true;
            this.txtYearTo.Size = new System.Drawing.Size(32, 20);
            this.txtYearTo.TabIndex = 17;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(287, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(10, 20);
            this.textBox2.TabIndex = 16;
            this.textBox2.Text = "-";
            // 
            // txtYearFrom
            // 
            this.txtYearFrom.Location = new System.Drawing.Point(256, 20);
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
            this.label2.Location = new System.Drawing.Point(179, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Fiscal Year:";
            // 
            // MonthlyDepositList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.metal_texture1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(754, 439);
            this.Controls.Add(this.txtYearTo);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtYearFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtMemberId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.grdDepositList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MonthlyDepositList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Deposits";
            this.Load += new System.EventHandler(this.MonthlyDepositList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepositList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDepositList;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYearTo;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtYearFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepositedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmForYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmlForMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepositedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCollectedBy;

    }
}