using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfXPathTool
{
    public class FormDataDto : INotifyPropertyChanged
    {
        private string _XPath = "";
        public string XPath {
            get
            {
                return _XPath;
            }
            set
            {
                _XPath = value;
                OnPropertyChanged("XPath");
            }
        }


        private string _SourceHtml = "";
        public string SourceHtml
        {
            get
            {
                return _SourceHtml;
            }
            set
            {
                _SourceHtml = value;
                OnPropertyChanged("SourceHtml");
            }
        }


        private string _OutContent = "";
        public string OutContent
        {
            get
            {
                return _OutContent;
            }
            set
            {
                _OutContent = value;
                OnPropertyChanged("OutContent");
            }
        }

        private bool _IsOuterHtml =false;
        public bool IsOuterHtml
        {
            get
            {
                return _IsOuterHtml;
            }
            set
            {
                _IsOuterHtml = value;
                OnPropertyChanged("IsOuterHtml");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected internal virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
