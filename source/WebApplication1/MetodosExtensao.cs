using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace redux
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

        public static void Redirecionar(string pagina = null, NameValueCollection query = null, Page page = null,NameValueCollection data = null )
        {
            if(page == null && data == null)
                HttpContext.Current.Response.Redirect(GetLink(pagina, query));
            else if (page != null && data != null)
            {
                RedirectAndPOST(page, GetLink(pagina, query), data);
            }
        }

        public static string GetLink(string pagina = null, NameValueCollection query = null)
        {
            string ancora = "";
            if (pagina != null && pagina.Contains('#'))
            {
                ancora = pagina.Substring(pagina.IndexOf('#'));
                pagina = pagina.Substring(0, pagina.IndexOf('#'));
            }
            pagina = (pagina == null) ? "index" : pagina;
            string baseUrl = String.Format("http://{0}/{1}.aspx{2}", HttpContext.Current.Request.Url.Authority, pagina, ancora);
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

        public static void RedirectAndPOST(Page page, string destinationUrl, NameValueCollection data)
        {
            //Prepare the Posting form
            string strForm = PreparePOSTForm(destinationUrl, data);
            //Add a literal control the specified page holding 
            //the Post Form, this is to submit the Posting form with the request.
            page.Controls.Add(new LiteralControl(strForm));
        }

        private static String PreparePOSTForm(string url, NameValueCollection data)
        {
            //Set a name for the form
            string formID = "PostForm";
            //Build the form using the specified data to be posted.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" + 
                           formID + "\" action=\"" + url + 
                           "\" method=\"POST\">");

            foreach (string key in data)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + key + 
                               "\" value=\"" + data[key] + "\">");
            }

            strForm.Append("</form>");
            //Build the JavaScript which will do the Posting operation.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language=\"javascript\">");
            strScript.Append("var v" + formID + " = document." + formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            //Return the form and the script concatenated.
            //(The order is important, Form then JavaScript)
            return strForm.ToString() + strScript.ToString();
        }
    }
}