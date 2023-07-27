using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace Gestion_gastronomica.Entidades
{
    class entPago_Pedido:Conexion
    {
         private int id_pago_pedido;
        private int id_pedido;
        private int id_forma_pago;
        private double  importe;
        private int id_banco;
        private int id_cliente;
        private string nro_cheque;
        private int id_caja;
        Conexion cnn = new Conexion();

        public int pid_pago_pedido
        {
            get { return id_pago_pedido; }
            set { id_pago_pedido = value; }
        }
        public int pid_pedido
        {
            get { return id_pedido; }
            set { id_pedido = value; }
        }
        public int pid_banco
        {
            get { return id_banco; }
            set { id_banco = value; }
        }
        public int pid_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }
        public int pid_forma_pago
        {
            get { return id_forma_pago; }
            set { id_forma_pago = value; }
        }
        public double pimporte
        {
            get { return importe; }
            set { importe = value; }
        }
        public string pnro_cheque 
        {
            get { return nro_cheque; }
            set { nro_cheque = value; }
        }
        public int pid_caja
        {
            get { return id_caja; }
            set { id_caja = value; }
        }

        public entPago_Pedido()
        {
            id_pago_pedido = 0;
            id_pedido = 0;
            id_forma_pago = 0;
            importe = 0.0;
            id_banco = 0;
            id_cliente = 0;
            nro_cheque = "";
            id_caja = 0;
        }

        ////procedimiento de insertar
        public void Insertar()
        {



            // SqlParameter outparam = cmd.Parameters.Add("@id_pedido", SqlDbType.Int);
            // outparam.Direction = ParameterDirection.Output;
            // pid_pedido = Convert.ToInt32(cmd.Parameters["@id_pedido"].Value);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Pago_Pedido_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter outparam = cmd.Parameters.Add("@id_pago_pedido", SqlDbType.Int);
            outparam.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@id_forma_pago", pid_forma_pago);
            cmd.Parameters.AddWithValue("@id_pedido", pid_pedido);
            cmd.Parameters.AddWithValue("@importe", pimporte);
            cmd.Parameters.AddWithValue("@id_banco", pid_banco);
            cmd.Parameters.AddWithValue("@id_cliente", pid_cliente);
            cmd.Parameters.AddWithValue("@nro_cheque", pnro_cheque);
            cmd.Parameters.AddWithValue("@id_caja", pid_caja);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            pid_pago_pedido = Convert.ToInt32(cmd.Parameters["@id_pago_pedido"].Value);
            cmd.Connection.Close();
        }

        //procedimiento de Update
        public void Modificar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Pago_Pedido_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_forma_pago", pid_forma_pago);
            cmd.Parameters.AddWithValue("@id_pago_pedido", pid_pago_pedido);
            cmd.Parameters.AddWithValue("@id_pedido", pid_pedido);
            cmd.Parameters.AddWithValue("@importe", pimporte);
            cmd.Parameters.AddWithValue("@id_banco", pid_banco);
            cmd.Parameters.AddWithValue("@id_cliente", pid_cliente);
            cmd.Parameters.AddWithValue("@nro_cheque", pnro_cheque);
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
            cmd.CommandText = "cop_Pago_Pedido_Delete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_pago_pedido", pid_pago_pedido);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DataTable Buscar(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Pago_Pedido_Find", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
            oda.Fill(odt);

            return odt;
        }


        //funcion para llenar el combo
        public DataTable GetCmb()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Pago_Pedido_GetCmb", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.Fill(odt);

            return odt;
        }

        //funcion que trae un registro poniendo su ID
        public void GetOne(int id_pago_pedido)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Pago_Pedido_GetOne", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_pago_pedido", id_pago_pedido);

            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            pid_pedido = Convert.ToInt32(odr["Id_pedido"]);
            pid_forma_pago = Convert.ToInt32(odr["Id_forma_pago"]);
            pimporte = Convert.ToDouble(odr["Importe"]);
            pid_cliente = Convert.ToInt32(odr["id_cliente"]);
            pid_banco = Convert.ToInt32(odr["id_banco"]);
            pnro_cheque = Convert.ToString(odr["nro_cheque"]);
            pid_caja = Convert.ToInt32(odr["id_caja"]);

        }

        //controla si existe el registro en la BD

        public bool Exist()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Pago_Pedido_Exist", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_forma_pago", pid_forma_pago);
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", pid_pedido);
            oda.SelectCommand.Parameters.AddWithValue("@importe", pimporte);
            oda.SelectCommand.Parameters.AddWithValue("@id_banco", pid_banco);
            oda.SelectCommand.Parameters.AddWithValue("@id_cliente", pid_cliente);
            oda.SelectCommand.Parameters.AddWithValue("@nro_cheque", pnro_cheque);
            oda.SelectCommand.Parameters.AddWithValue("@id_caja", id_caja);
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
            cmd.CommandText = "TRUNCATE TABLE PAGO_PEDIDO";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Insertar un registro en la tabla
        public void InsertOne()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cnn.Coneccion();
            command.CommandText = "cop_Pago_Pedido_InsertOne";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public DataTable GetAll()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Pago_Pedido_GetAll", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }
    }
}
