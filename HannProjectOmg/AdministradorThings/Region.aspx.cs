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
    public partial class Region : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HannApp.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                drpStatus.Items.Add(new ListItem("Activo", "1"));
                drpStatus.Items.Add(new ListItem("Eliminado", "2"));
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
            cmd.CommandText = "Select Nombre_Region, estatus from Regiones where idRegion = " + Request.QueryString["idRegion"] + ";";

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    txtRegion.Text = reader.GetString(0);
                    drpStatus.SelectedValue = Convert.ToString(reader.GetInt32(1));

                }
            }
            else
            {
                Response.Redirect("/AdministradorThings/GestionarRegiones");
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
                cmd.CommandText = "UPDATE Regiones SET Nombre_Region = '" + txtRegion.Text.Trim() + "', estatus = "+drpStatus.SelectedValue+" where idRegion = " + Request.QueryString["idRegion"] + ";";
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Redirect("/AdministradorThings/GestionarRegiones");
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
                cmd.CommandText = "EXEC [InsertNewRegion] '" + txtRegion.Text.Trim() + "';";
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Redirect("/AdministradorThings/GestionarRegiones");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}