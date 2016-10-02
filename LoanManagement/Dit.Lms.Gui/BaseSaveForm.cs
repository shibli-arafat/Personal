using System;
using System.Windows.Forms;

namespace Dit.Lms.Gui
{
    public partial class BaseSaveForm : BaseForm
    {
        public BaseSaveForm()
        {
            InitializeComponent();
        }

        protected void btnSaveClick(object sender, System.EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    CollectData();
                    SaveData();
                    HookAnything();
                    RefreshGridData();
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected void btnClearClick(object sender, System.EventArgs e)
        {
            ClearData();
        }

        protected void btnDeleteClick(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the record.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DeleteData();
                    RefreshGridData();
                    ClearData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        protected virtual void SaveData() { }

        protected virtual void DeleteData() { }

        protected virtual void InitData() { }

        protected virtual bool ValidateData() { return false; }

        protected virtual void DisplayData() { }

        protected virtual void CollectData() { }

        protected virtual void ClearData() { }

        protected virtual void RefreshGridData() { }

        protected virtual void HookAnything() { }
    }
}
