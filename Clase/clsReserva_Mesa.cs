using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Clase
{
    class clsReserva_Mesa:Entidades.entReserva_Mesa
    {
        Conexion cnn = new Conexion();

        public DataTable GetAll_2(int bandera, DateTime fecha_inicio, DateTime fecha_fin, int id_reserva_mesa, string hora_reserva)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Mesa_GetAll_2", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@bandera", bandera);
            oda.SelectCommand.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            oda.SelectCommand.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            oda.SelectCommand.Parameters.AddWithValue("@id_reserva_mesa", id_reserva_mesa);
            oda.SelectCommand.Parameters.AddWithValue("@hora_reserva", hora_reserva);

            oda.Fill(odt);
            return odt;
        }

        
         public DataTable GetDiaMesAño()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Mesa_GetDiaMesAño", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }
         public DataTable GetDistinctFecha()
         {
             DataTable odt = new DataTable();
             SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Mesa_GetDistinctFecha", cnn.Coneccion());

             oda.SelectCommand.CommandType = CommandType.StoredProcedure;

             oda.Fill(odt);
             return odt;
         }
         public int GetCantidadPosibles()
         {
             DataTable odt = new DataTable();
             SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Mesa_GetCantidadPosibles", cnn.Coneccion());
             int Total = 0;

             oda.SelectCommand.CommandType = CommandType.StoredProcedure;


             oda.Fill(odt);

             Total = Convert.ToInt32(odt.Rows[0]["Total"].ToString());
             return Total;
         }
        public int ConsultarxHora(string hora, DateTime fecha)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_mesa_ConsultaxHora", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@fecha_reserva", fecha);
            oda.SelectCommand.Parameters.AddWithValue("@hora_reserva", hora);


            oda.Fill(odt);

            Total = Convert.ToInt32(odt.Rows[0]["Cantidad"].ToString());
            return Total;
        }
        public void GetOne_2(int id_reserva_mesa)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Mesa_GetOne_2", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_reserva_mesa", id_reserva_mesa);

            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            pfecha_reserva = Convert.ToDateTime(odr["fecha_reserva"]);
            phora_reserva = Convert.ToDateTime(odr["Hora_reserva"]);
            pid_mesa = Convert.ToInt32(odr["id_mesa"]);
            pid_cliente = Convert.ToInt32(odr["id_cliente"]);
            pestado_reserva = Convert.ToString(odr["estado_reserva"]);
            pnro_huesped = Convert.ToDouble(odr["nro_huesped"]);
            pobsevacion = Convert.ToString(odr["observacion"]);

        }

    }
}
