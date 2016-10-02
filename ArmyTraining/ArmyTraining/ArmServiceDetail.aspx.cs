using System;
using System.Web.UI;
using ArmyTraining.Model;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class ArmServiceDetail : System.Web.UI.Page, IServiceDetail
    {
        private ServiceDetailPresenter _Presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new ServiceDetailPresenter(this);
            _Presenter.OnPageLoad();
            if (!IsPostBack)
            {
                if (ServiceId > 0)
                {
                    header.Text = "Edit service (" + ServiceId + ").";
                }
                else
                {
                    header.Text = "Add service.";
                }
            }
        }

        protected void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                _Presenter.HandleSave();
                string js = "window.returnValue = 1;window.close();";
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "SaveSuccess", js, true);
            }
            catch (Exception ex)
            {
                hdnMessage.Value = ex.Message;
            }
        }


        public bool IsPagePostBack
        {
            get { return IsPostBack; }
        }

        public Service PopulateServiceFromGUI()
        {
            Service result = new Service();
            result.Name = txtName.Value;
            return result;
        }

        public int ServiceId
        {
            get { return int.Parse(Request[Constants.ServiceDetail_Request_Id]); }
        }

        public void PopulateGUIFromService(Service service)
        {
            txtName.Value = service.Name;
        }
    }
}
