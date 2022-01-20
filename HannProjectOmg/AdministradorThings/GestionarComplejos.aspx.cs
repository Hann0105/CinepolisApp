using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace HannProjectOmg.AdministradorThings
{
    public partial class GestionarComplejos : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HannApp.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

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
            cmd.CommandText = "Select idComplejo, Complejo, Nombre_Region, CASE WHEN a.estatus = '1' THEN 'ACTIVO' WHEN a.estatus = '2' THEN 'INACTIVO' END as estatus_bueno from Complejos a INNER JOIN Regiones b ON(a.idRegion = b.idRegion); ";
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
            try
            {
                using (con)
                {
                    con.Open();
                    string query = "UPDATE Complejos set estatus = 2 WHERE idComplejo = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, con);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(grdInspectores.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    displayData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Auxilio");
            }
        }
    }
}