using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Clase
{
    class clsCaja : Entidades.entCaja
    {
        Conexion cnn = new Conexion();

        public int UltimoID()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Caja_GetUltimo_id", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.Fill(odt);

            Total = Convert.ToInt32(odt.Rows[0]["Ultimo_id"].ToString());
            return Total;
        }
        //funcion para llenar el combo
        public DataTable GetCmb_2()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Caja_GetCmb_2", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.Fill(odt);

            return odt;
        }
    }
}
