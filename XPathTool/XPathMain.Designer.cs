namespace XPathTool
{
	// Token: 0x02000002 RID: 2
	public partial class XPathMain : global::System.Windows.Forms.Form
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002378 File Offset: 0x00000578
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000023B0 File Offset: 0x000005B0
		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.is_InnerHtml = new System.Windows.Forms.CheckBox();
            this.txt_xpath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_xpath = new System.Windows.Forms.Button();
            this.bt_Get = new System.Windows.Forms.Button();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rich_html = new System.Windows.Forms.RichTextBox();
            this.rich_match = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.bt_Get);
            this.panel1.Controls.Add(this.txt_url);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 38);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.is_InnerHtml);
            this.panel2.Controls.Add(this.txt_xpath);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.bt_xpath);
            this.panel2.Location = new System.Drawing.Point(319, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(631, 26);
            this.panel2.TabIndex = 8;
            // 
            // is_InnerHtml
            // 
            this.is_InnerHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.is_InnerHtml.AutoSize = true;
            this.is_InnerHtml.Location = new System.Drawing.Point(469, 6);
            this.is_InnerHtml.Name = "is_InnerHtml";
            this.is_InnerHtml.Size = new System.Drawing.Size(78, 16);
            this.is_InnerHtml.TabIndex = 10;
            this.is_InnerHtml.Text = "OuterHtml";
            this.is_InnerHtml.UseVisualStyleBackColor = true;
            // 
            // txt_xpath
            // 
            this.txt_xpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_xpath.Location = new System.Drawing.Point(50, 4);
            this.txt_xpath.Name = "txt_xpath";
            this.txt_xpath.Size = new System.Drawing.Size(413, 21);
            this.txt_xpath.TabIndex = 9;
            this.txt_xpath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_xpath_KeyDown);
            this.txt_xpath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_xpath_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Xpath：";
            // 
            // bt_xpath
            // 
            this.bt_xpath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_xpath.Location = new System.Drawing.Point(549, 2);
            this.bt_xpath.Name = "bt_xpath";
            this.bt_xpath.Size = new System.Drawing.Size(75, 23);
            this.bt_xpath.TabIndex = 7;
            this.bt_xpath.Text = "获取";
            this.bt_xpath.UseVisualStyleBackColor = true;
            this.bt_xpath.Click += new System.EventHandler(this.bt_xpath_Click);
            // 
            // bt_Get
            // 
            this.bt_Get.Location = new System.Drawing.Point(237, 9);
            this.bt_Get.Name = "bt_Get";
            this.bt_Get.Size = new System.Drawing.Size(75, 23);
            this.bt_Get.TabIndex = 5;
            this.bt_Get.Text = "GET";
            this.bt_Get.UseVisualStyleBackColor = true;
            this.bt_Get.Click += new System.EventHandler(this.bt_Get_Click);
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(43, 11);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(188, 21);
            this.txt_url.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "网址";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(958, 528);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rich_html);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rich_match);
            this.splitContainer1.Size = new System.Drawing.Size(952, 508);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 2;
            // 
            // rich_html
            // 
            this.rich_html.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rich_html.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rich_html.Location = new System.Drawing.Point(0, 0);
            this.rich_html.Name = "rich_html";
            this.rich_html.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rich_html.Size = new System.Drawing.Size(350, 508);
            this.rich_html.TabIndex = 1;
            this.rich_html.Text = "";
            // 
            // rich_match
            // 
            this.rich_match.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rich_match.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rich_match.Location = new System.Drawing.Point(0, 0);
            this.rich_match.Name = "rich_match";
            this.rich_match.Size = new System.Drawing.Size(600, 508);
            this.rich_match.TabIndex = 2;
            this.rich_match.Text = "";
            // 
            // XPathMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 596);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "XPathMain";
            this.Text = "XPath 测试工具";
            this.Load += new System.EventHandler(this.XPathMain_Load);
            this.Resize += new System.EventHandler(this.XPathMain_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		// Token: 0x04000001 RID: 1
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000002 RID: 2
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.TextBox txt_url;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Button bt_Get;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox is_InnerHtml;
        private System.Windows.Forms.TextBox txt_xpath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_xpath;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rich_html;
        private System.Windows.Forms.RichTextBox rich_match;
    }
}
