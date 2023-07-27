using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion_gastronomica.Formularios
{
    public partial class frmMultiTicket : Form
    {
        const int tam = 1000;
        Clase.clsCuerpo_Pedido[] vp = new Clase.clsCuerpo_Pedido[tam];
        //vector alternativo para segunda lista
        Clase.clsTemp_Ticket[] vTicket = new Clase.clsTemp_Ticket[tam];
        //*Clases utiles
        Clase.clsCuerpo_Pedido oCuerpo_Pedido = new Clase.clsCuerpo_Pedido();
        Clase.clsProducto oProducto = new Clase.clsProducto();
        Clase.clsPedido opedido = new Clase.clsPedido();
        Clase.clsMesa omesa = new Clase.clsMesa();
        Clase.clsTemp_Ticket oTemp_ticket = new Clase.clsTemp_Ticket();


        List<Clase.clsCuerpo_Pedido> lstCuerpo_pedido = new List<Clase.clsCuerpo_Pedido>();

        //vector para la segunda lista
        int c = 0;
        public frmMultiTicket()
        {
            InitializeComponent();
        }

        private void frmMultiTicket_Load(object sender, EventArgs e)
        {
            this.txtporcentajedescuento.Text = "0";
            this.txtdescuento.Text = "0,00";
            this.txtsubtotal_LstTicket.Text = "0,00";
            this.MaximizeBox = false;
            //this.ControlBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            opedido.GetOne(Inicio.id_pedido);
            omesa.GetOne(opedido.pid_mesa);

            txttotal_lstGeneral.Text = Convert.ToString(opedido.pimporte);
            this.txtPedido.Text = Convert.ToString(Inicio.id_pedido);
            this.txtMesa.Text = omesa.pnombre_mesa;

            CargarListaGeneral();

            
        }
        /// <summary>
        /// Existen dos CargarLista General
        /// El primero CARGARLISTAGENERAL se encarga de llenar la lista con los datos del pedido
        /// en tanto la segunda RECARGARLISTAGENERAL se encarga de ir de forma mas independiente al pedido
        /// principal. y trabajando con el vector creado en CARGARLISTAGENERAL
        /// como sucede con el cargarTicket
        /// </summary>
        /// 

        public void CargarListaGeneral()
        {
            DataTable odt = oCuerpo_Pedido.GetMesa_2(Inicio.id_mesa);
            c = 0;
            foreach (DataRow row in odt.Rows)
            {
                vp[c] = new Clase.clsCuerpo_Pedido();
                vp[c].pid_cuerpo_pedido = Convert.ToInt32(row["id cuerpo pedido"]);
                vp[c].pid_pedido = Convert.ToInt32(row["id pedido"]);
                vp[c].pid_producto = Convert.ToInt32(row["id_producto"]);
                vp[c].pcantidad = Convert.ToInt32(row["cantidad"]);
                vp[c].pprecio = Convert.ToDouble(row["precio"]);
                c++;
            }
            lstGeneral.Items.Clear();
            for (int i = 0; i < c; i++)
            {
                oProducto.GetOne(vp[i].pid_producto);
                lstGeneral.Items.Add(oProducto.pnombre_producto + " - " + vp[i].pcantidad);
            }
        }
     
        public void RecargarListaGeneral() 
        {
            lstGeneral.Items.Clear();
            for (int i = 0; i < vp.Length; i++)
            {
                if(vp[i] != null)
                {
                    oProducto.GetOne(vp[i].pid_producto);
                    lstGeneral.Items.Add(oProducto.pnombre_producto + " - " + vp[i].pcantidad);
                }
            }
        }
        public void CargarListaTickect() 
        {
            lstTicket.Items.Clear();
            for (int i = 0; i < vTicket.Length; i++)
            {
                if(vTicket[i] != null)
                {
                    oProducto.GetOne(vTicket[i].pid_producto);
                    lstTicket.Items.Add(oProducto.pnombre_producto + " - " + vTicket[i].pcantidad);
                }
            }
        }
        private void btnpasar_Click(object sender, EventArgs e)
        {
            if (lstGeneral.SelectedIndex != -1) 
            {
                int index = lstGeneral.SelectedIndex;
                int cant = lstTicket.Items.Count;
                int i = lstGeneral.SelectedIndex;
                int vec = -1;

                //recorro el vector de la lista secundaria
                for (int i2 = 0; i2 < vTicket.Length; i2++)
                {
                    //coloco a vec en -1 por si sale sin entrar al if
                    //puedo identificar que no existe ningun producto igual al que se va a pasar
                    //dado que los vectores tienen indice 0
                    if (vTicket[i2] != null)
                    {
                        if(vTicket[i2].pid_producto == vp[i].pid_producto)
                        {
                            //si existe me va a guardar el indice que luego uso
                            vec = i2;
                        }
                    }
                }
                if (vec == -1)//no existe el producto a pasar en la lista secundaria
                {//AGREGAMOS UNO NUEVO
                    vTicket[cant] = new Clase.clsTemp_Ticket();
                    vTicket[cant].pid_cuerpo_pedido = vp[i].pid_cuerpo_pedido;
                    vTicket[cant].pid_pedido = vp[i].pid_pedido;
                    vTicket[cant].pid_producto = vp[i].pid_producto;
                    vTicket[cant].pcantidad = 1;
                    vTicket[cant].pprecio = vp[i].pprecio;
                    oProducto.GetOne(vTicket[cant].pid_producto);
                    lstTicket.Items.Add(oProducto.pnombre_producto + " - " + vTicket[cant].pcantidad);
                    if (vp[i].pcantidad == 1)//si es el unico articulo lo removemos de lstgeneral
                    {
                        lstGeneral.Items.Remove(lstGeneral.SelectedItem);
                        //limpio mi vector con el dato pasado
                        vp[i] = null;
                        //re armo el vector quitando los espacios en nulos
                        vp = vp.Where(c => c != null).ToArray();
                        //le vuelvo a colocar el tamaño inicial al vector
                        Array.Resize(ref vp, tam);
                    }
                    else 
                    {
                        vp[i].pcantidad -= 1; // si no removemos uno
                        RecargarListaGeneral();
                    }
                    
                }
                else//si ya existe
                {//agregamos +1 al vector en la posicion de vec que trae el indice
                    vTicket[vec].pcantidad += 1;
                    CargarListaTickect();

                    if (vp[i].pcantidad == 1)//si es el unico articulo lo removemos de lstgeneral
                    {
                        lstGeneral.Items.Remove(lstGeneral.SelectedItem);
                        //limpio mi vector con el dato pasado
                        vp[i] = null;
                        //re armo el vector quitando los espacios en nulos
                        vp = vp.Where(c => c != null).ToArray();
                        Array.Resize(ref vp, tam);
                    }
                    else
                    {
                        vp[i].pcantidad -= 1; // si no removemos uno
                        RecargarListaGeneral();
                    }
                }
                //Cambio el index para dejarlo posicionado en el siguente
                if(lstGeneral.Items.Count > 0)
                {
                    try
                    {
                        this.lstGeneral.SelectedIndex = index;
                    }
                    catch (Exception)
                    {
                        this.lstGeneral.SelectedIndex = 0;
                    }
                }
                //Actualizo el total
                ActualizarTotales();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (lstTicket.SelectedIndex != -1)
            {
                int index = lstTicket.SelectedIndex;
                int cant = lstGeneral.Items.Count;
                int i = lstTicket.SelectedIndex;
                int vec = -1;

                //recorro el vector de la lista General
                for (int i2 = 0; i2 < vp.Length; i2++)
                {
                    //coloco a vec en -1 por si sale sin entrar al if
                    //puedo identificar que no existe ningun producto igual al que se va a pasar
                    //dado que los vectores tienen indice 0
                    if (vp[i2] != null)
                    {
                        if (vp[i2].pid_producto == vTicket[i].pid_producto)
                        {
                            //si existe me va a guardar el indice que luego uso
                            vec = i2;
                        }
                    }
                }
                if (vec == -1)//no existe el producto a pasar en la lista general
                {//AGREGAMOS UNO NUEVO
                    vp[cant] = new Clase.clsCuerpo_Pedido();
                    vp[cant].pid_cuerpo_pedido = vTicket[i].pid_cuerpo_pedido;
                    vp[cant].pid_pedido = vTicket[i].pid_pedido;
                    vp[cant].pid_producto = vTicket[i].pid_producto;
                    vp[cant].pcantidad = 1;
                    vp[cant].pprecio = vTicket[i].pprecio;
                    oProducto.GetOne(vp[cant].pid_producto);
                    lstGeneral.Items.Add(oProducto.pnombre_producto + " - " + vp[cant].pcantidad);
                    if (vTicket[i].pcantidad == 1)//si es el unico articulo lo removemos de lstTicket
                    {
                        lstTicket.Items.Remove(lstTicket.SelectedItem);
                        //limpio mi vector con el dato pasado
                        vTicket[i] = null;
                        //re armo el vector quitando los espacios en nulos
                        vTicket = vTicket.Where(c => c != null).ToArray();
                        //re armo el vector quitando los espacios en nulos
                        Array.Resize(ref vTicket, tam);
                    }
                    else
                    {
                        vTicket[i].pcantidad -= 1; // si no removemos uno
                        CargarListaTickect();
                    }

                }
                else//si ya existe
                {//agregamos +1 al vector en la posicion de vec que trae el indice
                    vp[vec].pcantidad += 1;
                    RecargarListaGeneral();

                    if (vTicket[i].pcantidad == 1)//si es el unico articulo lo removemos de lstgeneral
                    {
                        lstTicket.Items.Remove(lstTicket.SelectedItem);
                        //limpio mi vector con el dato pasado
                        vTicket[i] = null;
                        //re armo el vector quitando los espacios en nulos
                        vTicket = vTicket.Where(c => c != null).ToArray();
                        //re armo el vector quitando los espacios en nulos
                        Array.Resize(ref vTicket, tam);
                    }
                    else
                    {
                        vTicket[i].pcantidad -= 1; // si no removemos uno
                        CargarListaTickect();
                    }
                }
                if (lstTicket.Items.Count > 0)
                {
                    try
                    {
                        this.lstTicket.SelectedIndex = index;
                    }
                    catch (Exception)
                    {
                        this.lstTicket.SelectedIndex = 0;
                    }
                    
                }
                ActualizarTotales();
            }
        }

        private void btnPasarTodo_Click(object sender, EventArgs e)
        {
           if(lstGeneral.Items.Count == 0)
           {
               return;
           }
            
            //recorro el vector de la general
            for (int ivp = 0; ivp < vp.Length; ivp++)
            {
                if (vp[ivp] == null)
                {
                    break;
                }
                int vec = -1;
                int cant = lstTicket.Items.Count;
                //recorro el vector del ticket para identificar si debo agregar o modificar dependiendo del vector general
                for (int ivticket = 0; ivticket < vTicket.Length; ivticket++)
                {
                    //coloco a vec en -1 por si sale sin entrar al if
                    //puedo identificar que no existe ningun producto igual al que se va a pasar
                    //dado que los vectores tienen indice 0
                    if (vTicket[ivticket] != null)
                    {
                        if (vTicket[ivticket].pid_producto == vp[ivp].pid_producto)
                        {
                            //si existe me va a guardar el indice que luego uso
                            vec = ivticket;
                        }
                    }
                }
                if (vec == -1)//no existe el producto a pasar en la lista secundaria
                {//AGREGAMOS UNO NUEVO
                    vTicket[cant] = new Clase.clsTemp_Ticket();
                    vTicket[cant].pid_cuerpo_pedido = vp[ivp].pid_cuerpo_pedido;
                    vTicket[cant].pid_pedido = vp[ivp].pid_pedido;
                    vTicket[cant].pid_producto = vp[ivp].pid_producto;
                    vTicket[cant].pcantidad = vp[ivp].pcantidad;
                    vTicket[cant].pprecio = vp[ivp].pprecio;
                    oProducto.GetOne(vTicket[cant].pid_producto);
                    lstTicket.Items.Add(oProducto.pnombre_producto + " - " + vTicket[cant].pcantidad);

                }
                else//si ya existe
                {//agregamos +1 al vector en la posicion de vec que trae el indice
                    vTicket[vec].pcantidad += vp[ivp].pcantidad;
                    
                }
            }
            Array.Clear(vp,0,vp.Length);
            CargarListaTickect();
            RecargarListaGeneral();
            ActualizarTotales();
        }

        private void btnVolverTodo_Click(object sender, EventArgs e)
        {
            if (lstTicket.Items.Count == 0)
            {
                return;
            }
            //recorro el vector de la general
            for (int ivticket = 0; ivticket < vTicket.Length; ivticket++)
            {
                if (vTicket[ivticket] == null)
                {
                    break;
                }
                int vec = -1;
                int cant = lstGeneral.Items.Count;
                //recorro el vector del general para identificar si debo agregar o modificar dependiendo del vector ticket
                for (int ivp = 0; ivp < vp.Length; ivp++)
                {
                    //coloco a vec en -1 por si sale sin entrar al if
                    //puedo identificar que no existe ningun producto igual al que se va a pasar
                    //dado que los vectores tienen indice 0
                    if (vp[ivp] != null)
                    {
                        if (vp[ivp].pid_producto == vTicket[ivticket].pid_producto)
                        {
                            //si existe me va a guardar el indice que luego uso
                            vec = ivp;
                        }
                    }
                }
                if (vec == -1)//no existe el producto a pasar en la lista general
                {//AGREGAMOS UNO NUEVO

                    vp[cant] = new Clase.clsCuerpo_Pedido();
                    vp[cant].pid_cuerpo_pedido = vTicket[ivticket].pid_cuerpo_pedido;
                    vp[cant].pid_pedido = vTicket[ivticket].pid_pedido;
                    vp[cant].pid_producto = vTicket[ivticket].pid_producto;
                    vp[cant].pcantidad = vTicket[ivticket].pcantidad;
                    vp[cant].pprecio = vTicket[ivticket].pprecio;

                    oProducto.GetOne(vp[cant].pid_producto);
                    lstGeneral.Items.Add(oProducto.pnombre_producto + " - " + vp[cant].pcantidad);


                }
                else//si ya existe
                {//agregamos +1 al vector en la posicion de vec que trae el indice
                    vp[vec].pcantidad += vTicket[ivticket].pcantidad;
                }
            }
            Array.Clear(vTicket, 0, vTicket.Length);
            CargarListaTickect();
            RecargarListaGeneral();
            ActualizarTotales();
        }

        public void ActualizarTotales() 
        {
            double tota_lstGeneral = 0;
            double total_lstTicket = 0;

            for (int i = 0; i < vp.Length; i++)
            {
                if (vp[i] != null)
                {
                    oProducto.GetOne(vp[i].pid_producto);
                    tota_lstGeneral += oProducto.pprecio * vp[i].pcantidad;
                }
            }
            for (int i = 0; i < vTicket.Length; i++)
            {
                if (vTicket[i] != null)
                {
                    oProducto.GetOne(vTicket[i].pid_producto);
                    total_lstTicket += oProducto.pprecio * vTicket[i].pcantidad;
                }
            }
            this.txttotal_lstGeneral.Text = tota_lstGeneral.ToString();
            this.txtsubtotal_LstTicket.Text = total_lstTicket.ToString();
            this.txttotal_lstTicket.Text = Convert.ToString(Convert.ToDouble(this.txtsubtotal_LstTicket.Text) - Convert.ToDouble(txtdescuento.Text));
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
                        resultado = (Convert.ToDecimal(this.txtsubtotal_LstTicket.Text) * Convert.ToDecimal(this.txtporcentajedescuento.Text)) / 100;
                        txtdescuento.Text = Convert.ToString(resultado);

                        //txttotal.Text = Strings.FormatNumber(Convert.ToDouble(txtsubtotal.Text) - Convert.ToDouble(txtDescuento.Text), 2);
                        this.txttotal_lstTicket.Text = Convert.ToString(Convert.ToDouble(this.txtsubtotal_LstTicket.Text) - Convert.ToDouble(txtdescuento.Text));

                        //this.txtvuelto.Text = Convert.ToString(Convert.ToDouble(txtpago.Text) - Convert.ToDouble(txttotal_lstTicket.Text));

                        if (Convert.ToDouble(txtporcentajedescuento.Text) == 100)
                        {
                            //txtvuelto.Text = Convert.ToString(0);
                            //txtpago.Text = Convert.ToString(0);

                            if (Inicio.id_pago_pedido == 0)
                            {
                                return;
                            }
                            //oPago_Pedido.pid_pedido = Inicio.id_pedido;
                            //oPago_Pedido.BorrarporPedido();
                            //RefrescarGrillaPago();
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
            RestarTextbox(sender,e);
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            if (lstTicket.Items.Count == 0)
            {
                MessageBox.Show("La Lista debe tener al menos 1 producto", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            //Limpio por cada ticket
            oTemp_ticket.Truncate();
            //recorro el vector. para dejar los datos de la lista en la tabla
            for (int i = 0; i < vTicket.Length; i++)
            {
                if (vTicket[i] != null)
                {
                    //Genero un nuevo registro
                    oTemp_ticket.pid_cuerpo_pedido = vTicket[i].pid_cuerpo_pedido;
                    oTemp_ticket.pid_pedido = vTicket[i].pid_pedido;
                    oTemp_ticket.pid_producto = vTicket[i].pid_producto;
                    oTemp_ticket.pprecio = vTicket[i].pprecio;
                    oTemp_ticket.pcantidad = vTicket[i].pcantidad;
                    oTemp_ticket.pdescuento = Convert.ToDouble(this.txtdescuento.Text);
                    oTemp_ticket.pimporte = Convert.ToDouble(this.txtsubtotal_LstTicket.Text);
                    oTemp_ticket.pporcentaje_descuento = Convert.ToDouble(this.txtporcentajedescuento.Text);
                    oTemp_ticket.ptotals = Convert.ToDouble(this.txttotal_lstTicket.Text);
                    oTemp_ticket.Insertar();
                }
            }
            Reporte.rptCierrePedido CierrePedido = new Reporte.rptCierrePedido();
            CierrePedido.SetDataSource(oTemp_ticket.GetReporte(Inicio.id_pedido));
            Inicio.printCrystalReport(CierrePedido, 1, 0, 0, "rptCierrePedido");
        }

    }//end
}
