using System;
using System.Collections.Generic;
using System.Text;
using Product.Dominio;
using Product.Data;

namespace Product.Logic
{
    public static class ProductoBL
    {
        public static List<Producto> Listar()
        {
            var productData = new ProductoData();
            return productData.Listar();
        }
        public static Producto BuscarPorId(int Id)
        {
            var productoData = new ProductoData();
            return productoData.BuscarPorId(Id);
        }

        ///////////////Posible Regla de negocio///////////////
        //public static double MinimoCantidad(decimal precio, int stock)
        //{
        // var producto = new Producto();
        // decimal.Parse(txtPrecio.Text = producto.Precio.ToString());
        // int.Parse(txtStock.Text = producto.Stock.ToString());
        // if (producto.Precio >= 2500 && producto.Stock <5)
        // {
        //    MessageBox.Show("Esta excediendo el limite de cantidad", "Parcial");
        //}
        //else
        //{
        //     return Insertar();
        // }
        //}

        public static bool Insertar(Producto producto)
        {
            var productoData = new ProductoData();
            return productoData.Insertar(producto);
        }

        public static bool Actualizar(Producto producto)
        {
            var productoData = new ProductoData();
            return productoData.Actualizar(producto);
        }
        public static bool Eliminar(int Id)
        {
            var productoData = new ProductoData();
            return productoData.Eliminar(Id);
        }
    }

}

