using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfXPathTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Config.SourceHtml = Base64Helper.DeCode(args[0]);
            }
            WpfXPathTool.App app = new WpfXPathTool.App();
            app.InitializeComponent();
            app.Run();
        }
    }

    class Config
    {
        public static string SourceHtml { get; set; }
    }
}
