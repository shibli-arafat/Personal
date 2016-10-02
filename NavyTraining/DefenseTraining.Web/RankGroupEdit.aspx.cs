using System;
using System.Web.Services;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class RankGroupEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData SaveRankGroup(RankGroup rankGroup)
        {
            try
            {
                RankBol bol = new RankBol();
                return new AjaxData(true, bol.SaveRankGroup(rankGroup), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData GetRankGroup(int id)
        {
            try
            {
                RankBol bol = new RankBol();
                return new AjaxData(true, bol.GetRankGroup(id), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
