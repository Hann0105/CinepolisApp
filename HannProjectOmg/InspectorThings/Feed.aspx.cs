using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace HannProjectOmg
{
    public partial class Feed : Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HannApp.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e){

            if (!IsPostBack)
            {
                displayData();
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
            cmd.CommandText = "Select r.idreporte,  g.Nombre_Region, c.Complejo, r.Fecha, CASE WHEN r.estatusRevision = '1' THEN 'APROBADO' WHEN r.estatusRevision = '2' THEN 'REPROBADO' WHEN r.estatusRevision = '3' THEN 'SIN REVISION' WHEN r.estatusRevision = '4' THEN 'INACTIVO' END as estatus_bueno from reporte r INNER JOIN Regiones g ON (r.idregion = g.idRegion) INNER JOIN Complejos c ON (c.idComplejo = r.idComplejo) where r.idUsuario = "+ Session["idUsuario"] + ";";
            cmd.ExecuteNonQuery();



            DataTable tbl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tbl);
            grdInspectores.DataSource = tbl;
            grdInspectores.DataBind();

            con.Close();

        }

        protected void grdInspectores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            lblError.Text = "";
            int supervision = 0;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            ContentPlaceHolder Formulario = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            //Request.QueryString["idUsuario"]
            cmd.CommandText = "Select estatusRevision from reporte where idreporte = " + grdInspectores.DataKeys[e.RowIndex].Value.ToString() + ";";

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    supervision = reader.GetInt32(0);

                }
            }
            else
            {
                Response.Redirect("/AdministradorThings/GestionarInspectores");
            }

            con.Close();
            if(supervision == 1 || supervision == 2)
            {
                lblError.Text = "No puedes eliminar un reporte APROBADO/REPROBADO.";
            }
            else
            {
                try
                {
                    using (con)
                    {
                        con.Open();
                        string query = "UPDATE reporte set estatusRevision = 4 WHERE idReporte = @id";
                        SqlCommand sqlCmd = new SqlCommand(query, con);
                        sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(grdInspectores.DataKeys[e.RowIndex].Value.ToString()));
                        sqlCmd.ExecuteNonQuery();
                        displayData();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Auxilio uwu");
                }
                
            }
            
        }

    }
}