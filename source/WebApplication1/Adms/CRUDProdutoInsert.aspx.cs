using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CRUDProdutoInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            string aSQLConecStr;
            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["BottonsDoJorgeConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL = new SqlCommand("INSERT INTO Produto(descricao, preco, imagem, tamanho) VALUES (@descricao, @preco, @imagem, @tamanho)", aSQLCon);
           
            aSQL.Parameters.AddWithValue("@descricao", txtDescricao.Text);
            aSQL.Parameters.Add("@preco", SqlDbType.Float).Value = txtPreco.Text;
            aSQL.Parameters.AddWithValue("@imagem", txtEnderecoImg.Text);
            aSQL.Parameters.AddWithValue("@tamanho", txtTamanho.Text);
            aSQL.ExecuteNonQuery();

            Response.Redirect("~/Adms/CRUDProdutoSelect.aspx");
        
        }
    }
}