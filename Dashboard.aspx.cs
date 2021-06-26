using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Portal_Application
{
    public partial class dashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
        

        protected void Page_load(object sender, EventArgs e)
        {
            try
            {
 

                SqlCommand Query = new SqlCommand("select * from Faculty", con);
                SqlDataAdapter Adapter = new SqlDataAdapter(Query);
                DataTable Droplist = new DataTable();
                Adapter.Fill(Droplist);

                DropDownList1.DataSource = Droplist;
                DropDownList1.DataTextField = "name";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();

                StringBuilder table = new StringBuilder();  
                Query = new SqlCommand("SELECT Course.Id,Course.course_name,Course.activity,Course.confirmed_hours,Course.section,Course.start_at,Course.end_at,Instructor.full_name as instructor,Faculty.name as faculty FROM Course INNER JOIN Instructor ON Instructor.Id=Course.instructor INNER JOIN Faculty ON Faculty.Id='" + DropDownList1.SelectedValue + "'", con);
                Adapter = new SqlDataAdapter(Query);
                DataTable reader = new DataTable();
                Adapter.Fill(reader);
                GridView1.DataSource = reader;
                GridView1.DataBind();
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;


            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }


            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Wellcom.Text = "Wellcome "+ Session["id"].ToString();
            }
            
        }
        protected void Logout_btn(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
        protected void modal_btn(object sender, EventArgs e)
        {
            bool status = string.IsNullOrEmpty(registerTable.Attributes["class"].ToString());
            if (status)
            {
                modal.Text = "start registertion";
                actionbtn.Attributes["class"] = "p-3 d-flex justify-content-center ";
                registerTable.Attributes["class"] = "d-none";
            }
            else
            {
                modal.Text = "finish register";
                actionbtn.Attributes["class"] = "p-3";
                registerTable.Attributes["class"] = String.Empty;
            }
        }


        protected void select_Click(object sender, EventArgs e)
        {

                Label1.Text = "Your Choice is: " + DropDownList1.SelectedValue;
        }
    }
}