namespace Dit.Lms.Gui
{
    partial class ConfigDetailSave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigDetailSave));
            this.label1 = new System.Windows.Forms.Label();
            this.txtYearFrom = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtYearTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDepositAmount = new System.Windows.Forms.TextBox();
            this.txtMaxLoanInPercent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDepositCharge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(43, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fiscal Year";
            // 
            // txtYearFrom
            // 
            this.txtYearFrom.Location = new System.Drawing.Point(106, 32);
            this.txtYearFrom.MaxLength = 4;
            this.txtYearFrom.Name = "txtYearFrom";
            this.txtYearFrom.Size = new System.Drawing.Size(32, 20);
            this.txtYearFrom.TabIndex = 0;
            this.txtYearFrom.TextChanged += new System.EventHandler(this.txtYearFrom_TextChanged);
            this.txtYearFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYearFrom_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(137, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(10, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "-";
            // 
            // txtYearTo
            // 
            this.txtYearTo.BackColor = System.Drawing.SystemColors.Window;
            this.txtYearTo.Location = new System.Drawing.Point(146, 32);
            this.txtYearTo.MaxLength = 5;
            this.txtYearTo.Name = "txtYearTo";
            this.txtYearTo.ReadOnly = true;
            this.txtYearTo.Size = new System.Drawing.Size(32, 20);
            this.txtYearTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(39, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Deposit Amount";
            // 
            // txtDepositAmount
            // 
            this.txtDepositAmount.Location = new System.Drawing.Point(125, 62);
            this.txtDepositAmount.MaxLength = 10;
            this.txtDepositAmount.Name = "txtDepositAmount";
            this.txtDepositAmount.Size = new System.Drawing.Size(71, 20);
            this.txtDepositAmount.TabIndex = 2;
            this.txtDepositAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepositAmount_KeyPress);
            // 
            // txtMaxLoanInPercent
            // 
            this.txtMaxLoanInPercent.Location = new System.Drawing.Point(298, 32);
            this.txtMaxLoanInPercent.MaxLength = 3;
            this.txtMaxLoanInPercent.Name = "txtMaxLoanInPercent";
            this.txtMaxLoanInPercent.Size = new System.Drawing.Size(71, 20);
            this.txtMaxLoanInPercent.TabIndex = 1;
            this.txtMaxLoanInPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxLoanInPercent_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(186, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Max. Loan in Percent";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(224, 109);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 24);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(153, 109);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 24);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDepositCharge
            // 
            this.txtDepositCharge.Location = new System.Drawing.Point(298, 62);
            this.txtDepositCharge.MaxLength = 3;
            this.txtDepositCharge.Name = "txtDepositCharge";
            this.txtDepositCharge.Size = new System.Drawing.Size(71, 20);
            this.txtDepositCharge.TabIndex = 3;
            this.txtDepositCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepositCharge_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(214, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Deposit Charge";
            // 
            // ConfigDetailSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dit.Lms.Gui.Properties.Resources.metal_texture1;
            this.ClientSize = new System.Drawing.Size(386, 157);
            this.Controls.Add(this.txtDepositCharge);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMaxLoanInPercent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDepositAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtYearTo);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtYearFrom);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigDetailSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config Detail Save";
            this.Load += new System.EventHandler(this.ConfigDetailSave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYearFrom;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtYearTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDepositAmount;
        private System.Windows.Forms.TextBox txtMaxLoanInPercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDepositCharge;
        private System.Windows.Forms.Label label4;
    }
}