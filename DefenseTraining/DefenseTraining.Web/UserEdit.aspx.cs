using System;
using System.Web.Services;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class UserEdit : System.Web.UI.Page
    {
        [WebMethod]
        public static AjaxData SaveUser(User user)
        {
            try
            {
                UserBol bol = new UserBol();
                return new AjaxData(true, bol.SaveUser(user), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData GetUser(int id)
        {
            try
            {
                UserBol bol = new UserBol();
                return new AjaxData(true, bol.GetUser(id), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
