using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class DALTelefone : DAL
    {
        public DALTelefone() : base() {}

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Telefone> SelectAll()
        {
            // O telefone
            Modelo.Telefone telefone;
            // O retorno
            List<Modelo.Telefone> telefones = new List<Modelo.Telefone>();
           
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlTelefones = "SELECT * FROM Telefone";
                    SqlCommand cmdTelefones = new SqlCommand(sqlTelefones, conn);
                    SqlDataReader drTelefones;

                    using (drTelefones = cmdTelefones.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drTelefones.HasRows)
                        {
                            while (drTelefones.Read())
                            {
                                int id = Convert.ToInt32(drTelefones["id"]);
                                string numero = drTelefones["numero"].ToString();
                                int idUsuario = Convert.ToInt32(drTelefones["Usuario_id"]);

                                telefone = new Modelo.Telefone(id, numero, idUsuario);
                                telefones.Add(telefone);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return telefones;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Modelo.Telefone Select(int idTelefone)
        {
            // O telefone
            Modelo.Telefone telefone = null;            
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlTelefones = "SELECT * FROM Telefone WHERE id = @id";
                    SqlCommand cmdTelefones = new SqlCommand(sqlTelefones, conn);
                    cmdTelefones.Parameters.Add("@id", SqlDbType.Int).Value = idTelefone;
                    SqlDataReader drTelefones;

                    using (drTelefones = cmdTelefones.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drTelefones.HasRows)
                        {
                            while (drTelefones.Read())
                            {
                                int id = Convert.ToInt32(drTelefones["id"]);
                                string numero = drTelefones["numero"].ToString();
                                int idUsuario = Convert.ToInt32(drTelefones["Usuario_id"]);

                                telefone = new Modelo.Telefone(id, numero, idUsuario);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return telefone;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Telefone> SelectFromUsuario(int idUsuario)
        {
            // O telefone
            Modelo.Telefone telefone;
            // O retorno
            List<Modelo.Telefone> telefones = null;

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    // O SQL
                    string sqlTelefones = "SELECT * FROM Telefone WHERE Usuario_id = @idUsuario";
                    SqlCommand cmdTelefones = new SqlCommand(sqlTelefones, conn);
                    cmdTelefones.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                    SqlDataReader drTelefones;

                    using (drTelefones = cmdTelefones.ExecuteReader())
                    {
                        // Leitura do resultado
                        if (drTelefones.HasRows)
                        {
                            while (drTelefones.Read())
                            {
                                int idTelefone = Convert.ToInt32(drTelefones["id"]);
                                string numero = drTelefones["numero"].ToString();

                                telefone = new Modelo.Telefone(idTelefone, numero, idUsuario);
                                telefones.Add(telefone);
                            }
                        }
                    }
                }
            }
            catch (SystemException)
            {   
                throw;
            }

            return telefones;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Telefone telefone)
        {   try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlTelefones = "DELETE FROM Telefone WHERE id = @id";
                    SqlCommand cmdTelefones = new SqlCommand(sqlTelefones, conn);
                    cmdTelefones.Parameters.Add("@id", SqlDbType.Int).Value = telefone.id;
                    
                    cmdTelefones.ExecuteNonQuery();
                    
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Telefone telefone)
        {
            string numero = telefone.numero;
            int idUsuario = telefone.usuarioId;
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // O SQL
                    string sqlTelefone = "INSERT INTO Telefone (numero, Usuario_id) VALUES ('@numero', @idUsuario)";
                    SqlCommand cmdTelefone = new SqlCommand(sqlTelefone, conn);
                    cmdTelefone.Parameters.Add("@numero", SqlDbType.VarChar).Value = numero;
                    cmdTelefone.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    cmdTelefone.ExecuteNonQuery();
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Update(Modelo.Telefone telefone)
        {
            string numero = telefone.numero;
            int idUsuario = telefone.usuarioId;
            int idTelefone = telefone.id;
            if (Select(telefone.id) != telefone)
            {
                try
                {
                    using (conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        // O SQL
                        string sqlTelefone = "UPDATE Telefone SET numero = '@numero', Usuario_id = idUsuario WHERE id = @idTelefone";
                        SqlCommand cmdTelefone = new SqlCommand(sqlTelefone, conn);
                        cmdTelefone.Parameters.Add("@numero", SqlDbType.VarChar).Value = numero;
                        cmdTelefone.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                        cmdTelefone.Parameters.Add("@idTelefone", SqlDbType.Int).Value = idTelefone;

                        cmdTelefone.ExecuteNonQuery();
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