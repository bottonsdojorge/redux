using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace redux.Modelo
{
    public class Item
    {
        private Produto _produto;
        public Produto produto
        {
            get { return _produto; }
            set { _produto = value; }
        }

        private Tamanho _tamanho;
        public Tamanho tamanho
        {
            get { return _tamanho; }
            set { _tamanho = value; }
        }

        public Item()
        {
            this.produto = new Produto();
            this.tamanho = new Tamanho();
        }

        public Item(Produto produto, Tamanho tamanho)
        {
            this.produto = produto;
            this.tamanho = tamanho;
        }
        
    }
}