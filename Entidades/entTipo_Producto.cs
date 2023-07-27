﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_gastronomica.Entidades
{
    class entTipo_Producto:Conexion
    {
        private int id_tipo_producto;
        private int id_grupo_producto;
        private string nombre_tipo_producto;
        private string icono;
        private Conexion cnn = new Conexion();

        public int pid_tipo_producto
        {
            get { return id_tipo_producto; }
            set { id_tipo_producto = value; }
        }
        public int pid_grupo_producto
        {
            get { return id_grupo_producto; }
            set { id_grupo_producto = value; }
        }
        public string pnombre_tipo_producto
        {
            get { return nombre_tipo_producto; }
            set { nombre_tipo_producto = value; }
        }
        public string picono
        {
            get { return icono; }
            set { icono = value; }
        }

        public entTipo_Producto()
        {
            id_tipo_producto = 0;
            nombre_tipo_producto = "";
            icono = "";
        }

        public void Insertar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Tipo_Producto_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter outparam = cmd.Parameters.Add("@id_tipo_producto", SqlDbType.Int);
            outparam.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@nombre_tipo_producto", pnombre_tipo_producto);
            cmd.Parameters.AddWithValue("@id_grupo_producto", pid_grupo_producto);
            cmd.Parameters.AddWithValue("@icono", picono);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            pid_tipo_producto = Convert.ToInt32(cmd.Parameters["@id_tipo_producto"].Value);
            cmd.Connection.Close();
        }

        //procedimiento de Update
        public void Modificar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Tipo_Producto_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_tipo_producto", pid_tipo_producto);
            cmd.Parameters.AddWithValue("@id_grupo_producto", pid_grupo_producto);
            cmd.Parameters.AddWithValue("@nombre_tipo_producto", pnombre_tipo_producto);
            cmd.Parameters.AddWithValue("@icono", picono);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //procedimiento de BORRADO
        public void Borrar()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn.Coneccion();
            cmd.CommandText = "cop_Tipo_Producto_Delete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_tipo_producto", pid_tipo_producto);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DataTable Buscar(string Nombre)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Tipo_Producto_Find", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@nombre", Nombre);
            oda.Fill(odt);

            return odt;
        }


        //funcion para llenar el combo
        public DataTable GetCmb()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Tipo_Producto_GetCmb", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.Fill(odt);

            return odt;
        }

        //funcion que trae un registro poniendo su ID
        public void GetOne(int id_tipo_producto)
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Tipo_Producto_GetOne", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_tipo_producto", id_tipo_producto);

            oda.Fill(odt);
            DataRow odr;
            odr = odt.Rows[0];

            pid_grupo_producto = Convert.ToInt32(odr["id grupo producto"]);
            pnombre_tipo_producto = Convert.ToString(odr["nombre tipo producto"]);
            picono = Convert.ToString(odr["icono"]);

        }

        //controla si existe el registro en la BD

        public bool Exist()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Tipo_Producto_Exist", cnn.Coneccion());
            int Total = 0;

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.AddWithValue("@id_grupo_producto", pid_grupo_producto);
            oda.SelectCommand.Parameters.AddWithValue("@nombre_tipo_producto", pnombre_tipo_producto);
            oda.SelectCommand.Parameters.AddWithValue("@icono",picono);

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
            command.CommandText = "cop_Tipo_Producto_InsertOne";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public DataTable GetAll()
        {
            DataTable odt = new DataTable();
            SqlDataAdapter oda = new SqlDataAdapter("cop_Tipo_Producto_GetAll", cnn.Coneccion());

            oda.SelectCommand.CommandType = CommandType.StoredProcedure;

            oda.Fill(odt);
            return odt;
        }

    }
}
