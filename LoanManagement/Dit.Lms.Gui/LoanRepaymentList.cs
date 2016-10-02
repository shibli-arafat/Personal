using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class LoanRepaymentList : BaseForm
    {
        private Form _MdiParent;
        private LoanRepaymentSave _LoanRepaymentForm;
        private LoanRepayment _LoanRepayment;
        private LoanRepaymentCollection _LoanRepayments;

        public LoanRepaymentList(Form mdiParent)
        {
            _MdiParent = mdiParent;
            InitializeComponent();
            grdLoanRepaymentList.AutoGenerateColumns = false;
        }

        private void btnAddNew_Click(object sender, System.EventArgs e)
        {
            _LoanRepayment = new LoanRepayment();
            ShowLoanRepaymentForm();
        }

        private void ShowLoanRepaymentForm()
        {
            if (_LoanRepaymentForm == null || _LoanRepaymentForm.IsDisposed) _LoanRepaymentForm = new LoanRepaymentSave(_LoanRepayment, RefreshGridData);
            _LoanRepaymentForm.MdiParent = _MdiParent;
            if (!_LoanRepaymentForm.Visible) _LoanRepaymentForm.Show();
            else _LoanRepaymentForm.Activate();
        }

        private void LoanRepaymentList_Load(object sender, System.EventArgs e)
        {
            _LoanRepayments = Service.GetLoanRepayments();
            BindLoanRepayments();
        }

        private void RefreshGridData(LoanRepayment gridData)
        {
            _LoanRepayments.Update(gridData);
            BindLoanRepayments();
        }

        private void BindLoanRepayments()
        {
            this.BindingSource.DataSource = _LoanRepayments;
            this.BindingSource.ResetBindings(false);
            grdLoanRepaymentList.DataSource = this.BindingSource;
        }

        private void grdLoanRepaymentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _LoanRepayment = grdLoanRepaymentList.CurrentRow.DataBoundItem as LoanRepayment;
            ShowLoanRepaymentForm();
        }
    }
}
