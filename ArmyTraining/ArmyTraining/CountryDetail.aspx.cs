using System;
using System.Web.UI;
using ArmyTraining.Model;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class CountryDetail : System.Web.UI.Page, ICountryDetail
    {
        private CountryDetailPresenter _Presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new CountryDetailPresenter(this);
            _Presenter.OnPageLoad();
            if (!IsPostBack)
            {
                if (CountryId > 0)
                {
                    header.Text = "Edit country (" + CountryId + ").";
                }
                else
                {
                    header.Text = "Add country.";
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

        public Country PopulateCountryFromGUI()
        {
            Country result = new Country();
            result.Name = txtName.Value;
            return result;
        }

        public int CountryId
        {
            get { return int.Parse(Request[Constants.CountryDetail_Request_Id]); }
        }

        public void PopulateGUIFromCountry(Country country)
        {
            txtName.Value = country.Name;
        }
    }
}
