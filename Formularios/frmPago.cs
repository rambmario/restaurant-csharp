using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FiscalNET;
using System.Threading;

namespace Gestion_gastronomica.Formularios
{
    public partial class frmPago : Form
    {
        public frmPago()
        {
            InitializeComponent();

        }
        Clase.clsPedido opedido = new Clase.clsPedido();
        Clase.clsCuerpo_Pedido ocuerpo_pedido = new Clase.clsCuerpo_Pedido();
        Clase.clsForma_Pago oforma_pago = new Clase.clsForma_Pago();
        Clase.clsTipo_Forma_Pago otipo_forma_pago = new Clase.clsTipo_Forma_Pago();
        Clase.clsMesa omesa = new Clase.clsMesa();
        Clase.clsPago_Pedido oPago_Pedido = new Clase.clsPago_Pedido();
        Clase.clsTemp_Pedido oTemp_Pedido = new Clase.clsTemp_Pedido();
        Clase.clsCliente oCliente = new Clase.clsCliente();

        Int32 milliseconds = 1000;
        private void frmPago_Load(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Generar");
            sb.AppendLine("Multi Ticket");
            this.lblMulti_Ticket.Text = sb.ToString();
            this.txtporcentajedescuento.Text = "0";
            this.txtdescuento.Text = "0,00";
            this.txtPago.Focus();
            this.MaximizeBox = false;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Pago del pedido Nroº" + Inicio.id_pedido;

            //this.BackgroundImage = Properties.Resources.Fondo;

            opedido.GetOne(Inicio.id_pedido);
            omesa.GetOne(opedido.pid_mesa);


            txtsubtotal.Text = Convert.ToString(opedido.pimporte);
            txttotal.Text = Convert.ToString(opedido.pimporte);
            this.txtPedido.Text = Convert.ToString(Inicio.id_pedido);
            this.txtMesa.Text = omesa.pnombre_mesa;
            RefrescarGrillaPago();

            //dandole color a los botones
            var buttons = this.Controls.OfType<Button>();

            foreach (var button in buttons)
            {
                button.MouseDown += btn_MouseDown;
                button.MouseEnter += btn_MouseEnter;
                button.MouseLeave += btn_MouseLeave;
                button.MouseUp += btn_MouseUp;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackgroundImage = Properties.Resources._1button;
                //el resto
            }

            this.lblid_cliente.Text = "1";
            this.txtNombre_cliente.Text = "Consumidor Final";
            this.lblid_condicion_iva.Text = "1";
        }

        public void RefrescarGrillaPago()
        {
            Inicio.id_pago_pedido = 0;
            DataTable odt;
            double dectotalpago = 0;
            double decefectivo = 0;
            double dectarjeta = 0;
            double deccheque = 0;
            double decticket = 0;
            double decCC = 0;
            double decnoefectivo = 0;

            odt = oPago_Pedido.GetAllVenta(Inicio.id_pedido);
            this.dgvPago_pedido.DataSource = odt;
            this.dgvPago_pedido.Columns[0].Visible = false;

            this.txtIDEfectivo.Text = "0";
            foreach (DataRow row in odt.Rows)
            {
                switch (Convert.ToString(row["Tipo"]))
                {
                    case "Contado":
                        decefectivo = decefectivo + Convert.ToDouble(row["importe"]);
                        this.txtIDEfectivo.Text = Convert.ToString(row["id_pago_pedido"]);
                        break;
                    case "Tarjeta":
                        dectarjeta = dectarjeta + Convert.ToDouble(row["importe"]);
                        break;
                    case "Cuenta Corriente":
                        decCC = decCC + Convert.ToDouble(row["importe"]);
                        break;
                    case "Cheque":
                        deccheque = deccheque + Convert.ToDouble(row["importe"]);
                        break;
                    case "Ticket":
                        decticket = decticket + Convert.ToDouble(row["importe"]);
                        break;
                }
                dectotalpago = dectotalpago + Convert.ToDouble(row["importe"]);
            }
            decnoefectivo = dectarjeta + decCC + deccheque + decticket;
            this.txtPago.Text = Convert.ToString(dectotalpago);
            this.txtvuelto.Text = Convert.ToString(Convert.ToDouble(this.txtPago.Text) - Convert.ToDouble(this.txttotal.Text));

            this.txtefectivo.Text = Convert.ToString(decefectivo - Convert.ToDouble(this.txtvuelto.Text));
            this.txtTarjeta.Text = Convert.ToString(dectarjeta);
            this.txtTicket.Text = Convert.ToString(decticket);
            this.txtCheque.Text = Convert.ToString(deccheque);
            this.txtCC.Text = Convert.ToString(decCC);

            this.txtNoEfectivo.Text = Convert.ToString(decnoefectivo);
        }

        private void BotonesFunciones_Click(object sender, EventArgs e)
        {
            Button btntemp = new Button();
            frmDetalleMesa frmDetalles = new frmDetalleMesa();
            btntemp = (Button)sender;
            try
            {
                switch (btntemp.Name)
                {
                    case "btnContado":
                        DataTable odt = null;
                        odt = oPago_Pedido.GetAllVenta(Inicio.id_pedido);

                        //controlo efectivo duplicado
                        foreach (DataRow row in odt.Rows)
                        {
                            if (Convert.ToString(row["Tipo"]) == "Contado")
                            {
                                MessageBox.Show("Ya ingreso un monto en efectivo.", "Advertencia", MessageBoxButtons.OK
                                    , MessageBoxIcon.Information);
                                return;
                            }
                        }
                        frmFormaPagoContado contado = new frmFormaPagoContado();
                        Inicio.id_forma_pago = 2;
                        this.AddOwnedForm(contado);
                        contado.ShowDialog();
                        RefrescarGrillaPago();
                        break;

                    case "btnTarjeta":
                        frmFormaPagoTarjeta tarjeta = new frmFormaPagoTarjeta();
                        Inicio.id_forma_pago = 3;
                        this.AddOwnedForm(tarjeta);
                        tarjeta.ShowDialog();
                        RefrescarGrillaPago();
                        break;
                    case "btnCheque":
                        frmFormaPagoCheque cheque = new frmFormaPagoCheque();
                        Inicio.id_forma_pago = 4;
                        this.AddOwnedForm(cheque);
                        cheque.ShowDialog();
                        RefrescarGrillaPago();
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void RestarTextbox(object sender, KeyPressEventArgs e)
        {
            decimal resultado = 0;
            TabularDecimales(sender, e);
            if (!string.IsNullOrEmpty(this.txtporcentajedescuento.Text))
            {
                if (Convert.ToDouble(txtporcentajedescuento.Text) < 0 | Convert.ToDouble(txtporcentajedescuento.Text) > 100)
                {
                    e.Handled = true;
                    txtporcentajedescuento.Text = Convert.ToString(0);
                    txtporcentajedescuento.Clear();
                    txtporcentajedescuento.Focus();
                }
                if (e.KeyChar == (char)(Keys.Enter))
                {
                    try
                    {
                        resultado = (Convert.ToDecimal(this.txtsubtotal.Text) * Convert.ToDecimal(this.txtporcentajedescuento.Text)) / 100;
                        txtdescuento.Text = Convert.ToString(resultado);

                        //txttotal.Text = Strings.FormatNumber(Convert.ToDouble(txtsubtotal.Text) - Convert.ToDouble(txtDescuento.Text), 2);
                        this.txttotal.Text = Convert.ToString(Convert.ToDouble(this.txtsubtotal.Text) - Convert.ToDouble(txtdescuento.Text));

                        this.txtvuelto.Text = Convert.ToString(Convert.ToDouble(txtPago.Text) - Convert.ToDouble(txttotal.Text));

                        if (Convert.ToDouble(txtporcentajedescuento.Text) == 100)
                        {
                            txtvuelto.Text = Convert.ToString(0);
                            txtPago.Text = Convert.ToString(0);

                            if (Inicio.id_pago_pedido == 0)
                            {
                                return;
                            }
                            oPago_Pedido.pid_pedido = Inicio.id_pedido;
                            oPago_Pedido.BorrarporPedido();
                            RefrescarGrillaPago();
                        }


                    }
                    catch (Exception ex)
                    {
                    }

                }

            }

            this.txtporcentajedescuento.Focus();

        }
        //valida si esta ingresando numeros y ademas que solo tenga una unica coma.
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

        private void txtporcentajedescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            RestarTextbox(sender, e);
        }

        private void btnanularpago_Click(object sender, EventArgs e)
        {
            if (Inicio.id_pago_pedido == 0)
            {
                return;
            }
            oPago_Pedido.pid_pago_pedido = Inicio.id_pago_pedido;
            oPago_Pedido.Borrar();
            RefrescarGrillaPago();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtvuelto.Text) < 0)
                {
                    MessageBox.Show("Error Pago Incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Convert.ToDouble(txtPago.Text) < Convert.ToDouble(txttotal.Text))
                {
                    MessageBox.Show("Error el pago es menor al total", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //modifico y completo mi pedido
                opedido.GetOne(Inicio.id_pedido);
                opedido.ppago_cliente = Convert.ToDouble(this.txtPago.Text);
                opedido.pporcentaje_descuento = Convert.ToDouble(this.txtporcentajedescuento.Text);
                opedido.pdescuento = Convert.ToDouble(this.txtdescuento.Text);
                opedido.ptotals = Convert.ToDouble(this.txttotal.Text);
                opedido.pid_pedido = Inicio.id_pedido;


                //actualizo el pedido
                opedido.pfecha_entrega = DateTime.Now;
                opedido.pid_estado_pedido = 3; //Finalizada

                opedido.pid_cliente = Convert.ToInt32( this.lblid_cliente.Text);
                opedido.Modificar();

                //impresion fiscal
                try
                {
                    //si esta tildado facturar
                    if (chkFacturar.Checked == true)
                    {

                        //1   Consumidor Final
                        //2   Exento
                        //3   No Responsable
                        //4   Responsable Inscripto
                        //5   Responsable Monotributo

                        if (lblid_cliente.Text == "1")
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
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //Ya no se utiliza mas los datos de la temporal para impresiones asi que se borra el pedido
                DataTable odttemp = oTemp_Pedido.GetPedido(opedido.pid_pedido);
                foreach (DataRow row in odttemp.Rows)
                {
                    int idpro = Convert.ToInt32(row[0]);
                    oTemp_Pedido.pid_temp_pedido = idpro;
                    oTemp_Pedido.Borrar();
                }

                omesa.GetOne(opedido.pid_mesa);
                //Consulto si es una mesa agrupada
                if (omesa.pgrupo_mesa == 0)
                {
                    //Cambiamos el estado de la mesa
                    omesa.pestado = "Libre";
                    omesa.pid_mesa = opedido.pid_mesa;
                    omesa.Modificar();
                }
                else
                {
                    DataTable odt = omesa.GetAgrupada(omesa.pgrupo_mesa);
                    foreach (DataRow row in odt.Rows)
                    {
                        //Cambiamos el estado de la mesa agrupadas
                        omesa.GetOne(Convert.ToInt32(row["id_mesa"]));
                        omesa.pid_mesa = Convert.ToInt32(row["id_mesa"]);
                        omesa.pestado = "Libre";
                        omesa.pgrupo_mesa = 0;
                        omesa.Modificar();
                    }
                }

                // Reporte.rptCierrePedido CierrePedido = new Reporte.rptCierrePedido();
                //Inicio.printCrystalReport(CierrePedido,1,0,0,"rptCierrePedido");
            }
            catch (Exception)
            {
                MessageBox.Show("Se a Generado un Error al Cargar un Pago. Comuniquese con el Administrador", "ERROR",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
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

            if (odtCliente.Rows.Count>0)
            {
                DataRow rowCliente = odtCliente.Rows[0];
                intCondicionIva = Convert.ToInt32( rowCliente["id_condicion_iva"]);

                strCuit = Convert.ToString (rowCliente["numero_dni_cuit"]);
                intTipoDni = Convert.ToInt32(rowCliente["id_tipo_dni"]);
                strNombre = Convert.ToString(rowCliente["nombre_cliente"]);
                strDireccion = Convert.ToString(rowCliente["direccion"]);

                opedido.GetOne(Convert.ToInt32(txtPedido.Text));
                descuento = Convert.ToString( opedido.pdescuento);
                porcentaje_descuento = Convert.ToString(opedido.pporcentaje_descuento);

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

                nError = IFiscal.IF_OPEN(Inicio.vgPuertoFiscal , 9600);
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
                odtCuerpo = ocuerpo_pedido.GetAllPrintTicket(Convert.ToInt32(txtPedido.Text));
                decTotal = 0;

                //imprimo cuerpos
                foreach (DataRow row in odtCuerpo.Rows)
                {
                    string strCantidad = "";
                    string strProducto = "";
                    string strPrecio = "";
                    string strAlicuota = "";
                    int largo = 0;

                    strProducto = Convert.ToString(row["producto"]);
                    largo = strProducto.Length;
                    if (largo > 20)
                    {
                        strProducto = strProducto.Substring(0, 20);
                    }
                    decTotal = decTotal + Convert.ToDecimal(row["Total"]);

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
                if (descuento!="")
                {
                    if (Convert.ToDecimal(descuento) >0)
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

                DataTable odtPago = new DataTable();
                odtPago = oPago_Pedido.GetAllVentaFiscal(Convert.ToInt32(txtPedido.Text));

                //imprimo los pagos
                foreach (DataRow rowPago in odtPago.Rows)
                {
                    switch (Convert.ToString(rowPago["Tipo"]))
                    {
                        case "Contado":

                            strImporte = Convert.ToString( rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandContado == false)
                            {
                                bandContado = true;
                                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO CONTADO|" + strImporte + "|T|");
                            }

                            break;
                        case "Tarjeta":
                            strImporte = Convert.ToString(rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandTarjeta == false)
                            {
                                bandTarjeta = true;
                                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TARJETA|" + strImporte + "|T|");
                            }

                            break;
                        case "Cuenta Corriente":
                            strImporte = Convert.ToString(rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandCC == false)
                            {
                                bandCC = true;
                                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CUENTA CORRIENTE|" + strImporte + "|T|");
                            }

                            break;

                        case "Cheque":
                            strImporte = Convert.ToString(rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandCheque == false)
                            {
                                bandCheque = true;
                                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CHEQUE|" + strImporte + "|T|");
                            }

                            break;

                        case "Ticket":
                            strImporte = Convert.ToString(rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandTicket == false)
                            {
                                bandTicket = true;
                                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TICKET|" + strImporte + "|T|");
                            }

                            break;
                    }
                }
                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@TIQUECANCEL");
                }

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
                odtCuerpo = ocuerpo_pedido.GetAllPrintTicket(Convert.ToInt32(txtPedido.Text));
                decTotal = 0;

                //imprimo cuerpos
                foreach (DataRow row in odtCuerpo.Rows)
                {
                    string strCantidad = "";
                    string strProducto = "";
                    string strPrecio = "";
                    string strAlicuota = "";
                    int largo = 0;

                    strProducto = Convert.ToString(row["producto"]);
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

                strImporte = txtPago.Text;
                strImporte = strImporte.Replace(",", ".");

                DataTable odtPago = new DataTable();
                odtPago = oPago_Pedido.GetAllVentaFiscal(Convert.ToInt32(txtPedido.Text));

                //imprimo los pagos
                foreach (DataRow rowPago in odtPago.Rows)
                {
                    switch (Convert.ToString(rowPago["Tipo"]))
                    {
                        case "Contado":

                            strImporte = Convert.ToString(rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandContado == false)
                            {
                                bandContado = true;
                                nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO CONTADO|" + strImporte + "|T|");
                            }

                            break;
                        case "Tarjeta":
                            strImporte = Convert.ToString(rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandTarjeta == false)
                            {
                                bandTarjeta = true;
                                nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO TARJETA|" + strImporte + "|T|");
                            }

                            break;
                        case "Cuenta Corriente":
                            strImporte = Convert.ToString(rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandCC == false)
                            {
                                bandCC = true;
                                nError = IFiscal.IF_WRITE("@FACTPAGO|CUENTA CORRIENTE|" + strImporte + "|T|");
                            }

                            break;

                        case "Cheque":
                            strImporte = Convert.ToString(rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandCheque == false)
                            {
                                bandCheque = true;
                                nError = IFiscal.IF_WRITE("@FACTPAGO|CHEQUE|" + strImporte + "|T|");
                            }

                            break;

                        case "Ticket":
                            strImporte = Convert.ToString(rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandTicket == false)
                            {
                                bandTicket = true;
                                nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO TICKET|" + strImporte + "|T|");
                            }

                            break;
                    }
                }

                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

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
                odtCuerpo = ocuerpo_pedido.GetAllPrintTicket(Convert.ToInt32(txtPedido.Text));
                decTotal = 0;

                //imprimo cuerpos
                foreach (DataRow row in odtCuerpo.Rows)
                {
                    string strCantidad = "";
                    string strProducto = "";
                    string strPrecio = "";
                    string strAlicuota = "";
                    int largo = 0;

                    strProducto = Convert.ToString(row["producto"]);
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

                DataTable odtPago = new DataTable();
                odtPago = oPago_Pedido.GetAllVentaFiscal(Convert.ToInt32(txtPedido.Text));

                //imprimo los pagos
                foreach (DataRow rowPago in odtPago.Rows)
                {
                    switch (Convert.ToString(rowPago["Tipo"]))
                    {
                        case "Contado":

                            strImporte = Convert.ToString(rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandContado == false)
                            {
                                bandContado = true;
                                nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO CONTADO|" + strImporte + "|T|");
                            }

                            break;
                        case "Tarjeta":
                            strImporte = Convert.ToString(rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandTarjeta == false)
                            {
                                bandTarjeta = true;
                                nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO TARJETA|" + strImporte + "|T|");
                            }

                            break;
                        case "Cuenta Corriente":
                            strImporte = Convert.ToString(rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandCC == false)
                            {
                                bandCC = true;
                                nError = IFiscal.IF_WRITE("@FACTPAGO|CUENTA CORRIENTE|" + strImporte + "|T|");
                            }

                            break;

                        case "Cheque":
                            strImporte = Convert.ToString(rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandCheque == false)
                            {
                                bandCheque = true;
                                nError = IFiscal.IF_WRITE("@FACTPAGO|CHEQUE|" + strImporte + "|T|");
                            }

                            break;

                        case "Ticket":
                            strImporte = Convert.ToString(rowPago["importe"]);
                            strImporte = strImporte.Replace(",", ".");
                            if (Convert.ToDecimal(strImporte) != 0 & bandTicket == false)
                            {
                                bandTicket = true;
                                nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO TICKET|" + strImporte + "|T|");
                            }

                            break;
                    }
                }

                if (nError != 0)
                {
                    // nError = IFiscal.IF_WRITE("@FACTCANCEL");
                }

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

        //private void ImpresionFiscalNotaCreditoB()
        //{
        //    DriverFiscal IFiscal = new DriverFiscal();

        //    long nError;
        //    nError = 0;

        //    IFiscal.SerialNumber = "27-0163848-435";

        //    string nDoc = "";
        //    string strCondicionIva = "";
        //    int intCondicionIva = 0;
        //    string strTipoDni = "";
        //    int intTipoDni = 0;
        //    string strNombre = "";
        //    string strCuit = "";
        //    string strDireccion = "";
        //    decimal decPrecio = 0;
        //    decimal decAlicuota = 0;
        //    decimal decTotal = 0;

        //    string descuento = "";
        //    string porcentaje_descuento = "";
        //    string recargo = "";
        //    string porcentaje_recargo = "";

        //    string strNumero_comprobante_original = "";
        //    strNumero_comprobante_original = txtFacturaAsociada.Text;

        //    DataTable odtCliente = new DataTable();

        //    odtCliente = oCliente.GetOne_2(Convert.ToInt32(lblid_cliente.Text));

        //    if (odtCliente.Rows.Count > 0)
        //    {
        //        DataRow rowCliente = odtCliente.Rows[0];
        //        intCondicionIva = Convert.ToInt32(rowCliente["id_condicion_iva"]);

        //        strCuit = Convert.ToString(rowCliente["numero_dni_cuit"]);
        //        intTipoDni = Convert.ToInt32(rowCliente["id_tipo_dni"]);
        //        strNombre = Convert.ToString(rowCliente["nombre_cliente"]);
        //        strDireccion = Convert.ToString(rowCliente["direccion"]);

        //        ////opedido.GetOne(Convert.ToInt32(txtPedido.Text));
        //        descuento = "0";
        //        porcentaje_descuento = "0";

        //        switch (intCondicionIva)
        //        {
        //            case 1:
        //                //'F = CONSUMIDOR FINAL
        //                strCondicionIva = "F";
        //                break;
        //            case 2:
        //                //'E = EXENTO
        //                strCondicionIva = "E";
        //                break;
        //            case 3:
        //                //'N = NO RESPONSABLE
        //                strCondicionIva = "N";
        //                break;
        //            case 4:
        //                //'I = IVA RESPONSABLE INSCRIPTO
        //                strCondicionIva = "I";
        //                break;
        //            case 5:
        //                //'M = RESPONSABLE MONOTRIBUTO
        //                strCondicionIva = "M";
        //                break;
        //        }

        //        switch (intTipoDni)
        //        {
        //            //1	DNI
        //            case 1:
        //                strTipoDni = "DNI";
        //                break;
        //            //2	CUIL
        //            case 2:
        //                strTipoDni = "CUIL";
        //                break;
        //            //3	CUIT
        //            case 3:
        //                strTipoDni = "CUIT";
        //                break;
        //            //4	Libreta de Enrolamiento
        //            case 4:
        //                strTipoDni = "NDOC";
        //                break;
        //            //5	Libreta Civica
        //            case 5:
        //                strTipoDni = "NDOC";
        //                break;
        //            //6	Pasaporte
        //            case 6:
        //                strTipoDni = "NDOC";
        //                break;
        //            //7	Cedula
        //            case 7:
        //                strTipoDni = "NDOC";
        //                break;
        //        }

        //        nError = IFiscal.IF_OPEN(Inicio.vgPuertoFiscal, 9600);

        //        nError = IFiscal.IF_WRITE("@FACTABRE|M|C|B|1|P|10|I|" + strCondicionIva + "|" + strNombre + "||" + strTipoDni + "|" + strCuit + "|N|" + strDireccion + "|||" + strNumero_comprobante_original + "||C");

        //        //nError = IFiscal.IF_WRITE("@FACTABRE|T|C|B|1|P|10|I|" + strCondicionIva + "|" + strNombre + "||" + strTipoDni + "|" + strCuit + "|N|" + strDireccion + "|||" + "-" + "||C");
        //        //nError = IFiscal.IF_WRITE("@TIQUEABRE|B|");

        //        DataTable odtCuerpo = new DataTable();
        //        odtCuerpo = ocuerpo_pedido.GetAllPrintTicket(Convert.ToInt32(txtPedido.Text));
        //        decTotal = 0;

        //        //imprimo cuerpos
        //        foreach (DataRow row in odtCuerpo.Rows)
        //        {
        //            string strCantidad = "";
        //            string strProducto = "";
        //            string strPrecio = "";
        //            string strAlicuota = "";
        //            int largo = 0;

        //            strProducto = Convert.ToString(row["articulo"]);
        //            largo = strProducto.Length;
        //            if (largo > 20)
        //            {
        //                strProducto = strProducto.Substring(0, 20);
        //            }
        //            decTotal = decTotal + (Convert.ToInt32(row["cantidad"]) * Convert.ToDecimal(row["Precio"]));

        //            decPrecio = Convert.ToDecimal(row["precio"]);
        //            strPrecio = Convert.ToString(decPrecio);
        //            strPrecio = strPrecio.Replace(",", ".");
        //            strAlicuota = strAlicuota.Replace(",", ".");
        //            strCantidad = Convert.ToString(row["cantidad"]);
        //            strCantidad = strCantidad.Replace(",", ".");

        //            nError = IFiscal.IF_WRITE("@FACTITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0||||0|0");

        //            //nError = IFiscal.IF_WRITE("@FACTITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0||||0|0");
        //            //nError = IFiscal.IF_WRITE("@TIQUEITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0|0");
        //        }

        //        //si hay descuento imprimo
        //        if (descuento != "")
        //        {
        //            if (Convert.ToDecimal(descuento) > 0)
        //            {
        //                nError = IFiscal.IF_WRITE("@FACTPAGO|DESCUENTO % " + porcentaje_descuento + "|" + descuento.Replace(",", ".") + "|D");
        //                //nError = IFiscal.IF_WRITE("@TIQUEPAGO|DESCUENTO % " + porcentaje_descuento + "|" + descuento.Replace(",", ".") + "|D");
        //            }
        //        }

        //        //imprimo total
        //        nError = IFiscal.IF_WRITE("@FACTSUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
        //        //nError = IFiscal.IF_WRITE("@FACTSUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
        //        //nError = IFiscal.IF_WRITE("@TIQUESUBTOTAL|SubTotal|" + Convert.ToString(decTotal));

        //        string strImporte = "";
        //        bool bandContado = false;
        //        bool bandTarjeta = false;
        //        bool bandCC = false;
        //        bool bandCheque = false;
        //        bool bandTicket = false;

        //        //DataTable odtPago = new DataTable();
        //        //odtPago = oPago_Pedido.GetAllVenta(Convert.ToInt32(txtPedido.Text));

        //        ////imprimo los pagos
        //        //foreach (DataRow rowPago in odtPago.Rows)
        //        //{
        //        //    switch (Convert.ToString(rowPago["Tipo"]))
        //        //    {
        //        //        case "Contado":

        //        strImporte = txtPago.Text;
        //        strImporte = strImporte.Replace(",", ".");
        //        if (Convert.ToDecimal(strImporte) != 0 & bandContado == false)
        //        {
        //            bandContado = true;
        //            nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO CONTADO|" + strImporte + "|T|");
        //            //nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO CONTADO|" + strImporte + "|T|");
        //            //nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO CONTADO|" + strImporte + "|T|");
        //        }

        //        //            break;
        //        //        case "Tarjeta":
        //        //            strImporte = Convert.ToString(rowPago["importe"]);
        //        //            strImporte = strImporte.Replace(",", ".");
        //        //            if (Convert.ToDecimal(strImporte) != 0 & bandTarjeta == false)
        //        //            {
        //        //                bandTarjeta = true;
        //        //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TARJETA|" + strImporte + "|T|");
        //        //            }

        //        //            break;
        //        //        case "Cuenta Corriente":
        //        //            strImporte = Convert.ToString(rowPago["importe"]);
        //        //            strImporte = strImporte.Replace(",", ".");
        //        //            if (Convert.ToDecimal(strImporte) != 0 & bandCC == false)
        //        //            {
        //        //                bandCC = true;
        //        //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CUENTA CORRIENTE|" + strImporte + "|T|");
        //        //            }

        //        //            break;

        //        //        case "Cheque":
        //        //            strImporte = Convert.ToString(rowPago["importe"]);
        //        //            strImporte = strImporte.Replace(",", ".");
        //        //            if (Convert.ToDecimal(strImporte) != 0 & bandCheque == false)
        //        //            {
        //        //                bandCheque = true;
        //        //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CHEQUE|" + strImporte + "|T|");
        //        //            }

        //        //            break;

        //        //        case "Ticket":
        //        //            strImporte = Convert.ToString(rowPago["importe"]);
        //        //            strImporte = strImporte.Replace(",", ".");
        //        //            if (Convert.ToDecimal(strImporte) != 0 & bandTicket == false)
        //        //            {
        //        //                bandTicket = true;
        //        //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TICKET|" + strImporte + "|T|");
        //        //            }

        //        //            break;
        //        //    }
        //        //}

        //        nError = IFiscal.IF_WRITE("@FACTCIERRA|M|B|FINAL");
        //        //nError = IFiscal.IF_WRITE("@FACTCIERRA|T|B|FINAL");
        //        //nError = IFiscal.IF_WRITE("@TIQUECIERRA|T");
        //        nError = IFiscal.IF_CLOSE();
        //        IFiscal = null;


        //    }


        //}

        //private void ImpresionFiscalNotaCreditoA()
        //{
        //    DriverFiscal IFiscal = new DriverFiscal();

        //    long nError;
        //    nError = 0;

        //    IFiscal.SerialNumber = "27-0163848-435";

        //    string nDoc = "";
        //    string strCondicionIva = "";
        //    int intCondicionIva = 0;
        //    string strTipoDni = "";
        //    int intTipoDni = 0;
        //    string strNombre = "";
        //    string strCuit = "";
        //    string strDireccion = "";
        //    decimal decPrecio = 0;
        //    decimal decAlicuota = 0;
        //    decimal decTotal = 0;

        //    string descuento = "";
        //    string porcentaje_descuento = "";
        //    string recargo = "";
        //    string porcentaje_recargo = "";

        //    string strNumero_comprobante_original = "";
        //    strNumero_comprobante_original = txtFacturaAsociada.Text;

        //    DataTable odtCliente = new DataTable();

        //    odtCliente = oCliente.GetOne_2(Convert.ToInt32(lblid_cliente.Text));

        //    if (odtCliente.Rows.Count > 0)
        //    {
        //        DataRow rowCliente = odtCliente.Rows[0];
        //        intCondicionIva = Convert.ToInt32(rowCliente["id_condicion_iva"]);

        //        strCuit = Convert.ToString(rowCliente["numero_dni_cuit"]);
        //        intTipoDni = Convert.ToInt32(rowCliente["id_tipo_dni"]);
        //        strNombre = Convert.ToString(rowCliente["nombre_cliente"]);
        //        strDireccion = Convert.ToString(rowCliente["direccion"]);

        //        ////opedido.GetOne(Convert.ToInt32(txtPedido.Text));
        //        descuento = "0";
        //        porcentaje_descuento = "0";

        //        switch (intCondicionIva)
        //        {
        //            case 1:
        //                //'F = CONSUMIDOR FINAL
        //                strCondicionIva = "F";
        //                break;
        //            case 2:
        //                //'E = EXENTO
        //                strCondicionIva = "E";
        //                break;
        //            case 3:
        //                //'N = NO RESPONSABLE
        //                strCondicionIva = "N";
        //                break;
        //            case 4:
        //                //'I = IVA RESPONSABLE INSCRIPTO
        //                strCondicionIva = "I";
        //                break;
        //            case 5:
        //                //'M = RESPONSABLE MONOTRIBUTO
        //                strCondicionIva = "M";
        //                break;
        //        }

        //        switch (intTipoDni)
        //        {
        //            //1	DNI
        //            case 1:
        //                strTipoDni = "DNI";
        //                break;
        //            //2	CUIL
        //            case 2:
        //                strTipoDni = "CUIL";
        //                break;
        //            //3	CUIT
        //            case 3:
        //                strTipoDni = "CUIT";
        //                break;
        //            //4	Libreta de Enrolamiento
        //            case 4:
        //                strTipoDni = "NDOC";
        //                break;
        //            //5	Libreta Civica
        //            case 5:
        //                strTipoDni = "NDOC";
        //                break;
        //            //6	Pasaporte
        //            case 6:
        //                strTipoDni = "NDOC";
        //                break;
        //            //7	Cedula
        //            case 7:
        //                strTipoDni = "NDOC";
        //                break;
        //        }

        //        nError = IFiscal.IF_OPEN(Inicio.vgPuertoFiscal, 9600);

        //        nError = IFiscal.IF_WRITE("@FACTABRE|M|C|A|1|P|10|I|" + strCondicionIva + "|" + strNombre + "||" + strTipoDni + "|" + strCuit + "|N|" + strDireccion + "|||" + strNumero_comprobante_original + "||C");
        //        //nError = IFiscal.IF_WRITE("@FACTABRE|M|C|B|1|P|10|I|" + strCondicionIva + "|" + strNombre + "||" + strTipoDni + "|" + strCuit + "|N|" + strDireccion + "|||" + strNumero_comprobante_original + "||C");
        //        //nError = IFiscal.IF_WRITE("@FACTABRE|T|C|B|1|P|10|I|" + strCondicionIva + "|" + strNombre + "||" + strTipoDni + "|" + strCuit + "|N|" + strDireccion + "|||" + "-" + "||C");
        //        //nError = IFiscal.IF_WRITE("@TIQUEABRE|B|");

        //        DataTable odtCuerpo = new DataTable();
        //        odtCuerpo = ocuerpo_pedido.GetAllPrintTicket(Convert.ToInt32(txtPedido.Text));
        //        decTotal = 0;

        //        //imprimo cuerpos
        //        foreach (DataRow row in odtCuerpo.Rows)
        //        {
        //            string strCantidad = "";
        //            string strProducto = "";
        //            string strPrecio = "";
        //            string strAlicuota = "";
        //            int largo = 0;

        //            strProducto = Convert.ToString(row["articulo"]);
        //            largo = strProducto.Length;
        //            if (largo > 20)
        //            {
        //                strProducto = strProducto.Substring(0, 20);
        //            }
        //            decTotal = decTotal + (Convert.ToInt32(row["cantidad"]) * Convert.ToDecimal(row["Precio"]));

        //            // alicuota del 21%
        //            decAlicuota = Convert.ToDecimal(0.21);
        //            strAlicuota = Convert.ToString(decAlicuota);

        //            decPrecio = Convert.ToDecimal(row["precio"]);
        //            strPrecio = Convert.ToString(decPrecio / (1 + decAlicuota));
        //            strPrecio = strPrecio.Replace(",", ".");
        //            strAlicuota = strAlicuota.Replace(",", ".");
        //            strCantidad = Convert.ToString(row["cantidad"]);
        //            strCantidad = strCantidad.Replace(",", ".");

        //            nError = IFiscal.IF_WRITE("@FACTITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|" + strAlicuota + "|M|1|0||||0|0");

        //            //nError = IFiscal.IF_WRITE("@FACTITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0||||0|0");
        //            //nError = IFiscal.IF_WRITE("@TIQUEITEM|" + strProducto + "|" + strCantidad + "|" + strPrecio + "|0.21|M|1|0|0");
        //        }

        //        //si hay descuento imprimo
        //        if (descuento != "")
        //        {
        //            if (Convert.ToDecimal(descuento) > 0)
        //            {
        //                nError = IFiscal.IF_WRITE("@FACTPAGO|DESCUENTO % " + porcentaje_descuento + "|" + descuento.Replace(",", ".") + "|D");
        //                //nError = IFiscal.IF_WRITE("@TIQUEPAGO|DESCUENTO % " + porcentaje_descuento + "|" + descuento.Replace(",", ".") + "|D");
        //            }
        //        }

        //        //imprimo total
        //        nError = IFiscal.IF_WRITE("@FACTSUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
        //        //nError = IFiscal.IF_WRITE("@FACTSUBTOTAL|SubTotal|" + Convert.ToString(decTotal));
        //        //nError = IFiscal.IF_WRITE("@TIQUESUBTOTAL|SubTotal|" + Convert.ToString(decTotal));

        //        string strImporte = "";
        //        bool bandContado = false;
        //        bool bandTarjeta = false;
        //        bool bandCC = false;
        //        bool bandCheque = false;
        //        bool bandTicket = false;

        //        //DataTable odtPago = new DataTable();
        //        //odtPago = oPago_Pedido.GetAllVenta(Convert.ToInt32(txtPedido.Text));

        //        ////imprimo los pagos
        //        //foreach (DataRow rowPago in odtPago.Rows)
        //        //{
        //        //    switch (Convert.ToString(rowPago["Tipo"]))
        //        //    {
        //        //        case "Contado":

        //        strImporte = txtPago.Text;
        //        strImporte = strImporte.Replace(",", ".");
        //        if (Convert.ToDecimal(strImporte) != 0 & bandContado == false)
        //        {
        //            bandContado = true;
        //            nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO CONTADO|" + strImporte + "|T|");
        //            //nError = IFiscal.IF_WRITE("@FACTPAGO|PAGO CONTADO|" + strImporte + "|T|");
        //            //nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO CONTADO|" + strImporte + "|T|");
        //        }

        //        //            break;
        //        //        case "Tarjeta":
        //        //            strImporte = Convert.ToString(rowPago["importe"]);
        //        //            strImporte = strImporte.Replace(",", ".");
        //        //            if (Convert.ToDecimal(strImporte) != 0 & bandTarjeta == false)
        //        //            {
        //        //                bandTarjeta = true;
        //        //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TARJETA|" + strImporte + "|T|");
        //        //            }

        //        //            break;
        //        //        case "Cuenta Corriente":
        //        //            strImporte = Convert.ToString(rowPago["importe"]);
        //        //            strImporte = strImporte.Replace(",", ".");
        //        //            if (Convert.ToDecimal(strImporte) != 0 & bandCC == false)
        //        //            {
        //        //                bandCC = true;
        //        //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CUENTA CORRIENTE|" + strImporte + "|T|");
        //        //            }

        //        //            break;

        //        //        case "Cheque":
        //        //            strImporte = Convert.ToString(rowPago["importe"]);
        //        //            strImporte = strImporte.Replace(",", ".");
        //        //            if (Convert.ToDecimal(strImporte) != 0 & bandCheque == false)
        //        //            {
        //        //                bandCheque = true;
        //        //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|CHEQUE|" + strImporte + "|T|");
        //        //            }

        //        //            break;

        //        //        case "Ticket":
        //        //            strImporte = Convert.ToString(rowPago["importe"]);
        //        //            strImporte = strImporte.Replace(",", ".");
        //        //            if (Convert.ToDecimal(strImporte) != 0 & bandTicket == false)
        //        //            {
        //        //                bandTicket = true;
        //        //                nError = IFiscal.IF_WRITE("@TIQUEPAGO|PAGO TICKET|" + strImporte + "|T|");
        //        //            }

        //        //            break;
        //        //    }
        //        //}

        //        nError = IFiscal.IF_WRITE("@FACTCIERRA|M|A|FINAL");
        //        //nError = IFiscal.IF_WRITE("@FACTCIERRA|M|B|FINAL");
        //        //nError = IFiscal.IF_WRITE("@FACTCIERRA|T|B|FINAL");
        //        //nError = IFiscal.IF_WRITE("@TIQUECIERRA|T");
        //        nError = IFiscal.IF_CLOSE();
        //        IFiscal = null;


        //    }


        //}







        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //si cancelo borro todo los pagos de la grilla
            
            //foreach (DataGridViewRow row in dgvPago_pedido.Rows)
            //{
            //    oPago_Pedido.pid_pago_pedido = Inicio.id_pago_pedido;
            //    oPago_Pedido.Borrar();
            //}
            this.Close();
              
        }

        private void btnContado_Click(object sender, EventArgs e)
        {
            BotonesFunciones_Click(sender, e);
        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            BotonesFunciones_Click(sender, e);
        }

        private void btnCheque_Click(object sender, EventArgs e)
        {
            BotonesFunciones_Click(sender, e);
        }

        private void dgvPago_pedido_CurrentCellChanged_1(object sender, EventArgs e)
        {
            try
            {
                bool res = int.TryParse(this.dgvPago_pedido[0, this.dgvPago_pedido.CurrentRow.Index].Value.ToString(), out Inicio.id_pago_pedido );
            }
            catch
            {

            }
        }
        //dandole color a los botones
        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Properties.Resources._1button_click;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Properties.Resources._1button_hover;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Properties.Resources._1button;
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Properties.Resources._1button_hover;
        }

        private void frmPago_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1 ) 
            {
                DataTable odt = null;
                odt = oPago_Pedido.GetAllVenta(Inicio.id_pedido);

                //controlo efectivo duplicado
                foreach (DataRow row in odt.Rows)
                {
                    if (Convert.ToString(row["Tipo"]) == "Contado")
                    {
                        MessageBox.Show("Ya ingreso un monto en efectivo.", "Advertencia", MessageBoxButtons.OK
                            , MessageBoxIcon.Information);
                        return;
                    }
                }
                frmFormaPagoContado contado = new frmFormaPagoContado();
                Inicio.id_forma_pago = 2;
                this.AddOwnedForm(contado);
                contado.ShowDialog();
                RefrescarGrillaPago();
            }
            if (e.KeyData == Keys.F2) 
            {
                frmFormaPagoTarjeta tarjeta = new frmFormaPagoTarjeta();
                Inicio.id_forma_pago = 3;
                this.AddOwnedForm(tarjeta);
                tarjeta.ShowDialog();
                RefrescarGrillaPago();
            }
            if (e.KeyData == Keys.F3) 
            {
                frmFormaPagoCheque cheque = new frmFormaPagoCheque();
                Inicio.id_forma_pago = 4;
                this.AddOwnedForm(cheque);
                cheque.ShowDialog();
                RefrescarGrillaPago();
            }
            if(dgvPago_pedido.Focused)
            {
                if (e.KeyData == Keys.Delete) 
                {
                    if (Inicio.id_pago_pedido != 0) 
                    {
                        oPago_Pedido.pid_pago_pedido = Inicio.id_pago_pedido;
                        oPago_Pedido.Borrar();
                        RefrescarGrillaPago();
                    }
                }
            }
        }

        private void lblMulti_Ticket_Click(object sender, EventArgs e)
        {
            if (dgvPago_pedido.Rows.Count != 0)
            {
                oPago_Pedido.pid_pedido = Inicio.id_pedido;
                oPago_Pedido.BorrarporPedido();
            }
            frmMultiTicket multi = new frmMultiTicket();
            this.AddOwnedForm(multi);
            multi.ShowDialog();
        }

        private void txtPedido_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

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
    }
}
