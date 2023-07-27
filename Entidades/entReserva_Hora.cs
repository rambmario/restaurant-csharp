using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Entidades
{
    class entReserva_Hora:Conexion
    {
        private int id_reserva_hora;
        private DateTime hora_reserva;
        private int cantidad;
        Conexion cnn = new Conexion();

        public int pid_reserva_hora
        {
            get { return id_reserva_hora; }
            set { id_reserva_hora = value; }
        }
        public DateTime phora_reserva
        {
            get { return hora_reserva; }
            set { hora_reserva = value; }
        }
        public int pcantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public entReserva_Hora() 
        {
            id_reserva_hora = 0;
            hora_reserva = DateTime.Now;
            cantidad = 0;
        }

        ////procedimiento de insertar
        public void Insertar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Reserva_Hora_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@id_reserva_hora", pid_reserva_hora);
            SqlParameter outparam = cmd.Parameters.Add("@id_reserva_hora", SqlDbType.Int);
            outparam.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@hora_reserva", phora_reserva);
            cmd.Parameters.AddWithValue("@cantidad", pcantidad);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            pid_reserva_hora = Convert.ToInt32(cmd.Parameters["@id_reserva_hora"].Value);
            cmd.Connection.Close();
        }

        //procedimiento de Update
        public void Modificar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Reserva_Hora_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_reserva_hora", pid_reserva_hora);
            cmd.Parameters.AddWithValue("@hora_reserva", phora_reserva);
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
            cmd.CommandText = "cop_Reserva_Hora_Delete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_reserva_hora", pid_reserva_hora);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DataTable Buscar(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Hora_Find", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
            oda.Fill(odt);

            return odt;
        }


        //funcion para llenar el combo
        public DataTable GetCmb()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Hora_GetCmb", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.Fill(odt);

            return odt;
        }

        //funcion que trae un registro poniendo su ID
        public void GetOne(int id_reserva_hora)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Hora_GetOne", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_reserva_hora", id_reserva_hora);

            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            phora_reserva = Convert.ToDateTime(odr["hora_reserva"]);
            pcantidad = Convert.ToInt32(odr["cantidad"]);
        }

        //controla si existe el registro en la BD

        public bool Exist()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Hora_Exist", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@hora_reserva", phora_reserva);
            oda.SelectCommand.Parameters.AddWithValue("@cantidad", pcantidad);


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
            cmd.CommandText = "TRUNCATE TABLE RESERVA_HORA";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Insertar un registro en la tabla
        public void InsertOne()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cnn.Coneccion();
            command.CommandText = "cop_Reserva_Hora_InsertOne";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public DataTable GetAll()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Hora_GetAll", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }
    }
}
