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
    public class DALItemCarrinho : DAL
    {

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.itemCarrinho> SelectAll()
        {
            // O Tamanho
            Modelo.itemCarrinho itemCarrinho;
            // A lista de retorno
            List<Modelo.itemCarrinho> itensCarrinho = new List<Modelo.itemCarrinho>();

            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlItensCarrinho = "SELECT * FROM itensCarrinho";
                    SqlCommand cmdItensCarrinho = new SqlCommand(sqlItensCarrinho);
                    SqlDataReader drItensCarrinho;
                    using (drItensCarrinho = cmdItensCarrinho.ExecuteReader())
                    {                        
                        // Leitura do resultado
                        if (drItensCarrinho.HasRows)
                        {
                            while (drItensCarrinho.Read())
                            {
                                int idCarrinho = Convert.ToInt32(drItensCarrinho["carrinho_id"]);
                                int idTamanho = Convert.ToInt32(drItensCarrinho["Tamanho_id"]);
                                int idProduto = Convert.ToInt32(drItensCarrinho["Produto_id"]);
                                int quantidade = Convert.ToInt32(drItensCarrinho["quantidade"]);

                                DALItem dalItem = new DALItem();

                                Modelo.Item item = dalItem.Select(idProduto, idTamanho);
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
        public List<Modelo.itemCarrinho> SelectFromCarrinho(int idCarrinho)
        {
            //O itemCarrinho
            Modelo.itemCarrinho itemCarrinho = new Modelo.itemCarrinho();
            //A lista de retorno
            List<Modelo.itemCarrinho> itensCarrinho = new List<Modelo.itemCarrinho>();
            
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlItemCarrinho = "SELECT * FROM ItemCarrinho WHERE id = @id";
                    SqlCommand cmdItemCarrinho = new SqlCommand(sqlItemCarrinho);
                    cmdItemCarrinho.Parameters.Add("@id", SqlDbType.Int).Value = idCarrinho;
                    SqlDataReader drItemCarrinho;
                    using (drItemCarrinho = cmdItemCarrinho.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drItemCarrinho.HasRows)
                        {
                            while (drItemCarrinho.Read())
                            {
                                int idTamanho = Convert.ToInt32(drItemCarrinho["Tamanho_id"]);
                                int idProduto = Convert.ToInt32(drItemCarrinho["Produto_id"]);
                                int quantidade = Convert.ToInt32(drItemCarrinho["quantidade"]);

                                DALItem dalItem = new DALItem();

                                Modelo.Item item = dalItem.Select(idProduto, idTamanho);
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
        
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.itemCarrinho itemCarrinho)
        {
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlItemCarrinho = "INSERT INTO itemCarrinho (carrinho_id, Item_Tamanho_id, item_Produto_id, quantidade) VALUES (@carrinhoId, @tamanhoId, @produtoId, @quantidade)";
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
    }
}