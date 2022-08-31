using Product.Dominio;
using Product.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product.AppWin
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            var listado = ProductoBL.Listar();
            dgvListado.Rows.Clear();
            foreach (var producto in listado)
            {
                dgvListado.Rows.Add(producto.IdProducto, producto.Nombre, producto.Marca, producto.Precio);
            }
        }

          private void nuevoRegistro(object sender, EventArgs e)
        {
            var nuevoProducto = new Producto();
            var frm = new frmProductEdit(nuevoProducto);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var exito = ProductoBL.Insertar(nuevoProducto);
                if (exito) 
                {
                    MessageBox.Show("El Producto ha sido registrado", "Parcial",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar al producto", "Parcial",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void editarRegistro(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var IdProducto = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var productoEditar = ProductoBL.BuscarPorId(IdProducto);
                var frm = new frmProductEdit(productoEditar);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var exito = ProductoBL.Actualizar(productoEditar);
                    if (exito)
                    {
                        MessageBox.Show("El producto ha sido actualizado", "Parcial",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido completar la operación de actualización",
                            "Parcial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }
 }
        private void eliminarRegistro(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var IdProducto = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var nombreProducto = dgvListado.Rows[filaActual].Cells[1].Value.ToString();
                var rpta = MessageBox.Show("¿Realmente desea eliminar al Producto " + nombreProducto + " ?",
                    "Parcial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {
                    var exito = ProductoBL.Eliminar(IdProducto);
                    if (exito)
                    {
                        MessageBox.Show("El producto ha sido eliminado.", "parcial",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido completar la eliminación del producto",
                            "parcial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
    }
}
    }
}








