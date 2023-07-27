using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Clase
{
    class clsTemp_Pedido:Entidades.entTemp_Pedido 
    {
        Conexion cnn = new Conexion();

        //funcion que trae un registro poniendo su ID
        public void GetFiltro(int id_pedido, int id_cuerpo_pedido)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Temp_pedido_GetFiltro", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);
            oda.SelectCommand.Parameters.AddWithValue("@id_cuerpo_pedido", id_cuerpo_pedido);


            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            pid_temp_pedido = Convert.ToInt32(odr["Id_temp_pedido"]);
            pfecha = Convert.ToDateTime(odr["fecha"]);
            pid_mesa = Convert.ToInt32(odr["id_mesa"]);
            pid_pedido = Convert.ToInt32(odr["id_pedido"]);
            pid_cuerpo_pedido = Convert.ToInt32(odr["id_cuerpo_pedido"]);
            pid_producto = Convert.ToInt32(odr["id_producto"]);
            pprecio = Convert.ToInt32(odr["precio"]);
            pcantidad = Convert.ToInt32(odr["cantidad"]);

        }
             //funcion que trae un registro poniendo su ID
        public DataTable GetPedido(int id_pedido)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Temp_pedido_GetPedido", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);

            oda.Fill(odt);
            return odt;
            //
            //DataRow odr;
            //odr = odt.Rows[0];

            //pid_temp_pedido = Convert.ToInt32(odr["Id_temp_pedido"]);
            //pfecha = Convert.ToDateTime(odr["fecha"]);
            //pid_mesa = Convert.ToInt32(odr["id_mesa"]);
            //pid_pedido = Convert.ToInt32(odr["id_pedido"]);
            //pid_cuerpo_pedido = Convert.ToInt32(odr["id_cuerpo_pedido"]);
            //pid_producto = Convert.ToInt32(odr["id_producto"]);
            //pprecio = Convert.ToInt32(odr["precio"]);
            //pcantidad = Convert.ToInt32(odr["cantidad"]);

        }

        public DataTable GetPrint(int id_pedido)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Temp_pedido_GetPrint", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);

            oda.Fill(odt);
            return odt;
        }
    }
}
