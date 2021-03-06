﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace redux.DAL
{
    public class DALItemCarrinho : DAL
    {
        public DALItemCarrinho() : base()
        {

        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Modelo.itemCarrinho> SelectAll()
        {
            // O Tamanho
            Modelo.itemCarrinho itemCarrinho;
            // A lista de retorno
            List<Modelo.itemCarrinho> itensCarrinho = new List<Modelo.itemCarrinho>();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlItensCarrinho = "SELECT * FROM itensCarrinho";
                    SqlCommand cmdItensCarrinho = new SqlCommand(sqlItensCarrinho, conn);
                    SqlDataReader drItensCarrinho;
                    using (drItensCarrinho = cmdItensCarrinho.ExecuteReader())
                    {                        
                        // Leitura do resultado
                        if (drItensCarrinho.HasRows)
                        {
                            while (drItensCarrinho.Read())
                            {
                                int idCarrinho = Convert.ToInt32(drItensCarrinho["carrinho_id"]);
                                int idTamanho = Convert.ToInt32(drItensCarrinho["Item_Tamanho_id"]);
                                int idProduto = Convert.ToInt32(drItensCarrinho["Item_Produto_id"]);
                                int quantidade = Convert.ToInt32(drItensCarrinho["quantidade"]);

                                Modelo.Item item = DALItem.Select(idProduto, idTamanho);
                                itemCarrinho = new Modelo.itemCarrinho(idCarrinho, item, quantidade);
                                itensCarrinho.Add(itemCarrinho);

                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {                
                throw;
            }
            return itensCarrinho;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Modelo.itemCarrinho Select(int idCarrinho, int idTamanho, int idProduto)
        {
            //O itemCarrinho
            Modelo.itemCarrinho itemCarrinho = null;

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlItemCarrinho = "SELECT * FROM Itemcarrinho WHERE Carrinho_id = @idCarrinho AND item_tamanho_id = @idTamanho AND item_produto_id = @idProduto";
                    SqlCommand cmdItemCarrinho = new SqlCommand(sqlItemCarrinho, conn);
                    cmdItemCarrinho.Parameters.Add("@idCarrinho", SqlDbType.Int).Value = idCarrinho;
                    cmdItemCarrinho.Parameters.Add("@idTamanho", SqlDbType.Int).Value = idTamanho;
                    cmdItemCarrinho.Parameters.Add("@idProduto", SqlDbType.Int).Value = idProduto;
                    SqlDataReader drItemCarrinho;
                    using (drItemCarrinho = cmdItemCarrinho.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drItemCarrinho.HasRows)
                        {
                            while (drItemCarrinho.Read())
                            {
                                int quantidade = Convert.ToInt32(drItemCarrinho["quantidade"]);

                                Modelo.Item item = DALItem.Select(idProduto, idTamanho);
                                itemCarrinho = new Modelo.itemCarrinho(idCarrinho, item, quantidade);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return itemCarrinho;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Modelo.itemCarrinho> SelectFromCarrinho(int idCarrinho)
        {
            //O itemCarrinho
            Modelo.itemCarrinho itemCarrinho = null;
            //A lista de retorno
            List<Modelo.itemCarrinho> itensCarrinho = new List<Modelo.itemCarrinho>();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlItemCarrinho = "SELECT * FROM ItemCarrinho WHERE Carrinho_id = @id AND quantidade > 0";
                    SqlCommand cmdItemCarrinho = new SqlCommand(sqlItemCarrinho, conn);
                    cmdItemCarrinho.Parameters.Add("@id", SqlDbType.Int).Value = idCarrinho;
                    SqlDataReader drItemCarrinho;
                    using (drItemCarrinho = cmdItemCarrinho.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drItemCarrinho.HasRows)
                        {
                            while (drItemCarrinho.Read())
                            {
                                int idTamanho = Convert.ToInt32(drItemCarrinho["Item_Tamanho_id"]);
                                int idProduto = Convert.ToInt32(drItemCarrinho["Item_Produto_id"]);
                                int quantidade = Convert.ToInt32(drItemCarrinho["quantidade"]);

                                Modelo.Item item = DALItem.Select(idProduto, idTamanho);
                                itemCarrinho = new Modelo.itemCarrinho(idCarrinho, item, quantidade);

                                itensCarrinho.Add(itemCarrinho);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return itensCarrinho;
        }
        
        /*
         * Insere o itemCarrinho.
         * Verifica se já existe. Se sim, altera a quantidade. Utiliza Select() e Update()
         * Outra solução é uma função no SGBD tambem
         */

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void Insert(Modelo.itemCarrinho itemCarrinho)
        {
            Modelo.itemCarrinho itemAnterior = Select(itemCarrinho.carrinhoId, itemCarrinho.item.tamanho.id, itemCarrinho.item.produto.id);
            if ( itemAnterior == null && itemCarrinho.quantidade != 0)
            {
                try
                {
                    using (conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        // O SQL
                        string sqlItemCarrinho = "INSERT INTO itemCarrinho (Carrinho_id, Item_tamanho_id, item_Produto_id, quantidade) VALUES (@carrinhoId, @tamanhoId, @produtoId, @quantidade)";
                        SqlCommand cmdItemCarrinho = new SqlCommand(sqlItemCarrinho, conn);
                        cmdItemCarrinho.Parameters.Add("@carrinhoId", SqlDbType.Int).Value = itemCarrinho.carrinhoId;
                        cmdItemCarrinho.Parameters.Add("@produtoId", SqlDbType.Int).Value = itemCarrinho.item.produto.id;
                        cmdItemCarrinho.Parameters.Add("@tamanhoId", SqlDbType.Int).Value = itemCarrinho.item.tamanho.id;
                        cmdItemCarrinho.Parameters.Add("@quantidade", SqlDbType.Int).Value = itemCarrinho.quantidade;
                        cmdItemCarrinho.ExecuteNonQuery();
                    }
                }
                catch (SystemException)
                {
                    throw;
                }
            }
            else
            {
                itemCarrinho.quantidade = (itemCarrinho.quantidade != 0) ? itemAnterior.quantidade + itemCarrinho.quantidade : 0;
                Update(itemCarrinho);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Modelo.itemCarrinho itemCarrinho)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlItemCarrinho = "DELETE FROM itemCarrinho WHERE carrinho_id = @idCarrinho AND Item_Tamanho_id = @idTamanho AND Item_Produto_id = @idProduto";
                    SqlCommand cmdItemCarrinho = new SqlCommand(sqlItemCarrinho, conn);
                    cmdItemCarrinho.Parameters.Add("@idCarrinho", SqlDbType.Int).Value = itemCarrinho.carrinhoId;
                    cmdItemCarrinho.Parameters.Add("@idTamanho", SqlDbType.Int).Value = itemCarrinho.item.tamanho.id;
                    cmdItemCarrinho.Parameters.Add("@idProduto", SqlDbType.Int).Value = itemCarrinho.item.produto.id;
                    cmdItemCarrinho.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {   
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Modelo.itemCarrinho itemCarrinho)
        {
            if (Select(itemCarrinho.carrinhoId, itemCarrinho.item.tamanho.id, itemCarrinho.item.produto.id) != itemCarrinho && itemCarrinho.quantidade != 0)
            {
                try
                {
                    using (conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        // O SQL 
                        string sqlItemCarrinho = "UPDATE itemCarrinho SET quantidade = @quantidade WHERE carrinho_id = @idCarrinho AND Item_Tamanho_id = @idTamanho AND Item_Produto_id = @idProduto";
                        SqlCommand cmdItemCarrinho = new SqlCommand(sqlItemCarrinho, conn);
                        cmdItemCarrinho.Parameters.Add("@quantidade", SqlDbType.Int).Value = itemCarrinho.quantidade;
                        cmdItemCarrinho.Parameters.Add("@idCarrinho", SqlDbType.Int).Value = itemCarrinho.carrinhoId;
                        cmdItemCarrinho.Parameters.Add("@idTamanho", SqlDbType.Int).Value = itemCarrinho.item.tamanho.id;
                        cmdItemCarrinho.Parameters.Add("@idProduto", SqlDbType.Int).Value = itemCarrinho.item.produto.id;
                        cmdItemCarrinho.ExecuteNonQuery();
                    }
                }
                catch (SystemException)
                {
                    throw;
                }
            }
            else if (Select(itemCarrinho.carrinhoId, itemCarrinho.item.tamanho.id, itemCarrinho.item.produto.id) != itemCarrinho && itemCarrinho.quantidade == 0)
            {
                Delete(itemCarrinho);
            }
        }
    }
}