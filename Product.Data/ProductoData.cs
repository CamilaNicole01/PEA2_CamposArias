using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Product.Dominio;

namespace Product.Data
{
    public class ProductoData
    {
        string cadenaConexion = "server=localhost; database=Parcial; Integrated Security = true ";

        public List<Producto> Listar()
        {
            var listado = new List<Producto>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("Select * from Producto", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Producto producto;
                            while (lector.Read())
                            {
                                producto = new Producto();
                                producto.IdProducto = int.Parse(lector[0].ToString());
                                producto.Nombre = lector[1].ToString();
                                producto.Marca = lector[2].ToString();
                                producto.Precio = decimal.Parse(lector[3].ToString());
                                producto.Stock= int.Parse(lector[4].ToString());
                                listado.Add(producto);
                            }
                        }
                    }
                }
            }
            return listado;
        }


        public Producto BuscarPorId(int Id)
        {
            Producto producto = new Producto();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Producto WHERE IdProducto = @Id", conexion))
                {
                    comando.Parameters.AddWithValue("@Id", Id);
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            lector.Read();
                            producto = new Producto();
                            producto.IdProducto = int.Parse(lector[0].ToString());
                            producto.Nombre = lector[1].ToString();
                            producto.Marca = lector[2].ToString();
                            producto.Precio = decimal.Parse(lector[3].ToString());
                            producto.Stock = int.Parse(lector[4].ToString());
                        }
                    }
                }
            }
            return producto;
        }

        public bool Insertar(Producto producto)
        {
            int filasInsertadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var Insertsql = "INSERT INTO Producto (Nombre, Marca, Precio, Stock  ) VALUES(@Nombre, @Marca, @Precio, @Stock )";
                using (var comando = new SqlCommand(Insertsql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Marca", producto.Marca);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);
                    filasInsertadas = comando.ExecuteNonQuery();
                }
            }
            return filasInsertadas > 0;
        }

        public bool Actualizar(Producto producto)
        {
            int filasActualizadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var updatesql = "UPDATE Producto (Nombre, Marca, Precio, Stock ) VALUES(@Nombre, @Marca, @Precio, @Stock )";
                using (var comando = new SqlCommand(updatesql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Narca", producto.Marca);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);
                    filasActualizadas = comando.ExecuteNonQuery();
                }
            }
            return filasActualizadas > 0;
        }

        public bool Eliminar(int Id)
        {
            int filasEiminadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var deletesql = "DELETE FROM Producto WHERE IdProducto = @Id";
                using (var comando = new SqlCommand(deletesql, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", Id);
                    filasEiminadas = comando.ExecuteNonQuery();
                }
            }
            return filasEiminadas > 0;
        }
    }
}
