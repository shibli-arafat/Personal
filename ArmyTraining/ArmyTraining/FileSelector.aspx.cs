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
    public partial class FileSelector : System.Web.UI.Page
    {
        public string TrainingId { get; set; }
        public string PersonId { get; set; }
        public string JsMethod { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            TrainingId = Request.QueryString["TrainingId"];
            PersonId = Request.QueryString["PersonId"];
        }

        protected void UploadFile(object sender, EventArgs e)
        {
            string fileName = fileUploader.PostedFile.FileName;
            if (!string.IsNullOrEmpty(fileName))
            {
                string docFullPath = Path.Combine(ConfigurationManager.AppSettings["DocumentPath"], TrainingId + @"\" + PersonId + @"\" + fileName);
                if (!Directory.Exists(Path.GetDirectoryName(docFullPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(docFullPath));
                }
                fileUploader.PostedFile.SaveAs(docFullPath);
                JsMethod = string.Format("window.returnValue = '{0}'; window.close();", fileName);
            }
        }
    }
}