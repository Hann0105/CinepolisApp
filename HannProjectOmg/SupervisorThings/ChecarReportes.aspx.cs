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
    public partial class ChecarReportes : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HannApp.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString == null || Request.QueryString.Keys.Count == 0)
                {
                    Response.Redirect("/SupervisorThings/Feed.aspx");
                }
                else
                {
                    displayTextBoxes();
                    displayCombos();
                    displayData();
                }
            }
            
        }

        public void displayTextBoxes()
        {
            txtInstalaciones.TextMode = TextBoxMode.MultiLine;
            txtInstalaciones.Visible = false;

            txtSalas.TextMode = TextBoxMode.MultiLine;
            txtSalas.Visible = false;

            txtPersonal.TextMode = TextBoxMode.MultiLine;
            txtPersonal.Visible = false;

            txtServicio.TextMode = TextBoxMode.MultiLine;
            txtServicio.Visible = false;

            txtInsumos.TextMode = TextBoxMode.MultiLine;
            txtInsumos.Visible = false;

            txtDulceria.TextMode = TextBoxMode.MultiLine;
            txtDulceria.Visible = false;

            txtSanidad.TextMode = TextBoxMode.MultiLine;
            txtSanidad.Visible = false;

            txtTaquilla.TextMode = TextBoxMode.MultiLine;
            txtTaquilla.Visible = false;

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
            //Session["idUsuario"]
            cmd.CommandText = "Select r.*, g.Nombre_Region, c.Complejo, CONCAT(u.Nombre, ' ', u.Apellido) as Nombre from reporte r INNER JOIN Regiones g ON(g.idRegion = r.idregion) INNER JOIN Complejos c ON(c.idComplejo = r.idComplejo) INNER JOIN Usuarios u ON(r.idUsuario = u.idUsuario) where idreporte = "+ Request.QueryString["idreporte"] +"; ";

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    lblRegion.Text = reader.GetString(22);

                    lblComplejo.Text = reader.GetString(23);

                    drpInstalaciones.SelectedValue = Convert.ToString(reader.GetInt32(4));
                    txtInstalaciones.Text = reader.GetString(5);

                    drpStatus.SelectedValue = Convert.ToString(reader.GetInt32(3));

                    drpSalas.SelectedValue = Convert.ToString(reader.GetInt32(6));
                    txtSalas.Text = reader.GetString(7);

                    drpPersonal.SelectedValue = Convert.ToString(reader.GetInt32(8));
                    txtPersonal.Text = reader.GetString(9);

                    drpServicio.SelectedValue = Convert.ToString(reader.GetInt32(10));
                    txtServicio.Text = reader.GetString(11);

                    drpInsumos.SelectedValue = Convert.ToString(reader.GetInt32(12));
                    txtInsumos.Text = reader.GetString(13);

                    drpDulceria.SelectedValue = Convert.ToString(reader.GetInt32(14));
                    txtDulceria.Text = reader.GetString(15);

                    drpSanidad.SelectedValue = Convert.ToString(reader.GetInt32(16));
                    txtSanidad.Text = reader.GetString(17);

                    drpTaquilla.SelectedValue = Convert.ToString(reader.GetInt32(18));
                    txtTaquilla.Text = reader.GetString(19);

                    drpInstalaciones.Enabled = false;
                    txtInstalaciones.Enabled = false;

                    drpSalas.Enabled = false;
                    txtSalas.Enabled = false;

                    drpPersonal.Enabled = false;
                    txtPersonal.Enabled = false;

                    drpServicio.Enabled = false;
                    txtServicio.Enabled = false;

                    drpInsumos.Enabled = false;
                    txtInsumos.Enabled = false;

                    drpDulceria.Enabled = false;
                    txtDulceria.Enabled = false;

                    drpSanidad.Enabled = false;
                    txtSanidad.Enabled = false;

                    drpTaquilla.Enabled = false;
                    txtTaquilla.Enabled = false;

                }
            }
            else
            {
                Response.Redirect("/SupervisorThings/Feed");
            }

            con.Close();

            if (!txtInstalaciones.Text.Equals(""))
            {
                txtInstalaciones.Visible = true;
            }

            if (!txtSalas.Text.Equals(""))
            {
                txtSalas.Visible = true;
            }

            if (!txtPersonal.Text.Equals(""))
            {
                txtPersonal.Visible = true;
            }

            if (!txtServicio.Text.Equals(""))
            {
                txtServicio.Visible = true;
            }

            if (!txtInsumos.Text.Equals(""))
            {
                txtInsumos.Visible = true;
            }

            if (!txtDulceria.Text.Equals(""))
            {
                txtDulceria.Visible = true;
            }

            if (!txtSanidad.Text.Equals(""))
            {
                txtSanidad.Visible = true;
            }

            if (!txtTaquilla.Text.Equals(""))
            {
                txtTaquilla.Visible = true;
            }

        }

        public void displayCombos()
        {
            drpStatus.Items.Add(new ListItem("APROBADO", "1"));
            drpStatus.Items.Add(new ListItem("REPROBADO", "2"));
            drpStatus.Items.Add(new ListItem("SIN REVISION", "3"));

            drpInstalaciones.Items.Add(new ListItem("Buen Estado", "1"));
            drpInstalaciones.Items.Add(new ListItem("Regular", "2"));
            drpInstalaciones.Items.Add(new ListItem("Mal Estado", "3"));

            drpSalas.Items.Add(new ListItem("Buen Estado", "1"));
            drpSalas.Items.Add(new ListItem("Regular", "2"));
            drpSalas.Items.Add(new ListItem("Mal Estado", "3"));

            drpPersonal.Items.Add(new ListItem("Buen Estado", "1"));
            drpPersonal.Items.Add(new ListItem("Regular", "2"));
            drpPersonal.Items.Add(new ListItem("Mal Estado", "3"));

            drpServicio.Items.Add(new ListItem("Buen Estado", "1"));
            drpServicio.Items.Add(new ListItem("Regular", "2"));
            drpServicio.Items.Add(new ListItem("Mal Estado", "3"));

            drpInsumos.Items.Add(new ListItem("Buen Estado", "1"));
            drpInsumos.Items.Add(new ListItem("Regular", "2"));
            drpInsumos.Items.Add(new ListItem("Mal Estado", "3"));

            drpDulceria.Items.Add(new ListItem("Buen Estado", "1"));
            drpDulceria.Items.Add(new ListItem("Regular", "2"));
            drpDulceria.Items.Add(new ListItem("Mal Estado", "3"));

            drpSanidad.Items.Add(new ListItem("Buen Estado", "1"));
            drpSanidad.Items.Add(new ListItem("Regular", "2"));
            drpSanidad.Items.Add(new ListItem("Mal Estado", "3"));

            drpTaquilla.Items.Add(new ListItem("Buen Estado", "1"));
            drpTaquilla.Items.Add(new ListItem("Regular", "2"));
            drpTaquilla.Items.Add(new ListItem("Mal Estado", "3"));
        }

        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE reporte set estatusRevision = " + drpStatus.SelectedValue + " where idreporte = " + Request.QueryString["idreporte"] + ";";
                    cmd.ExecuteNonQuery();

                    con.Close();
                    Response.Redirect("/SupervisorThings/Feed");
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
        }
    }

    

}