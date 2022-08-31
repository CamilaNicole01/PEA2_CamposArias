using Product.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Product.AppWin
{
    public partial class frmProductEdit : Form
    {
        Producto producto;

        public frmProductEdit(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
        }

        private void iniciarFormulario(object sender, EventArgs e)
        {
          if(producto.IdProducto > 0)
            {
                asignarControles();
            }
        }
        
        private void grabarDatos(object sender, EventArgs e)
        {
            asignarObjetos();
            this.DialogResult = DialogResult.OK;
           }

        private void asignarObjetos()
        {
            producto.Nombre = txtNombre.Text;
            producto.Marca= txtMarca.Text;
            producto.Precio = decimal.Parse(txtPrecio.Text);
            producto.Stock = int.Parse(txtStock.Text);
            
        }
        private void asignarControles()
        {
            txtNombre.Text = producto.Nombre;
            txtMarca.Text = producto.Marca;
            decimal.Parse(txtPrecio.Text = producto.Precio.ToString());
            int.Parse(txtStock.Text = producto.Stock.ToString());
        }
    }
}
