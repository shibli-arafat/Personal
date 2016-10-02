using System;
using System.Configuration;
using System.Drawing;
using ArmyTraining.Internal;

namespace ArmyTraining
{
    public partial class ControlPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BackupDatabase_Click(object sender, EventArgs e)
        {
            string backupDir = ConfigurationManager.AppSettings["DBBackupDir"];
            TrainingInternal trInternal = new TrainingInternal();
            try
            {
                trInternal.BackupDatabase(backupDir);
                lblBackupMsg.ForeColor = Color.Green;
                lblBackupMsg.Text = "Backup taken successfully!";
            }
            catch (Exception ex)
            {
                lblBackupMsg.ForeColor = Color.Red;
                lblBackupMsg.Text = ex.Message;
            }
        }
    }
}