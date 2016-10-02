using System;
using System.Text;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class IncomeHeadSave : BaseSaveForm
    {
        private RefreshGridDataHandler<IncomeHead> _RefreshGridData;
        private IncomeHead _IncomeHead;

        public IncomeHeadSave(IncomeHead incomeHead, RefreshGridDataHandler<IncomeHead> refreshGridData)
        {
            _IncomeHead = incomeHead;
            _RefreshGridData = refreshGridData;
            InitializeComponent();
            btnSave.Click += btnSaveClick;
            btnDelete.Click += btnDeleteClick;
            btnClear.Click += btnClearClick;
        }

        private void IncomeHeadSave_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        protected override void DisplayData()
        {
            txtIncomeHead.Text = _IncomeHead.Name;
            btnDelete.Enabled = _IncomeHead.Id != 0;
        }

        protected override void CollectData()
        {
            _IncomeHead.Name = txtIncomeHead.Text.Trim();
        }

        protected override void ClearData()
        {
            _IncomeHead = new IncomeHead();
            DisplayData();
        }

        protected override void InitData() { }

        protected override bool ValidateData()
        {
            StringBuilder builder = new StringBuilder();
            if (string.IsNullOrEmpty(txtIncomeHead.Text.Trim()))
            {
                builder.AppendLine("Income head can't be blank.");
            }
            if (!string.IsNullOrEmpty(builder.ToString()))
            {
                MessageBox.Show(builder.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        protected override void RefreshGridData()
        {
            _RefreshGridData(_IncomeHead);
        }

        protected override void DeleteData()
        {
            Service.DeleteIncomeHead(_IncomeHead.Id);
            _IncomeHead.IsActive = false;
        }

        protected override void SaveData()
        {
            Service.SaveIncomeHead(_IncomeHead);
        }
    }
}
