using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Data.SqlClient;

using System.Data;

namespace Asp_Assignment
{
    public partial class User : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
             try

        {

            username.Focus();

            if (!IsPostBack)

            {

                FillGrid();
                GetRoleSelect();

            }

        }

        catch

        {

 

        }
        }
        void FillGrid()

        {

            try

            {

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "select u_id,u_username,email,password,r.ur_name from tbl_users u inner join tbl_userrole r on u.role_id = r.ur_id  where isActive = 1 and IsDelete = 0";

                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);

                gvDepartments.DataSource = ds;

                gvDepartments.DataBind();

            }

            catch

            {



            }

        }

        void GetRoleSelect()

        {

            try

            {

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "select *from tbl_userrole";

                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
               
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset
                role.DataTextField = ds.Tables[0].Columns["ur_name"].ToString(); // text field name of table dispalyed in dropdown
                role.DataValueField = ds.Tables[0].Columns["ur_id"].ToString();             // to retrive specific  textfield name 
                role.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
                role.DataBind();  //binding dropdownlist

            }

            catch

            {



            }

        }



        void ClearControls()

        {

            try

            {

                username.Text = "";

                email.Text = "";

                password.Text = "";

                hidUserID.Value = "";

                btnSave.Visible = true;

                btnUpdate.Visible = false;

            }

            catch

            {



                throw;

            }

        }
        protected void btnSave_Click(object sender, EventArgs e)

        {

            try

            {

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "insert into tbl_users (u_username,email,password,role_id) values (@u_username,@email,@password,@role)";

                cmd.Parameters.AddWithValue("@u_username", username.Text);

                cmd.Parameters.AddWithValue("@email", email.Text);

                cmd.Parameters.AddWithValue("@password", password.Text);
                cmd.Parameters.AddWithValue("@role", role.Text);

                cmd.Connection = con;

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                FillGrid();

                ClearControls();

                lblMessage.Text = "Saved Successfully.";

            }

            catch

            {



            }

            finally

            {

                if (con.State == ConnectionState.Open)

                    con.Close();

            }

        }



        protected void btnClear_Click(object sender, EventArgs e)

        {

            try

            {

                ClearControls();

            }

            catch

            {



            }

        }



        protected void btnEdit_Click(object sender, EventArgs e)

        {

            try

            {

                ClearControls();

                Button btn = sender as Button;

                GridViewRow grow = btn.NamingContainer as GridViewRow;

                hidUserID.Value = (grow.FindControl("lblUserID") as Label).Text;

                username.Text = (grow.FindControl("lblUsername") as Label).Text;

                email.Text = (grow.FindControl("lblEmail") as Label).Text;

                password.Text = (grow.FindControl("lblPassword") as Label).Text;

                btnSave.Visible = false;

                btnUpdate.Visible = true;

            }

            catch

            {



            }

        }



        protected void btnUpdate_Click(object sender, EventArgs e)

        {

            try

            {

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "update tbl_users set u_username=@u_username,email=@email,password=@password where u_id=@UserID";

                cmd.Parameters.AddWithValue("@u_username", username.Text);

                cmd.Parameters.AddWithValue("@email", email.Text);

                cmd.Parameters.AddWithValue("@password", password.Text);

                cmd.Parameters.AddWithValue("@UserID", hidUserID.Value);

                cmd.Connection = con;

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                FillGrid();

                ClearControls();

                lblMessage.Text = "Updated Successfully.";

            }

            catch

            {



            }

            finally

            {

                if (con.State == ConnectionState.Open)

                    con.Close();

            }

        }



        protected void btnDelete_Click(object sender, EventArgs e)

        {

            try

            {

                ClearControls();

                Button btn = sender as Button;

                GridViewRow grow = btn.NamingContainer as GridViewRow;

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "update tbl_users set isDelete=1 where u_id=@UserID";

                cmd.Parameters.AddWithValue("@UserID", (grow.FindControl("lblUserID") as Label).Text);

                cmd.Connection = con;

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                FillGrid();

                lblMessage.Text = "Deleted Successfully.";

            }

            catch

            {



            }

            finally

            {

                if (con.State == ConnectionState.Open)

                    con.Close();

            }

        }

        protected void gvDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}