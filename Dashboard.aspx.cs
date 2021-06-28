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
            try
            {
                SqlCommand Query = new SqlCommand("select * from Faculty", con);
                SqlDataAdapter Adapter = new SqlDataAdapter(Query);
                DataTable data = new DataTable();
                Adapter.Fill(data);

                Faculty.DataSource = data;
                Faculty.DataTextField = "name";
                Faculty.DataValueField = "id";
                Faculty.DataBind();

                //GET Schedule
                Query = new SqlCommand(
                   "SELECT Course.Id,Course.course_name,Course.activity,Course.confirmed_hours,Course.section,Course.room,Course.day,Course.start_at,Course.end_at," +
                   "Instructor.full_name as instructor,Faculty.name as faculty " +
                   "FROM Course " +
                   "INNER JOIN Instructor ON Instructor.Id=Course.instructor " +
                   "INNER JOIN Faculty ON Faculty.Id=Course.faculty " +
                   "Where Faculty.Id='" + Faculty.SelectedValue + "';", con);

                Adapter = new SqlDataAdapter(Query);
                data = new DataTable();
                Adapter.Fill(data);
                Registertion_Table.DataSource = data;
                Registertion_Table.DataBind();
            }catch(Exception error)
            {
                throw error;
            }
           




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
                try { 
                    //GET SUM confirmed_hours
                    SqlCommand Query = new SqlCommand("SELECT SUM(Course.confirmed_hours) " +
                        "FROM enrolled_courses " +
                        "CROSS JOIN Course " +
                        "CROSS JOIN Student " +
                        "Where Course.Id=enrolled_courses.Course and Student.Id=enrolled_courses.Student and Student.username='" + Session["id"].ToString() + "'", con);
                    con.Open();
                    SqlDataReader reader = Query.ExecuteReader();
                    if (reader.Read())
                    {
                        //Convert SQL result to int
                        int.TryParse(reader[0].ToString(), out confirmed_hours);

                        ConfirmedHours.Text = "Total Hours: " + confirmed_hours ;
                    }
                    con.Close();

                    //GET STUDENT ID 
                    Query = new SqlCommand("SELECT Id FROM Student WHERE username='" + Session["id"].ToString() + "'", con);
                    con.Open();
                    reader = Query.ExecuteReader();
                    if (reader.Read())
                    {

                        int.TryParse(reader[0].ToString(), out id_stu);
                    }
                    con.Close();
                    Wellcom.Text = "Wellcome " + Session["id"].ToString();
                }
                catch (Exception error)
                {
                    throw error;
            }
                try {
                    //GET STUDENT ID 
                    SqlCommand Query = new SqlCommand("SELECT Id FROM Student WHERE username='" + Session["id"].ToString() + "'", con);
                    con.Open();
                    SqlDataReader reader = Query.ExecuteReader();
                    if (reader.Read())
                    {

                        int.TryParse(reader[0].ToString(), out id_stu);
                    }
                    con.Close();
                    Wellcom.Text = "Wellcome " + Session["id"].ToString();
                }
                catch (Exception error)
                {
                    throw error;
                }

                try { 
                SqlCommand Query = new SqlCommand("SELECT enrolled_courses.Id,Course.course_name,Course.activity,Course.confirmed_hours,Course.section,Course.room,Course.day,Course.start_at,Course.end_at," +
                        "Instructor.full_name as instructor," +
                        "Faculty.name as faculty " +
                        "FROM enrolled_courses " +
                        "CROSS JOIN Course " +
                        "CROSS JOIN Instructor " +
                        "CROSS JOIN Faculty " +
                        "CROSS JOIN student " +
                        "Where Course.Id=enrolled_courses.Course and Course.faculty=Faculty.Id and Instructor.Id=Course.instructor and Student.Id=enrolled_courses.Student and Student.username ='" + Session["id"].ToString() + "'", con);
                SqlDataAdapter Adapter = new SqlDataAdapter(Query);
                DataTable data = new DataTable();
                Adapter.Fill(data);
                Schedule_Table.DataSource = data;
                Schedule_Table.DataBind();
                Schedule_Table.UseAccessibleHeader = true;
                Schedule_Table.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                catch (Exception error)
                {
                    throw error;
                }

                //update index Registertion_Table
                try
                { 

                StringBuilder table = new StringBuilder();
                SqlCommand Query = new SqlCommand("SELECT Course.Id,Course.course_name,Course.activity,Course.confirmed_hours,Course.section,Course.room,Course.day,Course.start_at,Course.end_at," +
                    "Instructor.full_name as instructor," +
                    "Faculty.name as faculty " +
                    "FROM Course " +
                    "INNER JOIN Instructor ON Instructor.Id=Course.instructor " +
                    "INNER JOIN Faculty ON Faculty.Id=Course.faculty " +
                    "where Course.faculty='" + Faculty.SelectedValue + "'", con);
                SqlDataAdapter Adapter = new SqlDataAdapter(Query);
                con.Open();
                DataTable Course_Table = new DataTable();
                Adapter.Fill(Course_Table);
                Registertion_Table.DataSource = Course_Table;
                Registertion_Table.DataBind();
                con.Close();
                }
                catch (Exception error)
                {
                    throw error;
                }

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
            try
            {
                StringBuilder table = new StringBuilder();
                SqlCommand Query = new SqlCommand("SELECT Course.Id,Course.course_name,Course.activity,Course.confirmed_hours,Course.section,Course.room,Course.day,Course.start_at,Course.end_at," +
                    "Instructor.full_name as instructor," +
                    "Faculty.name as faculty " +
                    "FROM Course " +
                    "INNER JOIN Instructor ON Instructor.Id=Course.instructor " +
                    "INNER JOIN Faculty ON Faculty.Id=Course.faculty " +
                    "where Course.faculty='" + Faculty.SelectedValue + "'", con);
                SqlDataAdapter Adapter = new SqlDataAdapter(Query);
                DataTable reader = new DataTable();
                Adapter.Fill(reader);
                Registertion_Table.DataSource = reader;
                Registertion_Table.DataBind();
            }
            catch (Exception error)
            {
                throw error;
            }


        }

        protected void GridView_Action(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "drop_record")
            {

                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow Schedule = Schedule_Table.Rows[index];
                try
                {
                    SqlCommand delete = new SqlCommand("delete from enrolled_courses where id=" + Schedule.Cells[0].Text + ";", con);
                    con.Open();
                    delete.ExecuteNonQuery();
                    con.Close();
                    //refresh page after execute Query
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception error)
                {
                    throw error;
                }

            }

            else if (e.CommandName == "join")
            {

                    Boolean conflicting = false;
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow Registertion = Registertion_Table.Rows[index];
                try
                {
                    SqlCommand Query = new SqlCommand("SELECT * FROM enrolled_courses WHERE course='" + Registertion.Cells[0].Text + "'and student='" + id_stu.ToString() + "'", con);
                    con.Open();
                    SqlDataReader reader = Query.ExecuteReader();
                    if (!reader.Read())
                    {
                        int load;
                        int.TryParse(Registertion.Cells[3].Text, out load);
                        load += confirmed_hours;

                        //Close the previous connection
                        con.Close();

                        if (load <= 18)
                        {

                            Query = new SqlCommand("select course_name " +
                                "From enrolled_courses " +
                                "INNER JOIN Course on enrolled_courses.Course=Course.Id and enrolled_courses.Student='" + id_stu.ToString() + "' and Course.start_at='" + Registertion.Cells[7].Text + "' and Course.end_at='" + Registertion.Cells[8].Text + "'and Course.day ='" + Registertion.Cells[6].Text + "';", con);
                            con.Open();
                            reader = Query.ExecuteReader();
                            if (reader.HasRows)
                            {
                                ErrorMessage.Text = "You have a schedule conflict with " + Registertion.Cells[1].Text;
                                ErrorMessage.CssClass = "alert alert-danger";
                                conflicting = true;
                            }
                            con.Close();

                            if (!conflicting)
                            {
                                Query = new SqlCommand("INSERT INTO enrolled_courses (Student, Course)" +
                                    "VALUES (" + id_stu.ToString() + "," + Registertion.Cells[0].Text + ");", con);
                                con.Open();
                                Query.ExecuteNonQuery();
                                con.Close();
                                Response.Redirect(Request.RawUrl);

                            }




                        }
                        else
                        {
                            ErrorMessage.Text = "The student burden is more than allowed";
                            ErrorMessage.CssClass = "alert alert-danger";

                        }






                    }
                    else
                    {
                        ErrorMessage.Text = Registertion.Cells[1].Text + " is already exists";
                        ErrorMessage.CssClass = "alert alert-danger";

                    }
                    con.Close();

                }
                catch (Exception error)
                {
                    throw error;
                }


            }



             }

    }
}   

        
    
