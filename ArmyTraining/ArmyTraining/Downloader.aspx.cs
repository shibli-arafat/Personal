using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;

namespace ArmyTraining
{
    public partial class Downloader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string trainingId = Request.QueryString["trainingId"];
            string personId = Request.QueryString["personId"];
            string docName = Request.QueryString["docName"];
            string filePath = string.Format(@"{0}\{1}\{2}\{3}", ConfigurationManager.AppSettings["DocumentPath"], trainingId, personId, docName);
            if (!File.Exists(filePath))
            {
                Response.Write("The file you're trying to download doesn't exist.");
            }
            else
            {
                FileInfo file = new FileInfo(filePath);
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "text/plain";
                Response.Flush();
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }
    }
}