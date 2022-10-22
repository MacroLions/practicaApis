using ApiViajes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiViajes.Data
{
    public class BodegaData
    {
        public static bool Save(Bodega obodega)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_bodega", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombrebodega", obodega.NombreBodega);
                cmd.Parameters.AddWithValue("@idsucursal", obodega.Id_Sucursal);

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
                SqlCommand cmd = new SqlCommand("Delete_bodega", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idbodega", id);

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

        public static bool Edit(Bodega obodega)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_bodega", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idbodega", obodega.Id_Bodega);
                cmd.Parameters.AddWithValue("@nombrebodega", obodega.NombreBodega);
                cmd.Parameters.AddWithValue("@idsucursal", obodega.Id_Sucursal);

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

        public static Bodega Select(int id)
        {
            Bodega obodega = new Bodega();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_bodega", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idbodega", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obodega = new Bodega
                            {
                                Id_Bodega = Convert.ToInt32(dr["id_bodega"]),
                                NombreBodega = dr["nombrebodega"].ToString(),
                                Id_Sucursal = Convert.ToInt32(dr["id_sucursal"]),
                            };
                        }
                    }
                    oConexion.Close();
                    return obodega;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<Bodega> SelectAll()
        {
            Bodega obodega = new Bodega();
            List<Bodega> listabodega = new List<Bodega>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_bodega", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obodega = new Bodega
                            {
                                Id_Bodega = Convert.ToInt32(dr["id_bodega"]),
                                NombreBodega = dr["nombrebodega"].ToString(),
                                Id_Sucursal = Convert.ToInt32(dr["id_sucursal"]),
                            };
                            listabodega.Add(obodega);
                        }
                    }
                    oConexion.Close();
                    return listabodega;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}