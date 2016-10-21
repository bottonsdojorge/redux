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
                        if (drTelefones.HasRows)
                        {
                            while (drTelefones.Read())
                            {
                                int id = Convert.ToInt32(drTelefones["id"]);
                                string numero = drTelefones["numero"].ToString();
                                int idUsuario = Convert.ToInt32(drTelefones["Usuario_id"];

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
                        if (drTelefones.HasRows)
                        {
                            while (drTelefones.Read())
                            {
                                int id = Convert.ToInt32(drTelefones["id"]);
                                string numero = drTelefones["numero"].ToString();
                                int idUsuario = Convert.ToInt32(drTelefones["Usuario_id"];

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
    }
}