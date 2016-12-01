using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modelo
{
    public class itemEncomenda
    {
        private int _encomendaId;
        public int encomendaId
        {
            get { return _encomendaId; }
            set { _encomendaId = value; }
        }
        
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

        private double _subTotal;
        private string p;
        public double subTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; }
        }
        

        public itemEncomenda()
        {
            this.encomendaId = 0;
            this.item = new Item();
            this.precoIndividual = 0;
            this.quantidade = 0;
        }

        public itemEncomenda(int encomendaId, Item item, double precoIndividual, int quantidade)
        {
            this.encomendaId = encomendaId;
            this.item = item;
            this.precoIndividual = item.tamanho.precoUnitario;
            this.quantidade = quantidade;
            calcularSubTotal();
        }

        private void calcularSubTotal()
        {
            this.subTotal = quantidade * precoIndividual;
        }
    }
}