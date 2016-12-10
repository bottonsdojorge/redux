using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace redux.Modelo
{
    public class localEntrega
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _rua;
        public string rua
        {
            get { return _rua; }
            set { _rua = value; }
        }
        private int _numero;
        public int numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        private string _bairro;
        public string bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }
        private string _complemento;
        public string complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }
        private string _descricao;
        public string descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        private string _cep;
        public string cep
        {
            get { return _cep; }
            set { _cep = value; }
        }
        public string enderecoFormatado { get; set; }
        public localEntrega()
        {
            this.id = 0;
            this.numero = 0;
            this.rua = "";
            this.descricao = "";
            this.bairro = "";
            this.cep = "";
            this.complemento = "";
            this.enderecoFormatado = "";
        }

        public localEntrega(int id, int numero, string rua, string descricao, string bairro, string cep, string complemento)
        {
            this.id = id;
            this.numero = numero;
            this.rua = rua;
            this.descricao = descricao;
            this.bairro = bairro;
            this.cep = cep;
            this.complemento = complemento;
            enderecoFormatado = String.Format("{0} - {1}, {2}{3} - {4}, {5}", descricao, rua, numero, (complemento != "") ? ", " + complemento : null, bairro, cep);
        }  
    }
}