using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ApiViajes.Models;

namespace ApiViajes.Data
{
    public class TipoUsuarioData
    {
        public static bool Save(TipoUsuario oTipoUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_tipoUsuario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombretipousuario", oTipoUsuario.NombreTipoUsuario);
                cmd.Parameters.AddWithValue("@funciones", oTipoUsuario.Funciones);

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
                SqlCommand cmd = new SqlCommand("Delete_tipoUsuario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idtipousuario", id);

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

        public static bool Edit(TipoUsuario oTipoUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_tipoUsuario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idtipousuario", oTipoUsuario.Id_TipoUsuario);
                cmd.Parameters.AddWithValue("@nombretipousuario", oTipoUsuario.NombreTipoUsuario);
                cmd.Parameters.AddWithValue("@funciones", oTipoUsuario.Funciones);

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

        public static TipoUsuario Select(int id)
        {
            TipoUsuario otipoUsuario = new TipoUsuario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_tipoUsuario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idtipousuario", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            otipoUsuario = new TipoUsuario
                            {
                                Id_TipoUsuario = Convert.ToInt32(dr["id_tipoUsuario"]),
                                NombreTipoUsuario = dr["nombreTipoUsuario"].ToString(),
                                Funciones = dr["Funciones"].ToString()
                            };
                        }
                    }
                    oConexion.Close();
                    return otipoUsuario;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<TipoUsuario> SelectAll()
        {
            TipoUsuario otipoUsuario = new TipoUsuario();
            List<TipoUsuario> listaTipoUsuario = new List<TipoUsuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_tipoUsuario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            otipoUsuario = new TipoUsuario
                            {
                                Id_TipoUsuario = Convert.ToInt32(dr["id_tipoUsuario"]),
                                NombreTipoUsuario = dr["nombreTipoUsuario"].ToString(),
                                Funciones = dr["Funciones"].ToString()
                            };
                            listaTipoUsuario.Add(otipoUsuario);
                        }
                    }
                    oConexion.Close();
                    return listaTipoUsuario;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}