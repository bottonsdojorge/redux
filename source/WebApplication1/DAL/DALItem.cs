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
    public class DALItem : DAL
    {
        public DALItem() : base(){}
        
        [DataObjectMethod(DataObjectMethodType.Select)]
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


        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Item item)
        {
            // A conexão
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                using (conn)
                {
                    // O SQL
                    string sqlItem = "DELETE FROM Item WHERE Tamanho_id = @idTamaho AND Produto_id = @idProduto";
                    SqlCommand cmditem = new SqlCommand(sqlItem);
                    cmditem.Parameters.Add("@idTamanho", SqlDbType.Int).Value = item.tamanho.id;
                    cmditem.Parameters.Add("@idProduto", SqlDbType.Int).Value = item.produto.id;
                    cmditem.ExecuteNonQuery();                    
                }
            }
            catch (SystemException)
            {                
                throw;
            }
        }
    }
}