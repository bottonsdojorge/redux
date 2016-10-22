﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class DALMensagem : DAL
    {
        public DALMensagem() : base() {}

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Mensagem> SelectAll()
        {
            Modelo.Mensagem mensagem;
            List<Modelo.Mensagem> mensagens = null;

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlMensagens = "SELECT ALL FROM Mensagem";
                    SqlCommand cmdMensagens = new SqlCommand(sqlMensagens, conn);
                    SqlDataReader drMensagens;

                    using (drMensagens = cmdMensagens.ExecuteReader())
                    {
                        if (drMensagens.HasRows)
                        {
                            while (drMensagens.Read())
                            {
                                int id = Convert.ToInt32(drMensagens["id"]);
                                DateTime data = Convert.ToDateTime(drMensagens["data"]);
                                string corpo = drMensagens["corpo"].ToString();
                                bool visualizada = Convert.ToBoolean(drMensagens["visualizada"]);
                                int idDestinatario = Convert.ToInt32(drMensagens["UsuarioDestinatario_id"]);
                                int idRemetente = Convert.ToInt32(drMensagens["UsuarioRemetente_id"]);

                                DALUsuario dalUsuario = new DALUsuario();

                                Modelo.Usuario destinatario = dalUsuario.Select(idDestinatario);
                                Modelo.Usuario remetente = dalUsuario.Select(idRemetente);

                                mensagem = new Modelo.Mensagem(id, data, corpo, visualizada, destinatario, remetente);
                                mensagens.Add(mensagem);                               
                            }
                        }

                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }

            return mensagens;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Modelo.Mensagem Select(int idMensagem)
        {
            Modelo.Mensagem mensagem = null;

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    string sqlMensagem = "SELECT * FROM Mensagem WHERE id = @idMensagem";
                    SqlCommand cmdMensagem = new SqlCommand(sqlMensagem, conn);
                    cmdMensagem.Parameters.Add("@idMensagem", SqlDbType.Int).Value = idMensagem;
                    SqlDataReader drMensagem;

                    using (drMensagem = cmdMensagem.ExecuteReader())
                    {
                        if (drMensagem.HasRows)
                        {
                            while (drMensagem.Read())
                            {
                                int id = Convert.ToInt32(drMensagem["id"]);
                                DateTime data = Convert.ToDateTime(drMensagem["data"]);
                                string corpo = drMensagem["corpo"].ToString();
                                bool visualizada = Convert.ToBoolean(drMensagem["visualizada"]);
                                int idDestinatario = Convert.ToInt32(drMensagem["UsuarioDestinatario_id"]);
                                int idRemetente = Convert.ToInt32(drMensagem["UsuarioRemetente_id"]);

                                DALUsuario dalUsuario = new DALUsuario();

                                Modelo.Usuario destinatario = dalUsuario.Select(idDestinatario);
                                Modelo.Usuario remetente = dalUsuario.Select(idRemetente);

                                mensagem = new Modelo.Mensagem(id, data, corpo, visualizada, destinatario, remetente);                                
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {   
                throw;
            }

            return mensagem;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Mensagem> SelectFromDestinatario(int idDestinatario)
        {
            Modelo.Mensagem mensagem;
            List<Modelo.Mensagem> mensagens = null;

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlMensagens = "SELECT ALL FROM Mensagem WHERE UsuarioDestinatario_id = @idDestinatario";
                    SqlCommand cmdMensagens = new SqlCommand(sqlMensagens, conn);
                    cmdMensagens.Parameters.Add("@idDestinatario", SqlDbType.Int).Value = idDestinatario;
                    SqlDataReader drMensagens;

                    using (drMensagens = cmdMensagens.ExecuteReader())
                    {
                        if (drMensagens.HasRows)
                        {
                            while (drMensagens.Read())
                            {
                                int id = Convert.ToInt32(drMensagens["id"]);
                                DateTime data = Convert.ToDateTime(drMensagens["data"]);
                                string corpo = drMensagens["corpo"].ToString();
                                bool visualizada = Convert.ToBoolean(drMensagens["visualizada"]);
                                int idRemetente = Convert.ToInt32(drMensagens["UsuarioRemetente_id"]);

                                DALUsuario dalUsuario = new DALUsuario();

                                Modelo.Usuario destinatario = dalUsuario.Select(idDestinatario);
                                Modelo.Usuario remetente = dalUsuario.Select(idRemetente);

                                mensagem = new Modelo.Mensagem(id, data, corpo, visualizada, destinatario, remetente);
                                mensagens.Add(mensagem);
                            }
                        }

                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }

            return mensagens;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Mensagem> SelectFromRemetente(int idRemetente)
        {
            Modelo.Mensagem mensagem;
            List<Modelo.Mensagem> mensagens = null;

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlMensagens = "SELECT ALL FROM Mensagem WHERE UsuarioRemetente_id = @idRemetente";
                    SqlCommand cmdMensagens = new SqlCommand(sqlMensagens, conn);
                    cmdMensagens.Parameters.Add("@idRemetente", SqlDbType.Int).Value = idRemetente;
                    SqlDataReader drMensagens;

                    using (drMensagens = cmdMensagens.ExecuteReader())
                    {
                        if (drMensagens.HasRows)
                        {
                            while (drMensagens.Read())
                            {
                                int id = Convert.ToInt32(drMensagens["id"]);
                                DateTime data = Convert.ToDateTime(drMensagens["data"]);
                                string corpo = drMensagens["corpo"].ToString();
                                bool visualizada = Convert.ToBoolean(drMensagens["visualizada"]);
                                int idDestinatario = Convert.ToInt32(drMensagens["UsuarioDestinatario_id"]);

                                DALUsuario dalUsuario = new DALUsuario();

                                Modelo.Usuario destinatario = dalUsuario.Select(idDestinatario);
                                Modelo.Usuario remetente = dalUsuario.Select(idRemetente);

                                mensagem = new Modelo.Mensagem(id, data, corpo, visualizada, destinatario, remetente);
                                mensagens.Add(mensagem);
                            }
                        }

                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }

            return mensagens;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Mensagem mensagem)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    string sqlMensagem = "DELETE FROM Mensagem WHERE id = @id";
                    SqlCommand cmdMensagem = new SqlCommand(sqlMensagem, conn);
                    cmdMensagem.Parameters.Add("@id", SqlDbType.Int).Value = mensagem.id;

                    cmdMensagem.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {   
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Mensagem mensagem)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    string sqlMensagem = "INSERT INTO Mensagem (data, corpo, visualizada, UsuarioDestinatario_id, UsuarioRemetente_id) VALUES (@data, '@corpo', @visualizada, @idDestinatario, @idRemetente)";
                    SqlCommand cmdMensagem = new SqlCommand(sqlMensagem, conn);
                    cmdMensagem.Parameters.Add("@data", SqlDbType.DateTime).Value = mensagem.data;
                    cmdMensagem.Parameters.Add("@corpo", SqlDbType.VarChar).Value = mensagem.corpo;
                    cmdMensagem.Parameters.Add("@visualizada", SqlDbType.Bit).Value = mensagem.visualizada;
                    cmdMensagem.Parameters.Add("@idDestinatario", SqlDbType.Int).Value = mensagem.destinatario.id;
                    cmdMensagem.Parameters.Add("@idRemetente", SqlDbType.Int).Value = mensagem.remetente.id;

                    cmdMensagem.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {   
                throw;
            }
        }

        /*
         * Será que na mensagem só deveríamos alterar o status? 
         * Acho que sim.. Talvez um trigger no SGBD.
         */
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Mensagem mensagem)
        {
            if (Select(mensagem.id) != mensagem)
            {
                try
                {
                    using (conn = new SqlConnection(connectionString))
                    {
                        string sqlMensagem = "UPDATE Mensagem SET data = @data, corpo = @corpo, visualizada = @visualizada, UsuarioDestinatario_id = @idDestinatario, UsuarioRemetente_id = @idRemetente";
                        SqlCommand cmdMensagem = new SqlCommand(sqlMensagem, conn);
                        cmdMensagem.Parameters.Add("@data", SqlDbType.DateTime).Value = mensagem.data;
                        cmdMensagem.Parameters.Add("@corpo", SqlDbType.VarChar).Value = mensagem.corpo;
                        cmdMensagem.Parameters.Add("@visualizada", SqlDbType.Bit).Value = mensagem.visualizada;
                        cmdMensagem.Parameters.Add("@idDestinatario", SqlDbType.Int).Value = mensagem.destinatario.id;
                        cmdMensagem.Parameters.Add("@idRemetente", SqlDbType.Int).Value = mensagem.remetente.id;

                        cmdMensagem.ExecuteNonQuery();
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