using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace redux.DAL
{
    public class DALItem : DAL
    {
        public DALItem() : base() { }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Modelo.Item> SelectAll()
        {
            Modelo.Item item;
            List<Modelo.Item> itens = new List<Modelo.Item>();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlItens = "SELECT * FROM Item";
                    SqlCommand cmdItens = new SqlCommand(sqlItens, conn);
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

                                Modelo.Produto produto = DALProduto.Select(idProduto);
                                Modelo.Tamanho tamanho = DALTamanho.Select(idTamanho);

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
        public static Modelo.Item Select(int idProduto, int idTamanho)
        {
            // O Produto retorno
            Modelo.Item item = null;

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlItens = "SELECT * FROM Item WHERE Tamanho_id = @idTamanho AND Produto_id = @idProduto";
                    SqlCommand cmdItens = new SqlCommand(sqlItens, conn);
                    cmdItens.Parameters.Add("@idTamanho", SqlDbType.Int).Value = idTamanho;
                    cmdItens.Parameters.Add("@idProduto", SqlDbType.Int).Value = idProduto;
                    SqlDataReader drItens;
                    using (drItens = cmdItens.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drItens.HasRows)
                        {
                            while (drItens.Read())
                            {
                                idProduto = Convert.ToInt32(drItens["Produto_id"]);
                                idTamanho = Convert.ToInt32(drItens["Tamanho_id"]);

                                Modelo.Produto produto = DALProduto.Select(idProduto);
                                Modelo.Tamanho tamanho = DALTamanho.Select(idTamanho);

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

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Modelo.Item> SelectToVitrine(List<int> marcadores, int pagina)
        {
            /* Verificar o que o sql server retorna se o offset for maior do que o numero de itens.*/

            int itensPorPagina = Convert.ToInt32(ConfigurationManager.AppSettings["itensPorPagina"]);
            int offset = (pagina - 1) * itensPorPagina;
            
            List<Modelo.Item> itens = new List<Modelo.Item>();
            Modelo.Item item = null;

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    /*
                     * O que isso aqui vai fazer?
                     * Vou retornar produtos a partir da página e a partir de filtros
                     * Que filtros? Marcadores.
                     * Tenho que encontrar os produtos que se referem a determinados marcadores passados.
                     * Logo, tenho que ter um loop na lista de maarcadores.
                     */
                    string where;
                    if (marcadores.Count == 0)
                        where = "WHERE 1 = 1";
                    else
                        where = "WHERE 1 = 2";
                    foreach (int marcador in marcadores)
                    {
                        where += String.Format(" OR mp.Marcador_id = {0} ", marcador);
                    }
                    string sqlItens = String.Format("SELECT i.Tamanho_id, i.Produto_id FROM ( SELECT i.Tamanho_id, i.Produto_id FROM Item i INNER JOIN marcadorProduto mp on mp.Produto_id = i.Produto_id {0} ) i ORDER BY i.Tamanho_id, i.Produto_id OFFSET @offSet ROWS FETCH NEXT @itensPorPagina ROWS ONLY", where);
                    SqlCommand cmdItens = new SqlCommand(sqlItens, conn);
                    cmdItens.Parameters.Add("@offSet", SqlDbType.Int).Value = offset;
                    cmdItens.Parameters.Add("@itensPorPagina", SqlDbType.Int).Value = itensPorPagina;
                    SqlDataReader drItens;

                    using (drItens = cmdItens.ExecuteReader())
                    {
                        if (drItens.HasRows)
                        {
                            while (drItens.Read())
                            {

                                int idProduto = Convert.ToInt32(drItens["Produto_id"]);
                                int idTamanho = Convert.ToInt32(drItens["Tamanho_id"]);

                                Modelo.Produto produto = DALProduto.Select(idProduto);
                                Modelo.Tamanho tamanho = DALTamanho.Select(idTamanho);

                                item = new Modelo.Item(produto, tamanho);
                                itens.Add(item);
                            }
                        }
                    }    
                }
            }
            catch (SystemException)
            {   
                throw;
            }

            return itens;
        }

        //teste index
        public static List<Modelo.Item> SelectToIndex(List<int> marcadores, int pagina)
        {
            /* Verificar o que o sql server retorna se o offset for maior do que o numero de itens.*/

            int itensPorPagina = Convert.ToInt32(ConfigurationManager.AppSettings["itensPorPagina"]);
            int offset = (pagina - 1) * itensPorPagina;

            List<Modelo.Item> itens = new List<Modelo.Item>();
            Modelo.Item item = null;

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    /*
                     * O que isso aqui vai fazer?
                     * Vou retornar produtos a partir da página e a partir de filtros
                     * Que filtros? Marcadores.
                     * Tenho que encontrar os produtos que se referem a determinados marcadores passados.
                     * Logo, tenho que ter um loop na lista de maarcadores.
                     */
                    string where;
                    if (marcadores.Count == 0)
                        where = "WHERE 1 = 1";
                    else
                        where = "WHERE 1 = 2";
                    foreach (int marcador in marcadores)
                    {
                        where += String.Format(" OR mp.Marcador_id = {0} ", marcador);
                    }
                    string sqlItens = String.Format("SELECT i.Tamanho_id, i.Produto_id FROM ( SELECT i.Tamanho_id, i.Produto_id FROM Item i INNER JOIN marcadorProduto mp on mp.Produto_id = i.Produto_id {0} ) i ORDER BY i.Produto_id OFFSET @offSet ROWS FETCH NEXT @itensPorPagina ROWS ONLY", where);
                    SqlCommand cmdItens = new SqlCommand(sqlItens, conn);
                    cmdItens.Parameters.Add("@offSet", SqlDbType.Int).Value = offset;
                    cmdItens.Parameters.Add("@itensPorPagina", SqlDbType.Int).Value = itensPorPagina;
                    SqlDataReader drItens;

                    using (drItens = cmdItens.ExecuteReader())
                    {
                        if (drItens.HasRows)
                        {
                            while (drItens.Read())
                            {

                                int idProduto = Convert.ToInt32(drItens["Produto_id"]);
                                int idTamanho = Convert.ToInt32(drItens["Tamanho_id"]);

                                Modelo.Produto produto = DALProduto.Select(idProduto);
                                Modelo.Tamanho tamanho = DALTamanho.Select(idTamanho);

                                item = new Modelo.Item(produto, tamanho);
                                itens.Add(item);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }

            return itens;
        }
        //fim teste index

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static int SelectNumPaginas(List<int> marcadores)
        {
            int itensPorPagina = Convert.ToInt32(ConfigurationManager.AppSettings["itensPorPagina"]);
            int count = 0;
            
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    /*
                     * O que isso aqui vai fazer?
                     * Vou retornar produtos a partir da página e a partir de filtros
                     * Que filtros? Marcadores.
                     * Tenho que encontrar os produtos que se referem a determinados marcadores passados.
                     * Logo, tenho que ter um loop na lista de marcadores.
                     */
                    string where;
                    if (marcadores.Count == 0)
                        where = "WHERE 1 = 1";
                    else
                        where = "WHERE 1 = 2";
                    foreach (int marcador in marcadores)
                    {
                        where += String.Format(" OR mp.Marcador_id ={0} ", marcador);
                    }
                    string sqlItens = String.Format("SELECT COUNT(i.Tamanho_id) FROM ( SELECT i.Tamanho_id, i.Produto_id FROM Item i INNER JOIN marcadorProduto mp on mp.Produto_id = i.Produto_id {0} ) i", where);
                    SqlCommand cmdItens = new SqlCommand(sqlItens, conn);
                    SqlDataReader drItens;

                    using (drItens = cmdItens.ExecuteReader())
                    {
                        if (drItens.HasRows)
                        {
                            while (drItens.Read())
                            {
                                count = (int)drItens[0];
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }

            return ((int)Math.Ceiling((double)count / itensPorPagina));
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Modelo.Item item)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlItem = "DELETE FROM Item WHERE Tamanho_id = @idTamaho AND Produto_id = @idProduto";
                    SqlCommand cmdItem = new SqlCommand(sqlItem, conn);
                    cmdItem.Parameters.Add("@idTamanho", SqlDbType.Int).Value = item.tamanho.id;
                    cmdItem.Parameters.Add("@idProduto", SqlDbType.Int).Value = item.produto.id;
                    cmdItem.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void Insert(Modelo.Item item)
        {
            if (Select(item.produto.id, item.tamanho.id) != item)
            {
                try
                {
                    using (conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sqlItem = "INSERT INTO Item (Tamanho_id, Produto_id) VALUES (@idTamanho, @idProduto)";
                        SqlCommand cmdItem = new SqlCommand(sqlItem, conn);
                        cmdItem.Parameters.Add("@idTamanho", SqlDbType.Int).Value = item.tamanho.id;
                        cmdItem.Parameters.Add("@idProduto", SqlDbType.Int).Value = item.produto.id;
                        cmdItem.ExecuteNonQuery();

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