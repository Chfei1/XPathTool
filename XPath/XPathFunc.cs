using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPath
{
    class XPathFunc
    {
        static XPathFunc()
        {

         
            Data.Add(new XPathCompletionData { Text = "@id", Description = "" });
            Data.Add(new XPathCompletionData { Text = "@class", Description = "" });

            Data.Add(new XPathCompletionData { Text = "node-name(node)", Description = "返回参数节点的节点名称。" });
            Data.Add(new XPathCompletionData { Text = "nilled(node)", Description = "返回是否拒绝参数节点的布尔值。" });
            Data.Add(new XPathCompletionData { Text = "data(item.item,...)", Description = "接受项目序列，并返回原子值序列。" });
            Data.Add(new XPathCompletionData { Text = "base-uri()", Description = "返回当前节点或指定节点的 base-uri 属性的值。" });
            Data.Add(new XPathCompletionData { Text = "document-uri(node)", Description = "返回指定节点的 document-uri 属性的值。" });

            Data.Add(new XPathCompletionData { Text = "number(arg)", Description = "返回参数的数值。参数可以是布尔值、字符串或节点集。" });
            Data.Add(new XPathCompletionData { Text = "abs(num)", Description = "返回参数的绝对值。" });
            Data.Add(new XPathCompletionData { Text = "ceiling(num)", Description = "返回大于 num 参数的最小整数。" });
            Data.Add(new XPathCompletionData { Text = "floor(num)", Description = "返回不大于 num 参数的最大整数。" });
            Data.Add(new XPathCompletionData { Text = "round(num)", Description = "把 num 参数舍入为最接近的整数。" });
            Data.Add(new XPathCompletionData { Text = "round-half-to-even()", Description = "例子：round-half-to-even(0.5)" });



            Data.Add(new XPathCompletionData { Text = "string(arg)", Description = "返回参数的字符串值。参数可以是数字、逻辑值或节点集。" });
            Data.Add(new XPathCompletionData { Text = "codepoints-to-string(int,int,...)", Description = "根据代码点序列返回字符串。" });
            Data.Add(new XPathCompletionData { Text = "string-to-codepoints(string)", Description = "根据字符串返回代码点序列。" });
            Data.Add(new XPathCompletionData { Text = "codepoint-equal(comp1,comp2)", Description = "根据 Unicode 代码点对照，如果 comp1 的值等于 comp2 的值，则返回 true。(http://www.w3.org/2005/02/xpath-functions/collation/codepoint)，否则返回 false。" });
            Data.Add(new XPathCompletionData { Text = "compare(comp1,comp2,collation)", Description = "如果 comp1 小于 comp2，则返回 -1。如果 comp1 等于 comp2，则返回 0。如果 comp1 大于 comp2，则返回 1。（根据所用的对照规则）。" });
            Data.Add(new XPathCompletionData { Text = "concat(string,string,...)", Description = "返回字符串的拼接。" });
            Data.Add(new XPathCompletionData { Text = "string-join((string,string,...),sep)", Description = "使用 sep 参数作为分隔符，来返回 string 参数拼接后的字符串。" });
            Data.Add(new XPathCompletionData { Text = "substring(string,start,len)", Description = "返回从 start 位置开始的指定长度的子字符串。第一个字符的下标是 1。如果省略 len 参数，则返回从位置 start 到字符串末尾的子字符串。" });
            Data.Add(new XPathCompletionData { Text = "string-length()", Description = "返回指定字符串的长度。如果没有 string 参数，则返回当前节点的字符串值的长度。" });
            Data.Add(new XPathCompletionData { Text = "normalize-space()", Description = "删除指定字符串的开头和结尾的空白，并把内部的所有空白序列替换为一个，然后返回结果。如果没有 string 参数，则处理当前节点。" });
            Data.Add(new XPathCompletionData { Text = "normalize-unicode()", Description = "执行 Unicode 规格化。" });
            Data.Add(new XPathCompletionData { Text = "upper-case(string)", Description = "把 string 参数转换为大写。" });
            Data.Add(new XPathCompletionData { Text = "lower-case(string)", Description = "把 string 参数转换为小写。" });
            Data.Add(new XPathCompletionData { Text = "translate(string1,string2,string3)", Description = "把 string1 中的 string2 替换为 string3。" });
            Data.Add(new XPathCompletionData { Text = "escape-uri(stringURI,esc-res)", Description = "Url编码	例子：escape-uri(http://example.com/test#car, true()) 结果：http%3A%2F%2Fexample.com%2Ftest#car" });
            Data.Add(new XPathCompletionData { Text = "contains(string1,string2)", Description = "如果 string1 包含 string2，则返回 true，否则返回 false。" });
            Data.Add(new XPathCompletionData { Text = "starts-with(string1,string2)", Description = "如果 string1 以 string2 开始，则返回 true，否则返回 false。" });
            Data.Add(new XPathCompletionData { Text = "ends-with(string1,string2)", Description = "如果 string1 以 string2 结尾，则返回 true，否则返回 false。" });
            Data.Add(new XPathCompletionData { Text = "substring-before(string1,string2)", Description = "返回 string2 在 string1 中出现之前的子字符串。" });
            Data.Add(new XPathCompletionData { Text = "substring-after(string1,string2)", Description = "返回 string2 在 string1 中出现之后的子字符串。" });
            Data.Add(new XPathCompletionData { Text = "matches(string,pattern)", Description = "如果 string 参数匹配指定的模式，则返回 true，否则返回 false。" });
            Data.Add(new XPathCompletionData { Text = "replace(string,pattern,replace)", Description = "把指定的模式替换为 replace 参数，并返回结果。" });
            Data.Add(new XPathCompletionData { Text = "tokenize(string,pattern)", Description = "例子：tokenize(\"XPath is fu \"\\s + \")" });


            Data.Add(new XPathCompletionData { Text = "boolean(arg)", Description = "返回数字、字符串或节点集的布尔值。" });
            Data.Add(new XPathCompletionData { Text = "not(arg)", Description = "首先通过 boolean() 函数把参数还原为一个布尔值。如果该布尔值为 false，则返回 true，否则返回 true" });
            Data.Add(new XPathCompletionData { Text = "true()", Description = "返回布尔值 true。" });
            Data.Add(new XPathCompletionData { Text = "false()", Description = "返回布尔值 false。" });





            Data.Add(new XPathCompletionData { Text = "dateTime(date,time)", Description = "把参数转换为日期和时间。" });
            Data.Add(new XPathCompletionData { Text = "years-from-duration(datetimedur)", Description = "返回参数值的年份部分的整数，以标准词汇表示法来表示。" });
            Data.Add(new XPathCompletionData { Text = "months-from-duration(datetimedur)", Description = "返回参数值的月份部分的整数，以标准词汇表示法来表示。" });
            Data.Add(new XPathCompletionData { Text = "days-from-duration(datetimedur)", Description = "返回参数值的天部分的整数，以标准词汇表示法来表示。" });
            Data.Add(new XPathCompletionData { Text = "hours-from-duration(datetimedur)", Description = "返回参数值的小时部分的整数，以标准词汇表示法来表示。" });
            Data.Add(new XPathCompletionData { Text = "minutes-from-duration(datetimedur)", Description = "返回参数值的分钟部分的整数，以标准词汇表示法来表示。" });
            Data.Add(new XPathCompletionData { Text = "seconds-from-duration(datetimedur)", Description = "返回参数值的分钟部分的十进制数，以标准词汇表示法来表示。" });
            Data.Add(new XPathCompletionData { Text = "year-from-dateTime(datetime)", Description = "返回参数本地值的年部分的整数。" });
            Data.Add(new XPathCompletionData { Text = "month-from-dateTime(datetime)", Description = "返回参数本地值的月部分的整数。" });
            Data.Add(new XPathCompletionData { Text = "day-from-dateTime(datetime)", Description = "返回参数本地值的天部分的整数。" });
            Data.Add(new XPathCompletionData { Text = "hours-from-dateTime(datetime)", Description = "返回参数本地值的小时部分的整数。" });
            Data.Add(new XPathCompletionData { Text = "minutes-from-dateTime(datetime)", Description = "返回参数本地值的分钟部分的整数。" });
            Data.Add(new XPathCompletionData { Text = "seconds-from-dateTime(datetime)", Description = "返回参数本地值的秒部分的十进制数。" });
            Data.Add(new XPathCompletionData { Text = "timezone-from-dateTime(datetime)", Description = "返回参数的时区部分，如果存在。" });
            Data.Add(new XPathCompletionData { Text = "year-from-date(date)", Description = "返回参数本地值中表示年的整数。" });
            Data.Add(new XPathCompletionData { Text = "month-from-date(date)", Description = "返回参数本地值中表示月的整数。" });
            Data.Add(new XPathCompletionData { Text = "day-from-date(date)", Description = "返回参数本地值中表示天的整数。" });
            Data.Add(new XPathCompletionData { Text = "timezone-from-date(date)", Description = "返回参数的时区部分，如果存在。" });
            Data.Add(new XPathCompletionData { Text = "hours-from-time(time)", Description = "返回参数本地值中表示小时部分的整数。" });
            Data.Add(new XPathCompletionData { Text = "minutes-from-time(time)", Description = "返回参数本地值中表示分钟部分的整数。" });
            Data.Add(new XPathCompletionData { Text = "seconds-from-time(time)", Description = "返回参数本地值中表示秒部分的整数。" });
            Data.Add(new XPathCompletionData { Text = "timezone-from-time(time)", Description = "返回参数的时区部分，如果存在。" });
            Data.Add(new XPathCompletionData { Text = "adjust-dateTime-to-timezone(datetime,timezone)", Description = "如果 timezone 参数为空，则返回没有时区的 dateTime。否则返回带有时区的 dateTime。" });
            Data.Add(new XPathCompletionData { Text = "adjust-date-to-timezone(date,timezone)", Description = "如果 timezone 参数为空，则返回没有时区的 date。否则返回带有时区的 date。" });
            Data.Add(new XPathCompletionData { Text = "adjust-time-to-timezone(time,timezone)", Description = "如果 timezone 参数为空，则返回没有时区的 time。否则返回带有时区的 time。" });




            Data.Add(new XPathCompletionData { Text = "name()", Description = "返回当前节点的名称或指定节点集中的第一个节点。" });
            Data.Add(new XPathCompletionData { Text = "local-name()", Description = "返回当前节点的名称或指定节点集中的第一个节点 - 不带有命名空间前缀。" });
            Data.Add(new XPathCompletionData { Text = "namespace-uri()", Description = "返回当前节点或指定节点集中第一个节点的命名空间 URI。" });
            Data.Add(new XPathCompletionData { Text = "lang(lang)", Description = "如果当前节点的语言匹配指定的语言，则返回 true。" });
            Data.Add(new XPathCompletionData { Text = "root()", Description = "返回当前节点或指定的节点所属的节点树的根节点。通常是文档节点。" });




            Data.Add(new XPathCompletionData { Text = "index-of((item,item,...),searchitem)", Description = "返回在项目序列中等于 searchitem 参数的位置。" });
            Data.Add(new XPathCompletionData { Text = "remove((item,item,...),position)", Description = "返回由 item 参数构造的新序列 - 同时删除 position 参数指定的项目。" });
            Data.Add(new XPathCompletionData { Text = "empty(item,item,...)", Description = "如果参数值是空序列，则返回 true，否则返回 false。" });
            Data.Add(new XPathCompletionData { Text = "exists(item,item,...)", Description = "如果参数值不是空序列，则返回 true，否则返回 false。" });
            Data.Add(new XPathCompletionData { Text = "insert-before((item,item,...),pos,inserts)", Description = "返回由 item 参数构造的新序列 - 同时在 pos 参数指定位置插入 inserts 参数的值。" });
            Data.Add(new XPathCompletionData { Text = "reverse((item,item,...))", Description = "返回指定的项目的颠倒顺序。" });
            Data.Add(new XPathCompletionData { Text = "subsequence((item,item,...),start,len)", Description = "返回 start 参数指定的位置返回项目序列，序列的长度由 len 参数指定。第一个项目的位置是 1。" });
            Data.Add(new XPathCompletionData { Text = "unordered((item,item,...))", Description = "依据实现决定的顺序来返回项目。" });







            Data.Add(new XPathCompletionData { Text = "count((item,item,...))", Description = "返回节点的数量。" });
            Data.Add(new XPathCompletionData { Text = "avg((arg,arg,...))", Description = "返回参数值的平均数。 例子：avg((1,2,3)) 结果：2" });
            Data.Add(new XPathCompletionData { Text = "max((arg,arg,...))", Description = "返回大于其它参数的参数。 例子：max((1,2,3)) 结果：3 例子：max(('a', 'k')) 结果：'k'" });
            Data.Add(new XPathCompletionData { Text = "min((arg,arg,...))", Description = "返回小于其它参数的参数。 例子：min((1,2,3)) 结果：1 例子：min(('a', 'k')) 结果：'a'" });
            Data.Add(new XPathCompletionData { Text = "sum(arg,arg,...)", Description = "返回指定节点集中每个节点的数值的总和。" });


            Data.Add(new XPathCompletionData { Text = "position()", Description = "返回当前正在被处理的节点的 index 位置。" });
            Data.Add(new XPathCompletionData { Text = "last()", Description = "返回在被处理的节点列表中的项目数目。" });
            Data.Add(new XPathCompletionData { Text = "current-dateTime()", Description = "返回当前的 dateTime（带有时区）。" });
            Data.Add(new XPathCompletionData { Text = "current-date()", Description = "返回当前的日期（带有时区）。" });
            Data.Add(new XPathCompletionData { Text = "current-time()", Description = "返回当前的时间（带有时区）。" });
            Data.Add(new XPathCompletionData { Text = "implicit-timezone()", Description = "返回隐式时区的值。" });
            Data.Add(new XPathCompletionData { Text = "default-collation()", Description = "返回默认对照的值。" });
            Data.Add(new XPathCompletionData { Text = "static-base-uri()", Description = "返回 base-uri 的值。" });







        }
        public static List<XPathCompletionData> Data = new List<XPathCompletionData>();
    }
}
