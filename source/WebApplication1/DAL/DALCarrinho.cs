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
    public class DALCarrinho : DAL
    {
        public DALCarrinho() : base(){}
                
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Carrinho> SelectAll()
        {
            // O carrinho
            Modelo.Carrinho carrinho;
            // A lista de retorno
            List<Modelo.Carrinho> carrinhos = new List<Modelo.Carrinho>();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlCarrinhos = "SELECT * FROM Carrinhos";
                    SqlCommand cmdCarrinhos = new SqlCommand(sqlCarrinhos, conn);
                    SqlDataReader drCarrinhos;

                    using (drCarrinhos = cmdCarrinhos.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drCarrinhos.HasRows)
                        {
                            while (drCarrinhos.Read())
                            {
                                int idUsuario = Convert.ToInt32(drCarrinhos["Usuario_id"]);
                                double precoTotal = Convert.ToDouble(drCarrinhos["precoTotal"]);
                                List<Modelo.itemCarrinho> itensCarrinho;

                                DALItemCarrinho dalItemCarrinho = new DALItemCarrinho();
                                itensCarrinho = dalItemCarrinho.SelectFromCarrinho(idUsuario);

                                carrinho = new Modelo.Carrinho(itensCarrinho, precoTotal, idUsuario);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
    
            return carrinhos;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Modelo.Carrinho Select(int idCarrinho)
        {
            // O carrinho retorno
            Modelo.Carrinho carrinho = new Modelo.Carrinho();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlCarrinhos = "SELECT * FROM Carrinho WHERE Usuario_id = @id";
                    SqlCommand cmdCarrinhos = new SqlCommand(sqlCarrinhos, conn);
                    cmdCarrinhos.Parameters.Add("@id", SqlDbType.Int).Value = idCarrinho;
                    SqlDataReader drCarrinhos;
                    using (drCarrinhos = cmdCarrinhos.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drCarrinhos.HasRows)
                        {
                            while (drCarrinhos.Read())
                            {
                                int idUsuario = Convert.ToInt32(drCarrinhos["Usuario_id"]);
                                double precoTotal = Convert.ToDouble(drCarrinhos["precoTotal"]);
                                List<Modelo.itemCarrinho> itensCarrinho;

                                DALItemCarrinho dalItemCarrinho = new DALItemCarrinho();
                                itensCarrinho = dalItemCarrinho.SelectFromCarrinho(idUsuario);

                                carrinho = new Modelo.Carrinho(itensCarrinho, precoTotal, idUsuario);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return carrinho;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Carrinho carrinho)
        {
            int id = Convert.ToInt32(carrinho.Usuario_id);
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlCarrinho = "DELETE FROM Carrinho WHERE id = @id";
                    SqlCommand cmdCarrinho = new SqlCommand(sqlCarrinho, conn);
                    cmdCarrinho.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmdCarrinho.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Limpar(Modelo.Carrinho carrinho)
        {
            int id = carrinho.Usuario_id;
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlCarrinho = "UPDATE Carrinho SET precoTotal = 0 WHERE Usuario_id = @id";
                    SqlCommand cmdCarrinho = new SqlCommand(sqlCarrinho, conn);
                    cmdCarrinho.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmdCarrinho.ExecuteNonQuery();

                    DALItemCarrinho dalItemCarrinho = new DALItemCarrinho();
                    foreach (Modelo.itemCarrinho itemCarrinho in carrinho.itens)
                    {
                        dalItemCarrinho.Delete(itemCarrinho);
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Carrinho carrinho)
        {
            try
            {
                if (this.Select(carrinho.Usuario_id) == null)
                {
                    using (conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        // O SQL do carrinho
                        string sqlCarrinho = "INSERT INTO Carrinho(Usuario_id, precoTotal) VALUES (@id, @preco)";
                        SqlCommand cmdCarrinho = new SqlCommand(sqlCarrinho, conn);
                        cmdCarrinho.Parameters.Add("@id", SqlDbType.Int).Value = carrinho.Usuario_id;
                        cmdCarrinho.Parameters.Add("@preco", SqlDbType.Decimal).Value = carrinho.precoTotal;
                        cmdCarrinho.ExecuteNonQuery();
                    }
                }
                else
                {
                    this.Update(carrinho);
                }
                // A inserção dos itens do carrinho
                DALItemCarrinho dalItemCarrinho = new DALItemCarrinho();
                foreach (Modelo.itemCarrinho itemCarrinho in carrinho.itens)
                {
                    dalItemCarrinho.Insert(itemCarrinho);
                }
            }
            catch (SystemException)
            {
                throw;
            }

        }

        /*
         * Será que aqui deveria ser calculado o preco do carrinho antes de incluir?
         */
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Update(Modelo.Carrinho carrinho)
        {
            if (Select(carrinho.Usuario_id) != carrinho)
            {
                try
                {
                    using (conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        // O SQL
                        string sqlCarrinho = "UPDATE Carrinho SET precoTotal = @preco WHERE Usuario_id = @id";
                        SqlCommand cmdCarrinho = new SqlCommand(sqlCarrinho, conn);
                        cmdCarrinho.Parameters.Add("@preco", SqlDbType.Decimal).Value = carrinho.precoTotal;
                        cmdCarrinho.Parameters.Add("@id", SqlDbType.Int).Value = carrinho.Usuario_id;
                        cmdCarrinho.ExecuteNonQuery();

                        // Atualizar os produtos
                        DALItemCarrinho dalItemCarrinho = new DALItemCarrinho();
                        foreach (Modelo.itemCarrinho itemCarrinho in carrinho.itens)
                        {
                            dalItemCarrinho.Update(itemCarrinho);
                        }
                    }
                }
                catch (SystemException)
                {
                    throw;
                }
            }
        }

        public void InserirItem(Modelo.itemCarrinho itemCarrinho, Modelo.Carrinho carrinho)
        {
            DALItemCarrinho dalItemCarrinho = new DALItemCarrinho();
            dalItemCarrinho.Insert(itemCarrinho);
        }

        public void InserirItem(int idProduto, int idTamanho, int quantidade, Modelo.Carrinho carrinho)
        {
            DALItem dalItem = new DALItem();
            DALItemCarrinho dalItemCarrinho = new DALItemCarrinho();

            Modelo.Item item = dalItem.Select(idProduto, idTamanho);
            Modelo.itemCarrinho itemCarrinho = new Modelo.itemCarrinho(carrinho.Usuario_id, item, quantidade);

            dalItemCarrinho.Insert(itemCarrinho);
        }

        public void RemoverItem(Modelo.itemCarrinho itemCarrinho, Modelo.Carrinho carrinho)
        {
            DALItemCarrinho dalItemCarrinho = new DALItemCarrinho();
            dalItemCarrinho.Delete(itemCarrinho);
        }

        public void RemoverItem(int idProduto, int idTamanho, Modelo.Carrinho carrinho)
        {
            DALItem dalItem = new DALItem();
            DALItemCarrinho dalItemCarrinho = new DALItemCarrinho();

            Modelo.Item item = dalItem.Select(idProduto, idTamanho);
            Modelo.itemCarrinho itemCarrinho = dalItemCarrinho.Select(carrinho.Usuario_id, idTamanho, idProduto);

            dalItemCarrinho.Delete(itemCarrinho);
        }
    }
}
    