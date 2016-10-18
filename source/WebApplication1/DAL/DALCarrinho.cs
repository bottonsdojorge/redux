using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            /*
             *  1. Seleciona tudo de Carrinho,
             *  2. Seleciona todos os Items a partir do ID do Carrinho
             *  3. Seleciona Produto e Tamanho a partir Item.
             *  4. Instancia Itens do Carrinho
             *  5. Instancia Carrinhos
             *  6. Retorna Lista de Carrinhos.
             */

            // O carrinho
            Modelo.Carrinho carrinho;
            // A lista de retorno
            List<Modelo.Carrinho> carrinhos = new List<Modelo.Carrinho>();
            
            // Abrindo a conexão
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            // Comando SQL Carrinho
            string sqlCarrinhos = "SELECT * FROM Carrinho";
            SqlCommand cmdCarrinhos = new SqlCommand(sqlCarrinhos);

            // Executa comando SQL Carrinho
            SqlDataReader drCarrinhos = cmdCarrinhos.ExecuteReader();
            
            // Leitura do drCarrinhos. Aqui, prepara-se as variáveis para o passo 2.
            if (drCarrinhos.HasRows)
            {
                // O id do carrinho
                int carrinhoId;

                // Comando SQL e DataReader itemCarrinhos.
                string sqlItems;
                SqlCommand cmdItems;
                SqlDataReader drItems;
 
                while (drCarrinhos.Read())
                {
                    //Pega o Id do carrinho 
                    carrinhoId = Convert.ToInt32(drCarrinhos["Usuario_Id"]);
                    
                    // Transferir isso para DAL item.
                    // Gera o comando sql e executa
                    sqlItems = String.Format("SELECT * FROM itemCarrinho WHERE Carrinho_id = {0}", carrinhoId);
                    cmdItems = new SqlCommand(sqlItems);
                    drItems = cmdItems.ExecuteReader();

                    // Leitura do drItems. Aqui, prepara-se as variaveis para o passo 3
                    if (drItems.HasRows)
                    {                  
                        // O item, seu tamanho e seu produto
                        Modelo.Item item;
                        Modelo.Tamanho tamanho;
                        Modelo.Produto produto;

                        // A lista de items do carrinho.
                        List<KeyValuePair<Modelo.Item, int>> itens = new List<KeyValuePair<Modelo.Item, int>>();

                        while (drItems.Read())
                        {

                        }
                    }
                }
            }
    
            return carrinhos;
        }
    }
}
    