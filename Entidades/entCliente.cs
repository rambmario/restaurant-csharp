using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Entidades
{
    class entCliente:Conexion
    {
        private int id_cliente;
        private string nombre;
        private string apellido;
        private string telefono_movil;
        private string telefono_fijo;
        private string direccion;
        private string correo;
        private int id_condicion_iva;
        private int id_tipo_dni;
        private string numero_dni_cuit;

        Conexion cnn = new Conexion();

        public int pid_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }
        public string pnombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string papellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string ptelefono_movil
        {
            get { return telefono_movil; }
            set { telefono_movil = value; }
        }
        public string ptelefono_fijo
        {
            get { return telefono_fijo; }
            set { telefono_fijo = value; }
        }
        public string pdireccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string pcorreo
        {
            get { return correo; }
            set { correo = value; }
        }
        public int pid_condicion_iva
        {
            get { return id_condicion_iva; }
            set { id_condicion_iva = value; }
        }

        public int pid_tipo_dni
        {
            get { return id_tipo_dni; }
            set { id_tipo_dni = value; }
        }
        public string pnumero_dni_cuit
        {
            get { return numero_dni_cuit; }
            set { numero_dni_cuit = value; }
        }


        public entCliente() 
        {
            id_cliente = 0;
            nombre = "";
            apellido = "";
            telefono_fijo = "-";
            telefono_movil = "-";
            direccion = "";
            correo = "";
            id_condicion_iva = 0;
            id_tipo_dni = 0;
            numero_dni_cuit = "";
        }
        ////procedimiento de insertar
        public void Insertar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Cliente_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter outparam = cmd.Parameters.Add("@id_cliente", SqlDbType.Int);
            outparam.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@nombre", pnombre);
            cmd.Parameters.AddWithValue("@apellido", papellido);
            cmd.Parameters.AddWithValue("@telefono_movil", ptelefono_movil);
            cmd.Parameters.AddWithValue("@telefono_fijo", ptelefono_fijo);
            cmd.Parameters.AddWithValue("@direccion", pdireccion);
            cmd.Parameters.AddWithValue("@correo", pcorreo);
            cmd.Parameters.AddWithValue("@id_condicion_iva", pid_condicion_iva);
            cmd.Parameters.AddWithValue("@id_tipo_dni", pid_tipo_dni);
            cmd.Parameters.AddWithValue("@numero_dni_cuit", pnumero_dni_cuit);

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            pid_cliente = Convert.ToInt32(cmd.Parameters["@id_cliente"].Value);
            cmd.Connection.Close();
        }

        //procedimiento de Update
        public void Modificar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Cliente_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_cliente",pid_cliente);
            cmd.Parameters.AddWithValue("@nombre", pnombre);
            cmd.Parameters.AddWithValue("@apellido", papellido);
            cmd.Parameters.AddWithValue("@telefono_movil", ptelefono_movil);
            cmd.Parameters.AddWithValue("@telefono_fijo", ptelefono_fijo);
            cmd.Parameters.AddWithValue("@direccion", pdireccion);
            cmd.Parameters.AddWithValue("@correo", pcorreo);
            cmd.Parameters.AddWithValue("@id_condicion_iva", pid_condicion_iva);
            cmd.Parameters.AddWithValue("@id_tipo_dni", pid_tipo_dni);
            cmd.Parameters.AddWithValue("@numero_dni_cuit", pnumero_dni_cuit);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //procedimiento de BORRADO
        public void Borrar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Cliente_Delete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_cliente", pid_cliente);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DataTable Buscar(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Cliente_Find", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
            oda.Fill(odt);

            return odt;
        }


        //funcion para llenar el combo
        public DataTable GetCmb()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Cliente_GetCmb", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.Fill(odt);

            return odt;
        }

        //funcion que trae un registro poniendo su ID
        public void GetOne(int id_cliente)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Cliente_GetOne", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_cliente", id_cliente);

            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            pnombre = Convert.ToString(odr["nombre"]);
            papellido = Convert.ToString(odr["apellido"]);
            ptelefono_fijo = Convert.ToString(odr["telefono_fijo"]);
            ptelefono_movil = Convert.ToString(odr["telefono_movil"]);
            pdireccion = Convert.ToString(odr["direccion"]);
            pcorreo = Convert.ToString(odr["correo"]);
            pid_condicion_iva = Convert.ToInt32(odr["id_condicion_iva"]);
            pid_tipo_dni= Convert.ToInt32(odr["id_tipo_dni"]);
            pnumero_dni_cuit= Convert.ToString(odr["numero_dni_cuit"]);


        }

        //controla si existe el registro en la BD

        public bool Exist()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Cliente_Exist", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", pnombre);
            oda.SelectCommand.Parameters.AddWithValue("@apellido", papellido);
            oda.SelectCommand.Parameters.AddWithValue("@telefono_movil", ptelefono_movil);
            oda.SelectCommand.Parameters.AddWithValue("@telefono_fijo", ptelefono_fijo);
            oda.SelectCommand.Parameters.AddWithValue("@direccion", pdireccion);
            oda.SelectCommand.Parameters.AddWithValue("@correo", pcorreo);
            oda.SelectCommand.Parameters.AddWithValue("@id_condicion_iva", pid_condicion_iva);
            oda.SelectCommand.Parameters.AddWithValue("@id_tipo_dni", pid_tipo_dni);
            oda.SelectCommand.Parameters.AddWithValue("@numero_dni_cuit", pnumero_dni_cuit);

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
            cmd.CommandText = "TRUNCATE TABLE CLIENTE";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Insertar un registro en la tabla
        public void InsertOne()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = cnn.Coneccion();
            command.CommandText = "cop_Cliente_InsertOne";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public DataTable GetAll()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Cliente_GetAll", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }
    }
}
