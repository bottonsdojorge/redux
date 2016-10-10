﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace WebApplication1.Modelo
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

        private Image _imagem;
        public Image imagem
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
            this.imagem = default(Image);
            this.marcadores = new List<Marcador>;
        }

        public Produto(int id, string descricao, Image imagem, List<Marcador> marcadores)
        {
            this.id = id;
            this.descricao = descricao;
            this.imagem = imagem;
            this.marcadores = marcadores;
        }
    }
}