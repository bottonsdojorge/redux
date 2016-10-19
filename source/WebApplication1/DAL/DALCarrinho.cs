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

            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                using (conn)
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
            Modelo.Carrinho carrinho = null;
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                using (conn)
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
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            int id = Convert.ToInt32(carrinho.Usuario_id);
            try
            {
                using (conn)
                {
                    conn.Open();
                    // O SQL
                    string sqlTamanho = "DELETE FROM Carrinho WHERE id = @id";
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
         * Tem que alterar o carrinho anterior. Aqui só está inserindo um novo carrinho sem verificar nada..
         * A atualização dos itens é tratada no DALitemCarrinho.
         */

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Carrinho carrinho)
        {
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                if (this.Select(carrinho.Usuario_id) == null)
                {
                    using (conn)
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
            {   throw;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Update(Modelo.Carrinho carrinho)
        {
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                using (conn)
                {
                    conn.Open();
                    // O SQL
                    string sqlCarrinho = "UPDATE Carrinho SET precoTotal = @preco WHERE Usuario_id = @id";
                    SqlCommand cmdCarrinho = new SqlCommand(sqlCarrinho, conn);
                    cmdCarrinho.Parameters.Add("@preco", SqlDbType.Decimal).Value = carrinho.precoTotal;
                    cmdCarrinho.Parameters.Add("@id", SqlDbType.Int).Value = carrinho.Usuario_id;
                    cmdCarrinho.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }
    }
}
    