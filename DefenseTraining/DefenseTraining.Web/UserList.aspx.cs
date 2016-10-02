using System;
using System.Web.Services;
using DefenseTraining.Bol;

namespace DefenseTraining.Web
{
    public partial class UserList : System.Web.UI.Page
    {
        [WebMethod]
        public static AjaxData GetRoles()
        {
            try
            {
                UserBol bol = new UserBol();
                return new AjaxData(true, bol.GetRoles(), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData GetUsers(string keyword, int roleId, int rankId)
        {
            try
            {
                UserBol bol = new UserBol();
                return new AjaxData(true, bol.GetUsers(keyword, roleId, rankId), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData DeleteUser(int id)
        {
            try
            {
                UserBol bol = new UserBol();
                bol.DeleteUser(id);
                return new AjaxData(true, null, string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
