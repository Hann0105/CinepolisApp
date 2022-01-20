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
    public partial class Complejo : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HannApp.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                drpStatus.Items.Add(new ListItem("Activo", "1"));
                drpStatus.Items.Add(new ListItem("Eliminado", "2"));
                displayComboData();
                if (Request.QueryString == null || Request.QueryString.Keys.Count == 0)
                {

                    btnUpdate.Visible = false;
                    drpStatus.Visible = false;
                    lblEstatus.Visible = false;
                }
                else
                {
                    displayData();
                    btnInsert.Visible = false;
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

            ContentPlaceHolder Formulario = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            //Request.QueryString["idUsuario"]
            cmd.CommandText = "Select idComplejo, Complejo, idRegion, estatus from Complejos where idComplejo = " + Request.QueryString["idComplejo"] + ";";

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    txtComplejo.Text = reader.GetString(1);
                    drpRegion.SelectedValue = Convert.ToString(reader.GetInt32(2));
                    drpStatus.SelectedValue = Convert.ToString(reader.GetInt32(3));

                }
            }
            else
            {
                Response.Redirect("/AdministradorThings/GestionarComplejos");
            }

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
            cmd.CommandText = "Select [idRegion], [Nombre_Region] from Regiones;";

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
                Response.Redirect("/AdministradorThings/GestionarComplejos");
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
                cmd.CommandText = "Update Complejos SET Complejo = '" + txtComplejo.Text.Trim() + "', idRegion = " + drpRegion.SelectedValue.Trim() +", estatus = "+drpStatus.SelectedValue+" where idComplejo = "+ Request.QueryString["idComplejo"] + ";";
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Redirect("/AdministradorThings/GestionarComplejos");
            }
            catch (Exception ex)
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
                cmd.CommandText = "EXEC [spInsertNewComplex] '" + txtComplejo.Text.Trim() + "', "+ drpRegion.SelectedValue.Trim() +";";
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Redirect("/AdministradorThings/GestionarComplejos");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}