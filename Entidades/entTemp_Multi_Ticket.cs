using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion_gastronomica.Entidades
{
    class entTemp_Multi_Ticket:Conexion
    {
        private int id_cuerpo_pedido;
        private int id_pedido;
        private int id_producto;
        private int cantidad;
        private double precio;

        public int pid_cuerpo_pedido
        {
            get { return id_cuerpo_pedido; }
            set { id_cuerpo_pedido = value; }
        }
        public int pid_pedido
        {
            get { return id_pedido; }
            set { id_pedido = value; }
        }
        public int pid_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }
        public int pcantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public double pprecio
        {
            get { return precio; }
            set { precio = value; }
        }

        public entTemp_Multi_Ticket()
        {
            id_cuerpo_pedido = 0;
            id_pedido = 0;
            id_producto = 0;
            cantidad = 0;
            precio = 0.0;
        }
    }
}
