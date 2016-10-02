﻿using System;
using System.Web.Services;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class RankEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData SaveRank(Rank rank)
        {
            try
            {
                RankBol bol = new RankBol();
                return new AjaxData(true, bol.SaveRank(rank), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData GetRank(int id)
        {
            try
            {
                RankBol bol = new RankBol();
                return new AjaxData(true, bol.GetRank(id), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
