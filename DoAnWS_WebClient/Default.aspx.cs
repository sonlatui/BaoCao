using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class _Default : System.Web.UI.Page
{
    static svTGTP.Service1Client proxy = new svTGTP.Service1Client();
    protected void Page_Load(object sender, EventArgs e)
    {
        //proxy.Login("web1", System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("password", "MD5").ToString());
        if (!IsPostBack)
        {
            string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("password", "MD5").ToString().ToLower();
            proxy.Login("web1", pass);
 
        }

    }
    protected void Btt_Login_Click(object sender, EventArgs e)
    {
        string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Txb_password.Text, "MD5").ToString().ToLower();
        proxy.Login(Txb_username.Text, pass).ToString();
        

        //string a = proxy.GetQuyen().Quyen.ToString();
        Session["Quyen"] = proxy.GetQuyen().Quyen.ToString();
        if (Session["Quyen"].ToString() == "1")
        {
            Panel1.Visible = false;
            Btt_Logout.Visible = true;
            ph_admin.Visible = true;
            ph_themtacgia.Visible = false;
            ph_themtacpham.Visible = false;
        }
    }
    protected void Btt_Logout_Click(object sender, EventArgs e)
    {
        proxy.Logout();
        Session["Quyen"] = proxy.GetQuyen().Quyen.ToString();
        if (Session["Quyen"].ToString() != "1")
        {
            Response.Redirect("http://localhost:3699/DoAnWS_WebClient/Default.aspx");
            //Panel1.Visible = true;
            //Btt_Logout.Visible = false;
        }
    }
    protected void Btt_Tim_Click(object sender, EventArgs e)
    {
        //Response.Write();
        if (Ddl_theotg.SelectedValue == "1")
        {
            Lit_ketqua.Text = proxy.GetTSTGbyTG(Txb_tim.Text);
        }
        if (Ddl_theotg.SelectedValue == "2")
        {
            Lit_ketqua.Text = proxy.GetTSTGbyND(Txb_tim.Text);
        }
        if (Ddl_theotg.SelectedValue == "3")
        {
            Lit_ketqua.Text = proxy.GetTPbyTG(Txb_tim.Text);
        }
        if (Ddl_theotg.SelectedValue == "4")
        {
            Lit_ketqua.Text = proxy.GetTPbyTP(Txb_tim.Text);
        }
        if (Ddl_theotg.SelectedValue == "5")
        {
            Lit_ketqua.Text = proxy.GetTPbyTL(Txb_tim.Text);
        }
        if (Ddl_theotg.SelectedValue == "6")
        {
            Lit_ketqua.Text = proxy.GetTPbyND(Txb_tim.Text);
        }
        //if (Ddl_theotg.SelectedValue == "1")
        //{
        //    DataTable dt = new DataTable();
        //    dt = proxy.TimTSbyTen(Txb_tim.Text).Tables[0];
        //    TableRow row = null;

        //    //Add the Headers
        //    row = new TableRow();
        //    for (int j = 0; j < dt.Columns.Count; j++)
        //    {
        //        TableHeaderCell headerCell = new TableHeaderCell();
        //        headerCell.Text = dt.Columns[j].ColumnName;
        //        row.Cells.Add(headerCell);
        //    }
        //    Table1.Rows.Add(row);
        //    //Add the Column values
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        row = new TableRow();
        //        for (int j = 0; j < dt.Columns.Count; j++)
        //        {
        //            TableCell cell = new TableCell();
        //            cell.Text = dt.Rows[i][j].ToString();
        //            row.Cells.Add(cell);
        //        }
        //        // Add the TableRow to the Table
        //        Table1.Rows.Add(row);
        //    }
        //}
       
    }

 
    protected void btt_them_Click1(object sender, EventArgs e)
    {
        lbl_them.Text = proxy.ThemTG(txb_themtg.Text, txb_themts.Text);
    }
    protected void btt_themtp_Click(object sender, EventArgs e)
    {
        lbl_themtp.Text = proxy.ThemTP(txt_themtentp.Text, txt_themtheloai.Text, txt_themnoidung.Text, txt_themtentg.Text);
    }
    protected void btt_adminthemtg_Click(object sender, EventArgs e)
    {
        ph_themtacgia.Visible = true;
        ph_themtacpham.Visible = false;
    }
    protected void btt_adminthemtp_Click(object sender, EventArgs e)
    {
        ph_themtacgia.Visible = false;
        ph_themtacpham.Visible = true;
    }
}
