using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace redux.App_Code
{
    public static class Global
    {
        private static int _uid;
        public static int uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        
    }
}