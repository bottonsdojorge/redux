using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace redux.DAL
{
    public class DALStatus : DAL
    {
        public DALStatus() : base() {}

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Modelo.Status> SelectAll()
        {
            Modelo.Status status;
            List<Modelo.Status> statue = new List<Modelo.Status>();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlStatue = "SELECT * FROM Status";
                    SqlCommand cmdStatue = new SqlCommand(sqlStatue, conn);
                    SqlDataReader drStatue;

                    using (drStatue = cmdStatue.ExecuteReader())
                    {
                        if (drStatue.HasRows)
                        {
                            while (drStatue.Read())
                            {
                                int id = Convert.ToInt32(drStatue["id"]);
                                string descricao = drStatue["descricao"].ToString();

                                status = new Modelo.Status(id, descricao);
                                statue.Add(status);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {   
                throw;
            }

            return statue;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Modelo.Status Select(int idStatus)
        {
            Modelo.Status status = null;
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlStatus = "SELECT * FROM Status WHERE id = @id";
                    SqlCommand cmdStatus = new SqlCommand(sqlStatus, conn);
                    cmdStatus.Parameters.Add("@id", SqlDbType.Int).Value = idStatus;
                    SqlDataReader drStatus = cmdStatus.ExecuteReader();

                    if (drStatus.HasRows)
                    {
                        while (drStatus.Read())
                        {
                            string descricao = drStatus["descricao"].ToString();
                            status = new Modelo.Status(idStatus, descricao);
                        }
                    }

                }
            }
            catch (SystemException)
            {   
                throw;
            }

            return status;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Modelo.Status status)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlStatus = "DELETE FROM Status WHERE id = @id";
                    SqlCommand cmdStatus = new SqlCommand(sqlStatus, conn);
                    cmdStatus.Parameters.Add("@id", SqlDbType.Int).Value = status.id;

                    cmdStatus.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {   
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void Insert(Modelo.Status status)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlStatus = "INSERT INTO Status (descricao) VALUES ('@descricao')";
                    SqlCommand cmdStatus = new SqlCommand(sqlStatus, conn);
                    cmdStatus.Parameters.Add("@descricao", SqlDbType.VarChar).Value = status.descricao;

                    cmdStatus.ExecuteNonQuery();
                }
            }   
            catch (SystemException)
            {   
                throw;
            }    
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Modelo.Status status)
        {
            if (Select(status.id) != status)
            {
                try
                {
                    using (conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string sqlStatus = "UPDATE Status SET descricao = '@descricao' WHERE id = @id";
                        SqlCommand cmdStatus = new SqlCommand(sqlStatus, conn);
                        cmdStatus.Parameters.Add("@id", SqlDbType.Int).Value = status.id;
                        cmdStatus.Parameters.Add("@descricao", SqlDbType.VarChar).Value = status.descricao;

                        cmdStatus.ExecuteNonQuery();
                    }
                }
                catch (SystemException)
                {   
                    throw;
                }   
            }
        }
    }
}