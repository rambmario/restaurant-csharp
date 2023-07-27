using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Entidades
{
    class entPedido:Conexion
    {
        private int id_pedido;
        private DateTime fecha;
        private double importe;
        private int id_mesa;
        private DateTime fecha_entrega;
        private double porcentaje_descuento;
        private double pago_cliente;
        private double descuento;
        private double totals;
        private int id_estado_pedido;
        private int id_cliente;

        Conexion cnn = new Conexion();

        public int pid_pedido
        {
            get { return id_pedido; }
            set { id_pedido = value; }
        }
        public int pid_estado_pedido
        {
            get { return id_estado_pedido; }
            set { id_estado_pedido = value; }
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

        public DateTime pfecha_entrega
        {
            get { return fecha_entrega; }
            set { fecha_entrega = value; }
        }

        public double pimporte
        {
            get { return importe; }
            set { importe = value; }
        }
        public double pporcentaje_descuento
        {
            get { return porcentaje_descuento; }
            set { porcentaje_descuento = value; }
        }
        public double pdescuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
        public double ppago_cliente
        {
            get { return pago_cliente; }
            set { pago_cliente = value; }
        }
        public double ptotals
        {
            get { return totals; }
            set { totals = value; }
        }

        public int pid_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }


        public entPedido() 
        {
            id_pedido = 0;
            id_estado_pedido = 0;
            id_mesa = 0;
            fecha = DateTime.Today;
            importe = 0.0;
            pago_cliente = 0.0;
            porcentaje_descuento = 0.0;
            descuento = 0.0;
            fecha_entrega = DateTime.Today;
            totals = 0.0;
            id_cliente = 1;
        }

        ////procedimiento de insertar
        public void Insertar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Pedido_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@id_pedido", pid_pedido);
            SqlParameter outparam = cmd.Parameters.Add("@id_pedido", SqlDbType.Int);
            outparam.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@fecha", pfecha);
            cmd.Parameters.AddWithValue("@fecha_entrega", pfecha_entrega);
            cmd.Parameters.AddWithValue("@importe", pimporte);
            cmd.Parameters.AddWithValue("@porcentaje_descuento", pporcentaje_descuento);
            cmd.Parameters.AddWithValue("@descuento", pdescuento);
            cmd.Parameters.AddWithValue("@totals", ptotals);
            cmd.Parameters.AddWithValue("@pago_cliente", ppago_cliente);
            cmd.Parameters.AddWithValue("@id_mesa", pid_mesa);
            cmd.Parameters.AddWithValue("@id_estado_pedido", pid_estado_pedido);
            cmd.Parameters.AddWithValue("@id_cliente", pid_cliente);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            pid_pedido = Convert.ToInt32(cmd.Parameters["@id_pedido"].Value);
            cmd.Connection.Close();
        }

        //procedimiento de Update
        public void Modificar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Pedido_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_pedido", pid_pedido);
            cmd.Parameters.AddWithValue("@fecha", pfecha);
            cmd.Parameters.AddWithValue("@fecha_entrega", pfecha_entrega);
            cmd.Parameters.AddWithValue("@importe", pimporte);
            cmd.Parameters.AddWithValue("@porcentaje_descuento", pporcentaje_descuento);
            cmd.Parameters.AddWithValue("@descuento", pdescuento);
            cmd.Parameters.AddWithValue("@pago_cliente", ppago_cliente);
            cmd.Parameters.AddWithValue("@totals", ptotals);
            cmd.Parameters.AddWithValue("@id_mesa", pid_mesa);
            cmd.Parameters.AddWithValue("@id_estado_pedido", pid_estado_pedido);
            cmd.Parameters.AddWithValue("@id_cliente", pid_cliente);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //procedimiento de BORRADO
        public void Borrar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Pedido_Delete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_pedido", pid_pedido);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DataTable Buscar(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Pedido_Find", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
            oda.Fill(odt);

            return odt;
        }


        //funcion para llenar el combo
        public DataTable GetCmb()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Pedido_GetCmb", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.Fill(odt);

            return odt;
        }

        //funcion que trae un registro poniendo su ID
        public void GetOne(int id_pedido)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Pedido_GetOne", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);
            
            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            pfecha = Convert.ToDateTime(odr["fecha"]);
            pfecha_entrega = Convert.ToDateTime(odr["Fecha_entrega"]);
            pimporte = Convert.ToDouble(odr["importe"]);
            pporcentaje_descuento = Convert.ToDouble(odr["Porcentaje_descuento"]);
            pdescuento = Convert.ToDouble(odr["descuento"]);
            ptotals = Convert.ToDouble(odr["pago_cliente"]);
            ptotals = Convert.ToDouble(odr["totals"]);
            pid_mesa = Convert.ToInt32(odr["id_mesa"]);
            pid_estado_pedido = Convert.ToInt32(odr["id_estado_pedido"]);
            pid_cliente = Convert.ToInt32(odr["id_cliente"]);
        }

        //controla si existe el registro en la BD

        public bool Exist()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Pedido_Exist", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@fecha", pfecha);
            oda.SelectCommand.Parameters.AddWithValue("@fecha_entrega", pfecha_entrega);
            oda.SelectCommand.Parameters.AddWithValue("@importe", pimporte);
            oda.SelectCommand.Parameters.AddWithValue("@porcentaje_descuento", pporcentaje_descuento);
            oda.SelectCommand.Parameters.AddWithValue("@pago_cliente", ppago_cliente);
            oda.SelectCommand.Parameters.AddWithValue("@descuento", pdescuento);
            oda.SelectCommand.Parameters.AddWithValue("@totals", ptotals);
            oda.SelectCommand.Parameters.AddWithValue("@id_mesa", pid_mesa);
            oda.SelectCommand.Parameters.AddWithValue("@id_estado_pedido", pid_estado_pedido);
            oda.SelectCommand.Parameters.AddWithValue("@id_cliente", pid_cliente);

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
            cmd.CommandText = "TRUNCATE TABLE PEDIDO";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Insertar un registro en la tabla
        public void InsertOne()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cnn.Coneccion();
            command.CommandText = "cop_Pedido_InsertOne";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public DataTable GetAll()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Pedido_GetAll", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }

    }
}
