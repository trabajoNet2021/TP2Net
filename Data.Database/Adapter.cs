using System.Data.SqlClient;

namespace Data.Database
{
    public class Adapter
    {
        private SqlConnection sqlConnection;
        string conexion = null;


        public Adapter()
        {
            conexion = @"Data Source=LAPTOP-3IUT7RL9;Initial Catalog=AcademiaNet;Integrated Security=True";
            SqlConnection = new SqlConnection(conexion);
        }

        public SqlConnection SqlConnection
        {
            get { return this.sqlConnection; }
            set { this.sqlConnection = value; }
        }

        protected void OpenConnection()
        {
            SqlConnection.Open();
        }

        protected void CloseConnection()
        {
            SqlConnection.Close();
        }


    }
}
