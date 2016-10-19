﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class DALProduto : DAL
    {
        /*
         * --Tem que prestar atenção no caminho da imagem.
         * --Usar caminho absoluto?
         * Atualizado: utilizando caminho ~/Upload/imagem-produto/ 
         */

        public DALProduto() : base(){}

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
                    conn.Open();
                    // O SQL
                    string sqlProdutos = "SELECT * FROM Produto";
                    SqlCommand cmdProdutos = new SqlCommand(sqlProdutos, conn);
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
                                string imagem = drProdutos["imagem"].ToString();
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
        public Modelo.Produto Select(int idProduto)
        {
            // O Produto retorno
            Modelo.Produto produto = null;

            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                using (conn)
                {
                    conn.Open();
                    // O SQL
                    string sqlProdutos = "SELECT * FROM Produto WHERE id = @id";
                    SqlCommand cmdProdutos = new SqlCommand(sqlProdutos, conn);
                    cmdProdutos.Parameters.Add("@id", SqlDbType.Int).Value = idProduto;
                    SqlDataReader drProdutos;
                    using (drProdutos = cmdProdutos.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drProdutos.HasRows)
                        {
                            while (drProdutos.Read())
                            {
                                string descricao = drProdutos["descricao"].ToString();
                                string imagem = drProdutos["imagem"].ToString();
                                List<Modelo.Marcador> marcadores;

                                DALMarcador dalMarcador = new DALMarcador();
                                marcadores = dalMarcador.SelectFromProduto(idProduto);

                                produto = new Modelo.Produto(idProduto, descricao, imagem, marcadores);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return produto;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Produto produto)
        {
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            int id = Convert.ToInt32(produto.id);
            try
            {
                using (conn)
                {
                    conn.Open();
                    // O SQL
                    string sqlTamanho = "DELETE FROM Produto WHERE id = @id";
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

        /*
         * Salva imagem no servidor a partir de um arquivo de imagem.
         * Testar e extender para salvar a partir de um uploaded file.
         * Modelo de nome: btupcliente+unixtimestamp
         * Retorna nome da imagem.
         */

        public string InsertImage(Image image)
        {
            string unixTimestamp = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString();
            string nome = "btupcliente" + unixTimestamp;
            string path = "~/Upload/imagem-produto/";
            try
            {
                image.Save(path + nome, ImageFormat.Jpeg);
                return nome;
            }
            catch (SystemException)
            {
                throw;
            }
            return null;
        }

        /*
         * PROBLEMATICA DO ARMAZENAMENTO DA IMAGEM A PARTIR DO OBJETO AQUI
         * 
         * 1 - Gera nome para a imagem:
         * 2 - Salva imagem em diretorio padrão (~/Upload/imagem-produto/
         * 3 - Salva caminho da imagem no BD
         * 
         * Acima está inválido. Aceitando apenas nome da imagem. 
         */

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Produto produto)
        {
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            int idProduto;
            string descricao = produto.descricao;
            string imagem = produto.imagem;
            try
            {
                using (conn)
                {
                    conn.Open();
                    // O SQL da inserção do produto
                    string sqlProduto = "INSERT INTO Tamanho (descricao, imagem) VALUES ('@descricao', '@imagem') SET @ID = SCOPE_IDENTITY();";
                    SqlCommand cmdProduto = new SqlCommand(sqlProduto, conn);
                    cmdProduto.Parameters.Add("@descricao", SqlDbType.VarChar).Value = descricao;
                    cmdProduto.Parameters.Add("@imagem", SqlDbType.VarChar).Value = imagem;
                    cmdProduto.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmdProduto.ExecuteNonQuery();

                    //Pega o ID do produto registrado
                    idProduto = (int)cmdProduto.Parameters["@ID"].Value;

                    // O SQL da inserção dos Marcadores na tabela relacional.
                    string sqlMarcadores = "INSERT INTO marcadorProduto (Produto_id, Marcador_id) VALUES (@produtoId, @marcadorId)";
                    SqlCommand cmdMarcadores = new SqlCommand(sqlMarcadores, conn);
                    cmdMarcadores.Parameters.Add("@produtoId", SqlDbType.Int).Value = idProduto;

                    // Inserção de cada marcador na tabela relacional
                    foreach (Modelo.Marcador marcador in produto.marcadores)
                    {
                        cmdMarcadores.Parameters.Add("@marcadorId", SqlDbType.Int).Value = marcador.id;
                        cmdMarcadores.ExecuteNonQuery();
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }


        /*
         * Como funcionará o sistema de atualização de marcadores de um produto? 
         * Por enquanto, não faz nada.. Pensar nisso depois. 
         * Alterando, atualmente, apenas descrição e imagem do produto.
         * Atualmente não verifica a mudança de imagem, insere mesmo que não tenha mudado.
         */
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Produto produto)
        {
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            int id = produto.id;
            string descricao = produto.descricao;
            string imagem = produto.imagem;
            try
            {
                using (conn)
                {
                    conn.Open();
                    // O SQL
                    string sqlTamanho = "UPDATE Tamanho SET descricao = '@descricao', imagem = '@imagem' WHERE ID = @id";
                    SqlCommand cmdTamanho = new SqlCommand(sqlTamanho, conn);
                    cmdTamanho.Parameters.Add("@descricao", SqlDbType.VarChar).Value = descricao;
                    cmdTamanho.Parameters.Add("@imagem", SqlDbType.VarChar).Value = imagem;
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