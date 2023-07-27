using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Clase
{
    class clsPago_Pedido:Entidades.entPago_Pedido
    {

        Conexion cnn = new Conexion();
        public DataTable GetAllVenta(int id_pedido)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Pago_Pedido_GetAllVenta", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);
            oda.Fill(odt);

            return odt;
        }

        public DataTable GetAllVentaFiscal(int id_pedido)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Pago_Pedido_GetAllVentaFiscal", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);
            oda.Fill(odt);

            return odt;
        }

        public void BorrarporPedido()
        {
            SqlCommand cmd = new SqlCommand();  

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Pago_pedido_DeletePorPedido";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_pedido", pid_pedido);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public DataTable SaldoPorCaja(int id_caja)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Pago_pedido_SaldosPorCaja", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_caja", id_caja);
            oda.Fill(odt);

            return odt;
        }

        public DataTable GetCaja(int id_caja)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Pago_pedido_GetCaja", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_caja", id_caja);
            oda.Fill(odt);

            return odt;
        }
    }
}
