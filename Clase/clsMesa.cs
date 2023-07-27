using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Clase
{
    class clsMesa : Entidades.entMesa 
    {
        Conexion cnn = new Conexion();
        public double CantRegistada()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Mesa_CantRegistrada", cnn.Coneccion());
            double Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);

            Total = Convert.ToInt32(odt.Rows[0]["Total"].ToString());
            return Total;
        }
        public int CantMesaRegistada()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Mesa_CantMesaRegistrada", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);

            Total = Convert.ToInt32(odt.Rows[0]["Total"].ToString());
            return Total;
        }

        public int NextGrupo()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Mesa_NextGrupo", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);

            Total = Convert.ToInt32(odt.Rows[0]["Total"].ToString());
            return Total;
        }
        public DataTable GetAgrupada(int grupo_mesa)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Mesa_GetAgrupada", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@grupo_mesa", grupo_mesa);

            oda.Fill(odt);
            return odt;
        }
        public DataTable GetAgrupadaReserva(int id_reserva)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Mesa_GetAgrupadaReserva", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_reserva", id_reserva);

            oda.Fill(odt);
            return odt;
        }
    }
}
