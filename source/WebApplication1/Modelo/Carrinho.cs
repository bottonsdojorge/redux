using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace redux.Modelo
{
	public class Carrinho
	{
		private int _Usuario_id;
		public int Usuario_id
		{
			get { return _Usuario_id; }
			set { _Usuario_id = value; }
		}

		private List<itemCarrinho> _itens;
		public List<itemCarrinho> itens
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

		public Carrinho ()
		{
			itens = new List<itemCarrinho>();
			precoTotal = 0;
			Usuario_id = 0;
			subTotal = 0;
			desconto = 0;
		}

		public Carrinho(List<itemCarrinho> itens, double precoTotal, double subTotal, double desconto, int Usuario_id)
		{
			this.itens = itens;
			this.precoTotal = precoTotal;
			this.subTotal = subTotal;
			this.desconto = desconto;
			this.Usuario_id = Usuario_id;
		}
	}
}