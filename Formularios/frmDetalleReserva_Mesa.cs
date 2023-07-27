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
    public partial class frmDetalleReserva_Mesa : Form
    {
        public frmDetalleReserva_Mesa()
        {
            InitializeComponent();
        }
        Clase.clsCliente ocliente = new Clase.clsCliente();
        Clase.clsReserva_Hora oreserva_hora = new Clase.clsReserva_Hora();
        Clase.clsReserva_Mesa oreserva_mesa = new Clase.clsReserva_Mesa();
        Clase.clsMesa omesa = new Clase.clsMesa();

        //Variables Utiles
        string hora_seleccionada = "";
        int cantidad_seleccionada = 0 ;
        int i = 0;
        private void frmDetalleReserva_Mesa_Load(object sender, EventArgs e)
        {
            CargarComboCliente();

            RefrescarGrillaReserva_Hora();
            if (Inicio.Bandera_Reserva_Mesa == 1)
            {
                LimpiarControles();
                this.mcFecha_Reserva.SelectionStart = DateTime.Today.AddDays(-20);
                this.mcFecha_Reserva.SelectionEnd = DateTime.Today.AddDays(-20);
                this.mcFecha_Reserva.SelectionStart = DateTime.Today;
                this.mcFecha_Reserva.SelectionEnd = DateTime.Today;
            }
            else 
            {
                ObtenerDatos();

            }

            this.Location = ((frmPedido)this.Owner).lblLocalizacionReserva.Location;

            
            
            mcFecha_Reserva.MinDate = DateTime.Today;
            //dandole color a los botones
            var buttons = this.Controls.OfType<Button>();

            foreach (var button in buttons)
            {
                if (button.Name == "btnCliente")
                {
                    //no hago nada y dejo el color del boton por defecto
                }
                else
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
            this.dgvReserva_Hora.CurrentCell = this.dgvReserva_Hora.Rows[i].Cells[1];
            this.txtNroHuesped.Focus();

            mcFecha_Reserva.UpdateBoldedDates();
        }

        public void ObtenerDatos() 
        {
            oreserva_mesa.GetOne(Inicio.id_Reserva_Mesa);
            this.txtNroHuesped.Text = Convert.ToString(oreserva_mesa.pnro_huesped);
            this.txtObservaciones.Text = oreserva_mesa.pobsevacion;
            this.cmbCliente.SelectedValue = oreserva_mesa.pid_cliente;
            this.mcFecha_Reserva.SelectionStart = oreserva_mesa.pfecha_reserva.Date;
            this.mcFecha_Reserva.SelectionEnd = oreserva_mesa.pfecha_reserva.Date;
            string hora_reserva = Convert.ToString(oreserva_mesa.phora_reserva.TimeOfDay);

            //cuando se modifica uno se busca el index de la grilla y se lo deja seleccionado
            //para que el usuario no cometa errores
            foreach (DataGridViewRow row in dgvReserva_Hora.Rows)
            {
                if (row.Cells[1].Value == DBNull.Value)
                    continue;
                string hora_grilla = Convert.ToString(row.Cells[1].Value) + ":00";
                if (hora_grilla == hora_reserva) 
                {
                    i = row.Index;
                }
            }
            
            

        }
        public void AsignarDatos() 
        {
            oreserva_mesa.pnro_huesped = Convert.ToDouble(txtNroHuesped.Text);
            oreserva_mesa.pobsevacion = this.txtObservaciones.Text;
            oreserva_mesa.pid_cliente = Convert.ToInt32(cmbCliente.SelectedValue);
        }
        public void LimpiarControles() 
        {
            this.txtObservaciones.Text = "";
            this.txtNroHuesped.Text = "";
            this.cmbCliente.SelectedItem = null;
            this.cmbCliente.Text = "";
            
        }
        public void RefrescarGrillaReserva_Hora()
        {
            DataTable odt = null;
            oreserva_hora.ResetTable();
            odt = oreserva_hora.GetAll_2();
            foreach (DataRow item in odt.Rows)
            {
                string hora = Convert.ToString(item["Hora"]);
                DateTime fecha = mcFecha_Reserva.SelectionRange.Start.Date;
                int cantidad = oreserva_mesa.ConsultarxHora(hora,fecha);
                if(cantidad != 0)
                {
                    int id_reseva_hora = Convert.ToInt32(item["Id_reserva_hora"]);
                    oreserva_hora.ModificarCantidad(id_reseva_hora,cantidad);
                }
            }
            odt = oreserva_hora.GetAll_2();
            if(mcFecha_Reserva.SelectionStart.Date == DateTime.Today)
            {
                foreach (DataRow row in odt.Rows)
                {
                    DateTime hora_base = Convert.ToDateTime(row["Hora"]);
                    DateTime hora_actual = DateTime.Now;
                    if(hora_base < hora_actual)
                    {
                        row.Delete();
                    }
                }
            }

            
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

            foreach (DataGridViewRow  row in dgvReserva_Hora.Rows)
            {
                
                if (row.Cells[2].Value == DBNull.Value)
                    continue;
                int cantidad = 0;
                int.TryParse(Convert.ToString(row.Cells[2].Value), out cantidad);

                if (cantidad != 0)
                {
                    double cantRegistrada = Math.Ceiling(omesa.CantRegistada());
                    if (cantRegistrada == cantidad)
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
        public  void CargarComboCliente()
        {
            DataTable odt = new DataTable();
            odt = ocliente.GetCmb_2();
            cmbCliente.DataSource = odt;
            cmbCliente.DisplayMember = "nombre";
            cmbCliente.ValueMember = "id_cliente";
            if (this.cmbCliente.SelectedIndex > 0)
            {
                cmbCliente.SelectedIndex = 0;
                Inicio.id_cliente = Convert.ToInt32(cmbCliente.SelectedValue);
            }

        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_cliente = Convert.ToInt32(this.cmbCliente.SelectedValue);
            }
            catch (Exception)
            {
            }
        }
        private void dgvReserva_Hora_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int cantidad_seleccionada = 0;
                Inicio.id_reserva_hora = 0;
               bool res = int.TryParse(this.dgvReserva_Hora[0, this.dgvReserva_Hora.CurrentRow.Index].Value.ToString(), out Inicio.id_reserva_hora );
                hora_seleccionada = Convert.ToString(this.dgvReserva_Hora[1, this.dgvReserva_Hora.CurrentRow.Index].Value.ToString());
               res = int.TryParse(this.dgvReserva_Hora[2, this.dgvReserva_Hora.CurrentRow.Index].Value.ToString(), out cantidad_seleccionada  );
            }
            catch { }
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmAbmCliente oc = new frmAbmCliente();
            oc.ShowDialog();
            CargarComboCliente();
            this.cmbCliente.Focus();
            this.cmbCliente.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Validaciones.
            //validar que el combobox contenga un valor correcto y que no este vacio
            if (cmbCliente.SelectedItem == null | Inicio.id_cliente == 0)
            {

                MessageBox.Show("Llenar El Combo Con datos Correctos", "Advertencia"
                                    ,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                cmbCliente.Focus();
                return;
            }
            //validar que las cajas de texto no esten vacias

            if (string.IsNullOrEmpty(txtNroHuesped.Text) | string.IsNullOrEmpty(txtObservaciones.Text))
            {
                MessageBox.Show("Debe Llenar los Campos Obligatorios", "Advertencia"
                                ,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroHuesped.Focus();
                return;
            }
            if (Inicio.id_reserva_hora == 0 | hora_seleccionada == "" ) 
            {
                MessageBox.Show("Debe seleccionar un horario de reservacion", "Advertencia"
                                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oreserva_hora.GetOne(Inicio.id_reserva_hora);
            int cantidad = oreserva_hora.pcantidad;
            switch (Inicio.Bandera_Reserva_Mesa)
            {
                case 1:
                    cantidad += Convert.ToInt32(this.txtNroHuesped.Text);
                    break;
                case 2:
                    oreserva_mesa.GetOne_2(Inicio.id_Reserva_Mesa);
                    cantidad = (cantidad - Convert.ToInt32(oreserva_mesa.pnro_huesped)) + Convert.ToInt32(this.txtNroHuesped.Text);
                    break;
            }
            
            double cantRegistrada = Math.Ceiling(omesa.CantRegistada());
            if (cantRegistrada < cantidad) 
            {
                MessageBox.Show("Este dia ya tiene cubierta toda las mesas", "Advertencia"
                                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                switch (Inicio.Bandera_Reserva_Mesa) 
                {
                    case 1:
                        //Agrego una nueva reserva
                        oreserva_mesa.pfecha_reserva = mcFecha_Reserva.SelectionRange.Start;
                        oreserva_mesa.pestado_reserva = "Pendiente";
                        oreserva_mesa.phora_reserva = Convert.ToDateTime(hora_seleccionada);
                        oreserva_mesa.pid_cliente = Inicio.id_cliente;
                        oreserva_mesa.pnro_huesped = Convert.ToDouble(this.txtNroHuesped.Text);
                        oreserva_mesa.pobsevacion = this.txtObservaciones.Text;
                        oreserva_mesa.Insertar();
                        ((frmPedido)this.Owner).RefrescarGrillaReserva();
                        RefrescarGrillaReserva_Hora();
                        LimpiarControles();
                        this.txtNroHuesped.Focus();
                        break;
                    case 2:
                        //modifico
                        oreserva_mesa.pid_reserva_mesa = Inicio.id_Reserva_Mesa;
                        oreserva_mesa.pfecha_reserva = mcFecha_Reserva.SelectionRange.Start;
                        oreserva_mesa.pestado_reserva = "Pendiente";
                        oreserva_mesa.phora_reserva = Convert.ToDateTime(hora_seleccionada);
                        oreserva_mesa.pid_cliente = Inicio.id_cliente;
                        oreserva_mesa.pnro_huesped = Convert.ToDouble(this.txtNroHuesped.Text);
                        oreserva_mesa.pobsevacion = this.txtObservaciones.Text;
                        oreserva_mesa.Modificar();
                        this.Close();
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Se a Generado un Error al agregar una reserva. Comuniquese con el Administrador",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mcFecha_Reserva_DateChanged(object sender, DateRangeEventArgs e)
        {

            try
            {   
                int i = this.dgvReserva_Hora.CurrentRow.Index;
                RefrescarGrillaReserva_Hora();
                this.dgvReserva_Hora.CurrentCell = this.dgvReserva_Hora.Rows[i].Cells[1];

                DataTable odt = oreserva_mesa.GetDistinctFecha();
                foreach (DataRow  row in odt.Rows)
                {
                    int cantidad_por_fecha = Convert.ToInt32(row["Total"]);
                    int cantidad_posibles_x_dia = oreserva_mesa.GetCantidadPosibles();
                    DateTime fecha = Convert.ToDateTime(row["fecha_reserva"]);
                    if (cantidad_por_fecha == cantidad_posibles_x_dia)
                    {
                        
                        mcFecha_Reserva.AddBoldedDate(fecha.Date);
                    }
                    else if(cantidad_por_fecha > 0)
                    {
                        mcFecha_Reserva.AddBoldedDate(fecha.Date);
                    }
                }
                

            }
            catch (Exception)
            {
                RefrescarGrillaReserva_Hora();
                DataTable odt = oreserva_mesa.GetDistinctFecha();
                foreach (DataRow row in odt.Rows)
                {
                    int cantidad_por_fecha = Convert.ToInt32(row["Total"]);
                    int cantidad_posibles_x_dia = oreserva_mesa.GetCantidadPosibles();
                    DateTime fecha = Convert.ToDateTime(row["fecha_reserva"]);
                    if (cantidad_por_fecha == cantidad_posibles_x_dia)
                    {

                        mcFecha_Reserva.AddBoldedDate(fecha.Date);
                    }
                    else if (cantidad_por_fecha > 0)
                    {
                        mcFecha_Reserva.AddBoldedDate(fecha.Date);
                    }
                }
            }
            
        }
        
        //Tabulacion
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

        private void dgvReserva_Hora_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void txtNroHuesped_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //se asigna el valor y la funcion que va a tomar esa tecla.
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void cmbCliente_KeyDown(object sender, KeyEventArgs e)
        {
            TabularCombobox(sender,e);
        }

        private void txtObservaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }

        private void btnAyudar_Click(object sender, EventArgs e)
        {
            DataTable odt = oreserva_hora.GetAll();
            int cantidad_dia = Convert.ToInt32(Math.Ceiling(omesa.CantRegistada() * odt.Rows.Count));
            StringBuilder sp = new StringBuilder();
            sp.Append("Se toma como refrencia:");
            sp.AppendLine("Un total de: " + Math.Ceiling(omesa.CantRegistada()) + " persona por hora");
            sp.AppendLine("que conforman el 80% de personas que puede alojar el lugar por hora");
            sp.AppendLine("El calculo se realiza con la suma de la cantidad de persona que,");
            sp.AppendLine("completan una mesa");
            sp.AppendLine("");
            sp.AppendLine("Un total de: " + cantidad_dia + " personas por dia");

            MessageBox.Show(""+sp,"Ayuda",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }



        



   
    }
}
