using System.Configuration;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public delegate void RefreshGridDataHandler<T>(T gridData);

    public partial class BaseForm : Form
    {
        protected ILoanService Service;
        protected static string ImageFolder = ConfigurationManager.AppSettings["ImageFolder"];
        protected BindingSource BindingSource;
        public static User LoggedInUser { get; set; }

        public BaseForm()
        {
            Service = LoanServiceFactory.CreateLoanService();
            BindingSource = new BindingSource();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(468, 266);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseForm";
            this.ResumeLayout(false);
        }
    }
}
