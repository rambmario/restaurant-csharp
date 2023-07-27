using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Entidades
{
    class entEgreso_efectivo:Conexion 
    {
          private int id_egreso_efectivo;
        private DateTime fecha_egreso_efectivo;
        private int id_usuario;
        private int id_caja;
        private double  importe;
        private string detalle_egreso_efectivo;
        Conexion cnn = new Conexion();

        public int pid_egreso_efectivo
        {
            get { return id_egreso_efectivo; }
            set { id_egreso_efectivo = value; }
        }
        public int pid_usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }
        public DateTime pfecha_egreso_efectivo
        {
            get { return fecha_egreso_efectivo; }
            set { fecha_egreso_efectivo = value; }
        }
        public int pid_caja
        {
            get { return id_caja; }
            set { id_caja = value; }
        }
        public double pimporte
        {
            get { return importe; }
            set { importe = value; }
        }
        public string pdetalle_egreso_efectivo 
        {
            get { return detalle_egreso_efectivo; }
            set { detalle_egreso_efectivo = value; }
        }

        public entEgreso_efectivo()
        {
            id_egreso_efectivo = 0;
            id_usuario = 0;
            id_caja = 0;
            importe = 0.0;
            fecha_egreso_efectivo = DateTime.Now;
            detalle_egreso_efectivo = "";
        }

        ////procedimiento de insertar
        public void Insertar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Egreso_efectivo_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter outparam = cmd.Parameters.Add("@id_egreso_efectivo", SqlDbType.Int);
            outparam.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@id_caja", pid_caja);
            cmd.Parameters.AddWithValue("@id_usuario", pid_usuario);
            cmd.Parameters.AddWithValue("@importe", pimporte);
            cmd.Parameters.AddWithValue("@fecha_egreso_efectivo", pfecha_egreso_efectivo);
            cmd.Parameters.AddWithValue("@detalle_egreso_efectivo", pdetalle_egreso_efectivo);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            pid_egreso_efectivo = Convert.ToInt32(cmd.Parameters["@id_egreso_efectivo"].Value);
            cmd.Connection.Close();
        }

        //procedimiento de Update
        public void Modificar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Egreso_efectivo_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_egreso_efectivo", pid_egreso_efectivo);
            cmd.Parameters.AddWithValue("@id_usuario", pid_usuario);
            cmd.Parameters.AddWithValue("@importe", pimporte);
            cmd.Parameters.AddWithValue("@fecha_egreso_efectivo", pfecha_egreso_efectivo);
            cmd.Parameters.AddWithValue("@detalle_egreso_efectivo", pdetalle_egreso_efectivo);
            cmd.Parameters.AddWithValue("@id_caja", pid_caja);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //procedimiento de BORRADO
        public void Borrar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Egreso_efectivo_Delete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_egreso_efectivo", pid_egreso_efectivo);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DataTable Buscar(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Egreso_efectivo_Find", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
            oda.Fill(odt);

            return odt;
        }


        //funcion para llenar el combo
        public DataTable GetCmb()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Egreso_efectivo_GetCmb", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.Fill(odt);

            return odt;
        }

        //funcion que trae un registro poniendo su ID
        public void GetOne(int id_egreso_efectivo)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Egreso_efectivo_GetOne", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_egreso_efectivo", id_egreso_efectivo);

            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            pid_usuario = Convert.ToInt32(odr["id_usuario"]);
            pid_caja = Convert.ToInt32(odr["id_caja"]);
            pimporte = Convert.ToDouble(odr["Importe"]);
            pfecha_egreso_efectivo = Convert.ToDateTime(odr["fecha_egreso_efectivo"]);
            pdetalle_egreso_efectivo = Convert.ToString(odr["detalle_egreso_efectivo"]);

        }

        //controla si existe el registro en la BD

        public bool Exist()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Egreso_efectivo_Exist", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_caja", pid_caja);
            oda.SelectCommand.Parameters.AddWithValue("@id_usuario", pid_usuario);
            oda.SelectCommand.Parameters.AddWithValue("@importe", pimporte);
            oda.SelectCommand.Parameters.AddWithValue("@fecha_egreso_efectivo", pfecha_egreso_efectivo);
            oda.SelectCommand.Parameters.AddWithValue("@detalle_egreso_efectivo", pdetalle_egreso_efectivo);
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
            cmd.CommandText = "TRUNCATE TABLE Egreso_efectivo";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Insertar un registro en la tabla
        public void InsertOne()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cnn.Coneccion();
            command.CommandText = "cop_Egreso_efectivo_InsertOne";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public DataTable GetAll()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Egreso_efectivo_GetAll", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }
    }
}
