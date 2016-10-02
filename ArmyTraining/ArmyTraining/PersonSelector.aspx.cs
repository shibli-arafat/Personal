using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Model.Filters;

namespace ArmyTraining
{
    public partial class PersonSelector : System.Web.UI.Page
    {
        PersonFilter CreateFilter()
        {
            PersonFilter filter = new PersonFilter();
            filter.PersonNumber = txtPersonNo.Text;
            filter.RankName = txtKeyword.Text;
            filter.PageNumber = 1;
            filter.Count = 20;

            return filter;
        }

        protected void Search(object sender, EventArgs e)
        {
            BindData(CreateFilter());
        }

        private void BindData(PersonFilter filter)
        {
            PersonSearchResult persons = new PersonInternal().GetPersons(filter);
            if (persons.Persons.Count == 0)
            {
                pnlEmpty.Visible = true;
                pageHeader.Visible = false;
                rptPersons.Visible = false;
                spnEmpty.InnerText = "No result found.";
            }
            else
            {
                rptPersons.Visible = true;
                pageHeader.Visible = true;
                PopulatePager(persons, filter);
                pnlEmpty.Visible = false;
                rptPersons.DataSource = persons.Persons;
                rptPersons.DataBind();
            }
        }

        protected void PrevClicked(object sender, EventArgs e)
        {
            PersonFilter filter = CreateFilter();
            filter.PageNumber = int.Parse(drpPages.SelectedValue) - 1;
            BindData(filter);
        }

        protected void NextClicked(object sender, EventArgs e)
        {
            PersonFilter filter = CreateFilter();
            filter.PageNumber = int.Parse(drpPages.SelectedValue) + 1;
            BindData(filter);
        }

        protected void PageIndexChanged(object sender, EventArgs e)
        {
            PersonFilter filter = CreateFilter();
            filter.PageNumber = int.Parse((sender as DropDownList).SelectedValue);
            BindData(filter);
        }

        private void PopulatePager(PersonSearchResult data, PersonFilter filter)
        {
            int totalPages = (int)Math.Ceiling((float)data.TotalCount / filter.Count);
            drpPages.Items.Clear();
            for (int i = 1; i <= totalPages; i++)
            {
                ListItem li = new ListItem(i.ToString(), i.ToString());
                li.Selected = filter.PageNumber == i;
                drpPages.Items.Add(li);
            }
            lnkPrev.Enabled = true;
            lnkNext.Enabled = true;
            drpPages.Enabled = true;

            if (filter.PageNumber == 1)
            {
                lnkPrev.Enabled = false;
            }
            if (filter.PageNumber == totalPages)
            {
                lnkNext.Enabled = false;
            }
            if (totalPages == 1)
            {
                drpPages.Enabled = false;
            }
            int start = (filter.PageNumber - 1) * filter.Count + 1;
            int end = start + data.Persons.Count - 1;
            ltStart.Text = start.ToString();
            ltEnd.Text = end.ToString();
            ltTotal.Text = data.TotalCount.ToString();
        }



        protected void PersonBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox chk = e.Item.FindControl("chkSelect") as CheckBox;
                Person p = e.Item.DataItem as Person;
                chk.Attributes.Add("itemid", p.Id.ToString());
                chk.Text = p.GetNameWithRankAndNumber();
            }
        }

        protected void SelectUnSelectPerson(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            string[] ids = hdnSelectedPersonIds.Value.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> idList = new List<string>(ids);
            string personId = chk.Attributes["itemid"];

            if (chk.Checked)
            {
                idList.Add(personId);
            }
            else
            {
                idList.Remove(personId);
            }
            BindNames(idList);
        }

        private void BindNames(List<string> idList)
        {
            PersonInternal _internal = new PersonInternal();
            List<string> names = new List<string>();
            foreach (string personid in idList)
            {
                Person person = _internal.GetPersonById(int.Parse(personid));
                names.Add(person.GetNameWithRankAndNumber());
            }

            spnSelectedPersons.InnerText = string.Join(";", names.ToArray());
            hdnSelectedPersonIds.Value = string.Join(",", idList.ToArray());
        }
    }
}
