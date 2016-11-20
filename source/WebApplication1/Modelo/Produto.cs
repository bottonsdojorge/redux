using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace WebApplication1.Modelo
{
    public class Produto
    {

        /*
         * Modificado: Image imagem para string imagem. Corrigir como é o tratamento no crud..
         * TODO: Tratamento na classe Produto para receber caminho ou classe imagem..
         */
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _descricao;
        public string descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private string _imagem;
        public string imagem
        {
            get { return _imagem; }
            set { _imagem = value; }
        }

        private List<Marcador> _marcadores;
        public List<Marcador> marcadores
        {
            get { return _marcadores; }
            set { _marcadores = value; }
        }

        public Produto()
        {
            this.id = 0;
            this.descricao = "";
            this.imagem = "";
            this.marcadores = new List<Marcador>();
        }

        public Produto(int id, string descricao, string imagem, List<Marcador> marcadores)
        {
            this.id = id;
            this.descricao = descricao;
            this.imagem = imagem;
            this.marcadores = marcadores;
        }

        public Produto(int id, string descricao, Image imagem, List<Marcador> marcadores)
        {
            this.id = id;
            this.descricao = descricao;
            this.marcadores = marcadores;
            InsertImage(imagem);

        }

        private void InsertImage(Image image)
        {
            Bitmap imgBitmap = new Bitmap(image);
            string unixTimestamp = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString();
            string nome = "btupcliente" + unixTimestamp + ".jpg";
            string path = HttpContext.Current.Request.PhysicalApplicationPath + "Upload\\imagem-produto\\" + nome;
            try
            {
                imgBitmap.Save(path);
                this.imagem = nome;
            }
            catch (SystemException)
            {
                throw;
            }
        }
    }
}