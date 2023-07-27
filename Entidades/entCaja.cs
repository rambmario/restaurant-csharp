using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Entidades
{
    class entCaja
    {
        Conexion cnn = new Conexion();
        private int id_caja;
        private DateTime fecha_caja;
        private int id_usuario;
        private bool cerrada;
        private string detalle;
        private double saldo_efectivo;
        private double saldo_tarjeta;
        private double saldo_cheque;
        private double saldo_inicial;

        public int pid_caja
        {
            get { return id_caja; }
            set { id_caja = value; }
        }
        public DateTime pfecha_caja
        {
            get { return fecha_caja; }
            set { fecha_caja = value; }
        }
        public int pid_usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }
        public bool pcerrada
        {
            get { return cerrada; }
            set { cerrada = value; }
        }
        public string pdetalle
        {
            get { return detalle; }
            set { detalle = value; }
        }
        public double psaldo_efectivo
        {
            get { return saldo_efectivo; }
            set { saldo_efectivo = value; }
        }
        public double psaldo_tarjeta
        {
            get { return saldo_tarjeta; }
            set { saldo_tarjeta = value; }
        }
         public double psaldo_cheque
        {
            get { return saldo_cheque; }
            set { saldo_cheque = value; }
        }
         public double psaldo_inicial
         {
             get { return saldo_inicial; }
             set { saldo_inicial = value; }
         }

         public entCaja() 
         {
             id_caja = 0;
             fecha_caja = DateTime.Now;
             id_usuario = 0;
             detalle = "";
             saldo_cheque = 0.0;
             saldo_efectivo = 0.0;
             saldo_tarjeta = 0.0;
             cerrada = false;
             saldo_inicial = 0.0;
         }

         ////procedimiento de insertar
         public void Insertar()
         {
             SqlCommand cmd = new SqlCommand();

             cmd.Connection = cnn.Coneccion();
             cmd.CommandText = "cop_Caja_Insert";
             cmd.CommandType = CommandType.StoredProcedure;
             //cmd.Parameters.AddWithValue("@id_temp_pedido", pid_temp_pedido);
             SqlParameter outparam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
             outparam.Direction = ParameterDirection.Output;
             cmd.Parameters.AddWithValue("@fecha_caja", pfecha_caja);
             cmd.Parameters.AddWithValue("@cerrada", pcerrada);
             cmd.Parameters.AddWithValue("@detalle", detalle);
             cmd.Parameters.AddWithValue("@id_usuario", pid_usuario);
             cmd.Parameters.AddWithValue("@saldo_efectivo", psaldo_efectivo);
             cmd.Parameters.AddWithValue("@saldo_cheque", psaldo_cheque);
             cmd.Parameters.AddWithValue("@saldo_tarjeta", psaldo_tarjeta);
             cmd.Parameters.AddWithValue("@saldo_inicial", psaldo_inicial);
             cmd.Connection.Open();
             cmd.ExecuteNonQuery();
             pid_caja = Convert.ToInt32(cmd.Parameters["@id_caja"].Value);
             cmd.Connection.Close();
         }

         //procedimiento de Update
         public void Modificar()
         {
             SqlCommand cmd = new SqlCommand();

             cmd.Connection = cnn.Coneccion();
             cmd.CommandText = "cop_Caja_Update";
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@id_caja", pid_caja);
             cmd.Parameters.AddWithValue("@fecha_caja", pfecha_caja);
             cmd.Parameters.AddWithValue("@cerrada", pcerrada);
             cmd.Parameters.AddWithValue("@detalle", detalle);
             cmd.Parameters.AddWithValue("@id_usuario", pid_usuario);
             cmd.Parameters.AddWithValue("@saldo_efectivo", psaldo_efectivo);
             cmd.Parameters.AddWithValue("@saldo_cheque", psaldo_cheque);
             cmd.Parameters.AddWithValue("@saldo_tarjeta", psaldo_tarjeta);
             cmd.Parameters.AddWithValue("@saldo_inicial", psaldo_inicial);
             cmd.Connection.Open();
             cmd.ExecuteNonQuery();
             cmd.Connection.Close();
         }

         //procedimiento de BORRADO
         public void Borrar()
         {
             SqlCommand cmd = new SqlCommand();

             cmd.Connection = cnn.Coneccion();
             cmd.CommandText = "cop_Caja_Delete";
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@id_caja", pid_caja);
             cmd.Connection.Open();
             cmd.ExecuteNonQuery();
             cmd.Connection.Close();
         }

         public DataTable Buscar(string Nombre)
         {
             DataTable odt = new DataTable();
             SqlDataAdapter oda = new SqlDataAdapter("cop_Caja_Find", cnn.Coneccion());

             oda.SelectCommand.CommandType = CommandType.StoredProcedure;
             oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
             oda.Fill(odt);

             return odt;
         }


         //funcion para llenar el combo
         public DataTable GetCmb()
         {
             DataTable odt = new DataTable();
             SqlDataAdapter oda = new SqlDataAdapter("cop_Caja_GetCmb", cnn.Coneccion());

             oda.SelectCommand.CommandType = CommandType.StoredProcedure;
             oda.Fill(odt);

             return odt;
         }

         //funcion que trae un registro poniendo su ID
         public void GetOne(int id_caja)
         {
             DataTable odt = new DataTable();
             SqlDataAdapter oda = new SqlDataAdapter("cop_Caja_GetOne", cnn.Coneccion());

             oda.SelectCommand.CommandType = CommandType.StoredProcedure;
             oda.SelectCommand.Parameters.AddWithValue("@id_caja", id_caja);

             oda.Fill(odt);
             DataRow odr;
             odr = odt.Rows[0];

             pfecha_caja = Convert.ToDateTime(odr["fecha_caja"]);
             pcerrada = Convert.ToBoolean(odr["cerrada"]);
             pdetalle = Convert.ToString(odr["detalle"]);
             pid_usuario = Convert.ToInt32(odr["id_usuario"]);
             psaldo_tarjeta = Convert.ToDouble(odr["saldo_tarjeta"]);
             psaldo_cheque = Convert.ToDouble(odr["saldo_cheque"]);
             psaldo_efectivo = Convert.ToDouble(odr["saldo_efectivo"]);
             psaldo_inicial = Convert.ToDouble(odr["saldo_inicial"]);
         }

         //controla si existe el registro en la BD

         public bool Exist()
         {
             DataTable odt = new DataTable();
             SqlDataAdapter oda = new SqlDataAdapter("cop_Caja_Exist", cnn.Coneccion());
             int Total = 0;

             oda.SelectCommand.CommandType = CommandType.StoredProcedure;
             oda.SelectCommand.Parameters.AddWithValue("@fecha_caja", pfecha_caja);
             oda.SelectCommand.Parameters.AddWithValue("@cerrada", pcerrada);
             oda.SelectCommand.Parameters.AddWithValue("@detalle", pdetalle);
             oda.SelectCommand.Parameters.AddWithValue("@id_usuario", pid_usuario);
             oda.SelectCommand.Parameters.AddWithValue("@saldo_efectivo", psaldo_efectivo);
             oda.SelectCommand.Parameters.AddWithValue("@saldo_tarjeta", psaldo_tarjeta);
             oda.SelectCommand.Parameters.AddWithValue("@saldo_cheque", psaldo_cheque);
             oda.SelectCommand.Parameters.AddWithValue("@saldo_inicial", psaldo_inicial);

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
             cmd.CommandText = "TRUNCATE TABLE CAJA";
             cmd.Connection.Open();
             cmd.ExecuteNonQuery();
             cmd.Connection.Close();
         }

         //Insertar un registro en la tabla
         public void InsertOne()
         {
             SqlCommand command = new SqlCommand();
             command.Connection = cnn.Coneccion();
             command.CommandText = "cop_Caja_InsertOne";
             command.CommandType = CommandType.StoredProcedure;
             command.Connection.Open();
             command.ExecuteNonQuery();
             command.Connection.Close();
         }

         public DataTable GetAll()
         {
             DataTable odt = new DataTable();
             SqlDataAdapter oda = new SqlDataAdapter("cop_Caja_GetAll", cnn.Coneccion());

             oda.SelectCommand.CommandType = CommandType.StoredProcedure;

             oda.Fill(odt);
             return odt;
         }
    }
}
