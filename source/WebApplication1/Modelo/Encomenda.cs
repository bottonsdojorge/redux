using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modelo
{
    public class Encomenda
    {
        private Usuario _Usuario;
        public Usuario Usuario 
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        private List<itemEncomenda> _itens;
        public List<itemEncomenda> itens
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

        private DateTime _dataEntrega;
        public DateTime dataEntrega 
        {
            get { return _dataEntrega; }
            set { _dataEntrega = value; }
        }

        private localEntrega _localEntrega;
        public localEntrega localEntrega 
        {
            get { return _localEntrega; }
            set { _localEntrega = value; }
        }

        private Status _Status;
        public Status Status {
            get { return _Status; }
            set { _Status = value; }
        }

        public Encomenda()
        {
            this.Usuario = new Usuario();
            this.itens = new List<itemEncomenda>();
            this.precoTotal = 0;
            this.dataEntrega = default(DateTime);
            this.localEntrega = new localEntrega();
            this.Status = new Status();
        }

        public Encomenda(Usuario usuario, List<itemEncomenda> itens, DateTime dataentrega, localEntrega localEntrega, Status status)
        {
            this.Usuario = new Usuario();
            this.itens = itens;
            this.dataEntrega = default(DateTime);
            this.localEntrega = new localEntrega();
            this.Status = new Status();
            calcularPreco();
        }

        private void calcularPreco()
        {
            double preco = 0;
            foreach (var item in this.itens)
            {
                preco += item.precoIndividual * item.quantidade;
            }
        }
    }
}