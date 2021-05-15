using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPath
{
    public class XpathAxesData
    {

        static XpathAxesData()
        {
         
            Data.Add(new XPathCompletionData { Text = "@href", Description = "" });
            Data.Add(new XPathCompletionData { Text = "ancestor", Description = "选取当前节点的所有先辈（父、祖父等）。" });
            Data.Add(new XPathCompletionData { Text = "ancestor-or-self", Description = "选取当前节点的所有先辈（父、祖父等）以及当前节点本身。" });
            Data.Add(new XPathCompletionData { Text = "attribute", Description = "选取当前节点的所有属性。" });
            Data.Add(new XPathCompletionData { Text = "child", Description = "选取当前节点的所有子元素。" });
            Data.Add(new XPathCompletionData { Text = "descendant", Description = "选取当前节点的所有后代元素（子、孙等）。" });
            Data.Add(new XPathCompletionData { Text = "descendant-or-self", Description = "选取当前节点的所有后代元素（子、孙等）以及当前节点本身。" });
            Data.Add(new XPathCompletionData { Text = "following", Description = "选取文档中当前节点的结束标签之后的所有节点。" });
            Data.Add(new XPathCompletionData { Text = "following-sibling", Description = "选取当前节点之后的所有同级节点。" });
            Data.Add(new XPathCompletionData { Text = "namespace", Description = "选取当前节点的所有命名空间节点。" });
            Data.Add(new XPathCompletionData { Text = "parent", Description = "选取当前节点的父节点。" });
            Data.Add(new XPathCompletionData { Text = "preceding", Description = "选取文档中当前节点的开始标签之前的所有节点。" });
            Data.Add(new XPathCompletionData { Text = "preceding-sibling", Description = "选取当前节点之前的所有同级节点。" });
            Data.Add(new XPathCompletionData { Text = "self", Description = "选取当前节点。" });
        }
        public static List<XPathCompletionData> Data = new List<XPathCompletionData>();
    }
}
