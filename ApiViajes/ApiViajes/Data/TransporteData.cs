using ApiViajes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiViajes.Data
{
    public class TransporteData
    {
        public static bool Save(Transporte oTransporte)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Transporte", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombreTransporte", oTransporte.NombreTransporte);
                cmd.Parameters.AddWithValue("@idsucursal", oTransporte.Id_Sucursal);

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
                SqlCommand cmd = new SqlCommand("Delete_Transporte", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTransporte", id);

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

        public static bool Edit(Transporte oTransporte)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_Transporte", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTransporte", oTransporte.Id_Transporte);
                cmd.Parameters.AddWithValue("@nombreTransporte", oTransporte.NombreTransporte);
                cmd.Parameters.AddWithValue("@idsucursal", oTransporte.Id_Sucursal);

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

        public static Transporte Select(int id)
        {
            Transporte oTransporte = new Transporte();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Transporte", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTransporte", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oTransporte = new Transporte
                            {
                                Id_Transporte = Convert.ToInt32(dr["id_Transporte"]),
                                NombreTransporte = dr["nombreTransporte"].ToString(),
                                Id_Sucursal = Convert.ToInt32(dr["id_sucursal"]),
                            };
                        }
                    }
                    oConexion.Close();
                    return oTransporte;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<Transporte> SelectAll()
        {
            Transporte oTransporte = new Transporte();
            List<Transporte> listaTransporte = new List<Transporte>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Transporte", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oTransporte = new Transporte
                            {
                                Id_Transporte = Convert.ToInt32(dr["id_Transporte"]),
                                NombreTransporte = dr["nombreTransporte"].ToString(),
                                Id_Sucursal = Convert.ToInt32(dr["id_sucursal"]),
                            };
                            listaTransporte.Add(oTransporte);
                        }
                    }
                    oConexion.Close();
                    return listaTransporte;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}