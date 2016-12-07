using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace redux.DAL
{
    public class DALMarcador : DAL
    {
        public DALMarcador() : base(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Modelo.Marcador> SelectAll()
        {
            // O Marcador
            Modelo.Marcador marcador;
            // A lista de retorno
            List<Modelo.Marcador> marcadores = new List<Modelo.Marcador>();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlMarcadores = "SELECT * FROM Marcador";
                    SqlCommand cmdMarcadores = new SqlCommand(sqlMarcadores, conn);
                    SqlDataReader drMarcadores;
                    using (drMarcadores = cmdMarcadores.ExecuteReader())
                    {                        
                        // Leitura do resultado
                        if (drMarcadores.HasRows)
                        {
                            while (drMarcadores.Read())
                            {
                                int id = Convert.ToInt32(drMarcadores["id"]);
                                string descricao = drMarcadores["descricao"].ToString();
                                marcador = new Modelo.Marcador(id, descricao);
                                marcadores.Add(marcador);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {                
                throw;
            }
            return marcadores;
        }   

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Modelo.Marcador Select(int idMarcador)
        {
            // O Marcador
            Modelo.Marcador marcador = null;
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlMarcadores = "SELECT * FROM Marcador WHERE id = @id";
                    SqlCommand cmdMarcadores = new SqlCommand(sqlMarcadores, conn);
                    cmdMarcadores.Parameters.Add("@id", SqlDbType.Int).Value = idMarcador;
                    SqlDataReader drMarcadores;

                    using (drMarcadores = cmdMarcadores.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drMarcadores.HasRows)
                        {
                            while (drMarcadores.Read())
                            {
                                int id = Convert.ToInt32(drMarcadores["id"]);
                                string descricao = drMarcadores["descricao"].ToString();
                                marcador = new Modelo.Marcador(id, descricao);
                            }
                        }                        
                    }
                }
            }

            // Alguma excessão eventual deverá ser tratada aqui.
            catch (SystemException)
            {
                throw;
            }
            return marcador;
        }

        /*
         * Retorna uma lista de Marcadores a partir do ID do Produto. 
         * @param int id do produto
         */
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Modelo.Marcador> SelectFromProduto(int idProduto)
        {
            // O Marcador
            Modelo.Marcador marcador;
            // A lista de retorno
            List<Modelo.Marcador> marcadores = new List<Modelo.Marcador>();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL da tabela relacional
                    string sqlMarcador = "SELECT * FROM Marcador m INNER JOIN marcadorProduto mp ON mp.Marcador_id = m.id WHERE mp.Produto_id = @idProduto";
                    SqlCommand cmdMarcador = new SqlCommand(sqlMarcador, conn);
                    cmdMarcador.Parameters.Add("@idProduto", SqlDbType.Int).Value = idProduto;
                    SqlDataReader drMarcador;

                    using (drMarcador = cmdMarcador.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drMarcador.HasRows)
                        {
                            while (drMarcador.Read())
                            {
                                int id = Convert.ToInt32(drMarcador["id"]);
                                string descricao = drMarcador["descricao"].ToString();

                                // Instanciamento do marcador.
                                marcador = new Modelo.Marcador(id, descricao);
                                marcadores.Add(marcador);
                             
                            }
                        }
                    }
                }
            }

            // Alguma excessão eventual deverá ser tratada aqui.
            catch (SystemException)
            {
                throw;
            }
            return marcadores;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Modelo.Marcador marcador)
        {
            string id = marcador.id.ToString();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    // O SQL
                    string sqlMarcador = "DELETE FROM Marcador WHERE id = @id";
                    SqlCommand cmdMarcador = new SqlCommand(sqlMarcador, conn);
                    cmdMarcador.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmdMarcador.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {   
                throw;
            }            
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void Insert(Modelo.Marcador marcador)
        {
            string descricao = marcador.descricao;
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlMarcador = "INSERT INTO Marcador (descricao) VALUES ('@descricao')";
                    SqlCommand cmdMarcador = new SqlCommand(sqlMarcador, conn);
                    cmdMarcador.Parameters.Add("@descricao", SqlDbType.VarChar).Value = descricao;
                    cmdMarcador.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Modelo.Marcador marcador)
        {
            int id = marcador.id;
            string descricao = marcador.descricao;
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlMarcador = "UPDATE Marcador SET descricao = '@descricao' WHERE id = @id";
                    SqlCommand cmdMarcador = new SqlCommand(sqlMarcador, conn);
                    cmdMarcador.Parameters.Add("@descricao", SqlDbType.VarChar).Value = descricao;
                    cmdMarcador.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmdMarcador.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }
    }
}