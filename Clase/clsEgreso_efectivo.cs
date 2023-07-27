using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Clase
{
    class clsEgreso_efectivo:Entidades.entEgreso_efectivo 
    {
        Conexion cnn = new Conexion();

        public double EfectivoxCaja(int id_caja)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Egreso_efectivo_EfectivoxCaja", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_caja", id_caja);
            oda.Fill(odt);

            return Total = Convert.ToInt32(odt.Rows[0]["Total"].ToString());
        }
    }
}
