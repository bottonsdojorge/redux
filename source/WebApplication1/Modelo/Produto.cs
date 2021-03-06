﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace redux.Modelo
{
    public class Produto
    {
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

        private bool _ativo;
        public bool ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
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

        public Produto(int id, string descricao, string imagem, List<Marcador> marcadores, bool ativo = true)
        {
            this.id = id;
            this.descricao = descricao;
            this.imagem = imagem;
            this.marcadores = marcadores;
            this.ativo = ativo;
        }

        public Produto(int id, string descricao, Image imagem, List<Marcador> marcadores, bool personalizado = false, bool ativo = true)
        {
            this.id = id;
            this.descricao = descricao;
            this.marcadores = marcadores;
            this.ativo = ativo;
            InsertImage(imagem, personalizado);
        }

        private void InsertImage(Image image, bool personalizado = false)
        {
            Bitmap imgBitmap = new Bitmap(image);
            string unixTimestamp = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString();
            string nome = "btupcliente" + unixTimestamp + ".jpg";
            string path, pasta;
            path = HttpContext.Current.Request.PhysicalApplicationPath + "produtos\\";
            if (!personalizado)
                pasta = "loja\\";
            else
                pasta = "personalizados\\";
            try
            {
                imgBitmap.Save(path + pasta + nome);
                this.imagem = pasta + nome;
            }
            catch (SystemException)
            {
                throw;
            }
        }
    }
}