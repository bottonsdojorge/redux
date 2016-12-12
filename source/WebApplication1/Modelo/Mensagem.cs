using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace redux.Modelo
{
    public class Mensagem
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _idEncomenda;
        public int idEncomenda
        {
            get { return _idEncomenda; }
            set { _idEncomenda = value; }
        }
        
        private DateTime _data;
        public DateTime data
        {
            get { return _data; }
            set { _data = value; }
        }

        private string _corpo;
        public string corpo
        {
            get { return _corpo; }
            set { _corpo = value; }
        }

        private bool _visualizada;
        public bool visualizada
        {
            get { return _visualizada; }
            set { _visualizada = value; }
        }
        

        private Usuario _destinatario;
        public Usuario destinatario
        {
            get { return _destinatario; }
            set { _destinatario = value; }
        }

        private Usuario _remetente;
        public Usuario remetente
        {
            get { return _remetente; }
            set { _remetente = value; }
        }

        public Mensagem()
        {
            this.id = 0;
            this.data = default(DateTime);
            this.corpo = "";
            this.visualizada = false;
            this.destinatario = new Usuario();
            this.remetente = new Usuario();
            this.idEncomenda = 0;
        }
        public Mensagem(int id, DateTime data, string corpo, bool visualizada, Usuario destinatario, Usuario remetente, int idEncomenda)
        {
            this.id = id;
            this.data = data;
            this.corpo = corpo;
            this.visualizada = visualizada;
            this.remetente = remetente;
            this.destinatario = destinatario;
            this.idEncomenda = idEncomenda;
        }

    }
}