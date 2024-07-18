using System;
using System.Data.SqlClient;

namespace NotasWebApp
{
    public partial class CrearNota : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NotasDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Notas (Titulo, Contenido, FechaCreacion) VALUES (@Titulo, @Contenido, @FechaCreacion)", con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", TituloTextBox.Text);
                    cmd.Parameters.AddWithValue("@Contenido", ContenidoTextBox.Text);
                    cmd.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("Default.aspx");
        }
    }
}