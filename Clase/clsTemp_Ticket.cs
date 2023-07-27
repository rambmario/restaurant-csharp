using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Clase
{
    class clsTemp_Ticket:Entidades.entTemp_Ticket
    {
        Conexion cnn = new Conexion();

        public DataTable GetReporte(int id_pedido)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Temp_ticket_GetReporte", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);

            oda.Fill(odt);
            return odt;
        }
    }
}
