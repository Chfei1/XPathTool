using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using HtmlAgilityPack;

namespace XPathTool
{
    public partial class XPathMain : Form
    {
       
        public XPathMain()
        {
            this.InitializeComponent();
        }
        private void XPathMain_Load(object sender, EventArgs e)
        {
        }
        private void XPathMain_Resize(object sender, EventArgs e)
        {

        }
        private void bt_Get_Click(object sender, EventArgs e)
        {
            this.getHtml();
        }

        private void getHtml()
        {
            try
            {
                string url = this.txt_url.Text;
                bool flag = string.IsNullOrWhiteSpace(url);
                if (flag)
                {
                    MessageBox.Show("Url 空");
                    this.txt_url.Focus();
                }
                else
                {
                    this.rich_html.Text = "";
                    this.bt_Get.Enabled = false;
                    WebClient client = new WebClient();
                    Task.Run(delegate ()
                    {
                        string html = "";
                        try
                        {
                            client.Encoding = Encoding.UTF8;
                            html = client.DownloadString(url);
                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show("获取源码错误");
                        }
                        this.BeginInvoke(new Action(delegate ()
                        {
                            this.rich_html.Text = html;
                            this.bt_Get.Enabled = true;
                        }));
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_xpath_Click(object sender, EventArgs e)
        {
            this.matchXPath();
        }

        private void matchXPath()
        {
            try
            {
                bool isInnerHtml = this.is_InnerHtml.Checked;
                this.rich_match.Text = "";
                string xpath = this.txt_xpath.Text;
                string attr = "";
                Match match = Regex.Match(xpath, "^(?<xpath>.+?)/@(?<attr>[^(/@)]+)$");
                if (match.Success)
                {
                    xpath = match.Groups["xpath"].Value;
                    attr = match.Groups["attr"].Value;
                }
                string html = this.rich_html.Text;
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
                    Task.Run(delegate ()
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
                                sb.AppendLine(string.Format("[{0}]", num2++));
                                sb.AppendLine();
                                string value;
                                if (string.IsNullOrWhiteSpace(attr))
                                {
                                    if (isInnerHtml)
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
                                sb.AppendLine("--------------------------------------");
                            }
                        }
                        this.BeginInvoke(new Action(delegate ()
                        {
                            this.rich_match.Text = sb.ToString();
                        }));
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_xpath_KeyPress(object sender, KeyPressEventArgs e)
        {

            //bool flag = e.KeyChar == Keys.Enter;
            //if (flag)
            //{
            //    this.matchXPath();
            //}
        }

        private void txt_xpath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.matchXPath();
            }
           
        }
        public Label lb_describe = new Label() { Visible = false };
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listbox = sender as ListBox;


            lb_describe.AutoSize = true;
            lb_describe.Location = new Point(listbox.Location.X + listbox.Width, listbox.Location.Y);
            lb_describe.Text = listbox.SelectedItem.ToString();
            lb_describe.Visible = true;
            lb_describe.BringToFront();
        }
    }
}
