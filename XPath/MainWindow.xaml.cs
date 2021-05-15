using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace XPath
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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
        public MainWindow()
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







            SetMenu();


        }

        private void SetMenu()
        {
            ContextMenu aMenu = new ContextMenu();
            MenuItem copyMenuItem = new MenuItem();
            copyMenuItem.Header = "新的解析";
            copyMenuItem.Click += CopyMenuItem_Click;
            aMenu.Items.Add(copyMenuItem);


            txt_outContent.ContextMenu = aMenu;
        }

        /// <summary>
        /// 新建一个解析器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            txt_outContent.Copy();
            string clipboardText = Clipboard.GetText(TextDataFormat.Text);
            Clipboard.SetText("");
            //声明一个程序信息类
            System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
            Info.WorkingDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            Info.FileName = $"{AppDomain.CurrentDomain.FriendlyName}.exe";
            Info.UseShellExecute = false;
            Info.RedirectStandardInput = false;
            Info.RedirectStandardOutput = false;
            Info.RedirectStandardError = false;
            Info.CreateNoWindow = true;
            //设置外部程序的启动参数（命令行参数)
            Info.Arguments = Base64Helper.Encode(clipboardText);


            //声眀①个程序类
            System.Diagnostics.Process Proc;
            try
            {
                //
                //启动外部程序
                //
                Proc = System.Diagnostics.Process.Start(Info);

            }

            catch (System.ComponentModel.Win32Exception e1)
            {
                Console.WriteLine("系统找不到指定的程序文件。\r{0}", e);
                return;
            }

        }

        private static IHighlightingDefinition LoadHighlightingDefinition(string resourceName)
        {
            var type = typeof(MainWindow);
            var fullName = type.Namespace + "." + resourceName;
            using (var stream = type.Assembly.GetManifestResourceStream(fullName))

            using (var reader = new XmlTextReader(stream))
                return HighlightingLoader.Load(reader, HighlightingManager.Instance);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(Config.SourceHtml))
            {
                txt_SourceHtml.Text = Config.SourceHtml;
                txt_xpath.Focus();
            }
            else
            {
                txt_SourceHtml.Focus();
            }


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
                string html = txt_SourceHtml.Text;//  dto.SourceHtml;
                ResultContentType contentType = ResultContentType.Text;
                contentType = ck_outhtml.IsChecked.Value ? ResultContentType.OuterHtml : contentType;
                XpathMatchResult result = XPathHelper.Match(xpath, html, contentType);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(string.Format("共匹配到{0}条", result.Count));
                    sb.AppendLine();
                    sb.AppendLine();
                    int index = 1;
                    foreach (var item in result.Result)
                    {
                        sb.AppendLine($"#region {index}");
                        sb.AppendLine(item);
                        sb.AppendLine("#endregion");
                        sb.AppendLine();
                        index++;
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
