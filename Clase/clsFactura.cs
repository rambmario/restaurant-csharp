using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Gestion_gastronomica.Clase
{
    class clsFactura:Entidades.entFactura
    {
        Conexion cnn = new Conexion();
        public DataTable GetAll_2()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Factura_GetAll_2", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }


        public DataTable GetAll_Ticket()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Factura_GetAll_Ticket", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }
    }

}
