using ApiViajes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiViajes.Data
{
    public class SucursalData
    {

        public static bool Save(Sucursal oSucursal)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_sucursal", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombresucursal", oSucursal.NombreSucursal);

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
                SqlCommand cmd = new SqlCommand("Delete_sucursal", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idsucursal", id);

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

        public static bool Edit(Sucursal oSucursal)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_sucursal", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idsucursal", oSucursal.Id_Sucursal);
                cmd.Parameters.AddWithValue("@nombresucursal", oSucursal.NombreSucursal);

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

        public static Sucursal Select(int id)
        {
            Sucursal oSucursal = new Sucursal();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_sucursal", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idsucursal", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oSucursal = new Sucursal
                            {
                                Id_Sucursal = Convert.ToInt32(dr["id_sucursal"]),
                                NombreSucursal = dr["nombreSucursal"].ToString(),
                            };
                        }
                    }
                    oConexion.Close();
                    return oSucursal;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<Sucursal> SelectAll()
        {
            Sucursal oSucursal = new Sucursal();
            List<Sucursal> listaSucursal = new List<Sucursal>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_sucursal", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oSucursal = new Sucursal
                            {
                                Id_Sucursal = Convert.ToInt32(dr["id_Sucursal"]),
                                NombreSucursal = dr["nombreSucursal"].ToString()
                            };
                            listaSucursal.Add(oSucursal);
                        }
                    }
                    oConexion.Close();
                    return listaSucursal;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
