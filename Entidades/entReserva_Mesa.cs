using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Entidades
{
    class entReserva_Mesa:Conexion
    {
        private int id_reserva_mesa;
        private DateTime fecha_reserva;
        private DateTime hora_reserva;
        private double nro_huesped;
        private int id_mesa;
        private string estado_reserva;
        private int id_cliente;
        private string observacion;

        Conexion cnn = new Conexion();

        public int pid_reserva_mesa
        {
            get { return id_reserva_mesa; }
            set { id_reserva_mesa = value; }
        }
        public int pid_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }
        public int pid_mesa
        {
            get { return id_mesa; }
            set { id_mesa = value; }
        }
        public DateTime pfecha_reserva
        {
            get { return fecha_reserva; }
            set { fecha_reserva = value; }
        }
        public DateTime phora_reserva
        {
            get { return hora_reserva; }
            set { hora_reserva = value; }
        }
        public double pnro_huesped
        {
            get { return nro_huesped; }
            set { nro_huesped = value; }
        }
        public string pestado_reserva
        {
            get { return estado_reserva; }
            set { estado_reserva = value; }
        }
        public string pobsevacion
        {
            get { return observacion; }
            set { observacion = value; }
        }
        public entReserva_Mesa() 
        {
            id_mesa = 0;
            id_cliente = 0;
            id_reserva_mesa = 0;
            fecha_reserva = DateTime.Today;
            hora_reserva = DateTime.Now;
            nro_huesped = 0.0;
            estado_reserva = "";
            observacion = "-";
        }
        ////procedimiento de insertar
        public void Insertar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Reserva_Mesa_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@id_temp_pedido", pid_temp_pedido);
            SqlParameter outparam = cmd.Parameters.Add("@id_reserva_mesa", SqlDbType.Int);
            outparam.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@fecha_reserva", pfecha_reserva);
            cmd.Parameters.AddWithValue("@hora_reserva", phora_reserva);
            cmd.Parameters.AddWithValue("@id_mesa", pid_mesa);
            cmd.Parameters.AddWithValue("@id_cliente", pid_cliente);
            cmd.Parameters.AddWithValue("@nro_huesped", pnro_huesped);
            cmd.Parameters.AddWithValue("@estado_reserva", pestado_reserva);
            cmd.Parameters.AddWithValue("@observacion", pobsevacion);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            pid_reserva_mesa = Convert.ToInt32(cmd.Parameters["@id_reserva_mesa"].Value);
            cmd.Connection.Close();
        }

        //procedimiento de Update
        public void Modificar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Reserva_Mesa_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_reserva_mesa", pid_reserva_mesa);
            cmd.Parameters.AddWithValue("@fecha_reserva", pfecha_reserva);
            cmd.Parameters.AddWithValue("@hora_reserva", phora_reserva);
            cmd.Parameters.AddWithValue("@id_mesa", pid_mesa);
            cmd.Parameters.AddWithValue("@id_cliente", pid_cliente);
            cmd.Parameters.AddWithValue("@nro_huesped", pnro_huesped);
            cmd.Parameters.AddWithValue("@estado_reserva", pestado_reserva);
            cmd.Parameters.AddWithValue("@observacion", pobsevacion);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //procedimiento de BORRADO
        public void Borrar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Reserva_Mesa_Delete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_reserva_mesa", pid_reserva_mesa);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DataTable Buscar(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Mesa_Find", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
            oda.Fill(odt);

            return odt;
        }


        //funcion para llenar el combo
        public DataTable GetCmb()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Mesa_GetCmb", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.Fill(odt);

            return odt;
        }

        //funcion que trae un registro poniendo su ID
        public void GetOne(int id_reserva_mesa)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Mesa_GetOne", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_reserva_mesa", id_reserva_mesa);

            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            pfecha_reserva = Convert.ToDateTime(odr["fecha_reserva"]);
            phora_reserva = Convert.ToDateTime(odr["hora_reserva"]);
            pid_mesa = Convert.ToInt32(odr["id_mesa"]);
            pid_cliente = Convert.ToInt32(odr["id_cliente"]);
            pestado_reserva = Convert.ToString(odr["estado_reserva"]);
            pnro_huesped = Convert.ToDouble(odr["nro_huesped"]);
            pobsevacion = Convert.ToString(odr["observacion"]);

        }

        //controla si existe el registro en la BD

        public bool Exist()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Mesa_Exist", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@fecha_reserva", pfecha_reserva);
            oda.SelectCommand.Parameters.AddWithValue("@hora_reserva", phora_reserva);
            oda.SelectCommand.Parameters.AddWithValue("@id_mesa", pid_mesa);
            oda.SelectCommand.Parameters.AddWithValue("@id_cliente", pid_cliente);
            oda.SelectCommand.Parameters.AddWithValue("@nro_huesped", pnro_huesped);
            oda.SelectCommand.Parameters.AddWithValue("@observacion", pobsevacion);
            oda.SelectCommand.Parameters.AddWithValue("@estado_reserva", pestado_reserva);



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
            cmd.CommandText = "TRUNCATE TABLE RESERVA_MESA";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Insertar un registro en la tabla
        public void InsertOne()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cnn.Coneccion();
            command.CommandText = "cop_Reserva_Mesa_InsertOne";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public DataTable GetAll()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Reserva_Mesa_GetAll", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }
    }
}
