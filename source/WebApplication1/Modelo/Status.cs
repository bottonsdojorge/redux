﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace redux.Modelo
{
	public class Status
	{
		private int _id;
		public int id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _descricao;
		public string descricao
		{
			get { return _descricao; }
			set { _descricao = value; }
		}

		public Status()
		{
			this.id = 0;
			this.descricao = "";
		}

		public Status (int id, string descricao)
		{
			this.id = id;
			this.descricao = descricao;
		}
	}
}