using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace HannProjectOmg.SupervisorThings
{
    public partial class Feed : System.Web.UI.Page
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
            cmd.CommandText = "Select r.idreporte, CONCAT(u.Nombre, ' ', u.Apellido) as Nombre,  g.Nombre_Region, c.Complejo, r.Fecha, CASE WHEN r.estatusRevision = '1' THEN 'APROBADO' WHEN r.estatusRevision = '2' THEN 'REPROBADO' WHEN r.estatusRevision = '3' THEN 'SIN REVISION' WHEN r.estatusRevision = '4' THEN 'INACTIVO' END as estatus_bueno from reporte r INNER JOIN Usuarios u ON (r.idUsuario = u.idUsuario) INNER JOIN Complejos c ON (r.idComplejo = c.idComplejo) INNER JOIN Regiones g ON (g.idRegion = r.idregion) where r.estatusRevision != 4 AND u.idSupervisor = "+Session["idUsuario"]+";";
            cmd.ExecuteNonQuery();



            DataTable tbl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tbl);
            grdInspectores.DataSource = tbl;
            grdInspectores.DataBind();

            con.Close();

        }

    }
}