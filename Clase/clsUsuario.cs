using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Clase
{
    class clsUsuario:Entidades.entUsuario
    {
        Conexion cnn = new Conexion();

        //metodos para mostrar todo los usuario remplazando las ID por los nombres correspondiente
        public DataTable GetAll_2()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Usuario_GetAll_2", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }

        public DataTable Buscar_2(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Usuario_Find_2", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
            oda.Fill(odt);

            return odt;
        }

        public bool Logon()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Usuario_logon", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre_usuario", pnombre_usuario);
            oda.SelectCommand.Parameters.AddWithValue("@password_usuario", ppassword_usuario);

            oda.Fill(odt);

            Total = Convert.ToInt32(odt.Rows[0]["Total"].ToString());

            if (Total == 0)
            {
                return false;
                //NO EXISTE
            }
            else { return true; } //SI EXISTE
        }
        public int LogonID()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Usuario_logonID", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre_usuario", pnombre_usuario);
            oda.SelectCommand.Parameters.AddWithValue("@password_usuario", ppassword_usuario);

            oda.Fill(odt);

            Total = Convert.ToInt32(odt.Rows[0]["Total"].ToString());
            return Total;
        }
        public bool PasswordMaster()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Usuario_PaswwordMaster", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@password_usuario", ppassword_usuario);

            oda.Fill(odt);

            Total = Convert.ToInt32(odt.Rows[0]["Total"].ToString());

            if (Total == 0)
            {
                return false;
                //NO EXISTE
            }
            else { return true; } //SI EXISTE
        }
    }
}
