using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Clase
{
    class clsCuerpo_Pedido:Entidades.entCuerpo_Pedido
    {
        Conexion cnn = new Conexion();

        public DataTable GetAll_2()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Cuerpo_Pedido_GetAll_2", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }

        public DataTable GetMesa(int id_mesa)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Cuerpo_Pedido_GetMesa", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            //oda.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);
            oda.SelectCommand.Parameters.AddWithValue("@id_mesa", id_mesa);

            oda.Fill(odt);
            return odt;
        }
        public DataTable GetMesa_2(int id_mesa)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Cuerpo_Pedido_GetMesa_2", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            //oda.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);
            oda.SelectCommand.Parameters.AddWithValue("@id_mesa", id_mesa);

            oda.Fill(odt);
            return odt;
        }

        public DataTable GetPedido(int id_pedido)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Cuerpo_Pedido_GetPedido", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);
            //oda.SelectCommand.Parameters.AddWithValue("@id_mesa", id_mesa);

            oda.Fill(odt);
            return odt;
        }

        //public void GetOne(int id_cuerpo_pedido)
        //{
        //    DataTable odt = new DataTable();
        //    SqlDataAdapter oda = new SqlDataAdapter("cop_Cuerpo_Pedido_GetOne", cnn.Coneccion());

        //    oda.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    oda.SelectCommand.Parameters.AddWithValue("@id_cuerpo_pedido", id_cuerpo_pedido);

        //    oda.Fill(odt);
        //    DataRow odr;
        //    odr = odt.Rows[0];

        //    pid_pedido = Convert.ToInt32(odr["id pedido"]);
        //    pid_producto = Convert.ToInt32(odr["id producto"]);
        //    pcantidad = Convert.ToInt32(odr["cantidad"]);
        //    pprecio = Convert.ToDouble(odr["precio"]);

        //}

        public void GetCuerpo_Pedido(int id_pedido, int id_producto)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Cuerpo_Pedido_GetCuerpoPedido", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);
            oda.SelectCommand.Parameters.AddWithValue("@id_producto", id_producto);

            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            pid_cuerpo_pedido = Convert.ToInt32(odr["id cuerpo pedido"]);
        
        }


        public DataTable Buscar_2(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Cuerpo_Pedido_Find_2", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
            oda.Fill(odt);

            return odt;
        }

        //procedimiento de BORRADO POR PERIODOS
        public void BorrarPeriodo()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Cuerpo_Pedido_DeletexPedidos";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_pedido", pid_pedido);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DataTable GetReporte(int id_pedido)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Cuerpo_Pedido_GetReporte", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);
     
            oda.Fill(odt);
            return odt;
        }
        public DataTable GetAllPrintticket(int id_pedido)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Cuerpo_Pedido_GetAllPrint", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);

            oda.Fill(odt);
            return odt;
        }

        public DataTable GetAllPrintTicket(int id_pedido)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Cuerpo_Pedido_GetAllPrintTicket", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);

            oda.Fill(odt);
            return odt;
        }
    }
}
