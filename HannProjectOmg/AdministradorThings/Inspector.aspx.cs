using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace HannProjectOmg.AdministradorThings
{
    public partial class Inspector : System.Web.UI.Page
    {
        

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HannApp.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                drpStatus.Items.Add(new ListItem("Activo", "1"));
                drpStatus.Items.Add(new ListItem("Eliminado", "2"));
                displayComboRegion();
                displayComboData();
                if (Request.QueryString == null || Request.QueryString.Keys.Count == 0)
                {

                    btnUpdate.Visible = false;
                    drpStatus.Visible = false;
                    lblEstatus.Visible = false;
                    btnComplejos.Visible = false;
                    
                }
                else
                {
                    displayData();
                    btnInsert.Visible = false;

                }

                
            }
            
        }

        public void displayComboData()
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            ContentPlaceHolder Formulario = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            //Request.QueryString["idUsuario"]
            cmd.CommandText = "Select [idUsuario], CONCAT(Nombre, ' ', Apellido) as Nombre from Usuarios where tipoUsuario = 2;";

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    drpSupervisor.Items.Add(new ListItem(reader.GetString(1), Convert.ToString(reader.GetInt32(0))));

                }
            }
            else
            {
                Response.Redirect("/AdministradorThings/GestionarInspectores");
            }

            con.Close();

        }

        public void displayData()
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            ContentPlaceHolder Formulario = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            //Request.QueryString["idUsuario"]
            cmd.CommandText = "Select [User], [Password], Nombre, Apellido, estatus, idSupervisor, idRegion from Usuarios where idUsuario = "+ Request.QueryString["idUsuario"] +";";

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    txtUser.Text = reader.GetString(0);
                    txtPassword.Text = reader.GetString(1);
                    txtNombre.Text = reader.GetString(2);
                    txtApellido.Text = reader.GetString(3);
                    drpStatus.SelectedValue = Convert.ToString(reader.GetInt32(4));
                    drpSupervisor.SelectedValue = Convert.ToString(reader.GetInt32(5));
                    drpRegion.SelectedValue = Convert.ToString(reader.GetInt32(6));

                }
            }
            else
            {
                Response.Redirect("/AdministradorThings/GestionarInspectores");
            }

            con.Close();

        }


        public void displayComboRegion()
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            ContentPlaceHolder Formulario = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            //Request.QueryString["idUsuario"]
            cmd.CommandText = "Select * from Regiones;";

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    drpRegion.Items.Add(new ListItem(reader.GetString(1), Convert.ToString(reader.GetInt32(0))));

                }
            }
            else
            {
                Response.Redirect("/AdministradorThings/GestionarInspectores");
            }

            con.Close();

        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "EXEC spUpdateUserData " + Request.QueryString["idUsuario"] + ", '" + txtUser.Text.Trim() + "', '"+ txtPassword.Text.Trim()+"', '"+ txtNombre.Text.Trim() +"', '"+ txtApellido.Text.Trim() + "', " + drpStatus.SelectedValue + ", " + drpSupervisor.SelectedValue + ", "+drpRegion.SelectedValue+" ;";
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Redirect("/AdministradorThings/GestionarInspectores");
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
            
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "EXEC [spInsertNewUser] '" + txtUser.Text.Trim() + "', '" + txtPassword.Text.Trim() + "', '" + txtNombre.Text.Trim() + "', '" + txtApellido.Text.Trim() + "', 1, " + drpSupervisor.SelectedValue + ", " + drpRegion.SelectedValue + ";";
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Redirect("/AdministradorThings/GestionarInspectores");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnComplejos_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdministradorThings/Complejos_Inspector?idUsuario="+ Request.QueryString["idUsuario"]);
        }
    }
}