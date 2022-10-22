using ApiViajes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiViajes.Data
{
    public class TipoPagoData
    {
        public static bool Save(TipoPago oTipoPago)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_TipoPago", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombreTipoPago", oTipoPago.NombreTipoPago);

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
                SqlCommand cmd = new SqlCommand("Delete_TipoPago", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTipoPago", id);

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

        public static bool Edit(TipoPago oTipoPago)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_TipoPago", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTipoPago", oTipoPago.Id_TipoPago);
                cmd.Parameters.AddWithValue("@nombreTipoPago", oTipoPago.NombreTipoPago);

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

        public static TipoPago Select(int id)
        {
            TipoPago oTipoPago = new TipoPago();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_TipoPago", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTipoPago", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oTipoPago = new TipoPago
                            {
                                Id_TipoPago = Convert.ToInt32(dr["id_TipoPago"]),
                                NombreTipoPago = dr["nombreTipoPago"].ToString(),
                            };
                        }
                    }
                    oConexion.Close();
                    return oTipoPago;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<TipoPago> SelectAll()
        {
            TipoPago oTipoPago = new TipoPago();
            List<TipoPago> listaTipoPago = new List<TipoPago>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_TipoPago", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oTipoPago = new TipoPago
                            {
                                Id_TipoPago = Convert.ToInt32(dr["id_TipoPago"]),
                                NombreTipoPago = dr["nombreTipoPago"].ToString()
                            };
                            listaTipoPago.Add(oTipoPago);
                        }
                    }
                    oConexion.Close();
                    return listaTipoPago;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}