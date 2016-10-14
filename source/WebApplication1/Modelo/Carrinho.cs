using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modelo
{
    public class Carrinho
    {
        private int _Usuario_id;
        public int Usuario_id
        {
            get { return _Usuario_id; }
            set { _Usuario_id = value; }
        }

        private List<KeyValuePair<Item, int>> _itens;
        public List<KeyValuePair<Item, int>> itens
        {
            get { return _itens; }
            set { _itens = value; }
        }

        private double _precoTotal;
        public double precoTotal
        {
            get { return _precoTotal; }
            set { _precoTotal = value; }
        }

        public Carrinho ()
	    {
            this.itens = new List<KeyValuePair<Item,int>>();
            this.precoTotal = 0;
            this.Usuario_id = 0;
	    }

        public Carrinho(List<KeyValuePair<Item, int>> itens, int precoTotal, int Usuario_id)
        {
            this.itens = itens;
            this.precoTotal = precoTotal;
            this.Usuario_id = Usuario_id;
        }
    }
}