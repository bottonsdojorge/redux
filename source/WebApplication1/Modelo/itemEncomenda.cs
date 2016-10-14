using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modelo
{
    public class itemEncomenda
    {
        private Item _item;
        public Item item
        {
            get { return _item; }
            set { _item = value; }
        }

        private double _precoIndividual;
        public double precoIndividual
        {
            get { return _precoIndividual; }
            set { _precoIndividual = value; }
        }

        private int _quantidade;
        public int quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        public itemEncomenda()
        {
            this.item = new Item();
            this.precoIndividual = 0;
            this.quantidade = 0;
        }

        public itemEncomenda(Item item, double precoIndividual, int quantidade)
        {
            this.item = item;
            this.precoIndividual = item.tamanho.precoUnitario;
            this.quantidade = quantidade;
        }  
        
    }
}