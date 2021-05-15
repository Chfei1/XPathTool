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

        public object Description { get; set; }


        public double Priority => 0;

        public void Complete(TextArea textArea, ISegment completionSegment,
            EventArgs insertionRequestEventArgs)
        {
            var prevchar = textArea.Document.GetText(completionSegment.Offset - 1, 1);
            if (prevchar == ".")
            {
                textArea.Document.Replace(completionSegment.Offset - 1, completionSegment.Length + 1, "/" + this.Text);
            }
            else
            {
                textArea.Document.Replace(completionSegment, this.Text);
            }

        }
    }


}
