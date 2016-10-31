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
    public class DALEncomenda : DAL
    {
        public DALEncomenda() : base() {}

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Encomenda> SelectAll()
        {
            Modelo.Encomenda encomenda;
            List<Modelo.Encomenda> encomendas = new List<Modelo.Encomenda>();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlEncomendas = "SELECT * FROM Encomenda";
                    SqlCommand cmdEncomendas = new SqlCommand(sqlEncomendas, conn);
                    SqlDataReader drEncomendas;

                    DALUsuario dalUsuario = new DALUsuario();
                    DALItemEncomenda dalItemEncomenda = new DALItemEncomenda();
                    DALLocalEntrega dalLocalEntrega = new DALLocalEntrega();
                    DALStatus dalStatus = new DALStatus();


                    using (drEncomendas = cmdEncomendas.ExecuteReader())
                    {
                        int id = (int)drEncomendas["id"];
                        double precoTotal = (double)drEncomendas["precoTotal"];
                        DateTime dataEntrega = (DateTime)drEncomendas["dataEntrega"];

                        Modelo.Usuario usuario = dalUsuario.Select((int)drEncomendas["Usuario_id"]);
                        List<Modelo.itemEncomenda> itensEncomenda = dalItemEncomenda.SelectFromEncomenda(id);
                        Modelo.localEntrega localEntrega = dalLocalEntrega.Select((int)drEncomendas["localEntrega_id"]);
                        Modelo.Status status = dalStatus.Select((int)drEncomendas["Status_id"]);

                        encomenda = new Modelo.Encomenda(usuario, itensEncomenda, dataEntrega, localEntrega, status);
                        encomendas.Add(encomenda);
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
        public Modelo.Encomenda Select(int idEncomenda)
        {
            Modelo.Encomenda encomenda;

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlEncomenda = "SELECT * FROM Encomenda";
                    SqlCommand cmdEncomenda = new SqlCommand(sqlEncomenda, conn);
                    SqlDataReader drEncomenda;

                    DALUsuario dalUsuario = new DALUsuario();
                    DALItemEncomenda dalItemEncomenda = new DALItemEncomenda();
                    DALLocalEntrega dalLocalEntrega = new DALLocalEntrega();
                    DALStatus dalStatus = new DALStatus();

                    using (drEncomenda = cmdEncomenda.ExecuteReader())
                    {
                        int id = (int)drEncomenda["id"];
                        double precoTotal = (double)drEncomenda["precoTotal"];
                        DateTime dataEntrega = (DateTime)drEncomenda["dataEntrega"];

                        Modelo.Usuario usuario = dalUsuario.Select((int)drEncomenda["Usuario_id"]);
                        List<Modelo.itemEncomenda> itensEncomenda = dalItemEncomenda.SelectFromEncomenda(id);
                        Modelo.localEntrega localEntrega = dalLocalEntrega.Select((int)drEncomenda["localEntrega_id"]);
                        Modelo.Status status = dalStatus.Select((int)drEncomenda["Status_id"]);

                        encomenda = new Modelo.Encomenda(usuario, itensEncomenda, dataEntrega, localEntrega, status);
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return encomenda;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Encomenda encomenda)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlEncomenda = "DELETE FROM Encomenda WHERE id = @id";
                    SqlCommand cmdEncomenda = new SqlCommand(sqlEncomenda, conn);
                    cmdEncomenda.Parameters.Add("@id", SqlDbType.Int).Value = encomenda.id;
                }
            }
            catch (SystemException)
            {   
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Encomenda encomenda)
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

                        DALItemEncomenda dalItemEncomenda = new DALItemEncomenda();
                        foreach (Modelo.itemEncomenda item in encomenda.itens)
                        {
                            dalItemEncomenda.Update(item);
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
        public void Insert(Modelo.Encomenda encomenda)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlEncomenda = "UPDATE Encomenda SET precoTotal = @preco, dataEntrega = @dataEntrega, localEntrega_id = @localEntrega, Status_id = @status";
                    SqlCommand cmdEncomenda = new SqlCommand(sqlEncomenda, conn);
                    cmdEncomenda.Parameters.Add("@preco", SqlDbType.Decimal).Value = encomenda.precoTotal;
                    cmdEncomenda.Parameters.Add("@dataEntrega", SqlDbType.DateTime).Value = encomenda.dataEntrega;
                    cmdEncomenda.Parameters.Add("@localEntrega", SqlDbType.Int).Value = encomenda.localEntrega.id;
                    cmdEncomenda.Parameters.Add("@status", SqlDbType.Int).Value = encomenda.Status.id;

                    DALItemEncomenda dalItemEncomenda = new DALItemEncomenda();
                    foreach (Modelo.itemEncomenda item in encomenda.itens)
                    {
                        dalItemEncomenda.Insert(item);
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }
    }
}