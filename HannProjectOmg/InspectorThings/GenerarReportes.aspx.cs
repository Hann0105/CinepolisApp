using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace HannProjectOmg.InspectorThings
{
    public partial class GenerarReportes : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HannApp.mdf;Integrated Security=True");
        // class="" aria-label=".form-select-sm example"

        String globalRes = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            

            if (!IsPostBack)
            {
                drpRegion.Items.Add(new ListItem("Selecciona una región", "0"));
                drpComplejo.Items.Add(new ListItem("Selecciona un cine", "0"));
                drpComplejo.Enabled = false;
                displayComboData();
                displayCombos();
                displayTextBoxes();
                btnEditar.Visible = false;

                if (Request.QueryString != null && Request.QueryString.Keys.Count != 0)
                {
                   globalRes =  displayEditValues();
                   drpRegion_SelectedIndexChanged(globalRes, e);
                    btnEditar.Visible = true;
                    btnRegistrar.Visible = false;
                    drpComplejo.Enabled = false;
                }
                else
                {
                    drpStatus.Items.Add(new ListItem("SIN REVISION", "3"));
                    drpStatus.Enabled = false;
                }

            }
        }

        public String displayEditValues()
        {
            String res = "";
            drpRegion.Enabled = false;
            drpComplejo.Enabled = false;

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            ContentPlaceHolder Formulario = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            //Session["idUsuario"]
            cmd.CommandText = "Select * from reporte where idreporte = " + Request.QueryString["idreporte"] + ";";

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    drpRegion.SelectedValue = Convert.ToString(reader.GetInt32(1));
                    
                    res = Convert.ToString(reader.GetInt32(20));

                    drpInstalaciones.SelectedValue = Convert.ToString(reader.GetInt32(4));
                    txtInstalaciones.Text = reader.GetString(5);

                    int kekw = reader.GetInt32(3);
                    if (reader.GetInt32(3) == 1 || reader.GetInt32(3) == 2)
                    {
                        drpStatus.Items.Add(new ListItem("APROBADO", "1"));
                        drpStatus.Items.Add(new ListItem("REPROBADO", "2"));

                        btnEditar.Visible = false;

                        drpStatus.Enabled = false;

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
                    else
                    {
                        drpStatus.Items.Add(new ListItem("SIN REVISION", "3"));
                        drpStatus.Items.Add(new ListItem("INACTIVO", "4"));

                    }

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

                }
            }
            else
            {
                Response.Redirect("/InspectorThings/Feed");
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
            return res;
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

        public void displayCombos()
        {
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
            //Session["idUsuario"]
            cmd.CommandText = "Select r.idRegion, r.Nombre_region from Regiones r INNER JOIN Complejos c ON (c.idRegion = r.idRegion) INNER JOIN relInspectoresComplejos rel ON (rel.idComplejo = c.idComplejo) where r.estatus = 1 AND rel.idInspector = " + Session["idUsuario"] + ";";

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
                Response.Redirect("/InspectorThings/Feed");
            }

            con.Close();

        }

        protected void drpRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpComplejo.Enabled = true;
            drpComplejo.Items.Clear();
            
            if(drpRegion.SelectedValue.Equals("0"))
            {
                drpComplejo.Enabled = false;
                drpComplejo.Items.Add(new ListItem("Selecciona un cine", "0"));
            }
            else
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
                cmd.CommandText = "Select c.idComplejo, c.Complejo from Complejos c INNER JOIN relInspectoresComplejos r ON(r.idComplejo = c.idComplejo) where c.estatus = 1 AND r.idInspector = " + Session["idUsuario"] + " AND c.idRegion = " + drpRegion.SelectedValue + ";";

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        drpComplejo.Items.Add(new ListItem(reader.GetString(1), Convert.ToString(reader.GetInt32(0))));

                    }
                }
                else
                {
                    drpComplejo.Items.Add(new ListItem("Selecciona un cine", "0"));
                    drpComplejo.Enabled = false;
                }

                con.Close();
            }

            if (!globalRes.Equals(""))
            {
                drpComplejo.SelectedValue = globalRes;
            }
            
        }

        public void fillProCombo()
        {

        }

        protected void drpInstalaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!drpInstalaciones.SelectedValue.Equals("1"))
            {
                txtInstalaciones.Visible = true;
            }
            else
            {
                txtInstalaciones.Text = "";
                txtInstalaciones.Visible = false;
            }
        }

        protected void drpSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!drpSalas.SelectedValue.Equals("1"))
            {
                txtSalas.Visible = true;
            }
            else
            {
                txtSalas.Text = "";
                txtSalas.Visible = false;
            }
        }

        protected void drpPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!drpPersonal.SelectedValue.Equals("1"))
            {
                txtPersonal.Visible = true;
            }
            else
            {
                txtPersonal.Text = "";
                txtPersonal.Visible = false;
            }
        }

        protected void drpServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!drpServicio.SelectedValue.Equals("1"))
            {
                txtServicio.Visible = true;
            }
            else
            {
                txtServicio.Text = "";
                txtServicio.Visible = false;
            }
        }

        protected void drpInsumos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!drpInsumos.SelectedValue.Equals("1"))
            {
                txtInsumos.Visible = true;
            }
            else
            {
                txtInsumos.Text = "";
                txtInsumos.Visible = false;
            }
        }

        protected void drpDulceria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!drpDulceria.SelectedValue.Equals("1"))
            {
                txtDulceria.Visible = true;
            }
            else
            {
                txtDulceria.Text = "";
                txtDulceria.Visible = false;
            }
        }

        protected void drpSanidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!drpSanidad.SelectedValue.Equals("1"))
            {
                txtSanidad.Visible = true;
            }
            else
            {
                txtSanidad.Text = "";
                txtSanidad.Visible = false;
            }
        }

        protected void drpTaquilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!drpTaquilla.SelectedValue.Equals("1"))
            {
                txtTaquilla.Visible = true;
            }
            else
            {
                txtTaquilla.Text = "";
                txtTaquilla.Visible = false;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if(drpComplejo.SelectedValue.Equals("0") || drpComplejo.SelectedValue.Equals("0"))
            {
                lblError.Text = "Debes seleccionar un Cine / Región correctos";
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "EXEC [spInsertReport] " + Session["idUsuario"] + ", " + drpRegion.SelectedValue + ", "
                        + drpComplejo.SelectedValue + ", "
                        + drpInstalaciones.SelectedValue + ", '" 
                        + txtInstalaciones.Text.Trim() + "', " 
                        + drpSalas.SelectedValue + ", '"
                        + txtSalas.Text.Trim() + "', "
                        + drpPersonal.SelectedValue + ", '"
                        + txtPersonal.Text.Trim() + "', "
                        + drpServicio.SelectedValue + ", '"
                        + txtServicio.Text.Trim() + "', "
                        + drpInsumos.SelectedValue + ", '"
                        + txtInsumos.Text.Trim() + "', "
                        + drpDulceria.SelectedValue + ", '"
                        + txtDulceria.Text.Trim() + "', "
                        + drpSanidad.SelectedValue + ", '"
                        + txtSanidad.Text.Trim() + "', "
                        + drpTaquilla.SelectedValue + ", '"
                        + txtTaquilla.Text.Trim() + "';";
                    cmd.ExecuteNonQuery();

                    con.Close();
                    Response.Redirect("/InspectorThings/Feed");
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
            
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (drpComplejo.SelectedValue.Equals("0") || drpComplejo.SelectedValue.Equals("0"))
            {
                lblError.Text = "Debes seleccionar un Cine / Región correctos";
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE reporte set Instalaciones = " + drpInstalaciones.SelectedValue + 
                        ", InstalacionesText = '" + txtInstalaciones.Text.Trim() + 
                        "', Salas = " + drpSalas.SelectedValue + 
                        ", SalasText = '" + txtSalas.Text.Trim() + 
                        "', Personal = " + drpPersonal.SelectedValue + 
                        ", PersonalText = '" + txtPersonal.Text.Trim() + 
                        "', Servicio = " + drpServicio.SelectedValue + 
                        ", ServicioText = '" + txtServicio.Text.Trim() + 
                        "', Insumos = " + drpInsumos.SelectedValue + 
                        ", InsumosText = '" + txtInsumos.Text.Trim() + 
                        "', Dulceria = " + drpDulceria.SelectedValue + 
                        ", DulceriaText = '" + txtDulceria.Text.Trim() + 
                        "', Sanidad = " + drpSanidad.SelectedValue + 
                        ", SanidadText = '" + txtSanidad.Text.Trim() + 
                        "', Taquilla = " + drpTaquilla.SelectedValue + 
                        ", TaquillaText = '" + txtTaquilla.Text.Trim() +
                        "', estatusRevision = " + drpStatus.SelectedValue + 
                        " where idreporte = " + Request.QueryString["idreporte"] + ";";
                    cmd.ExecuteNonQuery();

                    con.Close();
                    Response.Redirect("/InspectorThings/Feed");
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }
    }

 }
