using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace redux.Modelo
{
    public class Tamanho
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

        private double _precoUnitario;
        public double precoUnitario
        {
            get { return _precoUnitario; }
            set { _precoUnitario = value; }
        }

        public Tamanho()
        {
            this.id = 0;
            this.descricao = "";
            this.precoUnitario = 0;
        }

        public Tamanho(int id, string descricao, double precoUnitario)
        {
            this.id = id;
            this.descricao = descricao;
            this.precoUnitario = precoUnitario;
        }
        
        
        
    }
}