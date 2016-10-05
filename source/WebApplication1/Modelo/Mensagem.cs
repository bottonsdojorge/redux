using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modelo
{
    public class Mensagem
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
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
            this.destinatario = new Usuario();
            this.remetente = new Usuario();
        }
        public Mensagem(int id, DateTime data, string corpo, Usuario destinatario, Usuario remetente)
        {
            this.id = id;
            this.data = data;
            this.corpo = corpo;
            this.remetente = remetente;
            this.destinatario = destinatario;
        }

    }
}