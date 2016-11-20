using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public static class MetodosExtensao
    {
        public static int GetValor(string chave, bool absoluto = false)
        {
            int valor;

            try
            {
                valor = (absoluto) ? Math.Abs(Convert.ToInt32(chave)) : Convert.ToInt32(chave);
            }
            catch (FormatException)
            {
                valor = 0;
            }

            return valor;
        }

        public static void Redirecionar(string pagina = null, NameValueCollection query = null)
        {
            HttpContext.Current.Response.Redirect(GetLink(pagina, query));
        }

        public static string GetLink(string pagina = null, NameValueCollection query = null)
        {
            pagina = (pagina == null) ? "index" : pagina;
            string baseUrl = String.Format("http://{0}/{1}.aspx", HttpContext.Current.Request.Url.Authority, pagina);
            string url = baseUrl;

            if (query != null)
            {
                url += "?";
                foreach (string chave in query)
                {
                    url += String.Format("{0}={1}&", chave, query[chave]);
                }
                url = url.Remove(url.Length - 1);
            }
            return url;
        }
    }
}