using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ApiViajes.Models;

namespace ApiViajes.Data
{
    public class TipoClienteData
    {
        public static bool Save(TipoCliente oTipoCliente)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_tipocliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombreTipoCliente", oTipoCliente.NombreTipoCliente);
                cmd.Parameters.AddWithValue("@cantidadmaxpaquetes", oTipoCliente.CantidadMaxPaquetes);

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
                SqlCommand cmd = new SqlCommand("Delete_tipocliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTipoCliente", id);

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

        public static bool Edit(TipoCliente oTipoCliente)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_tipocliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTipoCliente", oTipoCliente.Id_TipoCliente);
                cmd.Parameters.AddWithValue("@nombreTipoCliente", oTipoCliente.NombreTipoCliente);
                cmd.Parameters.AddWithValue("@cantidadmaxpaquetes", oTipoCliente.CantidadMaxPaquetes);

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

        public static TipoCliente Select(int id)
        {
            TipoCliente oTipoCliente = new TipoCliente();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_tipoCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idtipocliente", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oTipoCliente = new TipoCliente
                            {
                                Id_TipoCliente = Convert.ToInt32(dr["id_TipoCliente"]),
                                NombreTipoCliente = dr["nombreTipoCliente"].ToString(),
                                CantidadMaxPaquetes = Convert.ToInt32(dr["CantidadMaxPaquetes"])
                            };
                        }
                    }
                    oConexion.Close();
                    return oTipoCliente;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<TipoCliente> SelectAll()
        {
            TipoCliente oTipoCliente = new TipoCliente();
            List<TipoCliente> listaTipoCliente = new List<TipoCliente>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_tipocliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oTipoCliente = new TipoCliente
                            {
                                Id_TipoCliente = Convert.ToInt32(dr["id_TipoCliente"]),
                                NombreTipoCliente = dr["nombreTipoCliente"].ToString(),
                                CantidadMaxPaquetes = Convert.ToInt32(dr["CantidadMaxPaquetes"])
                            };
                            listaTipoCliente.Add(oTipoCliente);
                        }
                    }
                    oConexion.Close();
                    return listaTipoCliente;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}