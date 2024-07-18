using System;
using System.Data.SqlClient;

namespace NotasWebApp
{
    public partial class EditarNota : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NotasDBConnectionString"].ConnectionString;
        private int notaId;

        protected void Page_Load(object sender, EventArgs e)
        {
            bool isInt = int.TryParse(Request.QueryString["id"], out notaId);

            if (!IsPostBack)
            {
                if (isInt)
                {
                    CargarNota();
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        private void CargarNota()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Notas WHERE Id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", notaId);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IdTextBox.Text = reader["Id"].ToString();
                            TituloTextBox.Text = reader["Titulo"].ToString();
                            ContenidoTextBox.Text = reader["Contenido"].ToString();
                        }
                    }
                    con.Close();
                }
            }
        }

        protected void ActualizarButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Notas SET Titulo=@Titulo, Contenido=@Contenido WHERE Id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", notaId);
                    cmd.Parameters.AddWithValue("@Titulo", TituloTextBox.Text);
                    cmd.Parameters.AddWithValue("@Contenido", ContenidoTextBox.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("Default.aspx");
        }
    }
}
