using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Clase
{
    class clsProducto:Entidades.entProducto
    {

        Conexion cnn = new Conexion();


        //metodos para mostrar todo los producto remplazando las ID por los nombres correspondiente
        public DataTable GetAll_2()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Producto_GetAll_2", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }
        //metodos para mostrar todo los producto remplazando las ID por los nombres correspondiente
        public DataTable GetAll_Grupo(int id_grupo_producto = 1)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Producto_GetAll_Grupo", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_grupo_producto", id_grupo_producto);

            oda.Fill(odt);
            return odt;
        }
        //metodos para mostrar todo los producto remplazando las ID por los nombres correspondiente
        public DataTable GetTipo_Pedido(int id_tipo_producto)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Producto_GetTipo_Pedido", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@tipo_producto", id_tipo_producto);

            oda.Fill(odt);
            return odt;
        }

        public DataTable Buscar_2(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Producto_Find_2", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
            oda.Fill(odt);

            return odt;
        }

        public DataTable GetConsultaMaestra(int id_grupo_producto, int id_tipo_producto, string nombre, bool es_grupo, bool es_tipo)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Producto_GetConsultaMaestra", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_grupo_producto", id_grupo_producto);
            oda.SelectCommand.Parameters.AddWithValue("@id_tipo_producto", id_tipo_producto);
            oda.SelectCommand.Parameters.AddWithValue("@nombre", nombre);
            oda.SelectCommand.Parameters.AddWithValue("@es_grupo", es_grupo);
            oda.SelectCommand.Parameters.AddWithValue("@es_tipo", es_tipo);

            oda.Fill(odt);
            return odt;
        }
    }
}
