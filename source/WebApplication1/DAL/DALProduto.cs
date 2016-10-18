using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class DALProduto
    {
        //public List<Modelo.Produto> SelectAll();
        //public List<Modelo.Produto> Select(int idProduto);
        //public void Delete(Modelo.Produto produto);
        //public void Insert(Modelo.Produto produto);
        //public void Update(Modelo.Produto produto);

        /*
         * Tem que prestar atenção no caminho da imagem.
         * Usar caminho absoluto?
         * Pasta só para elas?
         */

        string connectionString = "";

        public DALProduto ()
	    {
            connectionString = ConfigurationManager.ConnectionStrings["BottonsDoJorgeConnectionString"].ConnectionString;
	    }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Produto> SelectAll()
        {
            // O Produto
            Modelo.Produto produto;
            // A lista de retorno
            List<Modelo.Produto> produtos = new List<Modelo.Produto>();

            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlProdutos = "SELECT * FROM Produto";
                    SqlCommand cmdProdutos = new SqlCommand(sqlProdutos);
                    SqlDataReader drProdutos;
                    using (drProdutos = cmdProdutos.ExecuteReader())
                    {                        
                        // Leitura do resultado
                        if (drProdutos.HasRows)
                        {
                            while (drProdutos.Read())
                            {
                                int idProduto = Convert.ToInt32(drProdutos["id"]);
                                string descricao = drProdutos["descricao"].ToString();
                                Image imagem = Image.FromFile(drProdutos["imagem"].ToString());
                                List<Modelo.Marcador> marcadores;

                                DALMarcador dalMarcador = new DALMarcador();
                                marcadores = dalMarcador.SelectFromProduto(idProduto);

                                produto = new Modelo.Produto(idProduto, descricao, imagem, marcadores);
                                produtos.Add(produto);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {                
                throw;
            }
            return produtos;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Produto> Select(int idProduto)
        {
            // O Produto
            Modelo.Produto produto;
            // A lista de retorno
            List<Modelo.Produto> produtos = new List<Modelo.Produto>();

            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlProdutos = String.Format("SELECT * FROM Produto WHERE id = {0}", idProduto);
                    SqlCommand cmdProdutos = new SqlCommand(sqlProdutos);
                    SqlDataReader drProdutos;
                    using (drProdutos = cmdProdutos.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drProdutos.HasRows)
                        {
                            while (drProdutos.Read())
                            {
                                string descricao = drProdutos["descricao"].ToString();
                                Image imagem = Image.FromFile(drProdutos["imagem"].ToString());
                                List<Modelo.Marcador> marcadores;

                                DALMarcador dalMarcador = new DALMarcador();
                                marcadores = dalMarcador.SelectFromProduto(idProduto);

                                produto = new Modelo.Produto(idProduto, descricao, imagem, marcadores);
                                produtos.Add(produto);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return produtos;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Produto produto)
        {
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            string id = produto.id.ToString();
            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlTamanho = string.Format("DELETE FROM Produto WHERE id = {0}", id);
                    SqlCommand cmdTamanho = new SqlCommand(sqlTamanho, conn);
                    cmdTamanho.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        /*
         * Salva imagem no servidor a partir de um arquivo de imagem.
         * Testar e extender para salvar a partir de um uploaded file.
         * Modelo de nome: btupcliente+unixtimestamp
         */

        public void InsertImage(Image image)
        {
            string unixTimestamp = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString();
            string nome = "btupcliente" + unixTimestamp;
        }

        /*
         * PROBLEMATICA DO ARMAZENAMENTO DA IMAGEM A PARTIR DO OBJETO AQUI
         * 
         * 1 - Gera nome para a imagem:
         * 2 - Salva imagem em diretorio padrão (~/Upload/imagem-produto/
         * 3 - Salva caminho da imagem no BD
         */

        //[DataObjectMethod(DataObjectMethodType.Insert)]
        //public void Insert(Modelo.Produto produto)
        //{
        //    // A conexão
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    string descricao = produto.descricao;
        //    string imagem = produto.imagem.
        //    try
        //    {
        //        using (conn)
        //        {
        //            // O SQL
        //            string sqlTamanho = string.Format("INSERT INTO Tamanho (descricao, precoUnitario) VALUES ('{0}', {1}", descricao, preco);
        //            SqlCommand cmdTamanho = new SqlCommand(sqlTamanho, conn);
        //            cmdTamanho.ExecuteNonQuery();
        //        }
        //    }
        //    catch (SystemException)
        //    {
        //        throw;
        //    }
        //}

        //[DataObjectMethod(DataObjectMethodType.Update)]
        //public void Update(Modelo.Produto produto)
        //{
        //    // A conexão
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    int id = tamanho.id;
        //    string descricao = tamanho.descricao;
        //    double preco = tamanho.precoUnitario;
        //    try
        //    {
        //        using (conn)
        //        {
        //            // O SQL
        //            string sqlTamanho = string.Format("UPDATE Tamanho SET descricao = '{0}', precoUnitario = {1:0.00}", descricao, preco);
        //            SqlCommand cmdTamanho = new SqlCommand(sqlTamanho, conn);
        //            cmdTamanho.ExecuteNonQuery();
        //        }
        //    }
        //    catch (SystemException)
        //    {
        //        throw;
        //    }
        //}
    }
}