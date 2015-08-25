using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jqUploadify
{
    public partial class TestCache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fileName = Context.Request.Params["filename"];
            string fullFilePath = Context.Server.MapPath("/uploads/" + fileName);
            //string fullFilePath = Context.Server.MapPath("/uploads/2222.jpg");
            FileInfo info = new FileInfo(fullFilePath);
            long fileSize = info.Length;
            Response.Clear();
            Response.ContentType = "application/x-zip-compressed";
            Response.AddHeader("Content-Disposition", "attachment;filename="+fileName);
            Response.AddHeader("Content-Length", fileSize.ToString());
            Response.TransmitFile(fullFilePath,0,fileSize);
            Response.Flush();
            Response.Close();
            //Response.Write(fullFilePath);
            //Response.Redirect(fullFilePath,true);
            //Response.End();
        }
    }
}