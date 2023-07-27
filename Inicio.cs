using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;

namespace Gestion_gastronomica
{
    public static class Inicio
    {
        //definicion de variables multiformulario
        //Entidad Mesas
        public static int BanderaMesa = 0;
        public static int id_mesa = 0; //referencia al id_mesa de latabla Mesa

        //Entidad Usuario
        public static int BanderaUsuario = 0;
        public static int id_usuario = 0; //referencia al id_usuario de la tabla usuario
        
        //Entidad Grupo_Usuario
        public static int BanderaGrupo_Usuario = 0;
        public static int id_grupo_usuario = 0; //referencia al id_grupo_usuario de la tabla grupo_usuario

        //Entidad Tipo_Producto
        public static int BanderaTipo_Producto = 0;
        public static int id_tipo_producto = 0;

        //Entidad Producto
        public static int BanderaProducto = 0;
        public static int id_Producto = 0;

        //Entidades Opcion_Modificacion
        public static int BanderaOpcion_modificacion = 0;
        public static int id_Opcion_Modificacion = 0;

        //Entidades Opcion_Modificacion_Producto
        public static int BanderaOpcion_modificacion_producto = 0;
        public static int id_Opcion_Modificacion_producto = 0;

        //Entidades Pedido
        public static int BanderaPedido = 0;
        public static int id_pedido = 0;

        //Entidades Cuerpo_Pedido
        public static int BanderaCuerpo_Pedido = 0;
        public static int id_cuerpo_pedido = 0;

        //Entidades Grupo_Producto
        public static int BanderaGrupo_Producto = 0;
        public static int id_grupo_Producto = 0;

        //Entidades Forma_Pago
        public static int BanderaForma_Pago = 0;
        public static int id_forma_pago = 0;

        //Entidades Tipo_Forma_Pago
        public static int BanderaTipo_Forma_Pago = 0;
        public static int id_tipo_forma_pago = 0;

        //Entidades Tipo_dni
        public static int BanderaTipo_dni = 0;
        public static int id_Tipo_dni = 0;

        //Entidades Pago_Pedido
        public static int BanderaPago_Pedio = 0;
        public static int id_pago_pedido = 0;

        //Entidades Temp_Pedido
        public static int BanderaTemp_Pedido = 0;
        public static int id_temp_pedido = 0;

        //Entidades Cliente
        public static int Bandera_Cliente = 0;
        public static int id_cliente = 0;
        public static int Bandera_id_cliente = 0;
        public static string Bandera_nombre_cliente = "";
        
        //Entidades Reserva_Hora
        public static int Bandera_Reserva_hora = 0;
        public static int id_reserva_hora = 0;

        //Entidades Reserva_Mesa
        public static int Bandera_Reserva_Mesa = 0;
        public static int id_Reserva_Mesa = 0;

        //Entidades Banco
        public static int Bandera_Banco = 0;
        public static int id_banco = 0;

        //Entidades Condicion_iva
        public static int Bandera_Condicion_Iva = 0;
        public static int id_condicion_iva = 0;

        //Entidades Caja
        public static int Bandera_Caja = 0;
        public static int id_caja = 0;

        //parametros
        public static int parametro_Salir = 0;
        public static int parametro_Boton_Click_Reserva = 1;
        public static int parametro_PasswordMaster = 0;
        public static int parametro_id_usuario_inicio = 0;
        public static int parametro_id_caja = 0;

        public static string vgPuertoFiscal = "COM1";
        //Metodos Utilies

        //completar ceros 4 y 8, se utiliza en metodo Numero. para completa numeros faltantes
        public static string CompletarCeros(string strCadena, int intLargo)
        {


            if (intLargo == 4)
            {
                switch (strCadena.Length)
                {

                    case 0:
                        strCadena = "0000" + strCadena;

                        break;
                    case 1:
                        strCadena = "000" + strCadena;

                        break;
                    case 2:
                        strCadena = "00" + strCadena;

                        break;
                    case 3:
                        strCadena = "0" + strCadena;

                        break;
                }

            }


            if (intLargo == 8)
            {
                switch (strCadena.Length)
                {

                    case 0:
                        strCadena = "00000000" + strCadena;

                        break;
                    case 1:
                        strCadena = "0000000" + strCadena;

                        break;
                    case 2:
                        strCadena = "000000" + strCadena;

                        break;
                    case 3:
                        strCadena = "00000" + strCadena;

                        break;
                    case 4:
                        strCadena = "0000" + strCadena;

                        break;
                    case 5:
                        strCadena = "000" + strCadena;

                        break;
                    case 6:
                        strCadena = "00" + strCadena;

                        break;
                    case 7:
                        strCadena = "0" + strCadena;

                        break;
                }

            }

            return strCadena;

        }
        //Imprimir Crystal Report

        
        public static void printCrystalReport(ReportDocument aoReport, int aiNumCopias, int aiPageBegin, int aiPageEnd, string nom_reporte)
        {
            String asPrinterName;

            System.Data.DataTable  odt;
            Clase.clsCuerpo_Pedido oCuerpo_pedido = new Clase.clsCuerpo_Pedido();
            Clase.clsTemp_Pedido oTemp_pedido = new Clase.clsTemp_Pedido();
           // Clase.clsCuerpo_Pedido oCuerpo_pedido = new Clase.clsCuerpo_Pedido();

            switch(nom_reporte)
            {
                case "rptCierrePedido":
                    odt = oCuerpo_pedido.GetReporte(Inicio.id_pedido);
                    aoReport.SetDataSource(odt);

                    aoReport.SetParameterValue("@id_pedido", Inicio.id_pedido);
                    break;
                case "rptImprimir_Pedido":
                    odt = oTemp_pedido.GetPrint(Inicio.id_pedido);
                    aoReport.SetDataSource(odt);

                    aoReport.SetParameterValue("@id_pedido", Inicio.id_pedido);
                    break;
                case "rptRe_Imprimir_Pedido":
                    odt = oCuerpo_pedido.GetAllPrintticket(Inicio.id_pedido);
                    aoReport.SetDataSource(odt);

                    aoReport.SetParameterValue("@id_pedido", Inicio.id_pedido);
                    break;
            }
            


            //Buscamos la impresora por defecto del sistema
            System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
            asPrinterName = printDoc.PrinterSettings.PrinterName;

            aoReport.PrintOptions.PrinterName = asPrinterName;
            //Si se quiere imprimir todo el documento, aiPageBegin y aiPageEnd a cero
            aoReport.PrintToPrinter(aiNumCopias, false, aiPageBegin, aiPageEnd);

        }

    }
}
