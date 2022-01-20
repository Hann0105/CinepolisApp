using System;
using System.Web.UI;


using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace HannProjectOmg
{
    public partial class InicioSesión : Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HannApp.mdf;Integrated Security=True");


        protected void Page_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

        }

        protected void InicioSesionButton(object sender, EventArgs e)
        {

            ContentPlaceHolder Formulario = (ContentPlaceHolder)this.Master.FindControl("MainContent");

            String Usuario = ((TextBox)Formulario.FindControl("txtUser")).Text;
            String Password = ((TextBox)Formulario.FindControl("txtPassword")).Text;


            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "Select idUsuario from Usuarios where [User] = '" + Usuario + "' and [Password] ='" + Password + "';";

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Response.Write("<script>alert('" + reader.GetInt32(0) + "')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('No hay coincidencia para esas credenciales')</script>");
            }


        }
    }
}