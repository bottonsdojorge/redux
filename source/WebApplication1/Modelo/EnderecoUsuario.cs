using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace redux.Modelo
{
    public class EnderecoUsuario
    {
        private localEntrega _localEntrega;
        public localEntrega localEntrega
        {
            get { return _localEntrega; }
            set { _localEntrega = value; }
        }

        private int _usuarioId;
        public int usuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        public EnderecoUsuario()
        {
            this.localEntrega = new localEntrega();
            this.usuarioId = 0;
        }

        public EnderecoUsuario(localEntrega localEntrega, int usuarioId)
        {
            this.localEntrega = localEntrega;
            this.usuarioId = usuarioId;
        }
    }
}