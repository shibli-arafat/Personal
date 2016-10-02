namespace Dit.Lms.Gui
{
    partial class MemberReportWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberReportWindow));
            this.rdoIndividual = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rdoIndividual
            // 
            this.rdoIndividual.AutoSize = true;
            this.rdoIndividual.BackColor = System.Drawing.Color.Transparent;
            this.rdoIndividual.Checked = true;
            this.rdoIndividual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoIndividual.Location = new System.Drawing.Point(39, 24);
            this.rdoIndividual.Name = "rdoIndividual";
            this.rdoIndividual.Size = new System.Drawing.Size(80, 17);
            this.rdoIndividual.TabIndex = 0;
            this.rdoIndividual.TabStop = true;
            this.rdoIndividual.Text = "Individual";
            this.rdoIndividual.UseVisualStyleBackColor = false;
            this.rdoIndividual.CheckedChanged += new System.EventHandler(this.rdoIndividual_CheckedChanged);
            this.rdoIndividual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdoIndividual_KeyPress);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.BackColor = System.Drawing.Color.Transparent;
            this.rdoAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAll.Location = new System.Drawing.Point(162, 24);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(39, 17);
            this.rdoAll.TabIndex = 1;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = false;
            this.rdoAll.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdoAll_KeyPress);
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(79, 94);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(79, 23);
            this.btnShowReport.TabIndex = 3;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(36, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Member ID:";
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(101, 56);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(100, 20);
            this.txtMemberId.TabIndex = 2;
            this.txtMemberId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMemberId_KeyPress);
            // 
            // MemberReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.metal_texture1;
            this.ClientSize = new System.Drawing.Size(237, 135);
            this.Controls.Add(this.txtMemberId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.rdoAll);
            this.Controls.Add(this.rdoIndividual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MemberReportWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Member Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoIndividual;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMemberId;
    }
}