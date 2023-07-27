using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Gestion_gastronomica.Entidades
{
    class entMesa:Conexion
    {
        //defino variables
        private int id_mesa;
        private string nombre_mesa;
        private string estado;
        private int id_reserva;
        private int grupo_mesa;
        private int cantidad_persona;
        private Conexion cnn = new Conexion();

        //defino propiedades publicas
        public int pid_mesa 
        {
            get { return id_mesa; }
            set { id_mesa = value; }
        }
        public int pgrupo_mesa
        {
            get { return grupo_mesa; }
            set { grupo_mesa = value; }
        }
        public int pcantidad_persona
        {
            get { return cantidad_persona; }
            set { cantidad_persona = value; }
        }
        public int pid_reserva
        {
            get { return id_reserva; }
            set { id_reserva = value; }
        }
        public string pnombre_mesa 
        {
            get { return nombre_mesa; }
            set { nombre_mesa = value; }
        }
        public string pestado
        {
            get { return estado; }
            set { estado = value; }
        }
        //defino contructor
        public entMesa() 
        {
            id_mesa = 0;
            nombre_mesa = "";
            id_reserva = 0;
            grupo_mesa = 0;
            cantidad_persona = 0;
        }

        ////procedimiento de insertar
        public void Insertar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Mesa_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter outparam = cmd.Parameters.Add("@id_mesa", SqlDbType.Int);
            outparam.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@nombre_mesa", pnombre_mesa);
            cmd.Parameters.AddWithValue("@estado", pestado);
            cmd.Parameters.AddWithValue("@id_reserva", pid_reserva);
            cmd.Parameters.AddWithValue("@grupo_mesa", pgrupo_mesa);
            cmd.Parameters.AddWithValue("@cantidad_persona", pcantidad_persona);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            pid_mesa = Convert.ToInt32(cmd.Parameters["@id_mesa"].Value);
            cmd.Connection.Close();
        }

        //procedimiento de Update
        public void Modificar() 
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion(); 
            cmd.CommandText = "cop_Mesa_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_mesa", pid_mesa);
            cmd.Parameters.AddWithValue("@nombre_mesa", pnombre_mesa);
            cmd.Parameters.AddWithValue("@estado",pestado);
            cmd.Parameters.AddWithValue("@id_reserva", pid_reserva);
            cmd.Parameters.AddWithValue("@grupo_mesa", pgrupo_mesa);
            cmd.Parameters.AddWithValue("@cantidad_persona", pcantidad_persona);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //procedimiento de BORRADO
        public void Borrar() 
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Mesa_Delete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_mesa", pid_mesa);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DataTable Buscar(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Mesa_Find", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre",Nombre);
            oda.Fill(odt);

            return odt;
        }


        //funcion para llenar el combo
        public DataTable GetCmb()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Mesa_GetCmb", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.Fill(odt);

            return odt;
        }

        //funcion que trae un registro poniendo su ID
        public void GetOne(int id_mesa)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Mesa_GetOne", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_mesa", id_mesa);

            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            pid_mesa = id_mesa;
            pnombre_mesa = Convert.ToString(odr["nombre_mesa"]);
            pestado = Convert.ToString(odr["Estado"]);
            pid_reserva = Convert.ToInt32(odr["id_reserva"]);
            pgrupo_mesa = Convert.ToInt32(odr["grupo_mesa"]);
            pcantidad_persona = Convert.ToInt32(odr["cantidad_persona"]);

            // return odt;
        }

        //controla si existe el registro en la BD

        public bool Exist()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Mesa_Exist", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre_mesa", pnombre_mesa);
            oda.SelectCommand.Parameters.AddWithValue("@estado", pestado);
            oda.SelectCommand.Parameters.AddWithValue("@id_reserva", pid_reserva);
            oda.SelectCommand.Parameters.AddWithValue("@grupo_mesa", pgrupo_mesa);
            oda.SelectCommand.Parameters.AddWithValue("@cantidad_persona", pcantidad_persona);

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
            command.Connection =  cnn.Coneccion();
            command.CommandText = "cop_Mesa_InsertOne";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public DataTable GetAll()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Mesa_GetAll", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }

    }
}
