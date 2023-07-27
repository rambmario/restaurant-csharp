using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
using FiscalNET;

namespace Gestion_gastronomica.Formularios
{
    public partial class frmPedido : Form
    {
        public frmPedido()
        {
            InitializeComponent();
        }
        #region -> Variables Generales
        Clase.clsPedido opedido = new Clase.clsPedido();
        Clase.clsCuerpo_Pedido ocuerpo_pedido = new Clase.clsCuerpo_Pedido();
        Clase.clsMesa omesa = new Clase.clsMesa();
        Clase.clsTipo_Producto otipo_producto = new Clase.clsTipo_Producto();
        Clase.clsProducto oproducto = new Clase.clsProducto();
        Clase.clsGrupo_Producto ogrupo_producto = new Clase.clsGrupo_Producto();
        Clase.clsTemp_Pedido oTemp_Pedido = new Clase.clsTemp_Pedido();
        Clase.clsReserva_Mesa oReserva_Mesa = new Clase.clsReserva_Mesa();
        Clase.clsReserva_Hora oReserva_Hora = new Clase.clsReserva_Hora();
        Clase.clsCaja oCaja = new Clase.clsCaja();
        //DataTable odt = null;
        int borrar = 0;
        int MostrarReservar = 0;
        int id_producto_seleccionado = 0;
        //Variables Utiles
        string Estados_Mesa;
        string reserva_hora_seleccionada = "";
        #endregion

        private void frmPedido_Load(object sender, EventArgs e)
        {
            //Set tt
            ttGeneral.SetToolTip(this.btnAgregar, "Agregar productos al pedido");
            ttGeneral.SetToolTip(this.btnModificar, "Modificar el pedido");
            ttGeneral.SetToolTip(this.btnBorrar, "Borrar el producto seleccionado");



            RefrescarGrillaGrupo_Producto();
            RefrescarGrillaTipo_Producto();
            RefrescarGrillaProducto();

            RefrescarGrillaCuerpo_Pedido();
            RefrescarGrillaMesa();

            DataTable odt = omesa.GetAll();
            Inicio.id_mesa = Convert.ToInt32(odt.Rows[0][0]);
            this.dgvMesa.CurrentCell = this.dgvMesa.Rows[0].Cells[1];

            RefrescarTotales();
            RefrescarReservas();
            RefrescarGrillaReserva_Hora();
            Color_Caja();
            CargarComboProducto();
            this.StartPosition = FormStartPosition.CenterScreen;
            Inicio.parametro_Boton_Click_Reserva = 1;
            this.lblfecha_actual.Text = "(" + DateTime.Now.ToString("d") + ")";
            this.lblhora_actual.Text = DateTime.Now.ToString("H:mm:ss");
            tbPrincipal.SelectedTab = tpPedido;
            this.dgvMesa.Focus();
            //this.BackgroundImage = Properties.Resources.Fondo;


            //dandole color a los botones
            //pintar los botones del load
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
            //pintar los botones de la pestaña pedido
            var buttons2 = tpPedido.Controls.OfType<Button>();
            foreach (var button in buttons2)
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

            //pintar los botones de la pestaña Reservaciones
            var buttons3 = tpReservas.Controls.OfType<Button>();
            foreach (var button in buttons3)
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

        }

        #region -> Metodos Utilies(Grillas, Labels, Botones)

        private void CargarComboProducto()
        {
            DataTable odt = new DataTable();
            odt = oproducto.GetCmb();
            cmbBuscarProducto.DataSource = odt;
            cmbBuscarProducto.DisplayMember = "nombre_producto";
            cmbBuscarProducto.ValueMember = "id_producto";
            if (this.cmbBuscarProducto.SelectedIndex >= 0)
            {
                this.cmbBuscarProducto.SelectedIndex = 0;
                id_producto_seleccionado = Convert.ToInt32(cmbBuscarProducto.SelectedValue);
            }

        }

        public void RefrescarGrillas()
        {
            RefrescarGrillaGrupo_Producto();
            RefrescarGrillaMesa();
            RefrescarGrillaCuerpo_Pedido();
            RefrescarGrillaProducto();
            RefrescarGrillaTipo_Producto();
            RefrescarGrillaReserva_Hora();
            RefrescarTotales();
        }
        //metodo para refrescar (actualizar) grillas, dependientes de las tablas MESA, PEDIDO Y CUERPO_PEDIDO
        public void RefrescarGrillaMesa()
        {
            DataTable odt = null;
            odt = omesa.GetAll();
            this.dgvMesa.DataSource = odt;
            this.dgvMesa.Columns[0].Visible = false;
            this.dgvMesa.Columns["Id_reserva"].Visible = false;
            this.dgvMesa.Columns["grupo_mesa"].Visible = false;
            this.dgvMesa.Columns["cantidad_persona"].Visible = false;
            this.dgvMesa.AllowUserToAddRows = false;
        }

        public void RefrescarGrillaGrupo_Producto()
        {
            DataTable odt = null;
            odt = ogrupo_producto.GetAll_2();
            this.dgvgrupotipoproducto.DataSource = odt;
            this.dgvgrupotipoproducto.Columns[0].Visible = false;
            this.dgvgrupotipoproducto.AllowUserToAddRows = false;
        }

        public void RefrescarGrillaTipo_Producto()
        {
            DataTable odt = null;
            odt = otipo_producto.GetGrupo_Producto(Inicio.id_grupo_Producto);
            this.dgvtipoproducto.DataSource = odt;
            this.dgvtipoproducto.Columns[0].Visible = false;
            this.dgvtipoproducto.AllowUserToAddRows = false;
        }

        public void RefrescarGrillaProducto()
        {
            DataTable odt = null;
            odt = oproducto.GetTipo_Pedido(Inicio.id_tipo_producto);
            this.dgvproducto.DataSource = odt;
            this.dgvproducto.Columns[0].Visible = false;
            this.dgvproducto.AllowUserToAddRows = false;
            if (odt.Rows.Count == 0)
            {
                Inicio.id_Producto = 0;
            }
        }

        public void RefrescarGrillaCuerpo_Pedido()
        {
            try
            {
                dgvdetalle.DefaultCellStyle.SelectionBackColor = Color.MidnightBlue;
                dgvdetalle.DefaultCellStyle.SelectionForeColor = Color.White;
                dgvdetalle.Columns[3].DefaultCellStyle.SelectionBackColor = Color.MidnightBlue;
                foreach (DataGridViewRow row in dgvdetalle.Rows)
                {
                    dgvdetalle.Rows[row.Index].DefaultCellStyle.Font =
                        new Font(DataGridView.DefaultFont, FontStyle.Regular);
                }
            }
            catch
            {
            }

            DataTable odt = null;
            //DataTable odtpedido = null;
            try
            {
                //odtpedido = opedido.GetMesa(Inicio.id_mesa);
                //int idpedido = Convert.ToInt32(odtpedido.Rows[0]["id pedido"].ToString());
                odt = ocuerpo_pedido.GetMesa(Inicio.id_mesa);
                this.dgvdetalle.DataSource = odt;
                this.dgvdetalle.Columns[0].Visible = false;
                this.dgvdetalle.Columns[1].Visible = false;
                this.dgvdetalle.AllowUserToAddRows = false;
            }
            catch (Exception)
            {
            }

        }

        public void RefrescarGrillaReserva()
        {

            DataTable odt = null;
            DateTime fecha_hora = DateTime.Now;
            if (rbtReservas_pendientes.Checked == true)
            {

                odt = oReserva_Mesa.GetAll_2(4, dtpFecha_Inicio.Value, dtpFecha_Fin.Value, Inicio.id_Reserva_Mesa, "");
                this.dgvReservas.DataSource = odt;
                this.dgvReservas.Columns[0].HeaderText = "Nº Reserva";
                this.dgvReservas.AllowUserToAddRows = false;
                foreach (DataGridViewRow row in dgvReservas.Rows)
                {
                    DateTime fecha_base = Convert.ToDateTime(row.Cells[1].Value);
                    DateTime hora_base = Convert.ToDateTime(row.Cells[2].Value);
                    DateTime fecha_hora_base = fecha_base.Add(hora_base.Subtract(hora_base.Date));
                    if (fecha_hora_base < fecha_hora)
                    {
                        dgvReservas.Rows[row.Index].DefaultCellStyle.BackColor = Color.Red;
                    }

                }
                return;
            }
            if (rbtReservas_Historicas.Checked == true)
            {
                odt = oReserva_Mesa.GetAll_2(5, dtpFecha_Inicio.Value, dtpFecha_Fin.Value, Inicio.id_Reserva_Mesa, "");
                this.dgvReservas.DataSource = odt;
                this.dgvReservas.Columns[0].HeaderText = "Nº Reserva";
                this.dgvReservas.AllowUserToAddRows = false;
                foreach (DataGridViewRow row in dgvReservas.Rows)
                {
                    DateTime fecha_base = Convert.ToDateTime(row.Cells[1].Value);
                    DateTime hora_base = Convert.ToDateTime(row.Cells[2].Value);
                    DateTime fecha_hora_base = fecha_base.Add(hora_base.Subtract(hora_base.Date));
                    if (fecha_hora_base < fecha_hora)
                    {
                        dgvReservas.Rows[row.Index].DefaultCellStyle.BackColor = Color.Red;
                    }

                }
                return;
            }
            if (rbtBusquedaRapida.Checked == true)
            {
                odt = oReserva_Mesa.GetAll_2(Inicio.parametro_Boton_Click_Reserva, dtpFecha_Inicio.Value, dtpFecha_Fin.Value, Inicio.id_Reserva_Mesa, "");
                this.dgvReservas.DataSource = odt;
                this.dgvReservas.Columns[0].HeaderText = "Nº Reserva";
                this.dgvReservas.AllowUserToAddRows = false;
                foreach (DataGridViewRow row in dgvReservas.Rows)
                {

                    DateTime fecha_base = Convert.ToDateTime(row.Cells[1].Value);
                    DateTime hora_base = Convert.ToDateTime(row.Cells[2].Value);
                    DateTime fecha_hora_base = fecha_base.Add(hora_base.Subtract(hora_base.Date));
                    if (fecha_hora_base < fecha_hora)
                    {
                        dgvReservas.Rows[row.Index].DefaultCellStyle.BackColor = Color.Red;
                    }

                }
                return;
            }

            //Este es por si se encuentra los 2 en false se realiza la busqueda segun el dia actual
            odt = oReserva_Mesa.GetAll_2(Inicio.parametro_Boton_Click_Reserva, dtpFecha_Inicio.Value, dtpFecha_Fin.Value, Inicio.id_Reserva_Mesa, reserva_hora_seleccionada);
            this.dgvReservas.DataSource = odt;
            this.dgvReservas.Columns[0].HeaderText = "Nº Reserva";
            this.dgvReservas.AllowUserToAddRows = false;

            foreach (DataGridViewRow row in dgvReservas.Rows)
            {
                DateTime fecha_base = Convert.ToDateTime(row.Cells[1].Value);
                DateTime hora_base = Convert.ToDateTime(row.Cells[2].Value);
                DateTime fecha_hora_base = fecha_base.Add(hora_base.Subtract(hora_base.Date));
                if (fecha_hora_base < fecha_hora)
                {
                    dgvReservas.Rows[row.Index].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        public void LimpiarTotales()
        {
            lblcantidadproductos.Text = "0";
            lblTotal.Text = "0";
        }

        public void RefrescarReservas()
        {
            DataTable odt = null;
            odt = oReserva_Mesa.GetDiaMesAño();

            lblreservadia.Text = Convert.ToString(odt.Rows[0]["Dia"].ToString());
            lblReservaMes.Text = Convert.ToString(odt.Rows[0]["Mes"].ToString());
            lblReservaAño.Text = Convert.ToString(odt.Rows[0]["Año"].ToString());
        }

        public void RefrescarGrillaReserva_Hora()
        {
            DataTable odt = null;
            oReserva_Hora.ResetTable();
            odt = oReserva_Hora.GetAll_2();
            foreach (DataRow item in odt.Rows)
            {
                string hora = Convert.ToString(item["Hora"]);
                DateTime fecha = DateTime.Today;
                int cantidad = oReserva_Mesa.ConsultarxHora(hora, fecha);
                if (cantidad != 0)
                {
                    int id_reseva_hora = Convert.ToInt32(item["Id_reserva_hora"]);
                    oReserva_Hora.ModificarCantidad(id_reseva_hora, cantidad);
                }
            }
            odt = oReserva_Hora.GetAll_2();
            this.dgvReserva_Hora.DataSource = odt;
            this.dgvReserva_Hora.Columns[0].Visible = false;
            this.dgvReserva_Hora.AllowUserToAddRows = false;

            /// <summary>
            /// codigo util para cambiar la letra de una columna
            /// dgvReserva_Hora.Columns[1].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            /// 
            /// 
            /// 
            /// </summary>
            /// 
            dgvReserva_Hora.Columns[1].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dgvReserva_Hora.Columns[2].DefaultCellStyle.ForeColor = Color.SkyBlue;

            foreach (DataGridViewRow row in dgvReserva_Hora.Rows)
            {

                if (row.Cells[2].Value == DBNull.Value)
                    continue;
                int cantidad = 0;
                int.TryParse(Convert.ToString(row.Cells[2].Value), out cantidad);

                if (cantidad != 0)
                {
                    if (omesa.CantRegistada() == cantidad)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        row.DefaultCellStyle.BackColor = Color.Red;

                    }
                    else
                    {
                        row.DefaultCellStyle.ForeColor = Color.Green;
                        dgvReserva_Hora.Columns[1].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                else
                {
                    dgvReserva_Hora.Columns[2].DefaultCellStyle.ForeColor = Color.SkyBlue;
                }
            }

        }

        public void RefrescarTotales()
        {
            try
            {

                //cargo el importe de pedido
                double total = 0;
                foreach (DataGridViewRow row in dgvdetalle.Rows)
                {
                    if (row.Cells[4].Value == DBNull.Value)
                        continue;
                    double valorcell = 0;
                    double.TryParse(Convert.ToString(row.Cells[4].Value), out valorcell);
                    total += Convert.ToInt32(valorcell);
                }
                this.lblTotal.Text = Convert.ToString(total);
                this.txtTotal.Text = "$" + this.lblTotal.Text;


                //saco la cantidad de producto comprados
                int sumacantidad = 0;
                foreach (DataGridViewRow row in dgvdetalle.Rows)
                {

                    if (row.Cells[3].Value == DBNull.Value)
                        continue;
                    int valorcell = 0;
                    int.TryParse(Convert.ToString(row.Cells[3].Value), out valorcell);
                    sumacantidad += Convert.ToInt32(valorcell);
                }
                lblcantidadproductos.Text = Convert.ToString(sumacantidad);
                this.txtConsumo.Text = this.lblcantidadproductos.Text;

                if (Inicio.id_pedido == 0)
                {
                    this.lblnumeropedido.Text = "0";
                    this.txtPedido.Text = "0";
                }
                else
                {
                    this.lblnumeropedido.Text = Inicio.id_pedido.ToString();
                    this.txtPedido.Text = Inicio.id_pedido.ToString();
                }
                omesa.GetOne(Inicio.id_mesa);
                this.lblNombreMesa.Text = omesa.pnombre_mesa;
            }

            catch (Exception)
            {
            }
        }
        public void RadioButton_Checked_Changed_Reservacion(object sender, EventArgs e)
        {

            RadioButton rbttemp = new RadioButton();
            rbttemp = (RadioButton)sender;

            switch (rbttemp.Name)
            {

                case "rbtDia":
                    Inicio.parametro_Boton_Click_Reserva = 1;
                    RefrescarGrillaReserva();
                    break;

                case "rbtMes":
                    Inicio.parametro_Boton_Click_Reserva = 2;
                    RefrescarGrillaReserva();
                    break;

                case "rbtAño":
                    Inicio.parametro_Boton_Click_Reserva = 3;
                    RefrescarGrillaReserva();
                    break;

                case "rbtReservas_pendientes":
                    label7.Visible = true;
                    label9.Visible = true;
                    dtpFecha_Fin.Visible = true;
                    dtpFecha_Inicio.Visible = true;
                    gbBusquedaRapida.Visible = false;
                    break;

                case "rbtReservas_Historicas":
                    label7.Visible = true;
                    label9.Visible = true;
                    dtpFecha_Fin.Visible = true;
                    dtpFecha_Inicio.Visible = true;
                    gbBusquedaRapida.Visible = false;
                    break;

                case "rbtBusquedaRapida":
                    label7.Visible = false;
                    label9.Visible = false;
                    rbtDia.Checked = true;
                    dtpFecha_Fin.Visible = false;
                    dtpFecha_Inicio.Visible = false;
                    gbBusquedaRapida.Visible = true;
                    break;
            }
            try
            {
                int i = this.dgvMesa.CurrentRow.Index;
                RefrescarGrillaReserva();
                RefrescarGrillaMesa();
                this.dgvMesa.CurrentCell = this.dgvMesa.Rows[i].Cells[1];
            }
            catch (Exception)
            {
                RefrescarGrillaReserva();
                RefrescarGrillaMesa();
            }

        }
        public void Color_Caja()
        {
            oCaja.GetOne(Inicio.parametro_id_caja);
            bool enable = false;
            if (oCaja.pcerrada == false)
            {
                cajaToolStripMenuItem.BackColor = Color.LightGreen;
                enable = true;
            }
            else
            {
                cajaToolStripMenuItem.BackColor = Color.OrangeRed;
                enable = false;
            }

            //Controlo los botones para evitar que se hagan operaciones con cajas Cerradas
            var buttons = this.Controls.OfType<Button>();

            foreach (var button in buttons)
            {
                button.Enabled = enable;
                //el resto
            }
            //pintar los botones de la pestaña pedido
            var buttons2 = tpPedido.Controls.OfType<Button>();
            foreach (var button in buttons2)
            {
                button.Enabled = enable;
                //el resto
            }

            //pintar los botones de la pestaña Reservaciones
            var buttons3 = tpReservas.Controls.OfType<Button>();
            foreach (var button in buttons3)
            {
                button.Enabled = enable;
            }


        }
        //Queda el codigo de VER POR DIA MES AÑO.
        //public void Botones_Ver_Click(object sender, EventArgs e) 
        //{
        //    Button btntemp = new Button();
        //    btntemp = (Button)sender;
        //    int i = this.dgvMesa.CurrentRow.Index;
        //    switch (btntemp.Name)
        //    {
        //        case "btnVerReservaDia":
        //            Inicio.parametro_Boton_Click_Reserva = 1;
        //            lblReserva_mostrar.Text = "Reservas del DIA ACTUAL";
        //            break;
        //        case "btnVerReservaMes":
        //            Inicio.parametro_Boton_Click_Reserva = 2;
        //            lblReserva_mostrar.Text = "Reservas del MES ACTUAL";
        //            break;
        //        case "btnVerReservaAño":
        //            Inicio.parametro_Boton_Click_Reserva = 3;
        //            lblReserva_mostrar.Text = "Reservas del AÑO ACTUAL";
        //            break;

        //    }

        //    if (MostrarReservar == 0)
        //    {
        //        gbReservas.Visible = true;
        //        this.btnVerReservaAño.Text = "Ocultar";
        //        this.btnVerReservaDia.Text = "Ocultar";
        //        this.btnVerReservaMes.Text = "Ocultar";
        //        RefrescarGrillaReserva();
        //        RefrescarGrillaMesa();
        //        MostrarReservar = 1;
        //    }
        //    else
        //    {
        //        gbReservas.Visible = false;
        //        this.btnVerReservaAño.Text = "Ver Reserva";
        //        this.btnVerReservaDia.Text = "Ver Reserva";
        //        this.btnVerReservaMes.Text = "Ver Reserva";
        //        RefrescarGrillaMesa();
        //        RefrescarGrillaReserva();
        //        MostrarReservar = 0;
        //    }
        //    this.dgvMesa.CurrentCell = this.dgvMesa.Rows[i].Cells[1];
        //    RefrescarGrillaReserva_Hora();
        //}
        #endregion

        #region -> CurrentCellChanged y CellFormating
        private void dgvMesa_CurrentCellChanged(object sender, EventArgs e)
        {
            Inicio.id_pedido = 0;
            try
            {
                Inicio.id_mesa = 0;
                bool res = int.TryParse(this.dgvMesa[0, this.dgvMesa.CurrentRow.Index].Value.ToString(), out Inicio.id_mesa);
                Estados_Mesa = Convert.ToString(this.dgvMesa[2, this.dgvMesa.CurrentRow.Index].Value.ToString());

                switch (Estados_Mesa.ToString())
                {
                    case "Ocupado":
                        btnReservarMesa.Visible = false;
                        btnImprimir.Visible = false;
                        btnReImprimir.Visible = true;
                        this.lblMensaje_mesa.Visible = false;
                        this.btnAgregar.Enabled = true;
                        this.btnModificar.Enabled = true;
                        this.btnBorrar.Enabled = true;
                        this.btnAnular.Enabled = true;
                        this.btnCerrar.Enabled = true;
                        break;

                    case "Libre":
                        btnReservarMesa.Visible = false;
                        btnImprimir.Visible = false;
                        btnReImprimir.Visible = false;
                        this.lblMensaje_mesa.Visible = false;
                        this.btnAgregar.Enabled = true;
                        this.btnModificar.Enabled = true;
                        this.btnBorrar.Enabled = true;
                        this.btnAnular.Enabled = true;
                        this.btnCerrar.Enabled = true;
                        break;

                    case "Reservada":
                        btnReservarMesa.Visible = false;
                        btnImprimir.Visible = false;
                        btnReImprimir.Visible = false;
                        this.lblMensaje_mesa.Visible = false;
                        this.btnAgregar.Enabled = true;
                        this.btnModificar.Enabled = true;
                        this.btnBorrar.Enabled = true;
                        this.btnAnular.Enabled = true;
                        this.btnCerrar.Enabled = true;
                        //traigo los datos de todas las mesas para verificar si se repiten
                        //las reservas y asi detectar si es grupal o comun
                        DataTable odt_2 = omesa.GetAll();
                        omesa.GetOne(Inicio.id_mesa);
                        StringBuilder nombre_mesa2 = new StringBuilder();
                        int counter = 0;
                        foreach (DataRow row in odt_2.Rows)
                        {
                            if (Convert.ToInt32(row["id_reserva"]) == omesa.pid_reserva)
                            {
                                counter += 1;
                            }
                        }
                        if (counter == 1) //si es 1 significa que es comun (porque hay una sola reserva con ese id)
                        {
                            //si es comun no le puestro nada al usuario
                            //return;
                        }
                        else //de lo contrario hay mas de una y es grupal
                        {


                            DataTable odt2 = omesa.GetAgrupadaReserva(omesa.pid_reserva);
                            foreach (DataRow row in odt2.Rows)
                            {
                                if (Convert.ToInt32(row["id_mesa"]) != Inicio.id_mesa)
                                {
                                    nombre_mesa2.AppendLine(Convert.ToString(row["Nombre_mesa"]));
                                }
                            }
                            this.lblMensaje_mesa.Visible = true;
                            StringBuilder sb_2 = new StringBuilder();
                            sb_2.AppendLine("La reserva de: " + omesa.pnombre_mesa);
                            sb_2.AppendLine("Nro de reservacion: " + omesa.pid_reserva);
                            sb_2.AppendLine("Se encuentra Asociada con: ");
                            sb_2.AppendLine("-" + nombre_mesa2);
                            this.lblMensaje_mesa.Text = sb_2.ToString();
                        }
                        break;

                    case "Bloqueada":
                        btnReservarMesa.Visible = false;
                        btnImprimir.Visible = false;
                        btnReImprimir.Visible = false;
                        this.lblMensaje_mesa.Visible = true;
                        this.btnAgregar.Enabled = true;
                        this.btnModificar.Enabled = true;
                        this.btnBorrar.Enabled = true;
                        this.btnAnular.Enabled = true;
                        this.btnCerrar.Enabled = true;
                        omesa.GetOne(Inicio.id_mesa);
                        DataTable odt3 = omesa.GetAgrupada(omesa.pgrupo_mesa);
                        StringBuilder nombre_mesa3 = new StringBuilder();
                        foreach (DataRow row in odt3.Rows)
                        {
                            if (Convert.ToInt32(row["id_mesa"]) != Inicio.id_mesa)
                            {
                                nombre_mesa3.AppendLine(Convert.ToString(row["Nombre_mesa"]));
                            }
                        }
                        StringBuilder sb_3 = new StringBuilder();
                        sb_3.AppendLine("El bloqueo de: " + omesa.pnombre_mesa);
                        sb_3.AppendLine("Se encuentra Asociada con: ");
                        sb_3.AppendLine("-" + nombre_mesa3);
                        sb_3.AppendLine("Para deblosquear Agrege un producto.");
                        sb_3.AppendLine("O Anule el bloqueo con el boton anular");
                        this.lblMensaje_mesa.Text = sb_3.ToString();
                        break;

                    default:
                        btnReservarMesa.Visible = false;
                        btnImprimir.Visible = false;
                        btnReImprimir.Visible = false;
                        this.lblMensaje_mesa.Visible = true;
                        this.btnAgregar.Enabled = false;
                        this.btnModificar.Enabled = false;
                        this.btnBorrar.Enabled = false;
                        this.btnAnular.Enabled = false;
                        this.btnCerrar.Enabled = false;
                        omesa.GetOne(Inicio.id_mesa);
                        DataTable odt = omesa.GetAgrupada(omesa.pgrupo_mesa);
                        string nombre_mesa = "";
                        foreach (DataRow row in odt.Rows)
                        {
                            if (Convert.ToString(row["Estado"]) == "Ocupado")
                            {
                                nombre_mesa = Convert.ToString(row["Nombre_mesa"]);
                            }
                        }
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("El pedido de: " + omesa.pnombre_mesa);
                        sb.AppendLine("Se encuentra en: " + nombre_mesa);
                        this.lblMensaje_mesa.Text = sb.ToString();
                        break;
                }
            }
            catch { }
            this.RefrescarGrillaCuerpo_Pedido();
            this.RefrescarTotales();
            Color_Caja();
        }


        private void dgvCuerpo_Pedido_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_cuerpo_pedido = 0;
                bool res = int.TryParse(this.dgvdetalle[0, this.dgvdetalle.CurrentRow.Index].Value.ToString(), out Inicio.id_cuerpo_pedido);
                ocuerpo_pedido.GetOne(Inicio.id_cuerpo_pedido);
                Inicio.id_pedido = ocuerpo_pedido.pid_pedido;
            }
            catch
            {

            }
        }


        private void dgvMesa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMesa.Columns[e.ColumnIndex].Name == "Estado")
            {
                string estado = Convert.ToString(e.Value);

                switch (estado.ToString())
                {
                    case "Ocupado":
                        e.CellStyle.BackColor = Color.Red;
                        break;

                    case "Libre":
                        e.CellStyle.BackColor = Color.Green;
                        break;

                    case "Reservada":
                        e.CellStyle.BackColor = Color.YellowGreen;
                        break;

                    case "Bloqueada":
                        e.CellStyle.BackColor = Color.CadetBlue;
                        break;

                    default:
                        e.CellStyle.BackColor = Color.Red;
                        break;
                }
            }
        }

        private void dgvgrupotipoproducto_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_grupo_Producto = 0;
                bool a = int.TryParse(this.dgvgrupotipoproducto[0, this.dgvgrupotipoproducto.CurrentRow.Index].Value.ToString(), out Inicio.id_grupo_Producto);
            }
            catch { }
            this.RefrescarGrillaTipo_Producto();
        }

        private void dgvtipoproducto_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_tipo_producto = 0;
                bool res = int.TryParse(this.dgvtipoproducto[0, this.dgvtipoproducto.CurrentRow.Index].Value.ToString(), out Inicio.id_tipo_producto);
            }
            catch { }
            this.RefrescarGrillaProducto();
        }

        private void dgvproducto_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_Producto = 0;
                bool res = int.TryParse(this.dgvproducto[0, this.dgvproducto.CurrentRow.Index].Value.ToString(), out Inicio.id_Producto);
            }
            catch { }
        }
        private void dgvReservas_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_Reserva_Mesa = 0;
                bool res = int.TryParse(this.dgvReservas[0, this.dgvReservas.CurrentRow.Index].Value.ToString(), out Inicio.id_Reserva_Mesa);
            }
            catch { }
        }


        private void dgvReserva_Hora_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_reserva_hora = 0;
                bool res = int.TryParse(this.dgvReserva_Hora[0, this.dgvReserva_Hora.CurrentRow.Index].Value.ToString(), out Inicio.id_reserva_hora);
                reserva_hora_seleccionada = Convert.ToString(this.dgvReserva_Hora[1, this.dgvReserva_Hora.CurrentRow.Index].Value);
            }
            catch
            {
            }
        }

        private void dgvproducto_DoubleClick(object sender, EventArgs e)
        {
            btnAgregar.PerformClick();
        }


        #endregion

        #region -> Evento Click Botones

        #region -> Pestaña Pedido
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Inicio.id_Producto == 0)
            {
                return;
            }
            if (Estados_Mesa == "Reservada")
            {
                if (MessageBox.Show("La mesa se encuentra actualmente RESERVADA" + Environment.NewLine +
                    Environment.NewLine + "¿Desea ocuparla?",
                    "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    //traigo los datos de todas las mesas para verificar si se repiten
                    //las reservas y asi detectar si es grupal o comun
                    DataTable odt = omesa.GetAll();
                    omesa.GetOne(Inicio.id_mesa);
                    int counter = 0;
                    foreach (DataRow row in odt.Rows)
                    {
                        if (Convert.ToInt32(row["id_reserva"]) == omesa.pid_reserva)
                        {
                            counter += 1;
                        }
                    }
                    if (counter == 1) //si es 1 significa que es comun (porque hay una sola reserva con ese id)
                    {
                        //SI!, Le cambio el id de la reserva a 0
                        omesa.pid_mesa = Inicio.id_mesa;
                        omesa.pid_reserva = 0;
                        omesa.Modificar();
                    }
                    else //de lo contrario hay mas de una y es grupal
                    {
                        if (MessageBox.Show("La mesa se encuentra actualmente Agrupada"
                            + Environment.NewLine +
                            Environment.NewLine + "¿Desea Colocar la mesa " + lblNombreMesa.Text + " Como principal?",
                            "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            int nextgrupo = omesa.NextGrupo();
                            omesa.pid_mesa = Inicio.id_mesa;
                            omesa.pestado = "Ocupado";
                            omesa.Modificar();
                            string nombre_mesa = omesa.pnombre_mesa;
                            DataTable odt2 = omesa.GetAgrupadaReserva(omesa.pid_reserva);
                            foreach (DataRow row in odt2.Rows)
                            {
                                //pregunto si es distinto para no modificar la principal
                                if (Convert.ToInt32(row["Id_mesa"]) != Inicio.id_mesa)
                                {
                                    //deja de ser reserva agupada y pasa a ser una agrupacion comun
                                    omesa.GetOne(Convert.ToInt32(row["Id_mesa"]));
                                    omesa.pid_mesa = Convert.ToInt32(row["Id_mesa"]);
                                    omesa.pestado = "G: " + nombre_mesa;
                                    omesa.pid_reserva = 0;
                                    omesa.pgrupo_mesa = nextgrupo;
                                    omesa.Modificar();
                                }
                            }
                            omesa.GetOne(Inicio.id_mesa);
                            omesa.pid_mesa = Inicio.id_mesa;
                            omesa.pid_reserva = 0;
                            omesa.pgrupo_mesa = nextgrupo;
                            omesa.Modificar();
                        }

                    }
                }
            }
            if (Estados_Mesa == "Bloqueada")
            {
                if (MessageBox.Show("La mesa se encuentra actualmente Agrupada" + Environment.NewLine +
                    Environment.NewLine + "¿Desea Colocar la mesa " + lblNombreMesa.Text + " Como principal?",
                    "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    //SI!, Le cambio el estado a la seleccionada por ocupado
                    // y al resto le pongo estados referenciados a esa mesa principal
                    omesa.GetOne(Inicio.id_mesa);
                    omesa.pid_mesa = Inicio.id_mesa;
                    omesa.pestado = "Ocupado";
                    omesa.Modificar();
                    string nombre_mesa = omesa.pnombre_mesa;
                    DataTable odt = omesa.GetAgrupada(omesa.pgrupo_mesa);
                    foreach (DataRow row in odt.Rows)
                    {
                        if (Convert.ToInt32(row["Id_mesa"]) != Inicio.id_mesa)
                        {
                            omesa.GetOne(Convert.ToInt32(row["Id_mesa"]));
                            omesa.pid_mesa = Convert.ToInt32(row["Id_mesa"]);
                            omesa.pestado = "G: " + nombre_mesa;
                            omesa.Modificar();
                        }
                    }
                }
            }
            int i = this.dgvMesa.CurrentRow.Index;
            try
            {
                if (this.Estados_Mesa == "Libre" | this.Estados_Mesa == "Reservada"
                    | this.Estados_Mesa == "Bloqueada")
                {
                    //Cambiamos el estado de la mesa
                    omesa.GetOne(Inicio.id_mesa);
                    omesa.pestado = "Ocupado";
                    omesa.Modificar();

                    //traigo los datos necesario para la carga de un pedido
                    opedido.pfecha = DateTime.Now;
                    oproducto.GetOne(Inicio.id_Producto);
                    opedido.pimporte = oproducto.pprecio;
                    opedido.pid_mesa = Inicio.id_mesa;
                    opedido.pid_estado_pedido = 4; //Pendiente

                    //inserto un pedido
                    opedido.Insertar();

                    //traigo los datos necesario para cargar un cuerpo_pedido
                    ocuerpo_pedido.pid_pedido = opedido.pid_pedido;
                    ocuerpo_pedido.pid_producto = Inicio.id_Producto;
                    ocuerpo_pedido.pcantidad = 1;
                    ocuerpo_pedido.pprecio = oproducto.pprecio;

                    //insert un cuerpo_pedido
                    ocuerpo_pedido.Insertar();

                    //Inserto datos en la temporal para futuras impresiones
                    oTemp_Pedido.pcantidad = ocuerpo_pedido.pcantidad;
                    oTemp_Pedido.pfecha = opedido.pfecha;
                    oTemp_Pedido.pid_cuerpo_pedido = ocuerpo_pedido.pid_cuerpo_pedido;
                    oTemp_Pedido.pid_mesa = Inicio.id_mesa;
                    oTemp_Pedido.pid_pedido = opedido.pid_pedido;
                    oTemp_Pedido.pid_producto = Inicio.id_Producto;
                    oTemp_Pedido.pprecio = ocuerpo_pedido.pprecio;
                    oTemp_Pedido.Insertar();

                    RefrescarGrillaMesa();
                    RefrescarGrillaCuerpo_Pedido();


                    this.dgvMesa.CurrentCell = this.dgvMesa.Rows[i].Cells[1];
                }
                else
                {
                    ocuerpo_pedido.GetOne(Inicio.id_cuerpo_pedido);
                    //recorro la tabla con el cuerpo_pedido para encontrar productos ya cargados
                    DataTable odtcuerpo = ocuerpo_pedido.GetPedido(ocuerpo_pedido.pid_pedido);
                    bool existe = false;
                    int idpro = 0;
                    foreach (DataRow row in odtcuerpo.Rows)
                    {
                        idpro = Convert.ToInt32(row[1]);
                        if (idpro == Inicio.id_Producto)
                        {
                            existe = true;
                        }

                    }
                    //si el producto se repito modifico su cantidad
                    //de lo contrario registro uno nuevo.
                    if (existe == true)
                    {
                        oproducto.GetOne(Inicio.id_Producto);
                        opedido.GetOne(ocuerpo_pedido.pid_pedido);
                        ocuerpo_pedido.GetCuerpo_Pedido(ocuerpo_pedido.pid_pedido, Inicio.id_Producto);
                        ocuerpo_pedido.GetOne(ocuerpo_pedido.pid_cuerpo_pedido);

                        //traigo los datos necesario para cargar un cuerpo_pedido
                        ocuerpo_pedido.pid_producto = Inicio.id_Producto;
                        ocuerpo_pedido.pcantidad = ocuerpo_pedido.pcantidad + 1;
                        ocuerpo_pedido.pprecio += oproducto.pprecio;

                        //insert un cuerpo_pedido
                        ocuerpo_pedido.Modificar();


                        //traigo los datos necesario para modificar el importe de un pedido
                        //opedido.pfecha = DateTime.Now;
                        opedido.pimporte = opedido.pimporte + oproducto.pprecio;
                        opedido.pid_mesa = Inicio.id_mesa;
                        opedido.pid_pedido = ocuerpo_pedido.pid_pedido;
                        //modifico un pedido
                        opedido.Modificar();

                        //Modifico la temp de pedido para futuras impresiones
                        oTemp_Pedido.GetFiltro(ocuerpo_pedido.pid_pedido, ocuerpo_pedido.pid_cuerpo_pedido);
                        oTemp_Pedido.pcantidad = ocuerpo_pedido.pcantidad;
                        oTemp_Pedido.pid_cuerpo_pedido = ocuerpo_pedido.pid_cuerpo_pedido;
                        oTemp_Pedido.pid_mesa = Inicio.id_mesa;
                        oTemp_Pedido.pid_pedido = opedido.pid_pedido;
                        oTemp_Pedido.pid_producto = Inicio.id_Producto;
                        oTemp_Pedido.pprecio = ocuerpo_pedido.pprecio;
                        oTemp_Pedido.Modificar();

                        RefrescarGrillaCuerpo_Pedido();

                    }
                    else
                    {
                        oproducto.GetOne(Inicio.id_Producto);
                        opedido.GetOne(ocuerpo_pedido.pid_pedido);

                        //traigo los datos necesario para cargar un cuerpo_pedido
                        ocuerpo_pedido.pid_producto = Inicio.id_Producto;
                        ocuerpo_pedido.pcantidad = 1;
                        ocuerpo_pedido.pprecio = oproducto.pprecio;

                        //insert un cuerpo_pedido
                        ocuerpo_pedido.Insertar();


                        //traigo los datos necesario para modificar el importe de un pedido
                        //opedido.pfecha = DateTime.Now;
                        opedido.pimporte = opedido.pimporte + oproducto.pprecio;
                        opedido.pid_mesa = Inicio.id_mesa;
                        opedido.pid_pedido = ocuerpo_pedido.pid_pedido;
                        //modifico un pedido
                        opedido.Modificar();

                        //inserto temporal de pedido para futuras impresiones
                        oTemp_Pedido.pcantidad = ocuerpo_pedido.pcantidad;
                        oTemp_Pedido.pfecha = opedido.pfecha;
                        oTemp_Pedido.pid_cuerpo_pedido = ocuerpo_pedido.pid_cuerpo_pedido;
                        oTemp_Pedido.pid_mesa = Inicio.id_mesa;
                        oTemp_Pedido.pid_pedido = opedido.pid_pedido;
                        oTemp_Pedido.pid_producto = Inicio.id_Producto;
                        oTemp_Pedido.pprecio = ocuerpo_pedido.pprecio;
                        oTemp_Pedido.Insertar();


                        RefrescarGrillaCuerpo_Pedido();
                    }

                }
                DataGridViewRow rowDetalle = dgvdetalle.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => Convert.ToString(x.Cells["id_producto"].Value) == Inicio.id_Producto.ToString());

                if (rowDetalle != null)
                {
                    dgvdetalle.ClearSelection();
                    rowDetalle.Selected = true;
                    dgvdetalle.CurrentCell = this.dgvdetalle.Rows[rowDetalle.Index].Cells[2];
                    dgvdetalle.DefaultCellStyle.SelectionBackColor = Color.YellowGreen;
                    dgvdetalle.DefaultCellStyle.SelectionForeColor = Color.Black;
                    dgvdetalle.Rows[rowDetalle.Index].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                    dgvdetalle.Columns[3].DefaultCellStyle.SelectionBackColor = Color.Red;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Se a Generado un Error al agregar un producto. Comuniquese con el Administrador",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RefrescarTotales();
        }


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                int filasgrilla = this.dgvdetalle.Rows.Count;

                if (filasgrilla == 0)
                {
                    MessageBox.Show("Debe Agregar un Producto antes de poder Borrar",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (filasgrilla == 1)
                {
                    omesa.GetOne(Inicio.id_mesa);
                    if (MessageBox.Show("Ah señalado el ultimo producto, ¿desea anular la " + omesa.pnombre_mesa, "Consulta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        borrar = 1;
                        int id = Inicio.id_cuerpo_pedido;
                        btnAnular.PerformClick();

                        return;
                    }
                    else
                        return;
                }
                if (MessageBox.Show("Desea BORRAR el producto seleccionado", "Advertencia", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //si dice que si, busco el id cuerpo pedido selecionado
                    ocuerpo_pedido.pid_cuerpo_pedido = Inicio.id_cuerpo_pedido;
                    //busco el precio, y el pedido para luego restar los totales

                    ocuerpo_pedido.GetOne(Inicio.id_cuerpo_pedido);

                    //modifico el importe total
                    opedido.GetOne(ocuerpo_pedido.pid_pedido);
                    opedido.pid_pedido = ocuerpo_pedido.pid_pedido;
                    opedido.pimporte -= ocuerpo_pedido.pprecio;
                    opedido.Modificar();

                    //borro el producto seleccionado
                    ocuerpo_pedido.Borrar();

                    //borro de mi temporal de impresiones futuras
                    oTemp_Pedido.GetFiltro(ocuerpo_pedido.pid_pedido, ocuerpo_pedido.pid_cuerpo_pedido);
                    oTemp_Pedido.Borrar();

                    RefrescarGrillaCuerpo_Pedido();
                    RefrescarTotales();
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Se a Generado un Error al Borrar un producto. Comuniquese con el Administrador", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int filasgrilla = this.dgvdetalle.Rows.Count;
            if (filasgrilla == 0)
            {
                MessageBox.Show("Debe Agregar un Producto antes de poder modificar",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmModificarPedido frm = new frmModificarPedido();
            this.AddOwnedForm(frm);
            frm.ShowDialog();


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmConsultaProducto frm = new frmConsultaProducto();
            this.AddOwnedForm(frm);
            frm.ShowDialog();
            if (Inicio.id_Producto != 0)
            {
                this.cmbBuscarProducto.SelectedValue = Inicio.id_Producto;
                this.btnSeleccionar.PerformClick();
            }
            else
                MessageBox.Show("No a seleccionado ningun producto", "Control", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                if (Estados_Mesa == "Reservada")
                {
                    //se llevo el codigo de anulacion de reservas a la pestaña de la misma
                    tbPrincipal.SelectedTab = tpReservas;
                    return;
                }
                if (Estados_Mesa == "Bloqueada")
                {
                    if (MessageBox.Show("¿Desea Desbloquear el Agrupamiento de mesas?",
                        "Reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Cambiamos el estado de las grupos de mesas
                        omesa.GetOne(Inicio.id_mesa);
                        DataTable odt = omesa.GetAgrupada(omesa.pgrupo_mesa);
                        foreach (DataRow row in odt.Rows)
                        {
                            omesa.GetOne(Convert.ToInt32(row["Id_mesa"]));
                            omesa.pid_mesa = Convert.ToInt32(row["Id_mesa"]);
                            omesa.pestado = "Libre";
                            omesa.pgrupo_mesa = 0;
                            omesa.Modificar();
                        }
                        RefrescarGrillaMesa();
                        return;
                    }
                    else
                    {
                        //no hago nada
                        return;
                    }
                }
                //En este caso seria estado = Ocupado
                int filasgrilla = this.dgvdetalle.Rows.Count;
                if (filasgrilla == 0)
                {
                    MessageBox.Show("Debe Agregar un Producto antes de poder Anular",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (borrar == 0)
                {
                    omesa.GetOne(Inicio.id_mesa);
                    if (MessageBox.Show("Seguro que desea Anular la " + omesa.pnombre_mesa, "Advertencia",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Inicio.parametro_PasswordMaster = 0;
                        frmPasswordControl Password = new frmPasswordControl();
                        Password.ShowDialog();

                        if (Inicio.parametro_PasswordMaster == 0)
                        {
                            return;
                        }

                        //cambio el estado del pedido

                        ocuerpo_pedido.GetOne(Inicio.id_cuerpo_pedido);
                        opedido.GetOne(ocuerpo_pedido.pid_pedido);
                        opedido.pid_estado_pedido = 2; //Anulada
                        opedido.pid_pedido = ocuerpo_pedido.pid_pedido;
                        opedido.Modificar();



                        //recorre mi temporal para no dejar datos inecesarios
                        DataTable odttemp = oTemp_Pedido.GetPedido(opedido.pid_pedido);
                        foreach (DataRow row in odttemp.Rows)
                        {
                            int idpro = Convert.ToInt32(row[0]);
                            oTemp_Pedido.pid_temp_pedido = idpro;
                            oTemp_Pedido.Borrar();
                        }
                        omesa.GetOne(Inicio.id_mesa);
                        //Consulto si es una mesa agrupada
                        if (omesa.pgrupo_mesa == 0)
                        {
                            //Cambiamos el estado de la mesa
                            omesa.pid_mesa = Inicio.id_mesa;
                            omesa.pestado = "Libre";
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



                        RefrescarGrillaMesa();

                        LimpiarTotales();
                        RefrescarTotales();
                        RefrescarGrillaCuerpo_Pedido();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    //Cambiamos el estado de la mesa
                    omesa.GetOne(Inicio.id_mesa);
                    omesa.pestado = "Libre";
                    omesa.Modificar();


                    //borro los cuerpo_pedidos relacionados con el pedido de la mesa
                    ocuerpo_pedido.GetOne(Inicio.id_cuerpo_pedido);
                    ocuerpo_pedido.BorrarPeriodo();

                    //borro el periodo
                    opedido.GetOne(ocuerpo_pedido.pid_pedido);
                    opedido.Borrar();

                    LimpiarTotales();
                    RefrescarTotales();
                    RefrescarGrillaCuerpo_Pedido();
                    RefrescarGrillaMesa();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Se a Generado un Error al Borrar un producto. Comuniquese con el Administrador", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            borrar = 0;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            int filasgrilla = this.dgvdetalle.Rows.Count;
            if (filasgrilla == 0)
            {
                MessageBox.Show("Debe Agregar un Producto antes de poder Cerrar",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            int i = this.dgvMesa.CurrentRow.Index;
            ocuerpo_pedido.GetOne(Inicio.id_cuerpo_pedido);
            opedido.GetOne(ocuerpo_pedido.pid_pedido);
            opedido.pid_pedido = ocuerpo_pedido.pid_pedido;
            //Confirmo el total antes de entrar al frm de pagos.
            opedido.pimporte = Convert.ToDouble(this.lblTotal.Text);
            opedido.Modificar();
            Inicio.id_pedido = ocuerpo_pedido.pid_pedido;
            frmPago pago = new frmPago();
            this.AddOwnedForm(pago);
            pago.ShowDialog();
            RefrescarGrillaCuerpo_Pedido();
            RefrescarGrillaMesa();
            this.dgvMesa.CurrentCell = this.dgvMesa.Rows[i].Cells[1];

        }
        private void btnReservarMesa_Click(object sender, EventArgs e)
        {
            int i = this.dgvMesa.CurrentRow.Index;

            //Cambiamos el estado de la mesa
            omesa.GetOne(Inicio.id_mesa);
            omesa.pestado = "Reservada";
            omesa.Modificar();
            RefrescarGrillaMesa();
            this.dgvMesa.CurrentCell = this.dgvMesa.Rows[i].Cells[1];
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ocuerpo_pedido.GetOne(Inicio.id_cuerpo_pedido);
            DataTable odttemp = oTemp_Pedido.GetPedido(ocuerpo_pedido.pid_pedido);

            if (odttemp.Rows.Count <= 0)
            {
                MessageBox.Show("Sr: Este pedido ya fue imprimido. Presione RE IMPRIMIR para imprimir nuevamente todo el pedido",
                    "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Reporte.rptImprimir_Pedido rptImprimir_Pedido = new Reporte.rptImprimir_Pedido();
            Inicio.printCrystalReport(rptImprimir_Pedido, 1, 0, 0, "rptImprimir_Pedido");

            //recorre mi temporal para no dejar datos inecesarios

            foreach (DataRow row in odttemp.Rows)
            {
                int idpro = Convert.ToInt32(row[0]);
                oTemp_Pedido.pid_temp_pedido = idpro;
                oTemp_Pedido.Borrar();
            }
        }
        private void btnReImprimir_Click(object sender, EventArgs e)
        {
            Reporte.rptRe_Imprimir_Pedido rptRe_Imprimir_Pedido = new Reporte.rptRe_Imprimir_Pedido();
            Inicio.printCrystalReport(rptRe_Imprimir_Pedido, 1, 0, 0, "rptRe_Imprimir_Pedido");
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            int id_producto_seleccionado = Convert.ToInt32(cmbBuscarProducto.SelectedValue);
            oproducto.GetOne(id_producto_seleccionado);
            int id_tipo_producto = oproducto.pid_tipo_producto;
            otipo_producto.GetOne(id_tipo_producto);
            int id_grupo_producto = otipo_producto.pid_grupo_producto;

            //Busco en la grilla por su id y selecciono
            DataGridViewRow rowGrupo = dgvgrupotipoproducto.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => Convert.ToString(x.Cells[0].Value) == id_grupo_producto.ToString());

            if (rowGrupo != null)
            {
                dgvgrupotipoproducto.ClearSelection();
                rowGrupo.Selected = true;
                Inicio.id_grupo_Producto = id_grupo_producto;
                RefrescarGrillaTipo_Producto();
            }

            DataGridViewRow rowTipo = dgvtipoproducto.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => Convert.ToString(x.Cells[0].Value) == id_tipo_producto.ToString());

            if (rowTipo != null)
            {
                dgvtipoproducto.ClearSelection();
                rowTipo.Selected = true;
                Inicio.id_tipo_producto = id_tipo_producto;
                RefrescarGrillaProducto();
            }

            DataGridViewRow rowProducto = dgvproducto.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => Convert.ToString(x.Cells[0].Value) == cmbBuscarProducto.SelectedValue.ToString());

            if (rowProducto != null)
            {
                dgvproducto.ClearSelection();
                rowProducto.Selected = true;
                dgvproducto.Focus();
                Inicio.id_Producto = id_producto_seleccionado;
            }
        }
        #endregion

        #region -> Pestaña Reservaciones
        private void btnAgregar_Reserva_Click(object sender, EventArgs e)
        {
            frmDetalleReserva_Mesa frm = new frmDetalleReserva_Mesa();
            Inicio.Bandera_Reserva_Mesa = 1;
            this.AddOwnedForm(frm);
            frm.ShowDialog();
            RefrescarReservas();
            RefrescarGrillaReserva_Hora();
        }

        private void btnModificar_Reserva_Click(object sender, EventArgs e)
        {
            if (Inicio.id_Reserva_Mesa == 0)
            {
                MessageBox.Show("Debe seleccionar una reserva",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int i = this.dgvReservas.CurrentRow.Index;
                frmDetalleReserva_Mesa frm = new frmDetalleReserva_Mesa();
                Inicio.Bandera_Reserva_Mesa = 2;
                this.AddOwnedForm(frm);
                frm.ShowDialog();
                RefrescarGrillaReserva();
                RefrescarReservas();
                RefrescarGrillaReserva_Hora();
                this.dgvReservas.CurrentCell = this.dgvReservas.Rows[i].Cells[1];
            }
            catch
            {
            }

        }

        private void btnAnular_Reserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (Estados_Mesa == "Reservada")
                {
                    if (MessageBox.Show("¿Desea Anular la reservacion? la reserva volvera a estar pendiente",
                        "Reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //traigo los datos de todas las mesas para verificar si se repiten
                        //las reservas y asi detectar si es grupal o comun
                        DataTable odt = omesa.GetAll();
                        omesa.GetOne(Inicio.id_mesa);
                        int counter = 0;
                        foreach (DataRow row in odt.Rows)
                        {
                            if (Convert.ToInt32(row["id_reserva"]) == omesa.pid_reserva)
                            {
                                counter += 1;
                            }
                        }
                        if (counter == 1) //si es 1 significa que es comun (porque hay una sola reserva con ese id)
                        {
                            //Cambiamos el estado de la mesa
                            omesa.GetOne(Inicio.id_mesa);
                            omesa.pestado = "Libre";
                            int id_reserva = omesa.pid_reserva; //Guardo el id para no perderlo
                            omesa.pid_reserva = 0;
                            omesa.Modificar();

                            oReserva_Mesa.GetOne_2(id_reserva);
                            oReserva_Mesa.pid_reserva_mesa = id_reserva;
                            oReserva_Mesa.pestado_reserva = "Pendiente";
                            oReserva_Mesa.pid_mesa = 0;
                            oReserva_Mesa.Modificar();
                        }
                        else //de lo contrario hay mas de una y es grupal
                        {
                            omesa.GetOne(Inicio.id_mesa);
                            DataTable odt2 = omesa.GetAgrupadaReserva(omesa.pid_reserva);

                            foreach (DataRow row in odt2.Rows)
                            {
                                //Modifico la mesa para dejarla libre
                                omesa.GetOne(Convert.ToInt32(row["Id_mesa"]));
                                omesa.pid_mesa = Convert.ToInt32(row["Id_mesa"]);
                                omesa.pestado = "Libre";
                                omesa.pid_reserva = 0;
                                omesa.Modificar();

                                //Modifico la reserva y la dejo pendiente
                                oReserva_Mesa.GetOne_2(Convert.ToInt32(row["id_reserva"]));
                                oReserva_Mesa.pid_reserva_mesa = Convert.ToInt32(row["id_reserva"]);
                                oReserva_Mesa.pestado_reserva = "Pendiente";
                                oReserva_Mesa.pid_mesa = 0;
                                oReserva_Mesa.Modificar();
                            }
                        }


                        RefrescarGrillaMesa();
                        RefrescarGrillaReserva();
                        RefrescarReservas();
                    }
                    else
                    {
                        //no hago nada
                        return;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Se a Generado un Error al Borrar un producto. Comuniquese con el Administrador", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBorrar_Reserva_Click(object sender, EventArgs e)
        {
            if (Inicio.id_Reserva_Mesa == 0)
            {
                MessageBox.Show("Debe seleccionar una reserva",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Desea eleminar la reserva Nro: " + Inicio.id_Reserva_Mesa, "Borrar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                //traigo los datos de todas las mesas para verificar si se repiten
                //las reservas y asi detectar si es grupal o comun o si no existen reservas en las mesas
                DataTable odt = omesa.GetAll();

                int counter = 0;
                foreach (DataRow row in odt.Rows)
                {
                    if (Convert.ToInt32(row["id_reserva"]) == Inicio.id_Reserva_Mesa)
                        counter += 1;
                }
                if (counter == 1) //si es 1 significa que es comun (porque hay una sola reserva con ese id)
                {
                    //Cambiamos el estado de la mesa
                    DataTable odt3 = omesa.GetAgrupadaReserva(Inicio.id_Reserva_Mesa);

                    omesa.GetOne(Convert.ToInt32(odt3.Rows[0]["Id_mesa"]));
                    omesa.pid_mesa = Convert.ToInt32(odt3.Rows[0]["Id_mesa"]);
                    omesa.pestado = "Libre";
                    int id_reserva = omesa.pid_reserva; //Guardo el id para no perderlo
                    omesa.pid_reserva = 0;
                    omesa.Modificar();

                    oReserva_Mesa.pid_reserva_mesa = Inicio.id_Reserva_Mesa;
                    oReserva_Mesa.Borrar();
                }

                if (counter > 1) //si es mayor que 1 significa que es grupal
                {
                    DataTable odt2 = omesa.GetAgrupadaReserva(omesa.pid_reserva);

                    foreach (DataRow row in odt2.Rows)
                    {
                        //Modifico la mesa para dejarla libre
                        omesa.GetOne(Convert.ToInt32(row["Id_mesa"]));
                        omesa.pid_mesa = Convert.ToInt32(row["Id_mesa"]);
                        omesa.pestado = "Libre";
                        omesa.pid_reserva = 0;
                        omesa.Modificar();
                    }
                    //borro la seleccionado luego de cambiar el estado de la mesa
                    oReserva_Mesa.pid_reserva_mesa = Inicio.id_Reserva_Mesa;
                    oReserva_Mesa.Borrar();
                }
                if (counter == 0)//Esto sucede en los casos de que la mesa no tenga ninguna reserva con ese id
                {
                    oReserva_Mesa.pid_reserva_mesa = Inicio.id_Reserva_Mesa;
                    oReserva_Mesa.Borrar();
                }

                RefrescarGrillaMesa();
                RefrescarGrillaReserva();
                RefrescarGrillaReserva_Hora();
                RefrescarReservas();
            }
        }
        private void btnReservacion_Click(object sender, EventArgs e)
        {
            if (rbtReservas_Historicas.Checked == true)
                return;
            if (Inicio.id_Reserva_Mesa <= 0)
            {
                MessageBox.Show("Debe seleccionar una reserva", "Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oReserva_Mesa.GetOne_2(Inicio.id_Reserva_Mesa);

            DateTime fecha_base = Convert.ToDateTime(oReserva_Mesa.pfecha_reserva);
            DateTime hora_base = Convert.ToDateTime(oReserva_Mesa.phora_reserva);
            DateTime fecha_hora_base = fecha_base.Add(hora_base.Subtract(hora_base.Date));
            if (fecha_hora_base < DateTime.Now)
            {
                MessageBox.Show("No es posible realizar esta reservacion" + Environment.NewLine +
                    "La fecha y la hora ya han sucedido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Estados_Mesa != "Libre")
            {
                MessageBox.Show("Esta mesa se encuentra " + Estados_Mesa + "," + Environment.NewLine +
                    " seleccione una distinta para poder realizar la reserva  " + Estados_Mesa, "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (Inicio.id_Reserva_Mesa == 0)
            {
                MessageBox.Show("Debe seleccionar una reserva",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable odt = omesa.GetAll();
            foreach (DataRow row in odt.Rows)
            {
                if (Convert.ToInt32(row["id_reserva"]) == Inicio.id_Reserva_Mesa)
                {
                    MessageBox.Show("La Reserva seleccionada ya se encuentra reservada",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            //Cambio el estado y le asigno el id de la mesa
            oReserva_Mesa.GetOne_2(Inicio.id_Reserva_Mesa);
            oReserva_Mesa.pid_reserva_mesa = Inicio.id_Reserva_Mesa;
            oReserva_Mesa.pestado_reserva = "Finalizada";
            oReserva_Mesa.pid_mesa = Inicio.id_mesa;
            oReserva_Mesa.Modificar();
            //modifico el estado de la mesa
            omesa.GetOne(Inicio.id_mesa);
            omesa.pestado = "Reservada";

            //cargo el id_reserva a la mesa para proximos detalles
            omesa.pid_reserva = Inicio.id_Reserva_Mesa;
            omesa.Modificar();
            int i = this.dgvMesa.CurrentRow.Index;
            RefrescarGrillaReserva();
            RefrescarGrillaMesa();
            RefrescarReservas();
            this.dgvMesa.CurrentCell = this.dgvMesa.Rows[i].Cells[1];
        }
        #endregion
        //Botones Extras
        private void btnAgrupar_Click(object sender, EventArgs e)
        {
            //Mensajes exclusivos de reserva
            if (Inicio.id_Reserva_Mesa == 0 && tbPrincipal.SelectedTab == tpReservas)
            {
                MessageBox.Show("Debe seleccionar una reserva",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvMesa.SelectedRows.Count <= 1)
            {
                MessageBox.Show("Debe seleccionar mas de una mesa para poder agrupar", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //declaro variables
            int counter;
            int counter_2;
            int id_mesa = 0;
            string estado = "";

            //declaro la variable de almacenamiento de los nombres de las mesas
            StringBuilder nombre_mesa = new StringBuilder();

            //cuento la cantidad de celdas seleccionadas
            //** Realizado para mostrar los nombres en los mensajes
            for (counter_2 = 0;
              counter_2 < (dgvMesa.SelectedCells.Count); counter_2++)
            {
                if (dgvMesa.SelectedCells[counter_2].FormattedValueType ==
                    Type.GetType("System.String"))
                {
                    string value = null;

                    // If the cell contains a value that has not been commited,
                    // use the modified value.
                    if (dgvMesa.IsCurrentCellDirty == true)
                    {

                        value = dgvMesa.SelectedCells[counter_2]
                            .EditedFormattedValue.ToString();
                    }
                    else
                    {
                        value = dgvMesa.SelectedCells[counter_2]
                            .FormattedValue.ToString();
                    }
                    if (value != null)
                    {
                        //ignoro todo lo que no sea nombre_mesa
                        if (dgvMesa.SelectedCells[counter_2].ColumnIndex ==
                            dgvMesa.Columns["Nombre_mesa"].Index)
                        {
                            if (value.Length != 0)
                            {
                                //le asigno el valor a mi StringBuild
                                nombre_mesa.AppendLine("-" + value);
                            }
                        }
                        if (dgvMesa.SelectedCells[counter_2].ColumnIndex ==
                            dgvMesa.Columns["Estado"].Index)
                        {
                            if (value.Length != 0)
                            {
                                estado = value;
                                if (estado != "Libre")
                                {
                                    MessageBox.Show("No se puede Agrupar una mesa que se encuentre  "
                                        + estado, "Error"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            if (MessageBox.Show("Desea Agrupar las mesas:" + Environment.NewLine +
                 nombre_mesa, "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            //Swich para diferencia si viene de la pestalla pedido o reservas.
            switch (tbPrincipal.SelectedTab.Name)
            {
                //si esta sobre los pedido las mesa se bloquea
                case "tpPedido":
                    //Realizado para modificar estados de la mesa
                    int NextGrupo = omesa.NextGrupo();
                    for (counter = 0;
                       counter < (dgvMesa.SelectedCells.Count); counter++)
                    {
                        if (dgvMesa.SelectedCells[counter].FormattedValueType ==
                            Type.GetType("System.String"))
                        {
                            string value = null;

                            // If the cell contains a value that has not been commited,
                            // use the modified value.
                            if (dgvMesa.IsCurrentCellDirty == true)
                            {

                                value = dgvMesa.SelectedCells[counter]
                                    .EditedFormattedValue.ToString();
                            }
                            else
                            {
                                value = dgvMesa.SelectedCells[counter]
                                    .FormattedValue.ToString();
                            }
                            if (value != null)
                            {
                                // Ignore cells in the Description column.
                                if (dgvMesa.SelectedCells[counter].ColumnIndex ==
                                    dgvMesa.Columns["Id_mesa"].Index)
                                {
                                    if (value.Length != 0)
                                    {
                                        //cambio el grupo y bloqueo la mesa
                                        id_mesa = int.Parse(value);
                                        omesa.GetOne(id_mesa);
                                        omesa.pid_mesa = id_mesa;
                                        omesa.pestado = "Bloqueada";
                                        omesa.pgrupo_mesa = NextGrupo;
                                        omesa.Modificar();
                                    }
                                }
                            }
                        }
                    }//End for
                    break;
                //si esta sobre las reservas la reserva se queda en estado de reserva
                case "tpReservas":
                    //Mensajes exclusivos de reserva
                    if (Inicio.id_Reserva_Mesa == 0)
                    {
                        MessageBox.Show("Debe seleccionar una reserva",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DataTable odt = omesa.GetAll();
                    foreach (DataRow row in odt.Rows)
                    {
                        if (Convert.ToInt32(row["id_reserva"]) == Inicio.id_Reserva_Mesa)
                        {
                            MessageBox.Show("La Reserva seleccionada ya se encuentra reservada",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    for (counter = 0;
                       counter < (dgvMesa.SelectedCells.Count); counter++)
                    {
                        if (dgvMesa.SelectedCells[counter].FormattedValueType ==
                            Type.GetType("System.String"))
                        {
                            string value = null;

                            // If the cell contains a value that has not been commited,
                            // use the modified value.
                            if (dgvMesa.IsCurrentCellDirty == true)
                            {

                                value = dgvMesa.SelectedCells[counter]
                                    .EditedFormattedValue.ToString();
                            }
                            else
                            {
                                value = dgvMesa.SelectedCells[counter]
                                    .FormattedValue.ToString();
                            }
                            if (value != null)
                            {
                                // Ignore cells in the Description column.
                                if (dgvMesa.SelectedCells[counter].ColumnIndex ==
                                    dgvMesa.Columns["Id_mesa"].Index)
                                {
                                    if (value.Length != 0)
                                    {
                                        //cambio el grupo y bloqueo la mesa
                                        id_mesa = int.Parse(value);
                                        omesa.GetOne(id_mesa);
                                        omesa.pid_mesa = id_mesa;
                                        omesa.pestado = "Reservada";
                                        omesa.pid_reserva = Inicio.id_Reserva_Mesa;
                                        omesa.Modificar();
                                    }
                                }
                            }
                        }
                    }//End for
                    //Cambio el estado y le asigno el id de la mesa
                    oReserva_Mesa.GetOne_2(Inicio.id_Reserva_Mesa);
                    oReserva_Mesa.pid_reserva_mesa = Inicio.id_Reserva_Mesa;
                    oReserva_Mesa.pestado_reserva = "Finalizada";
                    oReserva_Mesa.pid_mesa = Inicio.id_mesa;
                    oReserva_Mesa.Modificar();
                    RefrescarGrillaReserva();
                    RefrescarReservas();
                    break;
            }//End Switch


            RefrescarGrillaMesa();
        }
        #endregion

        #region -> Menus Contextuales y Redirecciones
        /// <summary>
        /// Asigancion de metodos Click de botones
        /// Redirecciones de MenuStrip
        /// Metodos para darle color a los botones
        /// </summary>
        private void ingresarNuevaReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetalleReserva_Mesa frm = new frmDetalleReserva_Mesa();
            Inicio.Bandera_Reserva_Mesa = 1;
            this.AddOwnedForm(frm);
            frm.ShowDialog();
            RefrescarReservas();
        }

        private void modificarReservaSeleccionadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Inicio.id_Reserva_Mesa == 0)
            {
                MessageBox.Show("Debe seleccionar una reserva",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int i = this.dgvReservas.CurrentRow.Index;
            frmDetalleReserva_Mesa frm = new frmDetalleReserva_Mesa();
            Inicio.Bandera_Reserva_Mesa = 2;
            this.AddOwnedForm(frm);
            frm.ShowDialog();
            RefrescarGrillaReserva();
            RefrescarReservas();
            this.dgvReservas.CurrentCell = this.dgvReservas.Rows[i].Cells[1];
        }
        private void eliminarReservaSeleccionadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Inicio.id_Reserva_Mesa == 0)
            {
                MessageBox.Show("Debe seleccionar una reserva",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Desea eleminar la reserva Nro: " + Inicio.id_Reserva_Mesa, "Borrar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oReserva_Mesa.pid_reserva_mesa = Inicio.id_Reserva_Mesa;
                oReserva_Mesa.Borrar();
                RefrescarGrillaReserva();
                RefrescarReservas();
            }

        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inicio.parametro_Salir = 1;
            Application.Exit();
        }
        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmUsuario usuario = new frmAbmUsuario();
            usuario.ShowDialog();
            this.Show();
            RefrescarGrillas();
        }
        private void mesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmMesa mesa = new frmAbmMesa();
            mesa.ShowDialog();
            this.Show();
            RefrescarGrillas();
        }
        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmProducto producto = new frmAbmProducto();
            producto.ShowDialog();
            this.Show();
            RefrescarGrillas();
        }
        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmCliente cliente = new frmAbmCliente();
            cliente.ShowDialog();
            this.Show();
            RefrescarGrillas();
        }
        //a la caja
        private void gestionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestion_caja frmgestion = new frmGestion_caja();
            this.AddOwnedForm(frmgestion);
            frmgestion.ShowDialog();
            Color_Caja();
        }
        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulta_caja frmconsulta = new frmConsulta_caja();
            frmconsulta.ShowDialog();
        }

        #endregion

        #region -> Metodos Pintar Botones
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
        #endregion

        #region -> Eventos Diversos componentes

        #region -> Pestaña Pedido
        private void dgvdetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvdetalle.DefaultCellStyle.SelectionBackColor = Color.MidnightBlue;
            dgvdetalle.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvdetalle.Columns[3].DefaultCellStyle.SelectionBackColor = Color.MidnightBlue;
            foreach (DataGridViewRow row in dgvdetalle.Rows)
            {
                dgvdetalle.Rows[row.Index].DefaultCellStyle.Font =
                    new Font(DataGridView.DefaultFont, FontStyle.Regular);
            }
        }

        private void cmbBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            //al igual que el textbox solo que en ves de tener un keychar se utiliza el keyvalues
            if (e.KeyValue == (char)(Keys.Enter))
            {
                this.btnSeleccionar.PerformClick();
            }
        }

        private void dgvproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAgregar.PerformClick();
            }
        }
        #endregion

        #region -> Pestaña Reservaciones
        private void rbtDia_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_Checked_Changed_Reservacion(sender, e);
        }

        private void rbtMes_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_Checked_Changed_Reservacion(sender, e);
        }

        private void rbtAño_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_Checked_Changed_Reservacion(sender, e);
        }
        private void rbtBusquedaRapida_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_Checked_Changed_Reservacion(sender, e);
        }

        private void rbtReservas_pendientes_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_Checked_Changed_Reservacion(sender, e);
        }

        private void rbtReservas_Historicas_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_Checked_Changed_Reservacion(sender, e);
        }
        private void dtpFecha_Inicio_ValueChanged(object sender, EventArgs e)
        {
            dtpFecha_Inicio.MaxDate = dtpFecha_Fin.Value;
            RefrescarGrillaReserva();
        }

        private void dtpFecha_Fin_ValueChanged(object sender, EventArgs e)
        {
            RefrescarGrillaReserva();
        }

        private void dgvReservas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rbtReservas_Historicas.Checked == true)
            {
                return;
            }
            oReserva_Mesa.GetOne_2(Inicio.id_Reserva_Mesa);

            DateTime fecha_base = Convert.ToDateTime(oReserva_Mesa.pfecha_reserva);
            DateTime hora_base = Convert.ToDateTime(oReserva_Mesa.phora_reserva);
            DateTime fecha_hora_base = fecha_base.Add(hora_base.Subtract(hora_base.Date));
            if (fecha_hora_base < DateTime.Now)
            {
                MessageBox.Show("No es posible realizar esta reservacion" + Environment.NewLine +
                    "La fecha y la hora ya han sucedido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Estados_Mesa != "Libre")
            {
                MessageBox.Show("Esta mesa se encuentra " + Estados_Mesa + "," + Environment.NewLine +
                    " seleccione una distinta para poder realizar la reserva  " + Estados_Mesa, "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (Inicio.id_Reserva_Mesa == 0)
            {
                MessageBox.Show("Debe seleccionar una reserva",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable odt = omesa.GetAll();
            foreach (DataRow row in odt.Rows)
            {
                if (Convert.ToInt32(row["id_reserva"]) == Inicio.id_Reserva_Mesa)
                {
                    MessageBox.Show("La Reserva seleccionada ya se encuentra reservada",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            //Cambio el estado y le asigno el id de la mesa
            oReserva_Mesa.GetOne_2(Inicio.id_Reserva_Mesa);
            oReserva_Mesa.pid_reserva_mesa = Inicio.id_Reserva_Mesa;
            oReserva_Mesa.pestado_reserva = "Finalizada";
            oReserva_Mesa.pid_mesa = Inicio.id_mesa;
            oReserva_Mesa.Modificar();
            //modifico el estado de la mesa
            omesa.GetOne(Inicio.id_mesa);
            omesa.pestado = "Reservada";

            //cargo el id_reserva a la mesa para proximos detalles
            omesa.pid_reserva = Inicio.id_Reserva_Mesa;
            omesa.Modificar();

            RefrescarGrillaReserva();
            RefrescarGrillaMesa();
            RefrescarReservas();
        }
        #endregion

        private void frmPedido_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
                btnAgregar.PerformClick();
            if (e.KeyCode == Keys.Delete)
                btnBorrar.PerformClick();
            if (e.KeyCode == Keys.F2)
                btnBuscar.PerformClick();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblhora_actual.Text = DateTime.Now.ToString("H:mm:ss");
            this.lblfecha_actual.Text = "(" + DateTime.Now.ToString("d") + ")";
        }

        private void dgvMesa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Estados_Mesa != "Reservada")
            {
                return;
            }
            int i = this.dgvMesa.CurrentRow.Index;
            omesa.GetOne(Inicio.id_mesa);
            Inicio.parametro_Boton_Click_Reserva = 6;
            Inicio.id_Reserva_Mesa = omesa.pid_reserva;
            tbPrincipal.SelectedTab = tpReservas;

            RefrescarGrillaMesa();
            RefrescarGrillaReserva();
            this.dgvMesa.CurrentCell = this.dgvMesa.Rows[i].Cells[1];
            RefrescarGrillaReserva_Hora();
        }

        private void dgvReserva_Hora_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            tbPrincipal.SelectedTab = tpReservas;
            this.rbtBusquedaRapida.Checked = false;
            this.rbtReservas_Historicas.Checked = false;
            this.rbtReservas_pendientes.Checked = false;
            this.rbtDia.Checked = false;
            this.rbtMes.Checked = false;
            this.rbtAño.Checked = false;
            Inicio.parametro_Boton_Click_Reserva = 7;
            RefrescarGrillaReserva();
        }

        private void tbPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int i = this.dgvMesa.CurrentRow.Index;
                switch (tbPrincipal.SelectedTab.Name)
                {
                    case "tpPedido":
                        rbtBusquedaRapida.Checked = false;
                        break;

                    case "tpReservas":
                        RefrescarGrillaReserva();
                        rbtBusquedaRapida.Checked = true;
                        RefrescarReservas();
                        break;
                }
                this.dgvMesa.CurrentCell = this.dgvMesa.Rows[i].Cells[1];
            }
            catch (Exception)
            {

            }

        }


        #endregion

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void tpPedido_Click(object sender, EventArgs e)
        {

        }

        private void btnLiberaMesa_Click(object sender, EventArgs e)
        {
            int filasgrilla = this.dgvdetalle.Rows.Count;
            if (filasgrilla == 0)
            {
                omesa.pestado = "Libre";
                omesa.Modificar();
                RefrescarGrillaMesa();
            }
        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactura frmTemp = new frmFactura();
            frmTemp.ShowDialog();
        }


        long error = 0;

        private void cierreXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverFiscal IFiscal = new DriverFiscal();

            long nError;
            nError = 0;

            IFiscal.SerialNumber = "27-0163848-435";
            nError = IFiscal.IF_OPEN(Inicio.vgPuertoFiscal, 9600);

            nError = IFiscal.IF_WRITE("@CIERRE|X|P");
            //  nError = IFiscal.IF_WRITE("@CIERRE|Z|P")






            error = IFiscal.IF_ERROR2(1);
            error = IFiscal.IF_ERROR2(2);
            error = IFiscal.IF_ERROR2(3);
            error = IFiscal.IF_ERROR2(4);
            error = IFiscal.IF_ERROR2(5);
            error = IFiscal.IF_ERROR2(6);
            error = IFiscal.IF_ERROR2(7);
            error = IFiscal.IF_ERROR2(8);
            error = IFiscal.IF_ERROR2(9);
            error = IFiscal.IF_ERROR2(10);
            error = IFiscal.IF_ERROR2(11);
            error = IFiscal.IF_ERROR2(12);
            error = IFiscal.IF_ERROR2(13);
            error = IFiscal.IF_ERROR2(14);
            error = IFiscal.IF_ERROR2(15);
            error = IFiscal.IF_ERROR2(16);


            error = IFiscal.IF_ERROR1(1);
            error = IFiscal.IF_ERROR1(2);
            error = IFiscal.IF_ERROR1(3);
            error = IFiscal.IF_ERROR1(4);
            error = IFiscal.IF_ERROR1(5);
            error = IFiscal.IF_ERROR1(6);
            error = IFiscal.IF_ERROR1(7);
            error = IFiscal.IF_ERROR1(8);
            error = IFiscal.IF_ERROR1(9);
            error = IFiscal.IF_ERROR1(10);
            error = IFiscal.IF_ERROR1(11);
            error = IFiscal.IF_ERROR1(12);
            error = IFiscal.IF_ERROR1(13);
            error = IFiscal.IF_ERROR1(14);
            error = IFiscal.IF_ERROR1(15);
            error = IFiscal.IF_ERROR1(16);


            nError = IFiscal.IF_CLOSE();
            IFiscal = null;
        }

        private void cierreZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverFiscal IFiscal = new DriverFiscal();

            long nError;
            nError = 0;

            IFiscal.SerialNumber = "27-0163848-435";
            nError = IFiscal.IF_OPEN(Inicio.vgPuertoFiscal, 9600);

            // nError = IFiscal.IF_WRITE("@CIERRE|X|P");
            nError = IFiscal.IF_WRITE("@CIERRE|Z|P");

            nError = IFiscal.IF_CLOSE();
            IFiscal = null;
        }

        private void cerrarComprobanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverFiscal IFiscal = new DriverFiscal();

            long nError;
            nError = 0;

            IFiscal.SerialNumber = "27-0163848-435";
            nError = IFiscal.IF_OPEN(Inicio.vgPuertoFiscal, 9600);

            // nError = IFiscal.IF_WRITE("@CIERRE|X|P");
            nError = IFiscal.IF_WRITE("@FACTCANCEL");
            nError = IFiscal.IF_WRITE("@TIQUECANCEL");
            nError = IFiscal.IF_WRITE("@NOFISCIERRA|T");


            nError = IFiscal.IF_CLOSE();
            IFiscal = null;
        }
    }
}