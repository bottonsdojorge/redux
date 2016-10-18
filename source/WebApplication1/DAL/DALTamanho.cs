using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class DALTamanho
    {
        public List<Modelo.Tamanho> SelectAll();
        public List<Modelo.Tamanho> Select(int idTamanho);
        public void Delete(Modelo.Tamanho tamanho);
        public void Insert(Modelo.Tamanho tamanho);
        public void Update(Modelo.Tamanho tamanho);

        string connectionString = "";

        public DALTamanho()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BottonsDoJorgeConnectionString"].ConnectionString;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Tamanho> SelectAll()
        {
            // O Tamanho
            Modelo.Tamanho tamanho;
            // A lista de retorno
            List<Modelo.Tamanho> tamanhos = new List<Modelo.Tamanho>();

            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlTamanhos = "SELECT * FROM Tamanho";
                    SqlCommand cmdTamanhos = new SqlCommand(sqlTamanhos);
                    SqlDataReader drTamanhos;
                    using (drTamanhos = cmdTamanhos.ExecuteReader())
                    {                        
                        // Leitura do resultado
                        if (drTamanhos.HasRows)
                        {
                            while (drTamanhos.Read())
                            {
                                int id = Convert.ToInt32(drTamanhos["id"]);
                                string descricao = drTamanhos["descricao"].ToString();
                                double precoUnitario = Convert.ToDouble(drTamanhos["precoUnitario"]);
                                tamanho = new Modelo.Tamanho(id, descricao, precoUnitario);
                                tamanhos.Add(tamanho);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {                
                throw;
            }
            return tamanhos;
        }   

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Tamanho> Select(int idTamanho)
        {
            // O Tamanho
            Modelo.Tamanho tamanho;
            // A lista de retorno
            List<Modelo.Tamanho> tamanhos = new List<Modelo.Tamanho>();

            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlTamanhos = String.Format("SELECT * FROM Tamanho WHERE id = {0}", idTamanho);
                    SqlCommand cmdTamanhos = new SqlCommand(sqlTamanhos);
                    SqlDataReader drTamanhos;

                    using (drTamanhos = cmdTamanhos.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drTamanhos.HasRows)
                        {
                            while (drTamanhos.Read())
                            {
                                int id = Convert.ToInt32(drTamanhos["id"]);
                                string descricao = drTamanhos["descricao"].ToString();
                                double precoUnitario = Convert.ToDouble(drTamanhos["precoUnitario"]);
                                tamanho = new Modelo.Tamanho(id, descricao, precoUnitario);
                                tamanhos.Add(tamanho);
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
            return tamanhos;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Tamanho tamanho)
        {
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            string id = tamanho.id.ToString();
            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlTamanho = string.Format("DELETE FROM Tamanho WHERE id = {0}", id);
                    SqlCommand cmdTamanho = new SqlCommand(sqlTamanho, conn);
                    cmdTamanho.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {   
                throw;
            }            
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Tamanho tamanho)
        {
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            string descricao = tamanho.descricao;
            double preco = tamanho.precoUnitario;
            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlTamanho = string.Format("INSERT INTO Tamanho (descricao, precoUnitario) VALUES ('{0}', {1}", descricao, preco);
                    SqlCommand cmdTamanho = new SqlCommand(sqlTamanho, conn);
                    cmdTamanho.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Tamanho tamanho)
        {
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            int id = tamanho.id;
            string descricao = tamanho.descricao;
            double preco = tamanho.precoUnitario;
            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlTamanho = string.Format("UPDATE Tamanho SET descricao = '{0}', precoUnitario = {1:0.00}", descricao, preco);
                    SqlCommand cmdTamanho = new SqlCommand(sqlTamanho, conn);
                    cmdTamanho.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }
    }
}