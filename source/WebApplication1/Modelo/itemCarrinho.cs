using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modelo
{
    public class itemCarrinho
    {
        private int _carrinhoId;
        public int carrinhoId
        {
            get { return _carrinhoId; }
            set { _carrinhoId = value; }
        }
        
        private Item _item;
        public Item item
        {
            get { return _item; }
            set { _item = value; }
        }

        private int _quantidade;
        public int quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        private double _subTotal;
        public double subTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; }
        }
        

        public itemCarrinho()
        {
            this.carrinhoId = 0;
            this.item = new Item();
            this.quantidade = 0;
        }

        public itemCarrinho(int carrinhoId, Item item, int quantidade)
        {
            this.carrinhoId = carrinhoId;
            this.item = item;
            this.quantidade = quantidade;
            this.calcularSubTotal();
        }

        public void calcularSubTotal()
        {
            this.subTotal = quantidade * item.tamanho.precoUnitario;
        }
    }
}