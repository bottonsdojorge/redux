using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebApplication1.Cliente
{
    public partial class personalizar : System.Web.UI.Page
    {
        private System.Drawing.Image _imagem;
        public System.Drawing.Image imagem
        {
            get { return _imagem; }
            set { _imagem = value; }
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            /**
             * Limite de arquivo de 5mb. Tem que ver aí as paradas do retorno de mensagem. 
             */
            imagem = System.Drawing.Image.FromStream(fileProduto.PostedFile.InputStream);
            int tamanhoArquivo = fileProduto.PostedFile.ContentLength;
            string tipoArquivo = fileProduto.PostedFile.ContentType;

            if (!(tamanhoArquivo > 5000000 || (tipoArquivo != "image/jpg" && tipoArquivo != "image/jpeg" && tipoArquivo != "image/png")))
            {
                DAL.DALProduto dalProduto = new DAL.DALProduto();
                Modelo.Produto produto = new Modelo.Produto(0, nomeUpload.Value, imagem, new List<Modelo.Marcador>());

                dalProduto.Insert(produto);

                Response.Write("Inserido");
            }
        }
    }
}