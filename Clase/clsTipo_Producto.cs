using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Clase
{
    class clsTipo_Producto:Entidades.entTipo_Producto
    {
        Conexion cnn = new Conexion();


        //metodos para mostrar todo los producto remplazando las ID por los nombres correspondiente
        public DataTable GetGrupo_Producto(int id_grupo_producto)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Tipo_Producto_GetGrupo_Producto", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_grupo_producto", id_grupo_producto);

            oda.Fill(odt);
            return odt;
        }

        public DataTable GetAll_2()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Tipo_Producto_GetAll_2", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }

        //funcion para llenar el combo
        public DataTable GetCmb_2(int id_grupo_producto)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Tipo_Producto_GetCmb_2", cnn.Coneccion());


            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_grupo_producto", id_grupo_producto);
            oda.Fill(odt);

            return odt;
        }
    }
}
