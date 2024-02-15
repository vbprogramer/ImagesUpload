using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net;
using System.IO;
using System.Data.SqlClient;

namespace ImagesUpload
{
    public partial class ImageUpload : System.Web.UI.Page
    {
        #region Input Properties...
        private int Id
        {
            get
            {
                if (ViewState["Id"] != null)
                    return int.Parse(ViewState["Id"].ToString());
                else
                    return 0;
            }
            set { ViewState["Id"] = value; }
        }
        public int EvalInt(string str)
        {
            try
            {
                int i = int.Parse(str);
                return i;
            }
            catch
            {
                return 0;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imbNew_Click(object sender, ImageClickEventArgs e)
        {
            if (FileUpload1.HasFile)
            {
               try
               {
                    if (Id == 0)
                    {
                        string extension = Path.GetExtension(FileUpload1.FileName);
                        if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                        {
                            if (FileUpload1.PostedFile.ContentLength <= 402400)
                            {
                                string fname = Path.GetFileName(FileUpload1.FileName);
                                FileUpload1.SaveAs(Server.MapPath("Images1/") + fname);

                                try
                                {
                                    Data.ImageUploadTableAdapters.advertisementTableAdapter ins = new
                                     Data.ImageUploadTableAdapters.advertisementTableAdapter();
                                    ins.InsertQuery(
                                        Convert.ToInt32("1"),    /// If we have page ImageUploadList
                                        FileUpload1.FileName,
                                        txtTitle.Text,
                                        txtDescription.Text,
                                        Convert.ToDateTime(DatStart.Text_YMD),
                                        Convert.ToDateTime(DatEnd.Text_YMD),
                                        txtLink.Text,
                                        "start",
                                        txtReference.Text
                                        );

                                    GridView1.DataBind();
                                    clearfn();
                                }
                                catch (Exception ex)
                                {
                                    //LogError(ex);
                                }

                            }
                            else
                            {
                                lblmsg.Text = "Mozete uneti velicinu fajla do 100 kb !";
                                lblmsg.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            lblmsg.Text = "mozete samo upload-ovati slece file-ove: jpg, jpeg, png !";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        string extension = Path.GetExtension(FileUpload1.FileName);
                        if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                        {
                            if (FileUpload1.PostedFile.ContentLength <= 102400)
                            {
                                string fname = Path.GetFileName(FileUpload1.FileName);
                                FileUpload1.SaveAs(Server.MapPath("Images1/") + fname);

                                try
                                {
                                    Data.ImageUploadTableAdapters.advertisementTableAdapter upd = new
                                     Data.ImageUploadTableAdapters.advertisementTableAdapter();
                                    upd.UpdateQuery(
                                        Convert.ToInt32("1"),    /// If we have page ImageUploadList
                                        FileUpload1.FileName,
                                        txtTitle.Text,
                                        txtDescription.Text,
                                        Convert.ToDateTime(DatStart.Text_YMD),
                                        Convert.ToDateTime(DatEnd.Text_YMD),
                                        txtLink.Text,
                                        "start",
                                        txtReference.Text,
                                        Id
                                        );

                                    GridView1.DataBind();
                                    clearfn();
                                }
                                catch (Exception ex)
                                {
                                    //LogError(ex);
                                }

                            }
                            else
                            {
                                lblmsg.Text = "Mozete uneti velicinu fajla do 100 kb !";
                                lblmsg.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            lblmsg.Text = "mozete samo upload-ovati slece file-ove: jpg, jpeg, png !";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                 }
                catch (Exception ex)
                {
                 //LogError(ex);
                 lblmsg.Text = "File ne može biti upload-ovan. Dogodila se sledeća greška:" + ex.Message;
                }
            }
        }
        public void clearfn()
        {
            txtReference.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
            lblmsg.Text = "";
            DatStart.Text = DateTime.Now.ToString();
            DatEnd.Text = DateTime.Now.ToString();
            txtLink.Text = "";
            Id = 0;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = EvalInt(e.CommandArgument.ToString());
            //string StrPorukaBrisanje = "Stavka je izbrisana !";

            try
            {
                switch (e.CommandName)
                {

                    case "Brisanje":
                        try
                        {
                            Data.ImageUploadTableAdapters.advertisementTableAdapter del = new
                                 Data.ImageUploadTableAdapters.advertisementTableAdapter();
                            del.DeleteQuery(Convert.ToInt32(e.CommandArgument));

                            GridView1.DataBind();
                            //MessageUspesanUpis(StrPorukaBrisanje);
                        }
                        catch (Exception ex)
                        {
                            //LogError(ex);
                        }
                        break;
                    case "Obrada":
                        try
                        {
                            Data.ImageUploadTableAdapters.advertisementTableAdapter edit = new
                                 Data.ImageUploadTableAdapters.advertisementTableAdapter();
                            edit.GetDataById(Convert.ToInt32(e.CommandArgument));

                            Data.ImageUpload.advertisementRow edit1;

                            if (edit.GetDataById(Convert.ToInt32(e.CommandArgument)).Count > 0)
                            {
                                edit1 = edit.GetDataById(Convert.ToInt32(e.CommandArgument))[0];

                                txtTitle.Text = edit1.Title;
                                txtReference.Text = edit1.Reference;
                                DatStart.Text = edit1.Date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                DatEnd.Text = edit1.Date1.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                txtLink.Text = edit1.Link;
                                txtDescription.Text = edit1.Description;
                            }

                        }
                        catch (Exception ex)
                        {
                            //LogError(ex);
                        }

                        break;

                }
            }
            catch (Exception ex)
            {
                //LogError(ex);
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#77aaff'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }
    }
}