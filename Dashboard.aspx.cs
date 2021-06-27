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
        //globle varibles 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
        int confirmed_hours = 0;
        int id_stu;

        //on page initial
        protected void Page_init(object sender, EventArgs e)
        {
            // GET Faculty list
            SqlCommand Query = new SqlCommand("select * from Faculty", con);
            SqlDataAdapter Adapter = new SqlDataAdapter(Query);
            DataTable data = new DataTable();
            Adapter.Fill(data);

            Faculty.DataSource = data;
            Faculty.DataTextField = "name";
            Faculty.DataValueField = "id";
            Faculty.DataBind();


            //GET Schedule
            Query = new SqlCommand("SELECT Course.Id,Course.course_name,Course.activity,Course.confirmed_hours,Course.section,Course.room,Day.day,Course.start_at,Course.end_at,Instructor.full_name as instructor,Faculty.name as faculty FROM Course INNER JOIN Instructor ON Instructor.Id=Course.instructor INNER JOIN Day ON Day.Id=Course.Day INNER JOIN Faculty ON Faculty.Id='" + Faculty.SelectedValue + "'", con);
            Adapter = new SqlDataAdapter(Query);
            data = new DataTable();
            Adapter.Fill(data);
            Registertion_Table.DataSource = data;
            Registertion_Table.DataBind();
            Registertion_Table.UseAccessibleHeader = true;
            Registertion_Table.HeaderRow.TableSection = TableRowSection.TableHeader;




        }

        protected void Page_load(object sender, EventArgs e)
        {

            if (Session["id"] == null)
            {
                //forbidden 
                Response.Redirect("Login.aspx");
            }
            else
            {
                //GET SUM confirmed_hours
                SqlCommand Query = new SqlCommand("SELECT SUM(Course.confirmed_hours) FROM enrolled_courses CROSS JOIN Course CROSS JOIN Student Where Course.Id=enrolled_courses.Course and Student.Id=enrolled_courses.Student and Student.username='" + Session["id"].ToString() + "'", con);
                con.Open();
                SqlDataReader reader = Query.ExecuteReader();
                if (reader.Read())
                {
                    //Convert SQL result to int
                    int.TryParse(reader[0].ToString(), out confirmed_hours);

                    ConfirmedHours.Text = "you are register: " + confirmed_hours + " Hours";
                }
                con.Close();


                //GET STUDENT ID 
                Query = new SqlCommand("SELECT Id FROM Student WHERE username='" + Session["id"].ToString() + "'", con);
                con.Open();
                reader = Query.ExecuteReader();
                if (reader.Read())
                {

                    int.TryParse(reader[0].ToString(), out id_stu);
                    Wellcom.Text = id_stu.ToString();
                }
                con.Close();
                Wellcom.Text = "Wellcome " + Session["id"].ToString();


                Query = new SqlCommand("SELECT enrolled_courses.Id,Course.course_name,Course.activity,Course.confirmed_hours,Course.section,Course.room,Day.day,Course.start_at,Course.end_at,Instructor.full_name as instructor,Faculty.name as faculty FROM enrolled_courses CROSS JOIN Course CROSS JOIN Instructor CROSS JOIN Faculty CROSS JOIN student CROSS JOIN Day Where Course.Id=enrolled_courses.Course and Course.faculty=Faculty.Id and Instructor.Id=Course.instructor and Student.Id=enrolled_courses.Student and Day.id=Course.day and Student.username ='" + Session["id"].ToString() + "'", con);
                SqlDataAdapter Adapter = new SqlDataAdapter(Query);
                DataTable data = new DataTable();
                Adapter.Fill(data);
                Schedule_Table.DataSource = data;
                Schedule_Table.DataBind();
                Schedule_Table.UseAccessibleHeader = true;
                Schedule_Table.HeaderRow.TableSection = TableRowSection.TableHeader;


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
            // 
            StringBuilder table = new StringBuilder();
            SqlCommand Query = new SqlCommand("SELECT Course.Id,Course.course_name,Course.activity,Course.confirmed_hours,Course.section,Course.start_at,Course.end_at,Instructor.full_name as instructor,Faculty.name as faculty FROM Course INNER JOIN Instructor ON Instructor.Id=Course.instructor INNER JOIN Faculty ON Faculty.Id=Course.faculty where Course.faculty='" + Faculty.SelectedValue + "'", con);
            SqlDataAdapter Adapter = new SqlDataAdapter(Query);
            DataTable reader = new DataTable();
            Adapter.Fill(reader);
            Registertion_Table.DataSource = reader;
            Registertion_Table.DataBind();
            Registertion_Table.UseAccessibleHeader = true;

        }

        protected void GridView_Action(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow Schedule = Schedule_Table.Rows[index];

            if (e.CommandName == "drop_record")
            {

                SqlCommand hours = new SqlCommand("delete from enrolled_courses where id=" + Schedule.Cells[0].Text + ";", con);
                con.Open();
                hours.ExecuteNonQuery();
                con.Close();

                //refresh page after execute Query
                Response.Redirect(Request.RawUrl);
            }
            else if (e.CommandName == "join")
            {
                GridViewRow Registertion = Registertion_Table.Rows[index];

                if (confirmed_hours < 18)
                {
                    foreach (DataRow row in Schedule)
                    {
                        if(row["course_name"].ToString() == Schedule.Cells[1].ToString())
                        {

                        }
                    }
                    ErrorMessage.Text = "Okay";
                    ErrorMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    ErrorMessage.Text = "The student burden is more than allowed";
                    ErrorMessage.ForeColor = System.Drawing.Color.Red;
                }
            }



     
        }
    }
}   

        
    
