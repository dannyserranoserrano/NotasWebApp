using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NotasWebApp
{
    public partial class _Default : Page
    {

        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NotasDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarNotas();
            }
        }

        private void CargarNotas()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Notas", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        NotasGridView.DataSource = dt;
                        NotasGridView.DataBind();
                    }
                }
            }
        }

        protected void CrearNotaButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearNota.aspx");
        }

        protected void NotasGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int notaId = Convert.ToInt32(NotasGridView.DataKeys[index].Value);
            //((System.Web.UI.WebControls.GridView)e.CommandSource).Rows[notaId].Cells[0].Text
            if (e.CommandName == "Editar")
            {
                Response.Redirect($"EditarNota.aspx?id={notaId}");
            }
            else if (e.CommandName == "Eliminar")
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Notas WHERE Id=@Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", notaId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                CargarNotas();
            }
        }
    }
}