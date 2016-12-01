using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebApplication1.DAL
{
    public class DALUsuario : DAL
    {
        public DALUsuario() : base() {}

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Usuario> SelectAll()
        {
            Modelo.Usuario usuario;
            List<Modelo.Usuario> usuarios = new List<Modelo.Usuario>();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlUsuarios = "SELECT * FROM Usuario";
                    SqlCommand cmdUsuarios = new SqlCommand(sqlUsuarios, conn);
                    SqlDataReader drUsuarios;

                    using (drUsuarios = cmdUsuarios.ExecuteReader())
                    {
                        if (drUsuarios.HasRows)
                        {
                            while (drUsuarios.Read())
                            {
                                int id = Convert.ToInt32(drUsuarios["id"]);
                                string idAspnet = drUsuarios["aspnet_id"].ToString();
                                string nome = drUsuarios["nome"].ToString();

                                DALTelefone dalTelefone = new DALTelefone();
                                DALEnderecoUsuario dalEnderecoUsuario = new DALEnderecoUsuario();
                                DALCarrinho dalCarrinho = new DALCarrinho();

                                List<Modelo.Telefone> telefones = dalTelefone.SelectFromUsuario(id);
                                List<Modelo.EnderecoUsuario> enderecos = dalEnderecoUsuario.SelectFromUsuario(id);
                                Modelo.Carrinho carrinho = dalCarrinho.Select(id);

                                usuario = new Modelo.Usuario(id, idAspnet, nome, telefones, enderecos, carrinho);
                                usuarios.Add(usuario);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }

            return usuarios;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Modelo.Usuario Select(int idUsuario)
        {
            Modelo.Usuario usuario = null;
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    string sqlUsuario = "SELECT * FROM Usuario WHERE id = @id";
                    SqlCommand cmdUsuario = new SqlCommand(sqlUsuario, conn);
                    cmdUsuario.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
                    SqlDataReader drUsuario;

                    using (drUsuario = cmdUsuario.ExecuteReader())
                    {
                        if (drUsuario.HasRows)
                        {
                            while (drUsuario.Read())
                            {
                                int id = Convert.ToInt32(drUsuario["id"]);
                                string idAspnet = drUsuario["aspnet_id"].ToString();
                                string nome = drUsuario["nome"].ToString();

                                DALTelefone dalTelefone = new DALTelefone();
                                DALEnderecoUsuario dalEnderecoUsuario = new DALEnderecoUsuario();
                                DALCarrinho dalCarrinho = new DALCarrinho();

                                List<Modelo.Telefone> telefones = dalTelefone.SelectFromUsuario(id);
                                List<Modelo.EnderecoUsuario> enderecos = dalEnderecoUsuario.SelectFromUsuario(id);
                                Modelo.Carrinho carrinho = dalCarrinho.Select(id);

                                usuario = new Modelo.Usuario(id, idAspnet, nome, telefones, enderecos, carrinho);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return usuario;
        }

        /*
         * Isso aqui é um problema. Tem que deletar da tabela aspnet id.
         * ~Se deletar só daqui, haverá problemas.
         * Possível solução: trigger a partir do SGBD
         */

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Usuario usuario)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlUsuario = "DELETE FROM Usuario WHERE id = @id";
                    SqlCommand cmdUsuario = new SqlCommand(sqlUsuario, conn);
                    cmdUsuario.Parameters.Add("@id", SqlDbType.Int).Value = usuario.id;

                    cmdUsuario.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {   
                throw;
            }
        }

        /*
         * Aqui, a mesma coisa. Da forma que a tabela existe hoje, não há sentido.
         * Urgente: revisar tabela do usuário, acrescentar informações a ela para que seja útil de alguma forma.
         */
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Usuario usuario)
        {   
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlUsuario = "INSERT INTO Usuario (nome, aspnet_id) VALUES ('@nome', '@idAspnet')";
                    SqlCommand cmdUsuario = new SqlCommand(sqlUsuario, conn);
                    cmdUsuario.Parameters.Add("@nome", SqlDbType.VarChar).Value = usuario.nome;
                    cmdUsuario.Parameters.Add("@idAspnet", SqlDbType.VarChar).Value = usuario.aspnet_id;

                    DALTelefone dalTelefone = new DALTelefone();
                    foreach (Modelo.Telefone telefone in usuario.telefones)
                    {
                        dalTelefone.Insert(telefone);
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
           
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Usuario usuario)
        {
            if (Select(usuario.id) != usuario)
            {
                try
                {
                    using (conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string sqlUsuario = "UPDATE Usuario SET nome = '@nome' WHERE id = @id";
                        SqlCommand cmdUsuario = new SqlCommand(sqlUsuario, conn);
                        cmdUsuario.Parameters.Add("@nome", SqlDbType.VarChar).Value = usuario.nome;
                        cmdUsuario.Parameters.Add("@id", SqlDbType.Int).Value = usuario.id;

                        cmdUsuario.ExecuteNonQuery();
                    }
                }
                catch (SystemException)
                {   
                    throw;
                }
            }
        }

        public int GetCurrentUserId(string aspnetid)
        {
            int id = 0;
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //MembershipUser usuario = Membership.Providers["pedroPcConnectionString"].GetUser(HttpContext.Current.User.Identity.Name, false);
                    string sqlUsuario = "SELECT id FROM Usuario WHERE aspnet_id = @aspnet_id";
                    SqlCommand cmdUsuario = new SqlCommand(sqlUsuario, conn);
                    cmdUsuario.Parameters.Add("@aspnet_id", System.Data.SqlDbType.VarChar).Value = aspnetid;
                    SqlDataReader drUsuario;

                    using (drUsuario = cmdUsuario.ExecuteReader())
                    {
                        if (drUsuario.HasRows)
                        {
                            drUsuario.Read();
                            id = Convert.ToInt32(drUsuario["id"]);
                        }
                    }
                }
            }
            catch (SystemException)
            {   
                throw;
            }
            return id;
        }
    }
}