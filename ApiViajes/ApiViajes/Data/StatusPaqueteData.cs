using ApiViajes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiViajes.Data
{
    public class StatusPaqueteData
    {
        public static bool Save(StatusPaquete oStatusPaquete)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_StatusPaquete", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombreStatusPaquete", oStatusPaquete.NombreStatusPaquete);

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
                SqlCommand cmd = new SqlCommand("Delete_StatusPaquete", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idStatusPaquete", id);

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

        public static bool Edit(StatusPaquete oStatusPaquete)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_StatusPaquete", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idStatusPaquete", oStatusPaquete.Id_StatusPaquete);
                cmd.Parameters.AddWithValue("@nombreStatusPaquete", oStatusPaquete.NombreStatusPaquete);

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

        public static StatusPaquete Select(int id)
        {
            StatusPaquete oStatusPaquete = new StatusPaquete();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_StatusPaquete", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idStatusPaquete", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oStatusPaquete = new StatusPaquete
                            {
                                Id_StatusPaquete = Convert.ToInt32(dr["id_StatusPaquete"]),
                                NombreStatusPaquete = dr["nombreStatusPaquete"].ToString(),
                            };
                        }
                    }
                    oConexion.Close();
                    return oStatusPaquete;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<StatusPaquete> SelectAll()
        {
            StatusPaquete oStatusPaquete = new StatusPaquete();
            List<StatusPaquete> listaStatusPaquete = new List<StatusPaquete>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_StatusPaquete", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oStatusPaquete = new StatusPaquete
                            {
                                Id_StatusPaquete = Convert.ToInt32(dr["id_StatusPaquete"]),
                                NombreStatusPaquete = dr["nombreStatusPaquete"].ToString()
                            };
                            listaStatusPaquete.Add(oStatusPaquete);
                        }
                    }
                    oConexion.Close();
                    return listaStatusPaquete;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}