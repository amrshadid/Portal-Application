using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal_Application
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if(Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Wellcom.Text += Session["id"].ToString();
            }
            
        }
        protected void Logout_btn(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
        protected void modal_btn(object sender, EventArgs e)
        {
            if (scheduleTable.Attributes["class"].ToString() == "table-responsive schedule")
            {
                modal.Text = "Show my schedule";
                ConfirmedHours.Attributes["class"] = "d-none";
                scheduleTable.Attributes["class"] = "d-none";
            }
            else
            {
                modal.Text = "close my schedule";
                ConfirmedHours.Attributes["class"] = "d-inline-flex";
                scheduleTable.Attributes["class"] = "table-responsive schedule";
            }
        }
        protected void select_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "")
            {
                Label1.Text = "Please Select a City";
            }
            else
                Label1.Text = "Your Choice is: " + DropDownList1.SelectedValue;
        }
    }
}