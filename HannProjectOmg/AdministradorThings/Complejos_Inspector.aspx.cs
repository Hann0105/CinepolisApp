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
    public partial class Complejos_Inspector : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HannApp.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString == null || Request.QueryString.Keys.Count == 0)
                {
                    Response.Redirect("/AdministradorThings/GestionarInspectores");
                }
                else
                {
                    displayComboData();
                    displayData();
                }
            }

            
                
        }

        public void displayData()
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select r.idRel, c.Complejo, CONCAT(i.Nombre, ' ', i.Apellido) as Inspector from Usuarios i INNER JOIN relInspectoresComplejos r ON(r.idInspector = i.idUsuario) INNER JOIN Complejos c ON(c.idComplejo = r.idComplejo) where i.idUsuario = "+ Request.QueryString["idUsuario"] +"; ";
            cmd.ExecuteNonQuery();



            DataTable tbl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tbl);
            grdInspectores.DataSource = tbl;
            grdInspectores.DataBind();

            con.Close();

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
            cmd.CommandText = "Select c.[idComplejo], c.Complejo from Complejos c INNER JOIN Usuarios u ON(c.idRegion = u.idRegion) where c.estatus = 1 AND u.idUsuario = " + Request.QueryString["idUsuario"] + "; ";
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    drpComplejos.Items.Add(new ListItem(reader.GetString(1), Convert.ToString(reader.GetInt32(0))));

                }
            }
            else
            {
                Response.Redirect("/AdministradorThings/GestionarInspectores");
            }

            con.Close();

        }

        protected void grdInspectores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (con)
                {
                    con.Open();
                    string query = "DELETE from relInspectoresComplejos where idRel = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, con);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(grdInspectores.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    displayData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
                
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();

                ContentPlaceHolder Formulario = (ContentPlaceHolder)this.Master.FindControl("MainContent");
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;
            //Request.QueryString["idUsuario"]
                cmd.CommandText = "EXEC [spAgregarRel] " + Request.QueryString["idUsuario"] + "," + drpComplejos.SelectedValue + ";";

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                    lblError.Text = reader.GetString(0);

                    }
                }
                else
                {
                    Response.Redirect("/AdministradorThings/GestionarInspectores");
                }

                con.Close();
            displayData();
        }
    }
        
}