using System;
using System.Windows.Forms;

namespace XPathTool
{
	// Token: 0x02000009 RID: 9
	internal static class Program
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00002109 File Offset: 0x00000309
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new XPathMain());
		}
	}
}
