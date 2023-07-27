using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Entidades
{
    class entProducto:Conexion
    {
        private int id_producto;
        private string nombre_producto;
        private int id_tipo_producto;
        private string descripcion;
        private string receta;
        private double precio;
        private bool sin_disponibilidad;
        private string icono;
        private int id_opcion_modificacion;
        Conexion cnn = new Conexion();


        public int pid_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }
        public int pid_tipo_producto
        {
            get { return id_tipo_producto; }
            set { id_tipo_producto = value; }
        }
        public string pnombre_producto
        {
            get { return nombre_producto; }
            set { nombre_producto = value; }
        }
        public string pdescripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string picono
        {
            get { return icono; }
            set { icono = value; }
        }
        public string preceta
        {
            get { return receta; }
            set { receta = value; }
        }
        public double pprecio 
        {
            get { return precio; }
            set { precio = value; }
        }
        public bool psin_disponibilidad
        {
            get { return sin_disponibilidad; }
            set { sin_disponibilidad = value; }
        }
        public int pid_opcion_modificacion 
        {
            get { return id_opcion_modificacion; }
            set { id_opcion_modificacion = value; }
        }
        
        public entProducto() 
        {
            id_producto = 0;
            id_tipo_producto = 0;
            descripcion = "";
            nombre_producto = "";
            icono = "";
            receta = "";
            precio = 0.0;
            sin_disponibilidad = false;
            id_opcion_modificacion = 0;
        }

        ////procedimiento de insertar
        public void Insertar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Producto_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter outparam = cmd.Parameters.Add("@id_producto", SqlDbType.Int);
            outparam.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@nombre_producto", pnombre_producto);
            cmd.Parameters.AddWithValue("@descripcion", pdescripcion);
            cmd.Parameters.AddWithValue("@id_tipo_producto", pid_tipo_producto);
            cmd.Parameters.AddWithValue("@receta", preceta );
            cmd.Parameters.AddWithValue("@icono", picono);
            cmd.Parameters.AddWithValue("@precio", pprecio);
            cmd.Parameters.AddWithValue("@sin_disponibilidad", psin_disponibilidad);
            cmd.Parameters.AddWithValue("@id_opcion_modificacion", pid_opcion_modificacion);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            pid_producto = Convert.ToInt32(cmd.Parameters["@id_producto"].Value);
            cmd.Connection.Close();
        }

        //procedimiento de Update
        public void Modificar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Producto_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_producto", pid_producto);
            cmd.Parameters.AddWithValue("@nombre_producto", pnombre_producto);
            cmd.Parameters.AddWithValue("@descripcion", pdescripcion);
            cmd.Parameters.AddWithValue("@id_tipo_producto", pid_tipo_producto);
            cmd.Parameters.AddWithValue("@receta", preceta);
            cmd.Parameters.AddWithValue("@icono", picono);
            cmd.Parameters.AddWithValue("@precio", pprecio);
            cmd.Parameters.AddWithValue("@sin_disponibilidad", psin_disponibilidad);
            cmd.Parameters.AddWithValue("@id_opcion_modificacion", pid_opcion_modificacion);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //procedimiento de BORRADO
        public void Borrar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Producto_Delete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_producto", pid_producto);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DataTable Buscar(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Producto_Find", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
            oda.Fill(odt);

            return odt;
        }


        //funcion para llenar el combo
        public DataTable GetCmb()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Producto_GetCmb", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.Fill(odt);

            return odt;
        }

        //funcion que trae un registro poniendo su ID
        public void GetOne(int id_producto)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Producto_GetOne", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_producto", id_producto);

            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            pnombre_producto = Convert.ToString(odr["Nombre producto"]);
            pdescripcion = Convert.ToString(odr["descripcion"]);
            pid_tipo_producto = Convert.ToInt32(odr["id tipo producto"]);
            preceta = Convert.ToString(odr["receta"]);
            picono = Convert.ToString(odr["icono"]);
            psin_disponibilidad = Convert.ToBoolean(odr["sin disponibilidad"]);
            pprecio = Convert.ToDouble(odr["precio"]);
            pid_opcion_modificacion = Convert.ToInt32(odr["id opcion modificacion"]);
            

        }

        //controla si existe el registro en la BD

        public bool Exist()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Producto_Exist", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre_producto", pnombre_producto);
            oda.SelectCommand.Parameters.AddWithValue("@descripcion", pdescripcion);
            oda.SelectCommand.Parameters.AddWithValue("@receta", preceta);
            oda.SelectCommand.Parameters.AddWithValue("@id_tipo_producto", pid_tipo_producto);
            oda.SelectCommand.Parameters.AddWithValue("@icono", picono);
            oda.SelectCommand.Parameters.AddWithValue("@precio", pprecio);
            oda.SelectCommand.Parameters.AddWithValue("@sin_disponibilidad",psin_disponibilidad);
            oda.SelectCommand.Parameters.AddWithValue("@id_opcion_modificacion", pid_opcion_modificacion);

            oda.Fill(odt);

            Total = Convert.ToInt32(odt.Rows[0]["Total"].ToString());

            if (Total == 0)
            {
                return false;
                //NO EXISTE
            }
            else { return true; } //SI EXISTE
        }

        //borra todos los datos de la tabla
        public void Truncate()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "TRUNCATE TABLE Mesas";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Insertar un registro en la tabla
        public void InsertOne()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cnn.Coneccion();
            command.CommandText = "cop_Producto_InsertOne";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public DataTable GetAll()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Producto_GetAll", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }


    }
}
