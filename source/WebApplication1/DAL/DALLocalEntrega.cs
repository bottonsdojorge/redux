using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace redux.DAL
{
    public class DALLocalEntrega : DAL
    {
        public DALLocalEntrega() : base() {}
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Modelo.localEntrega> SelectAll()
        {
            Modelo.localEntrega localEntrega;
            List<Modelo.localEntrega> locaisEntrega = new List<Modelo.localEntrega>();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlLocaisEntrega = "SELECT * FROM localEntrega";
                    SqlCommand cmdLocaisEntrega = new SqlCommand(sqlLocaisEntrega, conn);
                    SqlDataReader drLocaisEntrega;

                    using (drLocaisEntrega = cmdLocaisEntrega.ExecuteReader())
                    {
                        if (drLocaisEntrega.HasRows)
                        {
                            while (drLocaisEntrega.Read())
                            {
                                int id = (int)drLocaisEntrega["id"];
                                string rua = drLocaisEntrega["rua"].ToString();
                                int numero = (int)drLocaisEntrega["numero"];
                                string bairro = drLocaisEntrega["bairro"].ToString();
                                string complemento = drLocaisEntrega["complemento"].ToString();
                                string descricao = drLocaisEntrega["descricao"].ToString();
                                string cep = drLocaisEntrega["cep"].ToString();

                                localEntrega = new Modelo.localEntrega(id, numero, rua, descricao, bairro, cep, complemento);
                                locaisEntrega.Add(localEntrega);
                            }                            
                        }
                    }
                }
            }
            catch (SystemException)
            {   
                throw;
            }

            return locaisEntrega;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Modelo.localEntrega Select(int idLocalEntrega)
        {
            Modelo.localEntrega localEntrega = null;

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlLocalEntrega = "SELECT * FROM localEntrega WHERE id = @id";
                    SqlCommand cmdLocalEntrega = new SqlCommand(sqlLocalEntrega, conn);
                    cmdLocalEntrega.Parameters.Add("@id", SqlDbType.Int).Value = idLocalEntrega;
                    SqlDataReader drLocalEntrega;

                    using (drLocalEntrega = cmdLocalEntrega.ExecuteReader())
                    {
                        if (drLocalEntrega.HasRows)
                        {
                            while (drLocalEntrega.Read())
                            {
                                string rua = drLocalEntrega["rua"].ToString();
                                int numero = (int)drLocalEntrega["numero"];
                                string bairro = drLocalEntrega["bairro"].ToString();
                                string complemento = drLocalEntrega["complemento"].ToString();
                                string descricao = drLocalEntrega["descricao"].ToString();
                                string cep = drLocalEntrega["cep"].ToString();

                                localEntrega = new Modelo.localEntrega(idLocalEntrega, numero, rua, descricao, bairro, cep, complemento);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }

            return localEntrega;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.localEntrega localEntrega)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlLocalEntrega = "DELETE FROM localEntrega WHERE id = @id";
                    SqlCommand cmdLocalEntrega = new SqlCommand(sqlLocalEntrega, conn);
                    cmdLocalEntrega.Parameters.Add("@id", SqlDbType.Int).Value = localEntrega.id;

                    cmdLocalEntrega.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.localEntrega localEntrega)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlLocalEntrega = "INSERT INTO localEntrega (rua, numero, bairro, complemento, descricao, cep) VALUES ('@rua', @numero, '@bairro', '@complemento', '@descricao', '@cep')";
                    SqlCommand cmdLocalEntrega = new SqlCommand(sqlLocalEntrega, conn);
                    cmdLocalEntrega.Parameters.Add("@rua", SqlDbType.VarChar).Value = localEntrega.rua;
                    cmdLocalEntrega.Parameters.Add("@bairro", SqlDbType.VarChar).Value = localEntrega.bairro;
                    cmdLocalEntrega.Parameters.Add("@complemento", SqlDbType.VarChar).Value = localEntrega.complemento;
                    cmdLocalEntrega.Parameters.Add("@descricao", SqlDbType.VarChar).Value = localEntrega.descricao;
                    cmdLocalEntrega.Parameters.Add("@cep", SqlDbType.VarChar).Value = localEntrega.cep;
                    cmdLocalEntrega.Parameters.Add("@numero", SqlDbType.Int).Value = localEntrega.numero;

                    cmdLocalEntrega.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.localEntrega localEntrega)
        {
            if (Select(localEntrega.id) != localEntrega)
            {
                try
                {
                    using (conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string sqlLocalEntrega = "UPDATE localEntrega SET rua = '@rua', numero = @numero, bairro = '@bairro', complemento = '@complemento', descricao = '@descricao', cep = '@cep' WHERE id = @id";
                        SqlCommand cmdLocalEntrega = new SqlCommand(sqlLocalEntrega, conn);
                        cmdLocalEntrega.Parameters.Add("@id", SqlDbType.Int).Value = localEntrega.id;
                        cmdLocalEntrega.Parameters.Add("@rua", SqlDbType.VarChar).Value = localEntrega.rua;
                        cmdLocalEntrega.Parameters.Add("@bairro", SqlDbType.VarChar).Value = localEntrega.bairro;
                        cmdLocalEntrega.Parameters.Add("@complemento", SqlDbType.VarChar).Value = localEntrega.complemento;
                        cmdLocalEntrega.Parameters.Add("@descricao", SqlDbType.VarChar).Value = localEntrega.descricao;
                        cmdLocalEntrega.Parameters.Add("@cep", SqlDbType.VarChar).Value = localEntrega.cep;
                        cmdLocalEntrega.Parameters.Add("@numero", SqlDbType.Int).Value = localEntrega.numero;

                        cmdLocalEntrega.ExecuteNonQuery();
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