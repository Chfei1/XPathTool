using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPath
{
    public class XpathMatchResult
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "";
        public List<string> Result { get; set; } = new List<string>();
        public int Count
        {
            get
            {
                return Result.Count;
            }
        }
    }
    /// <summary>
    /// 解析
    /// </summary>
    public class XPathMatchModel
    {
        public string OuterHtml { get; set; } = "";
        public string InnerHtml { get; set; } = "";
        public string Text { get; set; } = "";
    }
}
