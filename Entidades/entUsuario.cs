using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Entidades
{
    class entUsuario:Conexion
    {
        private int id_usuario;
        private string nombre_usuario;
        private string password_usuario;
        private int id_grupo_usuario;
        private string mail;
        Conexion cnn = new Conexion();


        public int pid_usuario 
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        public string pnombre_usuario
        {
            get { return nombre_usuario; }
            set { nombre_usuario = value; }
        }
        public string ppassword_usuario
        {
            get { return password_usuario; }
            set { password_usuario = value; }
        }
        public int pid_grupo_usuario
        {
            get { return id_grupo_usuario; }
            set { id_grupo_usuario = value; }
        }
        public string pmail
        {
            get { return mail; }
            set { mail = value; }
        }
        public entUsuario() 
        {
            id_usuario = 0;
            id_grupo_usuario = 0;
            mail = "";
            password_usuario = "";
            nombre_usuario = "";
        }

        ////procedimiento de insertar
        public void Insertar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Usuario_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter outparam = cmd.Parameters.Add("@id_usuario", SqlDbType.Int);
            outparam.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@nombre_usuario", pnombre_usuario);
            cmd.Parameters.AddWithValue("@password_usuario", ppassword_usuario);
            cmd.Parameters.AddWithValue("@id_grupo_usuario", pid_grupo_usuario);
            cmd.Parameters.AddWithValue("@mail",mail);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            pid_usuario = Convert.ToInt32(cmd.Parameters["@id_usuario"].Value);
            cmd.Connection.Close();
        }

        //procedimiento de Update
        public void Modificar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Usuario_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_usuario", pid_usuario);
            cmd.Parameters.AddWithValue("@nombre_usuario", pnombre_usuario);
            cmd.Parameters.AddWithValue("@password_usuario",ppassword_usuario);
            cmd.Parameters.AddWithValue("@id_grupo_usuario", pid_grupo_usuario);
            cmd.Parameters.AddWithValue("@mail", pmail);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //procedimiento de BORRADO
        public void Borrar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Usuario_Delete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_usuario", pid_usuario);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DataTable Buscar(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Usuario_Find", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
            oda.Fill(odt);

            return odt;
        }


        //funcion para llenar el combo
        public DataTable GetCmb()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Usuario_GetCmb", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.Fill(odt);

            return odt;
        }

        //funcion que trae un registro poniendo su ID
        public void GetOne(int id_usuario)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Usuario_GetOne", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_usuario", id_usuario);

            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            pnombre_usuario = Convert.ToString(odr["Nombre usuario"]);
            ppassword_usuario = Convert.ToString(odr["password usuario"]);
            pid_grupo_usuario = Convert.ToInt32(odr["id_grupo_usuario"]);
            pmail = Convert.ToString(odr["mail"]);

            // return odt;
        }

        //controla si existe el registro en la BD

        public bool Exist()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Usuario_Exist", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre_usuario", pnombre_usuario);
            oda.SelectCommand.Parameters.AddWithValue("@password_usuario", ppassword_usuario);
            oda.SelectCommand.Parameters.AddWithValue("@mail", pmail);
            oda.SelectCommand.Parameters.AddWithValue("@id_grupo_usuario", pid_grupo_usuario);

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
            command.Connection = cnn.Coneccion();
            command.CommandText = "cop_Usuario_InsertOne";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public DataTable GetAll()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Usuario_GetAll", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }
    }//end inicio
}
