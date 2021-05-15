using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfXPathTool
{
    class Base64Helper
    {
        public static string Encode(string content)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(content);
            var newcontent = Convert.ToBase64String(b);
            return newcontent;
        }
        public static string DeCode(string content)
        {
            byte[] c = Convert.FromBase64String(content);
            string newcontent = System.Text.Encoding.Default.GetString(c);
            return newcontent;
        }
    }
}
