using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using System;

namespace XPath
{
    public class XPathCompletionData : ICompletionData
    {
        public XPathCompletionData()
        {

        }
        public XPathCompletionData(string text)
        {
            this.Text = text;
        }

        public System.Windows.Media.ImageSource Image
        {
            get { return null; }
        }

        public string Text { get; set; }

        // Use this property if you want to show a fancy UIElement in the list.
        public object Content
        {
            get
            {
                return this.Text;
            }
        }
        /// <summary>
        /// 补全信息
        /// </summary>
        /// <returns></returns>
        public Func<string, ISegment, (ISegment completionSegment, string Text, int SelectionStart)> Complement { get; set; }

        public object Description { get; set; }


        public double Priority => 0;


        public void Complete(TextArea textArea, ISegment completionSegment,
            EventArgs insertionRequestEventArgs)
        {
            if (Complement != null)
            {
                var ret = Complement(this.Text, completionSegment);
                int OldSelectionStart = completionSegment.Offset;
                textArea.Document.Replace(ret.completionSegment, ret.Text);
                if (ret.SelectionStart > 0)
                {
                    textArea.Caret.Offset = OldSelectionStart + ret.SelectionStart;
                }
            }
            else
            {
                textArea.Document.Replace(completionSegment, this.Text);
            }



        }
    }


}
