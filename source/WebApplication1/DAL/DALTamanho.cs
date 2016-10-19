using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class DALTamanho : DAL
    {
        public DALTamanho() : base(){}

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
                    conn.Open();
                    // O SQL
                    string sqlTamanhos = "SELECT * FROM Tamanho";
                    SqlCommand cmdTamanhos = new SqlCommand(sqlTamanhos, conn);
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
        public Modelo.Tamanho Select(int idTamanho)
        {
            // O Tamanho
            Modelo.Tamanho tamanho = null;

            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                using (conn)
                {
                    conn.Open();
                    // O SQL
                    string sqlTamanhos = "SELECT * FROM Tamanho WHERE id = @id";
                    SqlCommand cmdTamanhos = new SqlCommand(sqlTamanhos, conn);
                    cmdTamanhos.Parameters.Add("@id", SqlDbType.Int).Value = idTamanho;
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
            return tamanho;
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
                    conn.Open();
                    // O SQL
                    string sqlTamanho = "DELETE FROM Tamanho WHERE id = @id";
                    SqlCommand cmdTamanho = new SqlCommand(sqlTamanho, conn);
                    cmdTamanho.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
                    conn.Open();
                    // O SQL
                    string sqlTamanho = "INSERT INTO Tamanho (descricao, precoUnitario) VALUES ('@descricao', @preco)";
                    SqlCommand cmdTamanho = new SqlCommand(sqlTamanho, conn);
                    cmdTamanho.Parameters.Add("@descricao", SqlDbType.VarChar).Value = descricao;
                    cmdTamanho.Parameters.Add("@preco", SqlDbType.Decimal).Value = preco;
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
                    conn.Open();
                    // O SQL
                    string sqlTamanho = "UPDATE Tamanho SET descricao = '@descricao', precoUnitario = @preco WHERE id = @id";
                    SqlCommand cmdTamanho = new SqlCommand(sqlTamanho, conn);
                    cmdTamanho.Parameters.Add("@descricao", SqlDbType.VarChar).Value = descricao;
                    cmdTamanho.Parameters.Add("@preco", SqlDbType.Decimal).Value = preco;
                    cmdTamanho.Parameters.Add("@id", SqlDbType.Int).Value = id;
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