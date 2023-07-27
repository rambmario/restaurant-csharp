using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Entidades
{
    class entTemp_Pedido:Conexion
    {
        private int id_temp_pedido;
        private DateTime fecha;
        private int id_mesa;
        private int id_producto;
        private int id_cuerpo_pedido;
        private int id_pedido;
        private double precio;
        private double cantidad;

        Conexion cnn = new Conexion();


        public int pid_temp_pedido
        {
            get { return id_temp_pedido; }
            set { id_temp_pedido = value; }
        }

        public int pid_mesa
        {
            get { return id_mesa; }
            set { id_mesa = value; }
        }

        public DateTime pfecha 
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int pid_pedido
        {
            get { return id_pedido; }
            set { id_pedido = value; }
        }

        public int pid_cuerpo_pedido
        {
            get { return id_cuerpo_pedido; }
            set { id_cuerpo_pedido = value; }
        }
        public int pid_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }

        public double pprecio
        {
            get { return precio; }
            set { precio = value; }
        }
        public double pcantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
  
        public entTemp_Pedido() 
        {
            id_temp_pedido = 0;
            id_mesa = 0;
            fecha = DateTime.Today;
            id_producto = 0;
            id_pedido = 0;
            id_cuerpo_pedido = 0;
            precio = 0.0;
            cantidad = 0;
        }

        ////procedimiento de insertar
        public void Insertar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Temp_Pedido_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@id_temp_pedido", pid_temp_pedido);
            SqlParameter outparam = cmd.Parameters.Add("@id_temp_pedido", SqlDbType.Int);
            outparam.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@fecha", pfecha);
            cmd.Parameters.AddWithValue("@id_mesa", pid_mesa);
            cmd.Parameters.AddWithValue("@id_pedido", pid_pedido);
            cmd.Parameters.AddWithValue("@id_producto", pid_producto);
            cmd.Parameters.AddWithValue("@id_cuerpo_pedido", pid_cuerpo_pedido);
            cmd.Parameters.AddWithValue("@precio", pprecio);
            cmd.Parameters.AddWithValue("@cantidad", pcantidad);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            pid_temp_pedido = Convert.ToInt32(cmd.Parameters["@id_temp_pedido"].Value);
            cmd.Connection.Close();
        }

        //procedimiento de Update
        public void Modificar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Temp_Pedido_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_temp_pedido", pid_temp_pedido);
            cmd.Parameters.AddWithValue("@fecha", pfecha);
            cmd.Parameters.AddWithValue("@id_mesa", pid_mesa);
            cmd.Parameters.AddWithValue("@id_pedido", pid_pedido);
            cmd.Parameters.AddWithValue("@id_producto", pid_producto);
            cmd.Parameters.AddWithValue("@id_cuerpo_pedido", pid_cuerpo_pedido);
            cmd.Parameters.AddWithValue("@precio", pprecio);
            cmd.Parameters.AddWithValue("@cantidad", pcantidad);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //procedimiento de BORRADO
        public void Borrar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Temp_Pedido_Delete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_temp_pedido", pid_temp_pedido);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DataTable Buscar(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Temp_Pedido_Find", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
            oda.Fill(odt);

            return odt;
        }


        //funcion para llenar el combo
        public DataTable GetCmb()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Temp_Pedido_GetCmb", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.Fill(odt);

            return odt;
        }

        //funcion que trae un registro poniendo su ID
        public void GetOne(int id_temp_pedido)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Temp_Pedido_GetOne", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_temp_pedido", id_temp_pedido);
            
            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            pfecha = Convert.ToDateTime(odr["fecha"]);
            pid_mesa = Convert.ToInt32(odr["id_mesa"]);
            pid_pedido = Convert.ToInt32(odr["id_pedido"]);
            pid_cuerpo_pedido = Convert.ToInt32(odr["id_cuerpo_pedido"]);
            pid_producto = Convert.ToInt32(odr["id_producto"]);
            pprecio = Convert.ToInt32(odr["precio"]);
            pcantidad = Convert.ToInt32(odr["cantidad"]);

          }

        //controla si existe el registro en la BD

        public bool Exist()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Temp_Pedido_Exist", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@fecha", pfecha);
            oda.SelectCommand.Parameters.AddWithValue("@id_mesa", pid_mesa);
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", pid_mesa);
            oda.SelectCommand.Parameters.AddWithValue("@id_cuerpo_pedido", pid_mesa);
            oda.SelectCommand.Parameters.AddWithValue("@id_producto", pid_mesa);
            oda.SelectCommand.Parameters.AddWithValue("@precio", pid_mesa);
            oda.SelectCommand.Parameters.AddWithValue("@cantidad", pid_mesa);



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
            cmd.CommandText = "TRUNCATE TABLE TEMP_PEDIDO";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Insertar un registro en la tabla
        public void InsertOne()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cnn.Coneccion();
            command.CommandText = "cop_Temp_Pedido_InsertOne";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public DataTable GetAll()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Temp_Pedido_GetAll", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }

    }
}
