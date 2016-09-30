using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modelo
{
    public class Mensagem
    {
        private int _id;
        public int MyProperty
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

        private Modelo.Usuario _destinatario;
        public Modelo.Usuario destinatario
        {
            get { return _destinatario; }
            set { _destinatario = value; }
        }

        private Modelo.Usuario _remetente;
        public Modelo.Usuario remetente
        {
            get { return _remetente; }
            set { _remetente = value; }
        }
        
        
    }
}