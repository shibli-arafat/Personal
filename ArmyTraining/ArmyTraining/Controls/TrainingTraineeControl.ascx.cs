using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Model.Trainings;

namespace ArmyTraining.Controls
{
    public partial class TrainingTraineeControl : System.Web.UI.UserControl
    {
        TraineeCollection Persons
        {
            get
            {
                TraineeCollection result = ViewState["Persons"] as TraineeCollection;
                if (result == null)
                {
                    result = new TraineeCollection();
                    ViewState["Persons"] = result;
                }
                return ViewState["Persons"] as TraineeCollection;
            }
            set
            {
                ViewState["Persons"] = value;
            }
        }

        public void Initialize(TraineeCollection trainees)
        {
            Persons = trainees;
            BindTrainees();
            CheckBalance();
        }

        public void BindTrainees()
        {
            rptTranees.Controls.Clear();
            rptTranees.DataSource = Persons;
            rptTranees.DataBind();
        }

        protected void TraneeDataBinding(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.Item)
            {
                Trainee trainee = e.Item.DataItem as Trainee;
                HtmlGenericControl spnTrainees = e.Item.FindControl("spnTrainees") as HtmlGenericControl;
                ImageButton imgBtnDelete = e.Item.FindControl("imgBtnDelete") as ImageButton;
                imgBtnDelete.CommandArgument = trainee.PersonId.ToString();

                TextBox textBox = e.Item.FindControl("txtExpenditure") as TextBox;
                textBox.Text = trainee.Expenditure.ToString();

                textBox = e.Item.FindControl("txtOtherExpenditure") as TextBox;
                textBox.Text = trainee.OtherExpenditure.ToString();

                textBox = e.Item.FindControl("txtSponsor") as TextBox;
                textBox.Text = trainee.Sponsor.ToString();

                Person ps = new PersonInternal().GetPersonById(trainee.PersonId);
                spnTrainees.InnerText = ps.GetNameWithRankAndNumber();
                Button btnAttachFile = e.Item.FindControl("btnAttachFile") as Button;
                btnAttachFile.Attributes.Add("personId", ps.Id.ToString());

                int trainingId = (this.Page as EditTraining).TrainingId;

                HtmlAnchor lnkBtn = e.Item.FindControl("lnkFile") as HtmlAnchor;
                lnkBtn.HRef = "~/Downloader.aspx?trainingId=" + trainingId + "&personId=" + ps.Id + "&docName=" + trainee.DocName;
                //lnkBtn.PostBackUrl = "~/Downloader.aspx?trainingId=" + trainingId + "&personId=" + ps.Id + "&docName=" + trainee.DocName;
                lnkBtn.InnerText = trainee.DocName;
            }
        }

        protected void RemovePerson(object sender, ImageClickEventArgs e)
        {
            Persons.RemoveAll(x => x.PersonId.ToString() == (sender as ImageButton).CommandArgument);
            BindTrainees();
        }

        protected void AddTrainees(object sender, EventArgs e)
        {            
            string[] addedPersons = hdnAddedPersons.Value.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> list = new List<string>(addedPersons);
            list.RemoveAll(x => Persons.Exists(y => y.PersonId.ToString() == x));
            TraineeCollection addedTrainees = new TraineeCollection();
            foreach (var listItem in list)
            {
                Trainee addedTrainee = new Trainee(int.Parse(listItem));
                addedTrainee.RankId = new PersonInternal().GetPersonById(addedTrainee.PersonId).Rank.Id;
                addedTrainees.Add(addedTrainee);
            }
            if (addedTrainees.Count > 0)
            {
                Persons.AddRange(addedTrainees);
            }
            BindTrainees();
        }

        public void UpdateAttachedFile(object sender, EventArgs e)
        {
            Persons.UpdatePersonDoc(int.Parse(hdnSelectedPerson.Value), hdnSelectedDoc.Value);
            BindTrainees();
        }

        internal TraineeCollection GetInfo()
        {
            foreach (RepeaterItem item in rptTranees.Items)
            {
                if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                {
                    ImageButton imgBtnDelete = item.FindControl("imgBtnDelete") as ImageButton;
                    int personId = int.Parse(imgBtnDelete.CommandArgument);

                    TextBox textBox = item.FindControl("txtExpenditure") as TextBox;
                    Persons.GetTraineeByPersonId(personId).Expenditure = decimal.Parse(textBox.Text);

                    textBox = item.FindControl("txtOtherExpenditure") as TextBox;
                    Persons.GetTraineeByPersonId(personId).OtherExpenditure = decimal.Parse(textBox.Text);

                    HtmlAnchor lnkButton = item.FindControl("lnkFile") as HtmlAnchor;
                    Persons.GetTraineeByPersonId(personId).DocName = lnkButton.InnerText;

                    textBox = item.FindControl("txtSponsor") as TextBox;
                    Persons.GetTraineeByPersonId(personId).Sponsor = textBox.Text;
                }
            }
            return Persons;
        }

        private void CheckBalance()
        {
            decimal d = new TrainingInternal().GetBalanceForSameYearExceptThisTraining((Page as EditTraining).TrainingId, (Page as EditTraining).TrainingYear, (Page as EditTraining).TrainingMonth);
            GetInfo().ForEach(x => d -= x.Expenditure);
            ltBalance.Text = d.ToString();
        }

        protected void CheckBalance(object sender, EventArgs e)
        {
            CheckBalance();
        }
    }
}