using HtmlAgilityPack;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using WpfXPathTool.Properties;

namespace WpfXPathTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class XPathMain : Window
    {
        ///// <summary>
        ///// xpath 表达式
        ///// </summary>
        //public string XPath { get; set; }

        //public string SourceHtml { get; set; }

        //public string OutContent { get; set; }

        //public bool IsOuterHtml { get; set; }

        //public FormDataDto dto;
        private CompletionWindow completionWindow;
        private readonly FoldingManager foldingManager;

        private readonly MyFoldingStrategy foldingStrategy = new MyFoldingStrategy();
        public XPathMain()
        {

            InitializeComponent();
            //dto = new FormDataDto();
            //this.DataContext = dto;

            txt_outContent.SyntaxHighlighting = LoadHighlightingDefinition("init.xshd");
            foldingManager = FoldingManager.Install(txt_outContent.TextArea);

            var foldingTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            foldingTimer.Tick += (s, e)
                => foldingStrategy.UpdateFoldings(foldingManager, txt_outContent.Document);
            foldingTimer.Start();



            txt_xpath.TextArea.TextEntering += textEditor_TextArea_TextEntering;
            txt_xpath.TextArea.TextEntered += textEditor_TextArea_TextEntered;

            //txt_SourceHtml.TextArea.TextEntering += textEditor_TextArea_TextEntering;
            //txt_SourceHtml.TextArea.TextEntered += textEditor_TextArea_TextEntered;

        }

        private static IHighlightingDefinition LoadHighlightingDefinition(string resourceName)
        {
            var type = typeof(XPathMain);
            var fullName = type.Namespace + "." + resourceName;
            using (var stream = type.Assembly.GetManifestResourceStream(fullName))

            using (var reader = new XmlTextReader(stream))
                return HighlightingLoader.Load(reader, HighlightingManager.Instance);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {






        }

        private void textEditor_TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {

            if (e.Text.Length > 0 && completionWindow != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                    completionWindow.CompletionList.RequestInsertion(e);
                }
            }
        }

        private void textEditor_TextArea_TextEntered(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != "." && e.Text != "[") return;

            // Open code completion after the user has pressed dot:
            completionWindow = new CompletionWindow(txt_xpath.TextArea);
            IList<ICompletionData> data = completionWindow.CompletionList.CompletionData;

            if (e.Text == ".")
            {
                XpathAxesData.Data.ForEach(a =>
                {
                    data.Add(a);
                });

            }
            else if (e.Text == "[")
            {
                XPathFunc.Data.ForEach(a =>
                {
                    data.Add(a);
                });
            }

            completionWindow.Show();
          
            completionWindow.Closed += delegate
            {
                completionWindow = null;
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            matchXPath();

        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            bool flag = e.Key == Key.Enter;
            if (flag)
            {
                if (completionWindow == null)
                {
                    this.matchXPath();
                    e.Handled = true;
                }
            }

        }


        private void matchXPath()
        {
            try
            {
                txt_outContent.Text = "";
                string xpath = txt_xpath.Text;
                string attr = "";
                Match match = Regex.Match(xpath, "^(?<xpath>.+?)/@(?<attr>[^(/@)]+)$");
                if (match.Success)
                {
                    xpath = match.Groups["xpath"].Value;
                    attr = match.Groups["attr"].Value;
                }
                string html = txt_SourceHtml.Text;//  dto.SourceHtml;
                if (string.IsNullOrWhiteSpace(html))
                {
                    MessageBox.Show("需要匹配内容不存在");
                    this.txt_xpath.Focus();
                }
                else if (string.IsNullOrWhiteSpace(xpath))
                {
                    MessageBox.Show("xpath语句不存在");
                    this.txt_xpath.Focus();
                }
                else
                {

                    HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    htmlDocument.LoadHtml(html);
                    HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes(xpath);
                    int num = (htmlNodeCollection != null) ? htmlNodeCollection.Count : 0;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(string.Format("共匹配到{0}条", num));
                    sb.AppendLine();
                    int num2 = 1;
                    if (num > 0)
                    {
                        foreach (HtmlNode htmlNode in ((IEnumerable<HtmlNode>)htmlNodeCollection))
                        {
                            sb.AppendLine(string.Format("#region [{0}]", num2++));
                            sb.AppendLine();
                            string value;
                            if (string.IsNullOrWhiteSpace(attr))
                            {
                                if (ck_outhtml.IsChecked.Value)
                                {
                                    value = htmlNode.OuterHtml;
                                }
                                else
                                {
                                    value = htmlNode.InnerText;
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
                            sb.AppendLine(value);
                            sb.AppendLine();
                            sb.AppendLine("#endregion");
                        }
                    }
                    txt_outContent.Text = sb.ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
