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

        private double _precoTotal;
        public double precoTotal
        {
            get { return _precoTotal; }
            set { _precoTotal = value; }
        }
    }
}