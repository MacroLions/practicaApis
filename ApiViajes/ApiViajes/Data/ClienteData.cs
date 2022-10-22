using ApiViajes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiViajes.Data
{
    public class ClienteData
    {
        public static bool Save(Cliente oCliente)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Cliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idtipoCliente", oCliente.Id_TipoCliente);
                cmd.Parameters.AddWithValue("@nombreCliente", oCliente.NombreCliente);
                cmd.Parameters.AddWithValue("@apellidoCliente", oCliente.ApellidoCliente);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    oConexion.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Delete(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Delete_Cliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idCliente", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    oConexion.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Edit(Cliente oCliente)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_Cliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idCliente", oCliente.Id_Cliente);
                cmd.Parameters.AddWithValue("@idtipoCliente", oCliente.Id_TipoCliente);
                cmd.Parameters.AddWithValue("@nombreCliente", oCliente.NombreCliente);
                cmd.Parameters.AddWithValue("@apellidoCliente", oCliente.ApellidoCliente);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    oConexion.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static Cliente Select(int id)
        {
            Cliente oCliente = new Cliente();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Cliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idCliente", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCliente = new Cliente
                            {
                                Id_Cliente = Convert.ToInt32(dr["id_Cliente"]),
                                Id_TipoCliente = Convert.ToInt32(dr["id_tipoCliente"]),
                                NombreCliente = dr["nombreCliente"].ToString(),
                                ApellidoCliente = dr["apellidoCliente"].ToString(),
                            };
                        }
                    }
                    oConexion.Close();
                    return oCliente;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<Cliente> SelectAll()
        {
            Cliente oCliente = new Cliente();
            List<Cliente> listaCliente = new List<Cliente>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Cliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCliente = new Cliente
                            {
                                Id_Cliente = Convert.ToInt32(dr["id_Cliente"]),
                                Id_TipoCliente = Convert.ToInt32(dr["id_tipoCliente"]),
                                NombreCliente = dr["nombreCliente"].ToString(),
                                ApellidoCliente = dr["apellidoCliente"].ToString(),
                            };
                            listaCliente.Add(oCliente);
                        }
                    }
                    oConexion.Close();
                    return listaCliente;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}