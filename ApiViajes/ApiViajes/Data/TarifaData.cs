using ApiViajes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiViajes.Data
{
    public class TarifaData
    {
        public static bool Save(Tarifa oTarifa)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Tarifa", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idtipocliente", oTarifa.Id_TipoCliente);
                cmd.Parameters.AddWithValue("@idtransporte", oTarifa.Id_Transporte);
                cmd.Parameters.AddWithValue("@nombreTarifa", oTarifa.NombreTarifa);
                cmd.Parameters.AddWithValue("@costociudad", oTarifa.costoCiudad);
                cmd.Parameters.AddWithValue("@costoMunicipio", oTarifa.costoMunicipio);
                cmd.Parameters.AddWithValue("@costointeriorpais", oTarifa.costoInteriorPais);

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
                SqlCommand cmd = new SqlCommand("Delete_Tarifa", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTarifa", id);

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

        public static bool Edit(Tarifa oTarifa)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_tarifa", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idtarifa", oTarifa.Id_Tarifa);
                cmd.Parameters.AddWithValue("@idtipocliente", oTarifa.Id_TipoCliente);
                cmd.Parameters.AddWithValue("@idtransporte", oTarifa.Id_Transporte);
                cmd.Parameters.AddWithValue("@nombretarifa", oTarifa.NombreTarifa);
                cmd.Parameters.AddWithValue("@costociudad", oTarifa.costoCiudad);
                cmd.Parameters.AddWithValue("@costoMunicipio", oTarifa.costoMunicipio);
                cmd.Parameters.AddWithValue("@costointeriorpais", oTarifa.costoInteriorPais);

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

        public static Tarifa Select(int id)
        {
            Tarifa oTarifa = new Tarifa();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Tarifa", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTarifa", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oTarifa = new Tarifa
                            {
                                Id_Tarifa = Convert.ToInt32(dr["id_Tarifa"]),
                                Id_TipoCliente = Convert.ToInt32(dr["id_tipoCliente"]),
                                Id_Transporte = Convert.ToInt32(dr["id_transporte"]),
                                NombreTarifa = dr["nombreTarifa"].ToString(),
                                costoCiudad = Convert.ToSingle(dr["costoCiudad"]),
                                costoMunicipio = Convert.ToSingle(dr["costoMunicipio"]),
                                costoInteriorPais = Convert.ToSingle(dr["costoInteriorPais"]),
                            };
                        }
                    }
                    oConexion.Close();
                    return oTarifa;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<Tarifa> SelectAll()
        {
            Tarifa oTarifa = new Tarifa();
            List<Tarifa> listaTarifa = new List<Tarifa>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Tarifa", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oTarifa = new Tarifa
                            {
                                Id_Tarifa = Convert.ToInt32(dr["id_Tarifa"]),
                                Id_TipoCliente = Convert.ToInt32(dr["id_tipoCliente"]),
                                Id_Transporte = Convert.ToInt32(dr["id_transporte"]),
                                NombreTarifa = dr["nombreTarifa"].ToString(),
                                costoCiudad = Convert.ToSingle(dr["costoCiudad"]),
                                costoMunicipio = Convert.ToSingle(dr["costoMunicipio"]),
                                costoInteriorPais = Convert.ToSingle(dr["costoInteriorPais"]),
                            };
                            listaTarifa.Add(oTarifa);
                        }
                    }
                    oConexion.Close();
                    return listaTarifa;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}