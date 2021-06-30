using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AppTutoria
{
    public class Conexion
    {
        private string conexion = "Data Source=LAPTOP-IUT020T4 ; Initial catalog =BDTutoria;" + "User=sa;password=123456789";
        public bool ok()
        {
            try
            {
                SqlConnection connection = new SqlConnection(conexion);
                connection.Open();
            }
            catch
            {
                return false;

            }
            return true;
        }
    }
}
