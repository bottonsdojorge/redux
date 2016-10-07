using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modelo
{
    public class Telefone
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _numero;
        public string numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private int _usuarioId;
        public int usuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }
        

        public Telefone()
        {
            this.id = 0;
            this.numero = null;
        }

        public Telefone(int id, string numero, int usuarioId)
        {
            this.id = id;
            this.numero = numero;
            this.usuarioId = usuarioId;
        }
    }
}