using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Collections.Specialized;

namespace WebApplication1.usuario
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

        protected void btnupload_Click(object sender, EventArgs e)
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
                DAL.DALItem dalItem = new DAL.DALItem();
                DAL.DALTamanho dalTamanho = new DAL.DALTamanho();

                Modelo.Produto produto = new Modelo.Produto(0, nomeupload.Value, imagem, new List<Modelo.Marcador>());
                produto.id = dalProduto.Insert(produto);
                
                Modelo.Item item = new Modelo.Item(produto, dalTamanho.Select(Convert.ToInt32(Request.Form["tid"])));
                dalItem.Insert(item);

                NameValueCollection query = new NameValueCollection()
                {
                    {"addtid", item.tamanho.id.ToString()},
                    {"addpid", item.produto.id.ToString()},
                    {"addq", Request.Form["q"]}
                };

                MetodosExtensao.Redirecionar("usuario/cart", query);
            }
            else
            {
                Response.Write("Algo aconteceu. Tente novamente");
            }
        }
    }
}