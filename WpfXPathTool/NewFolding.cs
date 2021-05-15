using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Folding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace WpfXPathTool
{
    public class MyFoldingStrategy
    {
        public void UpdateFoldings(FoldingManager manager, TextDocument document)
        {
            var foldings = CreateNewFoldings(document, out var firstErrorOffset);
            manager.UpdateFoldings(foldings, firstErrorOffset);
        }

        private IEnumerable<NewFolding> CreateNewFoldings(TextDocument document, out int firstErrorOffset)
        {
            firstErrorOffset = -1;
            return CreateNewFoldings(document);
        }

        private IEnumerable<NewFolding> CreateNewFoldings(TextDocument document)
        {
            var newFoldings = new List<NewFolding>();
            Stack<int> starts = new Stack<int>();
            Stack<string> names = new Stack<string>();

            foreach (var line in document.Lines)
            {
                var text = document.GetText(line.Offset, line.Length).Trim();
                Match m = Regex.Match(text, "#region(\\s.+)$", RegexOptions.Multiline);
                if (m.Success)
                {
                    starts.Push(line.Offset + m.Index);
                    names.Push(m.Groups[1].Value);
                }
                m = Regex.Match(text, "^\\s*#endregion", RegexOptions.Multiline);
                if (m.Success && starts.Count > 0)
                {
                    int start = starts.Pop();
                    NewFolding fold = new NewFolding(start, line.Offset + m.Length);
                    fold.Name = names.Pop();
                    fold.DefaultClosed = true;
                    newFoldings.Add(fold);
                }

            }

           
            return newFoldings;
        }



      
    }
}
