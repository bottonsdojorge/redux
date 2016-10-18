using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class DALItem
    {
        string connectionString = "";
        public DALItem()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BottonsDoJorgeConnectionString"].ConnectionString;
        }
        
        public List<Modelo.Item> SelectAll()
        {
             // O Item
            Modelo.Item item;
            // A lista de retorno
            List<Modelo.Item> itens = new List<Modelo.Item>();

            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlItens = "SELECT * FROM Item";
                    SqlCommand cmdItens = new SqlCommand(sqlItens);
                    SqlDataReader drItens;
                    using (drItens = cmdItens.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drItens.HasRows)
                        {
                            while (drItens.Read())
                            {   
                                int idProduto = Convert.ToInt32(drItens["Produto_id"]);
                                int idTamanho = Convert.ToInt32(drItens["Tamanho_id"]);

                                DALProduto dalProduto = new DALProduto();
                                DALTamanho dalTamanho = new DALTamanho();

                                Modelo.Produto produto = dalProduto.Select(idProduto);
                                Modelo.Tamanho tamanho = dalTamanho.Select(idTamanho);

                                item = new Modelo.Item(produto, tamanho);
                                itens.Add(item);
                            }
                        }
                    }
                }
            }
            catch 
            {
                throw;
            }
            return itens;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Modelo.Item Select(int idItem)
        {
            // O Produto retorno
            Modelo.Item item = new Modelo.Item(); ;

            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlItens = "SELECT * FROM Item WHERE id = @id";
                    SqlCommand cmdItens = new SqlCommand(sqlItens);
                    cmdItens.Parameters.Add("@id", SqlDbType.Int).Value = idItem;
                    SqlDataReader drItens;
                    using (drItens = cmdItens.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drItens.HasRows)
                        {
                            while (drItens.Read())
                            {
                                int idProduto = Convert.ToInt32(drItens["Produto_id"]);
                                int idTamanho = Convert.ToInt32(drItens["Tamanho_id"]);

                                DALProduto dalProduto = new DALProduto();
                                DALTamanho dalTamanho = new DALTamanho();

                                Modelo.Produto produto = dalProduto.Select(idProduto);
                                Modelo.Tamanho tamanho = dalTamanho.Select(idTamanho);
                                
                                item = new Modelo.Item(produto, tamanho);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return item;
        }
    }
}