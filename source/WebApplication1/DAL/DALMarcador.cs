using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class DALMarcador
    {
        //public List<Modelo.Marcador> SelectAll();
        //public List<Modelo.Marcador> Select(int idMarcador);
        //public List<Modelo.Marcador> SelectFromProduto(int idProduto);
        //public void Delete(Modelo.Marcador marcador);
        //public void Insert(Modelo.Marcador marcador);
        //public void Update(Modelo.Marcador marcador);

        string connectionString = "";

        public DALMarcador()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BottonsDoJorgeConnectionString"].ConnectionString;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Marcador> SelectAll()
        {
            // O Marcador
            Modelo.Marcador marcador;
            // A lista de retorno
            List<Modelo.Marcador> marcadores = new List<Modelo.Marcador>();

            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlMarcadores = "SELECT * FROM Marcador";
                    SqlCommand cmdMarcadores = new SqlCommand(sqlMarcadores);
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
        public List<Modelo.Marcador> Select(int idMarcador)
        {
            // O Marcador
            Modelo.Marcador marcador;
            // A lista de retorno
            List<Modelo.Marcador> marcadores = new List<Modelo.Marcador>();

            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlMarcadores = String.Format("SELECT * FROM Marcador WHERE id = {0}", idMarcador);
                    SqlCommand cmdMarcadores = new SqlCommand(sqlMarcadores);
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

            // Alguma excessão eventual deverá ser tratada aqui.
            catch (SystemException)
            {
                throw;
            }
            return marcadores;
        }

        /*
         * Retorna uma lista de Marcadores a partir do ID do Produto. 
         * @param int id do produto
         */
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Marcador> SelectFromProduto(int idProduto)
        {
            // O Marcador
            Modelo.Marcador marcador;
            // A lista de retorno
            List<Modelo.Marcador> marcadores = new List<Modelo.Marcador>();

            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                using (conn)
                {
                    // O SQL da tabela relacional
                    string sqlRelacional = String.Format("SELECT * FROM marcadorProduto WHERE Produto_id = {0}", idProduto);
                    SqlCommand cmdRelacional = new SqlCommand(sqlRelacional);
                    SqlDataReader drRelacional;

                    using (drRelacional = cmdRelacional.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drRelacional.HasRows)
                        {
                            while (drRelacional.Read())
                            {
                                int idMarcador = Convert.ToInt32(drRelacional["Marcador_id"]);
                                // O SQL da tabela Marcador
                                string sqlMarcador = String.Format("SELECT * FROM Marcador WHERE id = {0}", idMarcador);
                                SqlCommand cmdMarcador = new SqlCommand(sqlMarcador);
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
        public void Delete(Modelo.Marcador marcador)
        {
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            string id = marcador.id.ToString();
            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlMarcador = string.Format("DELETE FROM Marcador WHERE id = {0}", id);
                    SqlCommand cmdMarcador = new SqlCommand(sqlMarcador, conn);
                    cmdMarcador.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {   
                throw;
            }            
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Marcador marcador)
        {
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            string descricao = marcador.descricao;
            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlMarcador = string.Format("INSERT INTO Marcador (descricao) VALUES ('{0}')", descricao);
                    SqlCommand cmdMarcador = new SqlCommand(sqlMarcador, conn);
                    cmdMarcador.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Marcador marcador)
        {
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            int id = marcador.id;
            string descricao = marcador.descricao;
            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlMarcador = string.Format("UPDATE Marcador SET descricao = '{0}'", descricao);
                    SqlCommand cmdMarcador = new SqlCommand(sqlMarcador, conn);
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