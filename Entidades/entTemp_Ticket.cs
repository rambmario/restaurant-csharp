using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Entidades
{
    class entTemp_Ticket:Conexion
    {
        private int id_temp_ticket;
        private int id_cuerpo_pedido;
        private int id_pedido;
        private int id_producto;
        private int cantidad;
        private double precio;
        private double importe;
        private double totals;
        private double porcentaje_descuento;
        private double descuento;
        Conexion cnn = new Conexion();

        public int pid_cuerpo_pedido
        {
            get { return id_cuerpo_pedido; }
            set { id_cuerpo_pedido = value; }
        }
        public int pid_temp_ticket
        {
            get { return id_temp_ticket; }
            set { id_temp_ticket = value; }
        }
        public int pid_pedido
        {
            get { return id_pedido; }
            set { id_pedido = value; }
        }
        public int pid_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }
        public int pcantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public double pprecio
        {
            get { return precio; }
            set { precio = value; }
        }
        public double pdescuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
        public double pimporte
        {
            get { return importe; }
            set { importe = value; }
        }
        public double ptotals
        {
            get { return totals; }
            set { totals = value; }
        }
        public double pporcentaje_descuento
        {
            get { return porcentaje_descuento; }
            set { porcentaje_descuento = value; }
        }

        public entTemp_Ticket()
        {
            id_temp_ticket = 0;
            id_cuerpo_pedido = 0;
            id_pedido = 0;
            id_producto = 0;
            cantidad = 0;
            precio = 0.0;
            importe = 0.0;
            totals = 0.0;
            porcentaje_descuento = 0.0;
            descuento = 0.0;
        }
        ////procedimiento de insertar
        public void Insertar()
        {

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Temp_Ticket_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter outparam = cmd.Parameters.Add("@id_temp_ticket", SqlDbType.Int);
            outparam.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@id_cuerpo_pedido", pid_cuerpo_pedido);
            cmd.Parameters.AddWithValue("@id_pedido", pid_pedido);
            cmd.Parameters.AddWithValue("@precio", pprecio);
            cmd.Parameters.AddWithValue("@id_producto", pid_producto);
            cmd.Parameters.AddWithValue("@cantidad", pcantidad);
            cmd.Parameters.AddWithValue("@importe", pimporte);
            cmd.Parameters.AddWithValue("@totals", ptotals);
            cmd.Parameters.AddWithValue("@porcentaje_descuento", pporcentaje_descuento);
            cmd.Parameters.AddWithValue("@descuento", pdescuento);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            pid_temp_ticket = Convert.ToInt32(cmd.Parameters["@id_temp_ticket"].Value);
            cmd.Connection.Close();
        }

        //procedimiento de Update
        public void Modificar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Temp_Ticket_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_cuerpo_pedido", pid_cuerpo_pedido);
            cmd.Parameters.AddWithValue("@id_temp_ticket", pid_temp_ticket);
            cmd.Parameters.AddWithValue("@id_pedido", pid_pedido);
            cmd.Parameters.AddWithValue("@precio", pprecio);
            cmd.Parameters.AddWithValue("@id_producto", pid_producto);
            cmd.Parameters.AddWithValue("@cantidad", pcantidad);
            cmd.Parameters.AddWithValue("@importe", pimporte);
            cmd.Parameters.AddWithValue("@totals", ptotals);
            cmd.Parameters.AddWithValue("@porcentaje_descuento", pporcentaje_descuento);
            cmd.Parameters.AddWithValue("@descuento", pdescuento);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //procedimiento de BORRADO
        public void Borrar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Temp_Ticket_Delete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_temp_ticket", pid_temp_ticket);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DataTable Buscar(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Temp_Ticket_Find", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
            oda.Fill(odt);

            return odt;
        }


        //funcion para llenar el combo
        public DataTable GetCmb()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Temp_Ticket_GetCmb", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.Fill(odt);

            return odt;
        }

        //funcion que trae un registro poniendo su ID
        public void GetOne(int id_temp_ticket)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Temp_Ticket_GetOne", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_temp_ticket", id_temp_ticket);

            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            pid_pedido = Convert.ToInt32(odr["Id_pedido"]);
            pid_cuerpo_pedido = Convert.ToInt32(odr["id_cuerpo_pedido"]);
            pprecio = Convert.ToDouble(odr["precio"]);
            pid_producto = Convert.ToInt32(odr["id_producto"]);
            pcantidad = Convert.ToInt32(odr["cantidad"]);
            pimporte = Convert.ToDouble(odr["importe"]);
            ptotals = Convert.ToDouble(odr["totals"]);
            pporcentaje_descuento = Convert.ToDouble(odr["porcentaje_descuento"]);
            pdescuento = Convert.ToDouble(odr["descuento"]);
        }

        //controla si existe el registro en la BD

        public bool Exist()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Temp_Ticket_Exist", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_cuerpo_pedido", pid_cuerpo_pedido);
            oda.SelectCommand.Parameters.AddWithValue("@id_pedido", pid_pedido);
            oda.SelectCommand.Parameters.AddWithValue("@precio", pprecio);
            oda.SelectCommand.Parameters.AddWithValue("@id_producto", pid_producto);
            oda.SelectCommand.Parameters.AddWithValue("@cantidad", pcantidad);
            oda.SelectCommand.Parameters.AddWithValue("@importe", pimporte);
            oda.SelectCommand.Parameters.AddWithValue("@totals", ptotals);
            oda.SelectCommand.Parameters.AddWithValue("@porcentaje_descuento", pporcentaje_descuento);
            oda.SelectCommand.Parameters.AddWithValue("@descuento", pdescuento);
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
            cmd.CommandText = "TRUNCATE TABLE TEMP_TICKET";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Insertar un registro en la tabla
        public void InsertOne()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cnn.Coneccion();
            command.CommandText = "cop_Temp_Ticket_InsertOne";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public DataTable GetAll()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Temp_Ticket_GetAll", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }

    }
}
