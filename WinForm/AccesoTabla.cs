using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormApp
{    
    /// <summary>
    /// Clase publica para acceder ya sea eliminando,agregando o modificando datos de mi tabla SQL
    /// </summary>
    public class AccesoTabla
    {
        #region Atributos
        /// <summary>
        /// Contiene CLAVE para la base de datos.
        /// </summary>
        private SqlConnection conexion;
        /// <summary>
        /// String privado de que contiene la clave de conexion para la base de datos.
        /// </summary>
        private static string cadena_conexion;
        /// <summary>
        /// Se utilizara para ejecutar comandos de tipo SQL COMMAND.
        /// </summary>
        private SqlCommand comando;
        /// <summary>
        /// Se utilizara para leer variables y agregarlos y demas en la tabla.
        /// </summary>
        private SqlDataReader lector;

        #endregion

        #region Constructor
        static AccesoTabla()
        {
            AccesoTabla.cadena_conexion = Properties.Resources.miConexion;
        }
        public AccesoTabla()
        {
            this.conexion = new SqlConnection(AccesoTabla.cadena_conexion);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo publico que obtendra los datos de la tabla de mi Base de Datos.
        /// </summary>
        public List<Electronica> ObtenerListaDatos()
        {
            List<Electronica> lista = new List<Electronica>();
            try
            { 
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = "select id,tipo,nombre,marca,stock,caracteristica1,caracteristica2 from tabla_crud";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();

                while (this.lector.Read())
                {
                    string parsear;
                    string tipo = this.lector["tipo"].ToString();
                    if (tipo == "COMPUTADORA")
                    {
                        Computadora dato = new Computadora();
                        dato.id = (int)this.lector["id"];
                        dato.tipo = this.lector["tipo"].ToString();
                        dato.nombre = this.lector["nombre"].ToString();
                        dato.marca = (EMarcas)Enum.Parse(typeof(EMarcas), this.lector["marca"].ToString());
                        dato.stock = (int)this.lector["stock"];
                        dato.grafica = this.lector["caracteristica1"].ToString(); 
                        parsear = this.lector["caracteristica2"].ToString();
                        dato.memoriaRam = int.Parse(parsear);
                        lista.Add(dato);
                    }
                    else
                    {
                        if (tipo == "TELEFONO")
                        {
                            Telefono dato = new Telefono();
                            dato.id = (int)this.lector["id"];
                            dato.tipo = this.lector["tipo"].ToString();
                            dato.nombre = this.lector["nombre"].ToString();
                            dato.marca = (EMarcas)Enum.Parse(typeof(EMarcas), this.lector["marca"].ToString());
                            dato.stock = (int)this.lector["stock"];
                            dato.pantalla = this.lector["caracteristica1"].ToString();
                            dato.modelo = this.lector["caracteristica2"].ToString();
                            lista.Add(dato);
                        }
                        else
                        {
                            if (tipo == "CONSOLA")
                            {
                                Consola dato = new Consola();
                                dato.id = (int)this.lector["id"];
                                dato.tipo = this.lector["tipo"].ToString();
                                dato.nombre = this.lector["nombre"].ToString();
                                dato.marca = (EMarcas)Enum.Parse(typeof(EMarcas), this.lector["marca"].ToString());
                                dato.stock = (int)this.lector["stock"];
                                dato.generacion = this.lector["caracteristica1"].ToString();
                                parsear = this.lector["caracteristica2"].ToString();
                                dato.almacenamiento = int.Parse(parsear);
                                lista.Add(dato);
                            }
                        }
                    }

                }
                this.lector.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open) 
                {
                    this.conexion.Close();
                }
            }

            return lista;
        }

        /// <summary>
        /// Metodo publico que agregara el producto "d" a mi base de datos desde mi CRUD.
        /// </summary>
        public bool AgregarDato(Electronica d)
        {
            bool retorno = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = d.InsertarDatoTabla();
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if(filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return retorno;
        }

        /// <summary>
        /// Metodo publico que modificara los datos del producto "d" mi base de datos desde mi CRUD
        /// </summary>
        public bool ModificarDato(Electronica d)
        {
            bool retorno = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@id", d.id);
                this.comando.Parameters.AddWithValue("@nombre", d.nombre);
                this.comando.Parameters.AddWithValue("@marca", d.marca.ToString());
                this.comando.Parameters.AddWithValue("@stock", d.stock);


                if (d is Computadora c)
                {
                    this.comando.Parameters.AddWithValue("@tipo", c.tipo);
                    this.comando.Parameters.AddWithValue("@caracteristica1", c.grafica);
                    this.comando.Parameters.AddWithValue("@caracteristica2", c.memoriaRam.ToString());
                }
                else if (d is Telefono t)
                {
                    this.comando.Parameters.AddWithValue("@tipo", t.tipo);
                    this.comando.Parameters.AddWithValue("@caracteristica1", t.pantalla);
                    this.comando.Parameters.AddWithValue("@caracteristica2", t.modelo);
                }
                else if (d is Consola con)
                {
                    this.comando.Parameters.AddWithValue("@tipo", con.tipo);
                    this.comando.Parameters.AddWithValue("@caracteristica1", con.generacion);
                    this.comando.Parameters.AddWithValue("@caracteristica2", con.almacenamiento.ToString());
                }
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = "update tabla_crud set tipo = @tipo, nombre = @nombre, marca = @marca, stock = @stock, caracteristica1 = @caracteristica1, caracteristica2 = @caracteristica2 where id = @id";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return retorno;
        }

        /// <summary>
        /// Metodo publico que eliminara "d" de mi base de datos leyendo desde mi CRUD.
        /// </summary>
        public bool EliminarDato(int id)
        {
            bool retorno = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@id", id);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = "DELETE FROM tabla_crud WHERE id = @id";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                    retorno = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return retorno;
        }
        #endregion
    }
}
