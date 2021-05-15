using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfXPathTool
{
    enum ResultContentType
    {
        OuterHtml,
        InnerHtml,
        Text
    }
    class XPathHelper
    {
        public static XpathMatchResult Match(string xpath, string html, ResultContentType type = ResultContentType.OuterHtml)
        {
            XpathMatchResult result = new XpathMatchResult();

            string attr = "";
            Match match = Regex.Match(xpath, "^(?<xpath>.+?)/@(?<attr>[^(/@)]+)$");
            if (match.Success)
            {
                xpath = match.Groups["xpath"].Value;
                attr = match.Groups["attr"].Value;
            }
            if (string.IsNullOrWhiteSpace(html))
            {
                result.Message = "需要匹配内容不存在";
            }
            else if (string.IsNullOrWhiteSpace(xpath))
            {
                result.Message = "xpath语句不存在";
            }
            else
            {
                result.Success = true;
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);
                HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes(xpath);
                int num = (htmlNodeCollection != null) ? htmlNodeCollection.Count : 0;
                if (num > 0)
                {
                    foreach (HtmlNode htmlNode in ((IEnumerable<HtmlNode>)htmlNodeCollection))
                    {
                        string value = "";
                        if (string.IsNullOrWhiteSpace(attr))
                        {
                            switch (type)
                            {
                                case ResultContentType.OuterHtml:
                                    value = htmlNode.OuterHtml;
                                    break;
                                case ResultContentType.InnerHtml:
                                    value = htmlNode.InnerHtml;
                                    break;
                                case ResultContentType.Text:
                                    value = htmlNode.InnerText;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            HtmlAttribute htmlAttribute = htmlNode.Attributes[attr];
                            if (htmlAttribute != null)
                            {
                                value = htmlAttribute.Value;
                            }
                            else
                            {
                                value = "无" + attr + "属性";
                            }
                        }

                        result.Result.Add(value);

                    }
                }

            }

            return result;
        }
    }
}
