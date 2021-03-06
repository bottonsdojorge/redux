﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace redux.Modelo
{
    public class Encomenda
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        
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

        private double _subTotal;
        public double subTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; }
        }

        private double _desconto;
        public double desconto
        {
            get { return _desconto; }
            set { _desconto = value; }
        }

        private double _precoTotal;
        public double precoTotal 
        {
            get { return _precoTotal; }
            set { _precoTotal = value; }
        }

        private DateTime? _dataEntrega;
        public DateTime? dataEntrega 
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
            this.id = 0;
            this.Usuario = new Usuario();
            this.itens = new List<itemEncomenda>();
            this.precoTotal = 0;
            this.dataEntrega = default(DateTime?);
            this.localEntrega = new localEntrega();
            this.Status = new Status();
        }

        public Encomenda(int id, Usuario usuario, List<itemEncomenda> itens, DateTime? dataentrega, localEntrega localEntrega, Status status, double subTotal, double desconto, double precoTotal)
        {
            this.id = id;
            this.Usuario = usuario;
            this.itens = itens;
            this.dataEntrega = (dataentrega == default(DateTime)) ? null : dataentrega;
            this.localEntrega = localEntrega;
            this.Status = status;
            this.precoTotal = precoTotal;
            this.subTotal = subTotal;
            this.desconto = desconto;
        }

        public Encomenda(int id, Usuario usuario, List<itemEncomenda> itens, localEntrega localEntrega, Status status, double subTotal, double desconto, double precoTotal)
        {
            this.id = id;
            this.Usuario = usuario;
            this.itens = itens;
            this.dataEntrega = null;
            this.localEntrega = localEntrega;
            this.Status = status;
            this.precoTotal = precoTotal;
            this.subTotal = subTotal;
            this.desconto = desconto;
        }

        public Encomenda(int id, Usuario usuario, List<itemEncomenda> itens, int localEntrega, Status status, double subTotal, double desconto, double precoTotal)
        {
            this.id = id;
            this.Usuario = usuario;
            this.itens = itens;
            this.dataEntrega = null;
            this.localEntrega = DAL.DALLocalEntrega.Select(localEntrega);
            this.Status = status;
            this.precoTotal = precoTotal;
            this.subTotal = subTotal;
            this.desconto = desconto;
        }

    }
}