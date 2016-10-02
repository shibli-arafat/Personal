using System;
using System.Windows.Forms;

namespace Dit.Lms.Gui
{
    public partial class BackupDatabase : BaseForm
    {
        public BackupDatabase()
        {
            InitializeComponent();
        }

        private void BackupDatabase_Load(object sender, System.EventArgs e)
        {

        }

        private void btnSelectDirectory_Click(object sender, System.EventArgs e)
        {
            if (fbdSelectDirectory.ShowDialog() == DialogResult.OK)
            {
                txtBackupDirectory.Text = fbdSelectDirectory.SelectedPath;
            }
        }

        private void btnStartBackup_Click(object sender, System.EventArgs e)
        {
            try
            {
                Service.BackupDatabase(txtBackupDirectory.Text.Trim());
                MessageBox.Show("Database backup is done successfully.", "Backup status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
