using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ArmyTraining.Model;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class PersonDetail : System.Web.UI.Page, IPersonDetailView
    {
        private PersonDetailPresenter _Presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new PersonDetailPresenter(this);
            _Presenter.OnViewLoaded();
            if (!IsPostBack)
            {
                if (PersonId > 0)
                {
                    header.Text = "Edit person (" + PersonId + ").";
                }
                else
                {
                    header.Text = "Add person.";
                }
            }
        }

        protected void SaveClicked(object sender, EventArgs e)
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

        protected void btnCheckDuplicate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Presenter.IsDuplicate(PersonId, txtPersonNo.Text))
                {
                    hdnMessage.Value = string.Format("This person number {0} already exists.", txtPersonNo.Text);
                }
                else
                {
                    hdnMessage.Value = "This is a valid personal number.";
                }
            }
            catch (Exception ex)
            {
                hdnMessage.Value = ex.Message;
            }
        }

        protected void RankTypeChanged(object sender, EventArgs e)
        {
            int val = int.Parse(((DropDownList)sender).SelectedValue);
            _Presenter.HandleRankTypeChange(val);
        }

        public bool IsPagePostBack
        {
            get { return IsPostBack; }
        }

        public int PersonId
        {
            get { return int.Parse(Request[Constants.PersonDetail_Request_Id]); }
        }

        public void BindRankTypes(DecorationCollection decorations)
        {
            chkDecorations.Items.Clear();
            chkDecorations.DataSource = decorations;
            chkDecorations.DataTextField = "Name";
            chkDecorations.DataValueField = "Id";
            chkDecorations.DataBind();
        }

        public void BindRanks(RankCollection ranks)
        {
            drpRank.Items.Clear();
            drpRank.DataSource = ranks;
            drpRank.DataTextField = "Name";
            drpRank.DataValueField = "Id";
            drpRank.DataBind();
            drpRank.Items.Insert(0, new ListItem("Please select", "0"));
            drpRank.SetTooltip();
        }

        public void BindArmyServices(ServiceCollection services)
        {
            ddlArmsService.Items.Clear();
            ddlArmsService.DataSource = services;
            ddlArmsService.DataTextField = "Name";
            ddlArmsService.DataValueField = "Id";
            ddlArmsService.DataBind();
            ddlArmsService.Items.Insert(0, new ListItem("Please select", "0"));
            ddlArmsService.SetTooltip();
        }

        public void PopulateFormData(Person person)
        {
            txtName.Text = person.Name;
            txtRemarks.Text = person.Remaks;
            txtPersonNo.Text = person.PersonNumber;
            drpRank.SelectedIndex = FindIndexByValue(drpRank, person.Rank.Id.ToString());
            ddlArmsService.SelectedIndex = FindIndexByValue(ddlArmsService, person.Service.Id.ToString());
            txtEmail.Text = person.Email;
            txtMobile.Text = person.Mobile;
            foreach (ListItem item in chkDecorations.Items)
            {
                item.Selected = person.Decorations.Exists(x => x.Id.ToString() == item.Value);
            }
        }

        int FindIndexByValue(DropDownList drp, string itemValue)
        {
            return drp.Items.IndexOf(drp.Items.FindByValue(itemValue));
        }

        public Person GetFormData()
        {
            Person person = new Person();
            person.Name = txtName.Text;
            person.Remaks = txtRemarks.Text;
            person.Service.Id = int.Parse(ddlArmsService.SelectedValue);
            person.Rank.Id = int.Parse(drpRank.SelectedValue);
            person.PersonNumber = txtPersonNo.Text;
            person.Decorations = new DecorationCollection();
            foreach (ListItem item in chkDecorations.Items)
            {
                if (item.Selected)
                {
                    Decoration d = new Decoration();
                    d.Id = int.Parse(item.Value);
                    d.Name = item.Text;
                    person.Decorations.Add(d);
                }
            }
            person.Email = txtEmail.Text;
            person.Mobile = txtMobile.Text;
            return person;
        }
    }
}
