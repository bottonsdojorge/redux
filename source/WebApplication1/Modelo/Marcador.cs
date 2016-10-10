using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modelo
{
    public class Marcador
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _descricacao;
        public string descricao
        {
            get { return _descricacao; }
            set { _descricacao = value; }
        }

        public Marcador()
        {
            this.id = 0;
            this.descricao = "";
        }

        public Marcador(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }
    }
}