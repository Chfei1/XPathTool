using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XPathTool
{
    public partial class TextBoxIntellisense : Panel
    {
        private TextBox txt = new TextBox();
        private Panel panel = new Panel();
        private ListBox list_items = new ListBox();
        private FlowLayoutPanel fl_panel = new FlowLayoutPanel();
        private Label lb_describe = new Label();
        private List<IntellisenseModel> _sourceData = new List<IntellisenseModel>();
        private IntellisenseModel SelectedItem { get; set; }
        public new event KeyEventHandler KeyDown;
        public bool IsShowIntellisense
        {
            get
            {
                return panel.Visible;
            }
            set
            {
                panel.Visible = value;
            }
        }
        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public List<IntellisenseModel> SourceData
        {
            get
            {
                return _sourceData; //_sourceData.Select(a => a as object).ToList();

            }
            set
            {
                
                _sourceData = value;
                list_items.DataSource = _sourceData;
            }
        }
        public new string Text
        {
            get
            {
                return txt.Text;
            }
            set
            {
                txt.Text = value;
            }
        }

        public TextBoxIntellisense()
        {
            InitializeComponent();

        }

        public TextBoxIntellisense(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.BackColor = Color.Transparent;

        }
        protected override ControlCollection CreateControlsInstance()
        {

            return base.CreateControlsInstance();
        }
        protected override void InitLayout()
        {
            initControls();
            IsShowIntellisense = false;
            base.InitLayout();
        }

        void initControls()
        {
            txt.LostFocus += Txt_LostFocus;
            txt.KeyDown += Txt_KeyDown;
            //txt.KeyDown += KeyDown;
            txt.Size = new Size(this.Width, 21);
            txt.Location = new Point(0, 0);
            txt.Dock = DockStyle.Top;
            this.Controls.Add(txt);


            panel.Visible = IsShowIntellisense;
            panel.Location = new Point(txt.Location.X, txt.Location.Y + txt.Size.Height + 5); ;
            panel.Size = new Size(this.Width, 200);
            //panel.BorderStyle = BorderStyle.FixedSingle;

            list_items.DataSource = _sourceData;
            list_items.DisplayMember = "Text";
            list_items.SelectedIndexChanged += List_items_SelectedIndexChanged;
            list_items.Location = new Point(0, 0);
            list_items.Size = new Size(250, 200);
            list_items.Dock = DockStyle.Left;


            fl_panel.Location = new Point(255, 0);
            fl_panel.Size = new Size(panel.Width - list_items.Width - 5, 60);
            
            lb_describe.Location = new Point(0, 0);
            lb_describe.Dock = DockStyle.Fill;
            lb_describe.AutoSize = true;
            lb_describe.BackColor = Color.Gainsboro;
            fl_panel.Controls.Add(lb_describe);



            panel.Controls.Add(list_items);
            panel.Controls.Add(fl_panel);


            this.Controls.Add(panel);

        }

        private void Txt_LostFocus(object sender, EventArgs e)
        {
            IsShowIntellisense = false;
        }

        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (IsShowIntellisense)
                {
                    txt.Text += SelectedItem.Text;
                    txt.SelectionStart = txt.Text.Length;
                    IsShowIntellisense = false;
                }
                else
                {
                    KeyDown(sender, e);
                }
            }
            else if (e.KeyCode == Keys.OemPeriod)
            {
                IsShowIntellisense = true;
            }
            else
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    int interval = e.KeyCode == Keys.Down ? 1 : -1;
                    var selectIndex = list_items.SelectedIndex;
                    var count = list_items.Items.Count;
                    selectIndex += interval;
                    selectIndex = selectIndex >= count ? 0 : selectIndex < 0 ? count - 1 : selectIndex;
                    list_items.SelectedIndex = selectIndex;

                    e.Handled = true;
                }
            }
        }

        private void List_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            var model = (list_items.SelectedItem as IntellisenseModel);
            SelectedItem = model;
            ShowDescribe();

        }

        private void ShowDescribe()
        {

            if (!string.IsNullOrEmpty(SelectedItem.Describe))
            {
                lb_describe.Visible = true;
                lb_describe.AutoSize = true;
                lb_describe.Location = new Point(list_items.Location.X + list_items.Width, list_items.Location.Y);
                lb_describe.Text = SelectedItem.Describe;
                lb_describe.Visible = true;
                lb_describe.BringToFront();
            }
            else
            {
                lb_describe.Visible = false;

            }



        }
        public new bool Focus()
        {
            return txt.Focus();
        }


    }
}
