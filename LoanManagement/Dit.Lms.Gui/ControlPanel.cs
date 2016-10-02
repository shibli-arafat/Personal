using System;
using System.Windows.Forms;

namespace Dit.Lms.Gui
{
    public partial class ControlPanel : Form
    {
        public ControlPanel()
        {
            InitializeComponent();
        }

        private void btnBackupDatabase_Click(object sender, EventArgs e)
        {
            new BackupDatabase().ShowDialog();
        }

        private void btnSystemConfig_Click(object sender, EventArgs e)
        {
            new SystemConfigSave().ShowDialog();
        }

    }
}
