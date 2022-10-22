using ApiViajes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiViajes.Data
{
    public class InformePaqueteData
    {
        public static bool Save(InformePaquete oInformePaquete)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_informePaquete", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@idcliente", oInformePaquete.Id_Cliente);
                cmd.Parameters.AddWithValue("@idtransporte", oInformePaquete.Id_Transporte);
                cmd.Parameters.AddWithValue("@fechaenvio", oInformePaquete.FechaEnvio);
                cmd.Parameters.AddWithValue("@fecharecibo", oInformePaquete.FechaRecibo);
                cmd.Parameters.AddWithValue("@idsucursalorigen", oInformePaquete.Id_SucursalOrigen);
                cmd.Parameters.AddWithValue("@idsucursaldestino", oInformePaquete.Id_SucursalDestino);

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
                SqlCommand cmd = new SqlCommand("Delete_informePaquete", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idInformePaquete", id);

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

        public static bool Edit(InformePaquete oInformePaquete)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_informePaquete", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idinformepaquete", oInformePaquete.Id_InformePaquete);
                cmd.Parameters.AddWithValue("@idcliente", oInformePaquete.Id_Cliente);
                cmd.Parameters.AddWithValue("@codigopaquete", oInformePaquete.CodigoPaquete);
                cmd.Parameters.AddWithValue("@idtransporte", oInformePaquete.Id_Transporte);
                cmd.Parameters.AddWithValue("@fechaenvio", oInformePaquete.FechaEnvio);
                cmd.Parameters.AddWithValue("@fecharecibo", oInformePaquete.FechaRecibo);
                cmd.Parameters.AddWithValue("@idsucursalorigen", oInformePaquete.Id_SucursalOrigen);
                cmd.Parameters.AddWithValue("@idsucursaldestino", oInformePaquete.Id_SucursalDestino);
                cmd.Parameters.AddWithValue("@idstatuspaquete", oInformePaquete.Id_StatusPaquete);

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

        public static InformePaquete Select(int id)
        {
            InformePaquete oInformePaquete = new InformePaquete();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_informePaquete", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idInformePaquete", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oInformePaquete = new InformePaquete
                            {
                                Id_InformePaquete = Convert.ToInt32(dr["id_informePaquete"]),
                                CodigoPaquete = dr["codigoPaquete"].ToString(),
                                Id_Cliente = Convert.ToInt32(dr["id_cliente"]),
                                Id_Transporte = Convert.ToInt32(dr["id_transporte"]),
                                FechaEnvio = Convert.ToDateTime(dr["fechaenvio"]),
                                FechaRecibo = Convert.ToDateTime(dr["fecharecibo"]),
                                Id_SucursalOrigen = Convert.ToInt32(dr["id_sucursalOrigen"]),
                                Id_SucursalDestino = Convert.ToInt32(dr["id_sucursalDestino"]),
                                Id_StatusPaquete = Convert.ToInt32(dr["id_StatusPaquete"]),
                            };
                        }
                    }
                    oConexion.Close();
                    return oInformePaquete;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<InformePaquete> SelectAll()
        {
            InformePaquete oInformePaquete = new InformePaquete();
            List<InformePaquete> listaInformePaquete = new List<InformePaquete>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_informePaquete", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oInformePaquete = new InformePaquete
                            {
                                Id_InformePaquete = Convert.ToInt32(dr["id_informePaquete"]),
                                CodigoPaquete = dr["codigoPaquete"].ToString(),
                                Id_Cliente = Convert.ToInt32(dr["id_cliente"]),
                                Id_Transporte = Convert.ToInt32(dr["id_transporte"]),
                                FechaEnvio = Convert.ToDateTime(dr["fechaenvio"]),
                                FechaRecibo = Convert.ToDateTime(dr["fecharecibo"]),
                                Id_SucursalOrigen = Convert.ToInt32(dr["id_sucursalOrigen"]),
                                Id_SucursalDestino = Convert.ToInt32(dr["id_sucursalDestino"]),
                                Id_StatusPaquete = Convert.ToInt32(dr["id_StatusPaquete"]),
                            };
                            listaInformePaquete.Add(oInformePaquete);
                        }
                    }
                    oConexion.Close();
                    return listaInformePaquete;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}