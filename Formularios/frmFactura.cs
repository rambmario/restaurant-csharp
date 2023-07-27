using FiscalNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Gestion_gastronomica.Formularios
{
    public partial class frmFactura : Form
    {
        public frmFactura()
         {
            InitializeComponent();
        }

            Clase.clsCliente oCliente = new Clase.clsCliente();
            Clase.clsFactura oFactura = new Clase.clsFactura();

        Int32 milliseconds = 2000;

        private void frmFactura_Load(object sender, EventArgs e)
        {
            lblid_cliente.Text = "1";
            txtNombre_cliente.Text = "Consumidor Final";



            oFactura.Truncate();
            txtArticulo.Focus();
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            frmAbmCliente frmTemp = new Formularios.frmAbmCliente();
            Inicio.Bandera_id_cliente = 0;
            frmTemp.ShowDialog();

            if (Inicio.Bandera_id_cliente == 0)
            {
                this.lblid_cliente.Text = "1";
                this.txtNombre_cliente.Text = "Consumidor Final";
            }
            else
            {
                this.lblid_cliente.Text = Convert.ToString(Inicio.Bandera_id_cliente);
                this.txtNombre_cliente.Text = Inicio.Bandera_nombre_cliente;
            }

            DataTable odtCli = new DataTable();
            odtCli = oCliente.GetOne_2(Convert.ToInt32(lblid_cliente.Text));

            lblid_condicion_iva.Text = odtCli.Rows[0]["id_condicion_iva"].ToString();

        }

        private void ImpresionFiscalTicketC()
        {
            DriverFiscal IFiscal = new DriverFiscal();

            long nError;
            nError = 0;

            IFiscal.SerialNumber = "27-0163848-435";

            string nDoc = "";
            string strCondicionIva = "";
            int intCondicionIva = 0;
            string strTipoDni = "";
            int intTipoDni = 0;
            string strNombre = "";
            string strCuit = "";
            string strDireccion = "";
            decimal decPrecio = 0;
            decimal decAlicuota = 0;
            decimal decTotal = 0;

            string descuento = "";
            string porcentaje_descuento = "";
            string recargo = "";
            string porcentaje_recargo = "";

            DataTable odtCliente = new DataTable();

            odtCliente = oCliente.GetOne_2(1);

            if (odtCliente.Rows.Count > 0)
            {
                DataRow rowCliente = odtCliente.Rows[0];
                intCondicionIva = Convert.ToInt32(rowCliente["id_condicion_iva"]);

                strCuit = Convert.ToString(rowCliente["numero_dni_cuit"]);
                intTipoDni = Convert.ToInt32(rowCliente["id_tipo_dni"]);
                strNombre = Convert.ToString(rowCliente["nombre_cliente"]);
                strDireccion = Convert.ToString(rowCliente["direccion"]);

                ////opedido.GetOne(Convert.ToInt32(txtPedido.Text));
                descuento = "0";
                porcentaje_descuento =  "0";

                switch (intCondicionIva)
                {
                    case 1:
                        //'F = CONSUMIDOR FINAL
                        strCondicionIva = "F";
                        break;
                    case 2:
                        //'E = EXENTO
                        strCondicionIva = "E";
                        break;
                    case 3:
                        //'N = NO RESPONSABLE
                        strCondicionIva = "N";
                        break;
                    case 4:
                        //'I = IVA RESPONSABLE INSCRIPTO
                        strCondicionIva = "I";
                        break;
                    case 5:
                        //'M = RESPONSABLE MONOTRIBUTO
                        strCondicionIva = "M";
                        break;
                }

                switch (intTipoDni)
                {
                    //1	DNI
                    case 1:
                        strTipoDni = "DNI";
                        break;
                    //2	CUIL
                    case 2:
                        strTipoDni = "CUIL";
                        break;
                    //3	CUIT
                    case 3:
                        strTipoDni = "CUIT";
                        break;
                    //4	Libreta de Enrolamiento
                    case 4:
                        strTipoDni = "NDOC";
                        break;
                    //5	Libreta Civica
                    case 5:
                        strTipoDni = "NDOC";
                        break;
                    //6	Pasaporte
                    case 6:
                        strTipoDni = "NDOC";
                        break;
                    //7	Cedula
                    case 7:
                        strTipoDni = "NDOC";
                        break;
                }

                nError = IFiscal.IF_OPEN(Inicio.vgPuertoFiscal, 9600);
                Thread.Sleep(milliseconds);
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@TIQUECANCEL");
                }

                nError = IFiscal.IF_WRITE("@TIQUEABRE|C|");
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@TIQUECANCEL");
                }

                DataTable odtCuerpo = new DataTable();
                odtCuerpo = oFactura.GetAll_Ticket();
                decTotal = 0;

                //imprimo cuerpos
                foreach (DataRow row in odtCuerpo.Rows)
                {
                    string strCantidad = "";
                    string strProducto = "";
                    string strPrecio = "";
                    string strAlicuota = "";
                    int largo = 0;

                    strProducto = Convert.ToString(row["articulo"]);
                    largo = strProducto.Length;
                    if (largo > 20)
                    {
                        strProducto = strProducto.Substring(0, 20);
                    }
                    decTotal = decTotal + (Convert.ToInt32(row["cantidad"])*Convert.ToDecimal(row["Precio"]));

                    decPrecio = Convert.ToDecimal(row["precio"]);
                    strPrecio = Convert.ToString(decPrecio);
                    strPrecio = strPrecio.Replace(",", ".");
                    strAlicuota = strAlicuota.Replace(",", ".");
                    strCantidad = Convert.ToString(row["cantidad"]);
                    strCantidad = strCantidad.Replace(",", ".");

                    nError = IFiscal.IF_WRITE("@TIQUEITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0|0");
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@TIQUECANCEL");
                }

                //si hay descuento imprimo
                if (descuento != "")
                {
                    if (Convert.ToDecimal(descuento) > 0)
                    {
                        nError = IFiscal.IF_WRITE("@TIQUEPAGO|DESCUENTO % " + porcentaje_descuento + "|" + descuento.Replace(",", ".") + "|D");
                    }
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@TIQUECANCEL");
                }

                //imprimo total
                nError = IFiscal.IF_WRITE("@TIQUESUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@TIQUECANCEL");
                }

                string strImporte = "";
                bool bandContado = false;
                bool bandTarjeta = false;
                bool bandCC = false;
                bool bandCheque = false;
                bool bandTicket = false;

                //DataTable odtPago = new DataTable();
                //odtPago = oPago_Pedido.GetAllVenta(Convert.ToInt32(txtPedido.Text));

                ////imprimo los pagos
                //foreach (DataRow rowPago in odtPago.Rows)
                //{
                //    switch (Convert.ToString(rowPago["Tipo"]))
                //    {
                //        case "Contado":

                            strImporte = txtPago.Text;
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandContado == false)
                            {
                                bandContado = true;
                                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO CONTADO|" + strImporte + "|T|");
                            }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@TIQUECANCEL");
                }


                //            break;
                //        case "Tarjeta":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandTarjeta == false)
                //            {
                //                bandTarjeta = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TARJETA|" + strImporte + "|T|");
                //            }

                //            break;
                //        case "Cuenta Corriente":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandCC == false)
                //            {
                //                bandCC = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CUENTA CORRIENTE|" + strImporte + "|T|");
                //            }

                //            break;

                //        case "Cheque":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandCheque == false)
                //            {
                //                bandCheque = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CHEQUE|" + strImporte + "|T|");
                //            }

                //            break;

                //        case "Ticket":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandTicket == false)
                //            {
                //                bandTicket = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TICKET|" + strImporte + "|T|");
                //            }

                //            break;
                //    }
                //}
                nError = IFiscal.IF_WRITE("@TIQUECIERRA|T");
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@TIQUECANCEL");
                }

                nError = IFiscal.IF_CLOSE();
                IFiscal = null;


            }

        }

        private void ImpresionFiscalTicketB()
        {
            DriverFiscal IFiscal = new DriverFiscal();

            long nError;
            nError = 0;

            IFiscal.SerialNumber = "27-0163848-435";

            string nDoc = "";
            string strCondicionIva = "";
            int intCondicionIva = 0;
            string strTipoDni = "";
            int intTipoDni = 0;
            string strNombre = "";
            string strCuit = "";
            string strDireccion = "";
            decimal decPrecio = 0;
            decimal decAlicuota = 0;
            decimal decTotal = 0;

            string descuento = "";
            string porcentaje_descuento = "";
            string recargo = "";
            string porcentaje_recargo = "";

            DataTable odtCliente = new DataTable();

            odtCliente = oCliente.GetOne_2(Convert.ToInt32(lblid_cliente.Text));

            if (odtCliente.Rows.Count > 0)
            {
                DataRow rowCliente = odtCliente.Rows[0];
                intCondicionIva = Convert.ToInt32(rowCliente["id_condicion_iva"]);

                strCuit = Convert.ToString(rowCliente["numero_dni_cuit"]);
                intTipoDni = Convert.ToInt32(rowCliente["id_tipo_dni"]);
                strNombre = Convert.ToString(rowCliente["nombre_cliente"]);
                strDireccion = Convert.ToString(rowCliente["direccion"]);

                ////opedido.GetOne(Convert.ToInt32(txtPedido.Text));
                descuento = "0";
                porcentaje_descuento = "0";

                switch (intCondicionIva)
                {
                    case 1:
                        //'F = CONSUMIDOR FINAL
                        strCondicionIva = "F";
                        break;
                    case 2:
                        //'E = EXENTO
                        strCondicionIva = "E";
                        break;
                    case 3:
                        //'N = NO RESPONSABLE
                        strCondicionIva = "N";
                        break;
                    case 4:
                        //'I = IVA RESPONSABLE INSCRIPTO
                        strCondicionIva = "I";
                        break;
                    case 5:
                        //'M = RESPONSABLE MONOTRIBUTO
                        strCondicionIva = "M";
                        break;
                }

                switch (intTipoDni)
                {
                    //1	DNI
                    case 1:
                        strTipoDni = "DNI";
                        break;
                    //2	CUIL
                    case 2:
                        strTipoDni = "CUIL";
                        break;
                    //3	CUIT
                    case 3:
                        strTipoDni = "CUIT";
                        break;
                    //4	Libreta de Enrolamiento
                    case 4:
                        strTipoDni = "NDOC";
                        break;
                    //5	Libreta Civica
                    case 5:
                        strTipoDni = "NDOC";
                        break;
                    //6	Pasaporte
                    case 6:
                        strTipoDni = "NDOC";
                        break;
                    //7	Cedula
                    case 7:
                        strTipoDni = "NDOC";
                        break;
                }

                nError = IFiscal.IF_OPEN(Inicio.vgPuertoFiscal, 9600);
                Thread.Sleep(milliseconds);
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                nError = IFiscal.IF_WRITE("@FACTABRE|T|C|B|1|P|10|I|" + strCondicionIva + "|" + strNombre + "||" + strTipoDni + "|" + strCuit + "|N|" + strDireccion + "|||" + "-" + "||C");
                //                nError = IFiscal.IF_WRITE("@TIQUEABRE|B|");
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                DataTable odtCuerpo = new DataTable();
                odtCuerpo = oFactura.GetAll_Ticket();
                decTotal = 0;

                //imprimo cuerpos
                foreach (DataRow row in odtCuerpo.Rows)
                {
                    string strCantidad = "";
                    string strProducto = "";
                    string strPrecio = "";
                    string strAlicuota = "";
                    int largo = 0;

                    strProducto = Convert.ToString(row["articulo"]);
                    largo = strProducto.Length;
                    if (largo > 20)
                    {
                        strProducto = strProducto.Substring(0, 20);
                    }
                    decTotal = decTotal + (Convert.ToInt32(row["cantidad"]) * Convert.ToDecimal(row["Precio"]));

                    decPrecio = Convert.ToDecimal(row["precio"]);
                    strPrecio = Convert.ToString(decPrecio);
                    strPrecio = strPrecio.Replace(",", ".");
                    strAlicuota = strAlicuota.Replace(",", ".");
                    strCantidad = Convert.ToString(row["cantidad"]);
                    strCantidad = strCantidad.Replace(",", ".");

                    nError = IFiscal.IF_WRITE("@FACTITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0||||0|0");
                   //nError = IFiscal.IF_WRITE("@TIQUEITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0|0");
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //si hay descuento imprimo
                if (descuento != "")
                {
                    if (Convert.ToDecimal(descuento) > 0)
                    {
                        nError = IFiscal.IF_WRITE("@FACTPAGO|DESCUENTO % " + porcentaje_descuento + "|" + descuento.Replace(",", ".") + "|D");
                        //nError = IFiscal.IF_WRITE("@TIQUEPAGO|DESCUENTO % " + porcentaje_descuento + "|" + descuento.Replace(",", ".") + "|D");
                    }
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //imprimo total
                nError = IFiscal.IF_WRITE("@FACTSUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
                //nError = IFiscal.IF_WRITE("@TIQUESUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                string strImporte = "";
                bool bandContado = false;
                bool bandTarjeta = false;
                bool bandCC = false;
                bool bandCheque = false;
                bool bandTicket = false;

                //DataTable odtPago = new DataTable();
                //odtPago = oPago_Pedido.GetAllVenta(Convert.ToInt32(txtPedido.Text));

                ////imprimo los pagos
                //foreach (DataRow rowPago in odtPago.Rows)
                //{
                //    switch (Convert.ToString(rowPago["Tipo"]))
                //    {
                //        case "Contado":

                strImporte = txtPago.Text;
                strImporte = strImporte.Replace(",", ".");
                if (Convert.ToDecimal(strImporte) != 0 & bandContado == false)
                {
                    bandContado = true;
                    nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO CONTADO|" + strImporte + "|T|");
                    //nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO CONTADO|" + strImporte + "|T|");
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //            break;
                //        case "Tarjeta":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandTarjeta == false)
                //            {
                //                bandTarjeta = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TARJETA|" + strImporte + "|T|");
                //            }

                //            break;
                //        case "Cuenta Corriente":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandCC == false)
                //            {
                //                bandCC = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CUENTA CORRIENTE|" + strImporte + "|T|");
                //            }

                //            break;

                //        case "Cheque":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandCheque == false)
                //            {
                //                bandCheque = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CHEQUE|" + strImporte + "|T|");
                //            }

                //            break;

                //        case "Ticket":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandTicket == false)
                //            {
                //                bandTicket = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TICKET|" + strImporte + "|T|");
                //            }

                //            break;
                //    }
                //}

                nError = IFiscal.IF_WRITE("@FACTCIERRA|T|B|FINAL");
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //nError = IFiscal.IF_WRITE("@TIQUECIERRA|T");
                nError = IFiscal.IF_CLOSE();
                IFiscal = null;


            }

        }

        private void ImpresionFiscalTicketA()
        {
            DriverFiscal IFiscal = new DriverFiscal();

            long nError;
            nError = 0;

            IFiscal.SerialNumber = "27-0163848-435";

            string nDoc = "";
            string strCondicionIva = "";
            int intCondicionIva = 0;
            string strTipoDni = "";
            int intTipoDni = 0;
            string strNombre = "";
            string strCuit = "";
            string strDireccion = "";
            decimal decPrecio = 0;
            decimal decAlicuota = 0;
            decimal decTotal = 0;

            string descuento = "";
            string porcentaje_descuento = "";
            string recargo = "";
            string porcentaje_recargo = "";

            DataTable odtCliente = new DataTable();

            odtCliente = oCliente.GetOne_2(Convert.ToInt32(lblid_cliente.Text));

            if (odtCliente.Rows.Count > 0)
            {
                DataRow rowCliente = odtCliente.Rows[0];
                intCondicionIva = Convert.ToInt32(rowCliente["id_condicion_iva"]);

                strCuit = Convert.ToString(rowCliente["numero_dni_cuit"]);
                intTipoDni = Convert.ToInt32(rowCliente["id_tipo_dni"]);
                strNombre = Convert.ToString(rowCliente["nombre_cliente"]);
                strDireccion = Convert.ToString(rowCliente["direccion"]);

                ////opedido.GetOne(Convert.ToInt32(txtPedido.Text));
                descuento = "0";
                porcentaje_descuento = "0";

                switch (intCondicionIva)
                {
                    case 1:
                        //'F = CONSUMIDOR FINAL
                        strCondicionIva = "F";
                        break;
                    case 2:
                        //'E = EXENTO
                        strCondicionIva = "E";
                        break;
                    case 3:
                        //'N = NO RESPONSABLE
                        strCondicionIva = "N";
                        break;
                    case 4:
                        //'I = IVA RESPONSABLE INSCRIPTO
                        strCondicionIva = "I";
                        break;
                    case 5:
                        //'M = RESPONSABLE MONOTRIBUTO
                        strCondicionIva = "M";
                        break;
                }

                switch (intTipoDni)
                {
                    //1	DNI
                    case 1:
                        strTipoDni = "DNI";
                        break;
                    //2	CUIL
                    case 2:
                        strTipoDni = "CUIL";
                        break;
                    //3	CUIT
                    case 3:
                        strTipoDni = "CUIT";
                        break;
                    //4	Libreta de Enrolamiento
                    case 4:
                        strTipoDni = "NDOC";
                        break;
                    //5	Libreta Civica
                    case 5:
                        strTipoDni = "NDOC";
                        break;
                    //6	Pasaporte
                    case 6:
                        strTipoDni = "NDOC";
                        break;
                    //7	Cedula
                    case 7:
                        strTipoDni = "NDOC";
                        break;
                }

                nError = IFiscal.IF_OPEN(Inicio.vgPuertoFiscal, 9600);
                Thread.Sleep(milliseconds);
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                nError = IFiscal.IF_WRITE("@FACTABRE|T|C|A|1|P|10|I|" + strCondicionIva + "|" + strNombre + "||" + strTipoDni + "|" + strCuit + "|N|" + strDireccion + "|||" + "-" + "||C");
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                // nError = IFiscal.IF_WRITE("@FACTABRE|T|C|B|1|P|10|I|" + strCondicionIva + "|" + strNombre + "||" + strTipoDni + "|" + strCuit + "|N|" + strDireccion + "|||" + "-" + "||C");
                //                nError = IFiscal.IF_WRITE("@TIQUEABRE|B|");

                DataTable odtCuerpo = new DataTable();
                odtCuerpo = oFactura.GetAll_Ticket();
                decTotal = 0;

                //imprimo cuerpos
                foreach (DataRow row in odtCuerpo.Rows)
                {
                    string strCantidad = "";
                    string strProducto = "";
                    string strPrecio = "";
                    string strAlicuota = "";
                    int largo = 0;

                    strProducto = Convert.ToString(row["articulo"]);
                    largo = strProducto.Length;
                    if (largo > 20)
                    {
                        strProducto = strProducto.Substring(0, 20);
                    }
                    decTotal = decTotal + (Convert.ToInt32(row["cantidad"]) * Convert.ToDecimal(row["Precio"]));

                    // alicuota del 21%
                    decAlicuota = Convert.ToDecimal(0.21);
                    strAlicuota = Convert.ToString(decAlicuota);

                    decPrecio = Convert.ToDecimal(row["precio"]);
                    strPrecio = Convert.ToString(decPrecio / (1 + decAlicuota));
                    strPrecio = strPrecio.Replace(",", ".");
                    strAlicuota = strAlicuota.Replace(",", ".");
                    strCantidad = Convert.ToString(row["cantidad"]);
                    strCantidad = strCantidad.Replace(",", ".");

                    nError = IFiscal.IF_WRITE("@FACTITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|" + strAlicuota + "|M|1|0||||0|0");

                    //nError = IFiscal.IF_WRITE("@FACTITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0||||0|0");
                    //nError = IFiscal.IF_WRITE("@TIQUEITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0|0");
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //si hay descuento imprimo
                if (descuento != "")
                {
                    if (Convert.ToDecimal(descuento) > 0)
                    {
                        nError = IFiscal.IF_WRITE("@FACTPAGO|DESCUENTO % " + porcentaje_descuento + "|" + descuento.Replace(",", ".") + "|D");

                        //nError = IFiscal.IF_WRITE("@FACTPAGO|DESCUENTO % " + porcentaje_descuento + "|" + descuento.Replace(",", ".") + "|D");
                        //nError = IFiscal.IF_WRITE("@TIQUEPAGO|DESCUENTO % " + porcentaje_descuento + "|" + descuento.Replace(",", ".") + "|D");
                    }
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //imprimo total
                nError = IFiscal.IF_WRITE("@FACTSUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
                //nError = IFiscal.IF_WRITE("@FACTSUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
                //nError = IFiscal.IF_WRITE("@TIQUESUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                string strImporte = "";
                bool bandContado = false;
                bool bandTarjeta = false;
                bool bandCC = false;
                bool bandCheque = false;
                bool bandTicket = false;

                //DataTable odtPago = new DataTable();
                //odtPago = oPago_Pedido.GetAllVenta(Convert.ToInt32(txtPedido.Text));

                ////imprimo los pagos
                //foreach (DataRow rowPago in odtPago.Rows)
                //{
                //    switch (Convert.ToString(rowPago["Tipo"]))
                //    {
                //        case "Contado":

                strImporte = txtPago.Text;
                strImporte = strImporte.Replace(",", ".");
                if (Convert.ToDecimal(strImporte) != 0 & bandContado == false)
                {
                    bandContado = true;
                    nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO CONTADO|" + strImporte + "|T|");
                    //nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO CONTADO|" + strImporte + "|T|");
                    //nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO CONTADO|" + strImporte + "|T|");
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //            break;
                //        case "Tarjeta":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandTarjeta == false)
                //            {
                //                bandTarjeta = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TARJETA|" + strImporte + "|T|");
                //            }

                //            break;
                //        case "Cuenta Corriente":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandCC == false)
                //            {
                //                bandCC = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CUENTA CORRIENTE|" + strImporte + "|T|");
                //            }

                //            break;

                //        case "Cheque":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandCheque == false)
                //            {
                //                bandCheque = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CHEQUE|" + strImporte + "|T|");
                //            }

                //            break;

                //        case "Ticket":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandTicket == false)
                //            {
                //                bandTicket = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TICKET|" + strImporte + "|T|");
                //            }

                //            break;
                //    }
                //}

                nError = IFiscal.IF_WRITE("@FACTCIERRA|T|A|FINAL");
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //nError = IFiscal.IF_WRITE("@FACTCIERRA|T|B|FINAL");
                //nError = IFiscal.IF_WRITE("@TIQUECIERRA|T");
                nError = IFiscal.IF_CLOSE();
                IFiscal = null;


            }

        }

        private void ImpresionFiscalNotaCreditoB()
        {
            DriverFiscal IFiscal = new DriverFiscal();

            long nError;
            nError = 0;

            IFiscal.SerialNumber = "27-0163848-435";

            string nDoc = "";
            string strCondicionIva = "";
            int intCondicionIva = 0;
            string strTipoDni = "";
            int intTipoDni = 0;
            string strNombre = "";
            string strCuit = "";
            string strDireccion = "";
            decimal decPrecio = 0;
            decimal decAlicuota = 0;
            decimal decTotal = 0;

            string descuento = "";
            string porcentaje_descuento = "";
            string recargo = "";
            string porcentaje_recargo = "";

            string strNumero_comprobante_original = "";
            strNumero_comprobante_original = txtFacturaAsociada.Text;
            
            DataTable odtCliente = new DataTable();

            odtCliente = oCliente.GetOne_2(Convert.ToInt32(lblid_cliente.Text));

            if (odtCliente.Rows.Count > 0)
            {
                DataRow rowCliente = odtCliente.Rows[0];
                intCondicionIva = Convert.ToInt32(rowCliente["id_condicion_iva"]);

                strCuit = Convert.ToString(rowCliente["numero_dni_cuit"]);
                intTipoDni = Convert.ToInt32(rowCliente["id_tipo_dni"]);
                strNombre = Convert.ToString(rowCliente["nombre_cliente"]);
                strDireccion = Convert.ToString(rowCliente["direccion"]);

                ////opedido.GetOne(Convert.ToInt32(txtPedido.Text));
                descuento = "0";
                porcentaje_descuento = "0";

                switch (intCondicionIva)
                {
                    case 1:
                        //'F = CONSUMIDOR FINAL
                        strCondicionIva = "F";
                        break;
                    case 2:
                        //'E = EXENTO
                        strCondicionIva = "E";
                        break;
                    case 3:
                        //'N = NO RESPONSABLE
                        strCondicionIva = "N";
                        break;
                    case 4:
                        //'I = IVA RESPONSABLE INSCRIPTO
                        strCondicionIva = "I";
                        break;
                    case 5:
                        //'M = RESPONSABLE MONOTRIBUTO
                        strCondicionIva = "M";
                        break;
                }

                switch (intTipoDni)
                {
                    //1	DNI
                    case 1:
                        strTipoDni = "DNI";
                        break;
                    //2	CUIL
                    case 2:
                        strTipoDni = "CUIL";
                        break;
                    //3	CUIT
                    case 3:
                        strTipoDni = "CUIT";
                        break;
                    //4	Libreta de Enrolamiento
                    case 4:
                        strTipoDni = "NDOC";
                        break;
                    //5	Libreta Civica
                    case 5:
                        strTipoDni = "NDOC";
                        break;
                    //6	Pasaporte
                    case 6:
                        strTipoDni = "NDOC";
                        break;
                    //7	Cedula
                    case 7:
                        strTipoDni = "NDOC";
                        break;
                }

                nError = IFiscal.IF_OPEN(Inicio.vgPuertoFiscal, 9600);
                Thread.Sleep(milliseconds);
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                nError = IFiscal.IF_WRITE("@FACTABRE|M|C|B|1|P|10|I|" + strCondicionIva + "|" + strNombre + "||" + strTipoDni + "|" + strCuit + "|N|" + strDireccion + "|||" + strNumero_comprobante_original + "||C");
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //nError = IFiscal.IF_WRITE("@FACTABRE|T|C|B|1|P|10|I|" + strCondicionIva + "|" + strNombre + "||" + strTipoDni + "|" + strCuit + "|N|" + strDireccion + "|||" + "-" + "||C");
                //nError = IFiscal.IF_WRITE("@TIQUEABRE|B|");

                DataTable odtCuerpo = new DataTable();
                odtCuerpo = oFactura.GetAll_Ticket();
                decTotal = 0;

                //imprimo cuerpos
                foreach (DataRow row in odtCuerpo.Rows)
                {
                    string strCantidad = "";
                    string strProducto = "";
                    string strPrecio = "";
                    string strAlicuota = "";
                    int largo = 0;

                    strProducto = Convert.ToString(row["articulo"]);
                    largo = strProducto.Length;
                    if (largo > 20)
                    {
                        strProducto = strProducto.Substring(0, 20);
                    }
                    decTotal = decTotal + (Convert.ToInt32(row["cantidad"]) * Convert.ToDecimal(row["Precio"]));

                    decPrecio = Convert.ToDecimal(row["precio"]);
                    strPrecio = Convert.ToString(decPrecio);
                    strPrecio = strPrecio.Replace(",", ".");
                    strAlicuota = strAlicuota.Replace(",", ".");
                    strCantidad = Convert.ToString(row["cantidad"]);
                    strCantidad = strCantidad.Replace(",", ".");

                    nError = IFiscal.IF_WRITE("@FACTITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0||||0|0");

                    //nError = IFiscal.IF_WRITE("@FACTITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0||||0|0");
                    //nError = IFiscal.IF_WRITE("@TIQUEITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0|0");
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //si hay descuento imprimo
                if (descuento != "")
                {
                    if (Convert.ToDecimal(descuento) > 0)
                    {
                        nError = IFiscal.IF_WRITE("@FACTPAGO|DESCUENTO % " + porcentaje_descuento + "|" + descuento.Replace(",", ".") + "|D");
                        //nError = IFiscal.IF_WRITE("@TIQUEPAGO|DESCUENTO % " + porcentaje_descuento + "|" + descuento.Replace(",", ".") + "|D");
                    }
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //imprimo total
                nError = IFiscal.IF_WRITE("@FACTSUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
                //nError = IFiscal.IF_WRITE("@FACTSUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
                //nError = IFiscal.IF_WRITE("@TIQUESUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                string strImporte = "";
                bool bandContado = false;
                bool bandTarjeta = false;
                bool bandCC = false;
                bool bandCheque = false;
                bool bandTicket = false;

                //DataTable odtPago = new DataTable();
                //odtPago = oPago_Pedido.GetAllVenta(Convert.ToInt32(txtPedido.Text));

                ////imprimo los pagos
                //foreach (DataRow rowPago in odtPago.Rows)
                //{
                //    switch (Convert.ToString(rowPago["Tipo"]))
                //    {
                //        case "Contado":

                strImporte = txtPago.Text;
                strImporte = strImporte.Replace(",", ".");
                if (Convert.ToDecimal(strImporte) != 0 & bandContado == false)
                {
                    bandContado = true;
                    nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO CONTADO|" + strImporte + "|T|");
                    //nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO CONTADO|" + strImporte + "|T|");
                    //nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO CONTADO|" + strImporte + "|T|");
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //            break;
                //        case "Tarjeta":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandTarjeta == false)
                //            {
                //                bandTarjeta = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TARJETA|" + strImporte + "|T|");
                //            }

                //            break;
                //        case "Cuenta Corriente":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandCC == false)
                //            {
                //                bandCC = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CUENTA CORRIENTE|" + strImporte + "|T|");
                //            }

                //            break;

                //        case "Cheque":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandCheque == false)
                //            {
                //                bandCheque = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CHEQUE|" + strImporte + "|T|");
                //            }

                //            break;

                //        case "Ticket":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandTicket == false)
                //            {
                //                bandTicket = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TICKET|" + strImporte + "|T|");
                //            }

                //            break;
                //    }
                //}

                nError = IFiscal.IF_WRITE("@FACTCIERRA|M|B|FINAL");
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //nError = IFiscal.IF_WRITE("@FACTCIERRA|T|B|FINAL");
                //nError = IFiscal.IF_WRITE("@TIQUECIERRA|T");
                nError = IFiscal.IF_CLOSE();
                IFiscal = null;


            }

 
        }

        private void ImpresionFiscalNotaCreditoA()
        {
            DriverFiscal IFiscal = new DriverFiscal();

            long nError;
            nError = 0;

            IFiscal.SerialNumber = "27-0163848-435";

            string nDoc = "";
            string strCondicionIva = "";
            int intCondicionIva = 0;
            string strTipoDni = "";
            int intTipoDni = 0;
            string strNombre = "";
            string strCuit = "";
            string strDireccion = "";
            decimal decPrecio = 0;
            decimal decAlicuota = 0;
            decimal decTotal = 0;

            string descuento = "";
            string porcentaje_descuento = "";
            string recargo = "";
            string porcentaje_recargo = "";

            string strNumero_comprobante_original = "";
            strNumero_comprobante_original = txtFacturaAsociada.Text;

            DataTable odtCliente = new DataTable();

            odtCliente = oCliente.GetOne_2(Convert.ToInt32(lblid_cliente.Text));

            if (odtCliente.Rows.Count > 0)
            {
                DataRow rowCliente = odtCliente.Rows[0];
                intCondicionIva = Convert.ToInt32(rowCliente["id_condicion_iva"]);

                strCuit = Convert.ToString(rowCliente["numero_dni_cuit"]);
                intTipoDni = Convert.ToInt32(rowCliente["id_tipo_dni"]);
                strNombre = Convert.ToString(rowCliente["nombre_cliente"]);
                strDireccion = Convert.ToString(rowCliente["direccion"]);

                ////opedido.GetOne(Convert.ToInt32(txtPedido.Text));
                descuento = "0";
                porcentaje_descuento = "0";

                switch (intCondicionIva)
                {
                    case 1:
                        //'F = CONSUMIDOR FINAL
                        strCondicionIva = "F";
                        break;
                    case 2:
                        //'E = EXENTO
                        strCondicionIva = "E";
                        break;
                    case 3:
                        //'N = NO RESPONSABLE
                        strCondicionIva = "N";
                        break;
                    case 4:
                        //'I = IVA RESPONSABLE INSCRIPTO
                        strCondicionIva = "I";
                        break;
                    case 5:
                        //'M = RESPONSABLE MONOTRIBUTO
                        strCondicionIva = "M";
                        break;
                }

                switch (intTipoDni)
                {
                    //1	DNI
                    case 1:
                        strTipoDni = "DNI";
                        break;
                    //2	CUIL
                    case 2:
                        strTipoDni = "CUIL";
                        break;
                    //3	CUIT
                    case 3:
                        strTipoDni = "CUIT";
                        break;
                    //4	Libreta de Enrolamiento
                    case 4:
                        strTipoDni = "NDOC";
                        break;
                    //5	Libreta Civica
                    case 5:
                        strTipoDni = "NDOC";
                        break;
                    //6	Pasaporte
                    case 6:
                        strTipoDni = "NDOC";
                        break;
                    //7	Cedula
                    case 7:
                        strTipoDni = "NDOC";
                        break;
                }

                nError = IFiscal.IF_OPEN(Inicio.vgPuertoFiscal, 9600);
                Thread.Sleep(milliseconds);
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                nError = IFiscal.IF_WRITE("@FACTABRE|M|C|A|1|P|10|I|" + strCondicionIva + "|" + strNombre + "||" + strTipoDni + "|" + strCuit + "|N|" + strDireccion + "|||" + strNumero_comprobante_original + "||C");
                //nError = IFiscal.IF_WRITE("@FACTABRE|M|C|B|1|P|10|I|" + strCondicionIva + "|" + strNombre + "||" + strTipoDni + "|" + strCuit + "|N|" + strDireccion + "|||" + strNumero_comprobante_original + "||C");
                //nError = IFiscal.IF_WRITE("@FACTABRE|T|C|B|1|P|10|I|" + strCondicionIva + "|" + strNombre + "||" + strTipoDni + "|" + strCuit + "|N|" + strDireccion + "|||" + "-" + "||C");
                //nError = IFiscal.IF_WRITE("@TIQUEABRE|B|");
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                DataTable odtCuerpo = new DataTable();
                odtCuerpo = oFactura.GetAll_Ticket();
                decTotal = 0;

                //imprimo cuerpos
                foreach (DataRow row in odtCuerpo.Rows)
                {
                    string strCantidad = "";
                    string strProducto = "";
                    string strPrecio = "";
                    string strAlicuota = "";
                    int largo = 0;

                    strProducto = Convert.ToString(row["articulo"]);
                    largo = strProducto.Length;
                    if (largo > 20)
                    {
                        strProducto = strProducto.Substring(0, 20);
                    }
                    decTotal = decTotal + (Convert.ToInt32(row["cantidad"]) * Convert.ToDecimal(row["Precio"]));

                    // alicuota del 21%
                    decAlicuota = Convert.ToDecimal(0.21);
                    strAlicuota = Convert.ToString(decAlicuota);

                    decPrecio = Convert.ToDecimal(row["precio"]);
                    strPrecio = Convert.ToString(decPrecio / (1 + decAlicuota));
                    strPrecio = strPrecio.Replace(",", ".");
                    strAlicuota = strAlicuota.Replace(",", ".");
                    strCantidad = Convert.ToString(row["cantidad"]);
                    strCantidad = strCantidad.Replace(",", ".");

                    nError = IFiscal.IF_WRITE("@FACTITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|" + strAlicuota + "|M|1|0||||0|0");

                    //nError = IFiscal.IF_WRITE("@FACTITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0||||0|0");
                    //nError = IFiscal.IF_WRITE("@TIQUEITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0|0");
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //si hay descuento imprimo
                if (descuento != "")
                {
                    if (Convert.ToDecimal(descuento) > 0)
                    {
                        nError = IFiscal.IF_WRITE("@FACTPAGO|DESCUENTO % " + porcentaje_descuento + "|" + descuento.Replace(",", ".") + "|D");
                        //nError = IFiscal.IF_WRITE("@TIQUEPAGO|DESCUENTO % " + porcentaje_descuento + "|" + descuento.Replace(",", ".") + "|D");
                    }
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //imprimo total
                nError = IFiscal.IF_WRITE("@FACTSUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
                //nError = IFiscal.IF_WRITE("@FACTSUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
                //nError = IFiscal.IF_WRITE("@TIQUESUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                string strImporte = "";
                bool bandContado = false;
                bool bandTarjeta = false;
                bool bandCC = false;
                bool bandCheque = false;
                bool bandTicket = false;

                //DataTable odtPago = new DataTable();
                //odtPago = oPago_Pedido.GetAllVenta(Convert.ToInt32(txtPedido.Text));

                ////imprimo los pagos
                //foreach (DataRow rowPago in odtPago.Rows)
                //{
                //    switch (Convert.ToString(rowPago["Tipo"]))
                //    {
                //        case "Contado":

                strImporte = txtPago.Text;
                strImporte = strImporte.Replace(",", ".");
                if (Convert.ToDecimal(strImporte) != 0 & bandContado == false)
                {
                    bandContado = true;
                    nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO CONTADO|" + strImporte + "|T|");
                    //nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO CONTADO|" + strImporte + "|T|");
                    //nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO CONTADO|" + strImporte + "|T|");
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //            break;
                //        case "Tarjeta":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandTarjeta == false)
                //            {
                //                bandTarjeta = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TARJETA|" + strImporte + "|T|");
                //            }

                //            break;
                //        case "Cuenta Corriente":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandCC == false)
                //            {
                //                bandCC = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CUENTA CORRIENTE|" + strImporte + "|T|");
                //            }

                //            break;

                //        case "Cheque":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandCheque == false)
                //            {
                //                bandCheque = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CHEQUE|" + strImporte + "|T|");
                //            }

                //            break;

                //        case "Ticket":
                //            strImporte = Convert.ToString(rowPago["importe"]);
                //            strImporte = strImporte.Replace(",", ".");
                //            if (Convert.ToDecimal(strImporte) != 0 & bandTicket == false)
                //            {
                //                bandTicket = true;
                //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TICKET|" + strImporte + "|T|");
                //            }

                //            break;
                //    }
                //}

                nError = IFiscal.IF_WRITE("@FACTCIERRA|M|A|FINAL");
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

                //nError = IFiscal.IF_WRITE("@FACTCIERRA|M|B|FINAL");
                //nError = IFiscal.IF_WRITE("@FACTCIERRA|T|B|FINAL");
                //nError = IFiscal.IF_WRITE("@TIQUECIERRA|T");
                nError = IFiscal.IF_CLOSE();
                IFiscal = null;


            }


        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            oFactura.particulo = txtArticulo.Text;
            oFactura.pcantidad = Convert.ToInt32(txtCantidad.Text);
            oFactura.pprecio = Convert.ToDouble(txtPrecio.Text);
            oFactura.Insertar();

            RefrescarGrilla();

            txtArticulo.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtArticulo.Focus();
        }

        private void RefrescarGrilla()
        {
            DataTable odt = new DataTable();
            odt = oFactura.GetAll_2();

            dgv1.DataSource = odt;
            dgv1.Columns[0].Visible = false;

            double total;
            total= 0;
            foreach (DataRow row in odt.Rows)
            {
                total = total + Convert.ToDouble(row["subtotal"]);
            }

            txtTotal.Text = Convert.ToString(total);
            txtPago.Text = txtTotal.Text;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {

            //1   Consumidor Final
            //2   Exento
            //3   No Responsable
            //4   Responsable Inscripto
            //5   Responsable Monotributo

            if (lblid_cliente.Text=="1")
            {
                //consumidor final
                ImpresionFiscalTicketC();
            }
            else
            {
            switch (lblid_condicion_iva.Text)
            {
                   case "1":
                        ImpresionFiscalTicketB();
                        break;
                   case "2":
                        ImpresionFiscalTicketB();
                        break;
                    case "3":
                        ImpresionFiscalTicketB();
                        break;
                    case "4":
                        ImpresionFiscalTicketA();
                        break;
                    case "5":
                        ImpresionFiscalTicketB();
                        break;
                }
            }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }

        private void dgv1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                lblid_factura.Value = Convert.ToInt32( dgv1[0, this.dgv1.CurrentRow.Index].Value.ToString());
            }
            catch
            {
                lblid_factura.Value = 0;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Realmente Eliminar el Registro Nro:" + lblid_factura.Value ,
                        "BORRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            oFactura.pid_factura =Convert.ToInt32( lblid_factura.Value) ;
            oFactura.Borrar();
            RefrescarGrilla();
        }



        public void TabularDecimales(object sender, KeyPressEventArgs e)
        {
            TextBox txttemp = new TextBox();
            txttemp = (TextBox)sender;

            //pregunta si se presiono la tecla "."
            if (e.KeyChar.ToString() == ".")
            {
                //pregunta si ya contiene alguna coma. si la contiene no deja ingresar otra
                if (txttemp.Text.Contains(','))
                {
                    e.Handled = false;
                }
                //de lo contrario si no la contiene y se presiono punto. cambia el punto por coma
                // y lo muestra
                else
                {
                    e.Handled = true;
                    txttemp.Text += ",";
                    SendKeys.Send("{END}");
                }

            }
            if (txttemp.Text.Contains(',') || txttemp.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }

            }

            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == ',' || e.KeyChar == '\b' || e.KeyChar == '.')
                {
                    e.Handled = false;
                }
            }
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //se asigna el valor y la funcion que va a tomar esa tecla.
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void TabularTextBox(object sender, KeyPressEventArgs e)
        {
            //se le asigna la tecla que realizara la accion de tabulacion
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //se asigna el valor y la funcion que va a tomar esa tecla.
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        public void TabularCombobox(object sender, KeyEventArgs e)
        {
            //al igual que el textbox solo que en ves de tener un keychar se utiliza el keyvalues
            if (e.KeyValue == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender, e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularDecimales(sender, e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularDecimales(sender, e);
        }

        private void btnNotaCredito_Click(object sender, EventArgs e)
        {
            //1   Consumidor Final
            //2   Exento
            //3   No Responsable
            //4   Responsable Inscripto
            //5   Responsable Monotributo

            if (lblid_cliente.Text == "1")
            {
                //consumidor final
                ImpresionFiscalNotaCreditoB();
            }
            else
            {
                switch (lblid_condicion_iva.Text)
                {
                    case "1":
                        ImpresionFiscalNotaCreditoB();
                        break;
                    case "2":
                        ImpresionFiscalNotaCreditoB();
                        break;
                    case "3":
                        ImpresionFiscalNotaCreditoB();
                        break;
                    case "4":
                        ImpresionFiscalNotaCreditoA();
                        break;
                    case "5":
                        ImpresionFiscalNotaCreditoB();
                        break;
                }
            }



            this.Close();
        }
    }



}
