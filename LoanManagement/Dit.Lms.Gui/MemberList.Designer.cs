namespace Dit.Lms.Gui
{
    partial class MemberList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberList));
            this.btnAddNew = new System.Windows.Forms.Button();
            this.grdMemberList = new System.Windows.Forms.DataGridView();
            this.clmMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInitialBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCurrentBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPresentAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMemberList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(780, 513);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // grdMemberList
            // 
            this.grdMemberList.AllowUserToAddRows = false;
            this.grdMemberList.AllowUserToDeleteRows = false;
            this.grdMemberList.AllowUserToOrderColumns = true;
            this.grdMemberList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdMemberList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMemberList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMemberList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMemberId,
            this.clmName,
            this.clmMobile,
            this.clmInitialBalance,
            this.clmCurrentBalance,
            this.clmDateOfBirth,
            this.clmPresentAddress});
            this.grdMemberList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdMemberList.Location = new System.Drawing.Point(19, 61);
            this.grdMemberList.Name = "grdMemberList";
            this.grdMemberList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMemberList.Size = new System.Drawing.Size(836, 437);
            this.grdMemberList.TabIndex = 2;
            this.grdMemberList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMemberList_CellDoubleClick);
            // 
            // clmMemberId
            // 
            this.clmMemberId.DataPropertyName = "MemberId";
            this.clmMemberId.HeaderText = "Member ID";
            this.clmMemberId.Name = "clmMemberId";
            this.clmMemberId.Width = 60;
            // 
            // clmName
            // 
            this.clmName.DataPropertyName = "Name";
            this.clmName.HeaderText = "Name";
            this.clmName.Name = "clmName";
            this.clmName.Width = 200;
            // 
            // clmMobile
            // 
            this.clmMobile.DataPropertyName = "Mobile";
            this.clmMobile.HeaderText = "Mobile No";
            this.clmMobile.Name = "clmMobile";
            // 
            // clmInitialBalance
            // 
            this.clmInitialBalance.DataPropertyName = "InitialBalance";
            this.clmInitialBalance.HeaderText = "Initial Balance";
            this.clmInitialBalance.Name = "clmInitialBalance";
            this.clmInitialBalance.Width = 70;
            // 
            // clmCurrentBalance
            // 
            this.clmCurrentBalance.DataPropertyName = "PresentBalance";
            this.clmCurrentBalance.HeaderText = "Current Balance";
            this.clmCurrentBalance.Name = "clmCurrentBalance";
            this.clmCurrentBalance.Width = 70;
            // 
            // clmDateOfBirth
            // 
            this.clmDateOfBirth.DataPropertyName = "DateOfBirth";
            this.clmDateOfBirth.HeaderText = "Date of Birth";
            this.clmDateOfBirth.Name = "clmDateOfBirth";
            this.clmDateOfBirth.Width = 75;
            // 
            // clmPresentAddress
            // 
            this.clmPresentAddress.DataPropertyName = "PresentAddress";
            this.clmPresentAddress.HeaderText = "Present Address";
            this.clmPresentAddress.Name = "clmPresentAddress";
            this.clmPresentAddress.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Member ID:";
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(89, 26);
            this.txtMemberId.MaxLength = 6;
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(86, 20);
            this.txtMemberId.TabIndex = 0;
            this.txtMemberId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMemberId_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(181, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // MemberList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.metal_texture1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(874, 552);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtMemberId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.grdMemberList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MemberList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Member List";
            this.Load += new System.EventHandler(this.MemberList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMemberList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.DataGridView grdMemberList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInitialBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCurrentBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPresentAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Button btnSearch;
    }
}