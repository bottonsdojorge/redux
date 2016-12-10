using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace redux.DAL
{
    public class DALEncomenda : DAL
    {
        public DALEncomenda() : base() {}

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Modelo.Encomenda> SelectAll()
        {
            Modelo.Encomenda encomenda = new Modelo.Encomenda();
            List<Modelo.Encomenda> encomendas = new List<Modelo.Encomenda>();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlEncomendas = "SELECT * FROM Encomenda";
                    SqlCommand cmdEncomendas = new SqlCommand(sqlEncomendas, conn);
                    SqlDataReader drEncomendas;

                    using (drEncomendas = cmdEncomendas.ExecuteReader())
                    {
                        if (drEncomendas.HasRows)
                        {
                            while (drEncomendas.Read())
                            {
                                int id = (int)drEncomendas["id"];
                                double precoTotal = Convert.ToDouble(drEncomendas["precoTotal"]);
                                DateTime dataEntrega;
                                DateTime.TryParse(drEncomendas["dataEntrega"].ToString(), out dataEntrega);

                                Modelo.Usuario usuario = DALUsuario.Select((int)drEncomendas["Usuario_id"]);
                                List<Modelo.itemEncomenda> itensEncomenda = DALItemEncomenda.SelectFromEncomenda(id);
                                Modelo.localEntrega localEntrega = DALLocalEntrega.Select((int)drEncomendas["localEntrega_id"]);
                                Modelo.Status status = DALStatus.Select((int)drEncomendas["Status_id"]);

                                encomenda = new Modelo.Encomenda(id, usuario, itensEncomenda, dataEntrega, localEntrega, status);
                                encomendas.Add(encomenda);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return encomendas;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Modelo.Encomenda Select(int idEncomenda)
        {
            Modelo.Encomenda encomenda = new Modelo.Encomenda();
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlEncomenda = "SELECT * FROM Encomenda";
                    SqlCommand cmdEncomenda = new SqlCommand(sqlEncomenda, conn);
                    SqlDataReader drEncomenda;

                    using (drEncomenda = cmdEncomenda.ExecuteReader())
                    {
                        if (drEncomenda.HasRows)
                        {
                            while (drEncomenda.Read())
                            {
                                int id = (int)drEncomenda["id"];
                                double precoTotal = Convert.ToDouble(drEncomenda["precoTotal"]);
                                DateTime dataEntrega;
                                DateTime.TryParse(drEncomenda["dataEntrega"].ToString(), out dataEntrega);

                                Modelo.Usuario usuario = DALUsuario.Select((int)drEncomenda["Usuario_id"]);
                                List<Modelo.itemEncomenda> itensEncomenda = DALItemEncomenda.SelectFromEncomenda(id);
                                Modelo.localEntrega localEntrega = DALLocalEntrega.Select((int)drEncomenda["localEntrega_id"]);
                                Modelo.Status status = DALStatus.Select((int)drEncomenda["Status_id"]);

                                encomenda = new Modelo.Encomenda(id, usuario, itensEncomenda, dataEntrega, localEntrega, status);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return encomenda;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Modelo.Encomenda> SelectFromUsuario(int idUsuario)
        {
            Modelo.Encomenda encomenda;
            List<Modelo.Encomenda> encomendas = new List<Modelo.Encomenda>();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlEncomendas = "SELECT * FROM Encomenda WHERE Usuario_id = @idUsuario";
                    SqlCommand cmdEncomendas = new SqlCommand(sqlEncomendas, conn);
                    cmdEncomendas.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                    SqlDataReader drEncomendas;

                    using (drEncomendas = cmdEncomendas.ExecuteReader())
                    {
                        if (drEncomendas.HasRows)
                        {
                            while (drEncomendas.Read())
                            {
                                int id = (int)drEncomendas["id"];
                                double precoTotal = Convert.ToDouble(drEncomendas["precoTotal"]);
                                DateTime dataEntrega;
                                DateTime.TryParse(drEncomendas["dataEntrega"].ToString(), out dataEntrega);

                                Modelo.Usuario usuario = DALUsuario.Select((int)drEncomendas["Usuario_id"]);
                                List<Modelo.itemEncomenda> itensEncomenda = DALItemEncomenda.SelectFromEncomenda(id);
                                Modelo.localEntrega localEntrega = DALLocalEntrega.Select((int)drEncomendas["localEntrega_id"]);
                                Modelo.Status status = DALStatus.Select((int)drEncomendas["Status_id"]);

                                encomenda = new Modelo.Encomenda(id, usuario, itensEncomenda, dataEntrega, localEntrega, status);
                                encomendas.Add(encomenda);
                    
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return encomendas;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Modelo.Encomenda encomenda)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlEncomenda = "DELETE FROM Encomenda WHERE id = @id";
                    SqlCommand cmdEncomenda = new SqlCommand(sqlEncomenda, conn);
                    cmdEncomenda.Parameters.Add("@id", SqlDbType.Int).Value = encomenda.id;
                    cmdEncomenda.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {   
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Modelo.Encomenda encomenda)
        {
            if (Select(encomenda.id) != encomenda)
            {
                try
                {
                    using (conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string sqlEncomenda = "UPDATE Encomenda SET precoTotal = @preco, dataEntrega = @dataEntrega, localEntrega_id = @localEntrega, Status_id = @status WHERE id = @id";
                        SqlCommand cmdEncomenda = new SqlCommand(sqlEncomenda, conn);
                        cmdEncomenda.Parameters.Add("@id", SqlDbType.Int).Value = encomenda.id;
                        cmdEncomenda.Parameters.Add("@preco", SqlDbType.Decimal).Value = encomenda.precoTotal;
                        cmdEncomenda.Parameters.Add("@dataEntrega", SqlDbType.DateTime).Value = encomenda.dataEntrega;
                        cmdEncomenda.Parameters.Add("@localEntrega", SqlDbType.Int).Value = encomenda.localEntrega.id;
                        cmdEncomenda.Parameters.Add("@status", SqlDbType.Int).Value = encomenda.Status.id;
                        cmdEncomenda.ExecuteNonQuery();
                        foreach (Modelo.itemEncomenda item in encomenda.itens)
                        {
                            DALItemEncomenda.Update(item);
                        }
                    }
                }
                catch (SystemException)
                {
                    throw;
                }
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void Insert(Modelo.Encomenda encomenda)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmdEncomenda;
                    if (encomenda.dataEntrega != null)
                    {
                        string sqlEncomenda = "INSERT INTO Encomenda (Usuario_id, precoTotal, dataEntrega, localEntrega_id, Status_id) VALUES (@idUsuario, @preco, @dataEntrega, @localEntrega,@status) SET @id = SCOPE_IDENTITY()";
                        cmdEncomenda = new SqlCommand(sqlEncomenda, conn);
                        cmdEncomenda.Parameters.Add("@dataEntrega", SqlDbType.DateTime).Value = encomenda.dataEntrega;
                    }
                    else
                    {
                        string sqlEncomenda = "INSERT INTO Encomenda (Usuario_id, precoTotal, localEntrega_id, Status_id) VALUES (@idUsuario, @preco, @localEntrega,@status) SET @id = SCOPE_IDENTITY()";
                        cmdEncomenda = new SqlCommand(sqlEncomenda, conn);
                    }
                    cmdEncomenda.Parameters.Add("@idUsuario", SqlDbType.Int).Value = encomenda.Usuario.id;
                    cmdEncomenda.Parameters.Add("@preco", SqlDbType.Decimal).Value = encomenda.precoTotal;
                    cmdEncomenda.Parameters.Add("@localEntrega", SqlDbType.Int).Value = encomenda.localEntrega.id;
                    cmdEncomenda.Parameters.Add("@status", SqlDbType.Int).Value = encomenda.Status.id;
                    cmdEncomenda.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmdEncomenda.ExecuteNonQuery();
                    foreach (Modelo.itemEncomenda item in encomenda.itens)
                    {
                        item.encomendaId = Convert.ToInt32(cmdEncomenda.Parameters["@id"].Value);
                        DALItemEncomenda.Insert(item);
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        public static void RegistrarEncomenda(int uid, int leid)
        {
            Modelo.Encomenda encomenda;
            Modelo.Usuario usuario;
            Modelo.itemEncomenda itemEncomenda;
            List<Modelo.itemEncomenda> itensEncomenda = new List<Modelo.itemEncomenda>();
            usuario = DALUsuario.Select(uid);
            foreach (Modelo.itemCarrinho item in usuario.carrinho.itens)
            {
                itemEncomenda = new Modelo.itemEncomenda(0, item.item, item.item.tamanho.precoUnitario, item.quantidade);
                itensEncomenda.Add(itemEncomenda);
            }
            encomenda = new Modelo.Encomenda(0, usuario, itensEncomenda, DALLocalEntrega.Select(leid), DALStatus.Select(1));
            Insert(encomenda);
            DALCarrinho.Limpar(usuario.carrinho);
        }
    }
}