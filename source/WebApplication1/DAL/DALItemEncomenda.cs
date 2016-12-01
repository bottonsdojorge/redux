using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class DALItemEncomenda : DAL
    {
        public DALItemEncomenda() : base() {}

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.itemEncomenda> SelectAll()
        {
            Modelo.itemEncomenda itemEncomenda;
            List<Modelo.itemEncomenda> itensEncomenda = new List<Modelo.itemEncomenda>();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlItensEncomenda = "SELECT * FROM itemEncomenda";
                    SqlCommand cmdItensEncomenda = new SqlCommand(sqlItensEncomenda, conn);
                    SqlDataReader drItensEncomenda;

                    using (drItensEncomenda = cmdItensEncomenda.ExecuteReader())
                    {
                        if (drItensEncomenda.HasRows)
                        {
                            while (drItensEncomenda.Read())
                            {
                                int idEncomenda = Convert.ToInt32(drItensEncomenda["Encomenda_id"]);
                                int idTamanho = Convert.ToInt32(drItensEncomenda["Item_Tamanho_id"]);
                                int idProduto = Convert.ToInt32(drItensEncomenda["Item_Produto_id"]);
                                int quantidade = Convert.ToInt32(drItensEncomenda["quantidade"]);
                                double precoUnitario = Convert.ToDouble(drItensEncomenda["precoUnitario"]);

                                DALItem dalItem = new DALItem();
                                Modelo.Item item = dalItem.Select(idProduto, idTamanho);

                                itemEncomenda = new Modelo.itemEncomenda(idEncomenda, item, precoUnitario, quantidade);
                                itensEncomenda.Add(itemEncomenda);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {   
                throw;
            }

            return itensEncomenda;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Modelo.itemEncomenda Select(int idEncomenda, int idProduto, int idTamanho)
        {
            Modelo.itemEncomenda itemEncomenda = null;

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlItemEncomenda = "SELECT * FROM itemEncomenda WHERE Encomenda_id = @idEncomenda AND Item_Produto_id = @idProduto AND Item_Tamanho_id = @idTamanho";
                    SqlCommand cmdItemEncomenda = new SqlCommand(sqlItemEncomenda, conn);
                    cmdItemEncomenda.Parameters.Add("@idEncomenda", SqlDbType.Int).Value = idEncomenda;
                    cmdItemEncomenda.Parameters.Add("@idProduto", SqlDbType.Int).Value = idProduto;
                    cmdItemEncomenda.Parameters.Add("@idTamanho", SqlDbType.Int).Value = idTamanho;
                    SqlDataReader drItemEncomenda;

                    using (drItemEncomenda = cmdItemEncomenda.ExecuteReader())
                    {
                        if (drItemEncomenda.HasRows)
                        {
                            while (drItemEncomenda.Read())
                            {
                                int quantidade = Convert.ToInt32(drItemEncomenda["quantidade"]);
                                double precoUnitario = Convert.ToDouble(drItemEncomenda["precoUnitario"]);

                                DALItem dalItem = new DALItem();
                                Modelo.Item item = dalItem.Select(idProduto, idTamanho);

                                itemEncomenda = new Modelo.itemEncomenda(idEncomenda, item, precoUnitario, quantidade);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {   
                throw;
            }

            return itemEncomenda;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.itemEncomenda> SelectFromEncomenda(int idEncomenda)
        {
            Modelo.itemEncomenda itemEncomenda;
            List<Modelo.itemEncomenda> itensEncomenda = new List<Modelo.itemEncomenda>();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlItensEncomenda = "SELECT * FROM itemEncomenda WHERE Encomenda_id = @idEncomenda";
                    SqlCommand cmdItensEncomenda = new SqlCommand(sqlItensEncomenda, conn);
                    cmdItensEncomenda.Parameters.Add("@idEncomenda", SqlDbType.Int).Value = idEncomenda;
                    SqlDataReader drItensEncomenda;

                    using (drItensEncomenda = cmdItensEncomenda.ExecuteReader())
                    {
                        if (drItensEncomenda.HasRows)
                        {
                            while (drItensEncomenda.Read())
                            {
                                int idTamanho = Convert.ToInt32(drItensEncomenda["Item_Tamanho_id"]);
                                int idProduto = Convert.ToInt32(drItensEncomenda["Item_Produto_id"]);
                                int quantidade = Convert.ToInt32(drItensEncomenda["quantidade"]);
                                double precoUnitario = Convert.ToDouble(drItensEncomenda["precoUnitario"]);

                                DALItem dalItem = new DALItem();
                                Modelo.Item item = dalItem.Select(idProduto, idTamanho);

                                itemEncomenda = new Modelo.itemEncomenda(idEncomenda, item, precoUnitario, quantidade);
                                itensEncomenda.Add(itemEncomenda);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }

            return itensEncomenda;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.itemEncomenda itemEncomenda)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlItemEncomenda = "DELETE FROM itemEncomenda WHERE Encomenda_id = @idEncomenda AND Item_Produto_id = @idProduto and Item_Tamanho_id = @idTamanho";
                    SqlCommand cmdItemEncomenda = new SqlCommand(sqlItemEncomenda, conn);
                    cmdItemEncomenda.Parameters.Add("@idEncomenda", SqlDbType.Int).Value = itemEncomenda.encomendaId;
                    cmdItemEncomenda.Parameters.Add("@idProduto", SqlDbType.Int).Value = itemEncomenda.item.produto.id;
                    cmdItemEncomenda.Parameters.Add("@idTamanho", SqlDbType.Int).Value = itemEncomenda.item.tamanho.id;

                    cmdItemEncomenda.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {   
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.itemEncomenda itemEncomenda)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlItemEncomenda = "INSERT INTO itemEncomenda (Encomenda_id, Item_Tamanho_id, Item_Produto_id, precoUnitario, quantidade) VALUES (@idEncomenda, @idTamanho, @idProduto, @preco, @quantidade)";
                    SqlCommand cmdItemEncomenda = new SqlCommand(sqlItemEncomenda, conn);
                    cmdItemEncomenda.Parameters.Add("@idEncomenda", SqlDbType.Int).Value = itemEncomenda.encomendaId;
                    cmdItemEncomenda.Parameters.Add("@idTamanho", SqlDbType.Int).Value = itemEncomenda.item.tamanho.id;
                    cmdItemEncomenda.Parameters.Add("@idProduto", SqlDbType.Int).Value = itemEncomenda.item.produto.id;
                    cmdItemEncomenda.Parameters.Add("@preco", SqlDbType.Int).Value = itemEncomenda.precoIndividual;
                    cmdItemEncomenda.Parameters.Add("@quantidade", SqlDbType.Int).Value = itemEncomenda.quantidade;

                    cmdItemEncomenda.ExecuteNonQuery();
                }
              }
            catch (SystemException)
            {   
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.itemEncomenda itemEncomenda)
        {
            if (Select(itemEncomenda.encomendaId, itemEncomenda.item.produto.id, itemEncomenda.item.tamanho.id) != itemEncomenda)
            {
                try
                {
                    using (conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string sqlItemEncomenda = "UPDATE itemEncomenda SET precoUnitario = @preco, quantidade = @quantidade WHERE Encomenda_id = @idEncomenda AND Item_Produto_id = @idProduto AND Item_Tamanho_id = @idTamanho";
                        SqlCommand cmdItemEncomenda = new SqlCommand(sqlItemEncomenda, conn);
                        cmdItemEncomenda.Parameters.Add("@idEncomenda", SqlDbType.Int).Value = itemEncomenda.encomendaId;
                        cmdItemEncomenda.Parameters.Add("@idTamanho", SqlDbType.Int).Value = itemEncomenda.item.tamanho.id;
                        cmdItemEncomenda.Parameters.Add("@idProduto", SqlDbType.Int).Value = itemEncomenda.item.produto.id;
                        cmdItemEncomenda.Parameters.Add("@preco", SqlDbType.Int).Value = itemEncomenda.precoIndividual;
                        cmdItemEncomenda.Parameters.Add("@quantidade", SqlDbType.Int).Value = itemEncomenda.quantidade;

                        cmdItemEncomenda.ExecuteNonQuery();
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