using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Gestion_gastronomica
{
    class Conexion
    {
        //public SqlCommand cmd = new SqlCommand();
        
        public SqlConnection Coneccion()
        {
            SqlConnection  ocnn  = new SqlConnection();

            string strServer = "";
            string strDB = "";
            string strPass = "";
            string strUser = "";

            strServer = ".\\SQLEXPRESS19";
            strDB = "Gestion_gastronomica";
            //strPass = "sa";
            //strUser = "ingesoft06";

            ocnn.ConnectionString = @"Data Source=" + strServer + ";Initial Catalog=Gestion_gastronomica;Integrated Security=True";
            //ocnn.ConnectionString = "@Server=" + strServer + ";" +
            //                        "DataBase=" + strDB + ";" + 
            //                        "User ID=" + strUser + ";" + 
            //                        "Password=" + strPass + ";" + 
            //                        "Trusted_Connection=false";
            //ocnn.ConnectionString = Properties.Settings.Default.Conexion;
            return ocnn;
        }
     
    
    
    
    }



}
