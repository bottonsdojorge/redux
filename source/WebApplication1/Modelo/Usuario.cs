﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace redux.Modelo
{
    public class Usuario
    {
        private int _id;
        public int id 
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _aspnet_id;
        public string aspnet_id 
        {
            get { return _aspnet_id; }
            set { _aspnet_id = value; }
        }

        private string _nome;
        public string nome 
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private List<Telefone> _telefones;
        public List<Telefone> telefones
        {
            get { return _telefones; }
            set { _telefones = value; }
        }

        private List<EnderecoUsuario> _enderecos;
        public List<EnderecoUsuario> enderecos
        {
            get { return _enderecos; }
            set { _enderecos = value; }
        }

        private Carrinho _carrinho;
        public Carrinho carrinho
        {
            get { return _carrinho; }
            set { _carrinho = value; }
        }
        
        public Usuario()
        {
            this.id = 0;
            this.aspnet_id = "";
            this.nome = "";
            this.telefones = new List<Telefone>();
            this.enderecos = new List<EnderecoUsuario>();
            this.carrinho = new Carrinho();
        }

        public Usuario(int id, string aspnet_id, string nome, List<Telefone> telefones, List<EnderecoUsuario> enderecos, Carrinho carrinho)
        {
            this.id = id;
            this.aspnet_id = aspnet_id;
            this.nome = nome;
            this.telefones = telefones;
            this.enderecos = enderecos;
            this.carrinho = carrinho;
        }

    }
}