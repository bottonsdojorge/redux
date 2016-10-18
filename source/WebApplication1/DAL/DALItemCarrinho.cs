using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class DALItemCarrinho
    {
        //public Modelo.itemCarrinho Select(int idCarrinho);
        string connectionString = "";

        public DALItemCarrinho()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BottonsDoJorgeConnectionString"].ConnectionString;
        }

        /*
         * Retorna itemCarrinho a partir do ID do carrinho.
         * @param int O id do carrinho
         */
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.itemCarrinho> Select(int idCarrinho)
        {
            // O item
            Modelo.itemCarrinho item = new Modelo.itemCarrinho();
            
            // A lista de retorno
            List<Modelo.itemCarrinho> items = new List<Modelo.itemCarrinho>();

            // Abrindo a conexão
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            // Comando SQL Items.
            string sqlItems = String.Format("SELECT * FROM ItemCarrinho WHERE carrinho_id = {0}", idCarrinho);
            SqlCommand cmdItems = new SqlCommand(sqlItems);
            
            // Executa comando SQL Items
            SqlDataReader drItems = cmdItems.ExecuteReader();

            return items;
        }

    }
}