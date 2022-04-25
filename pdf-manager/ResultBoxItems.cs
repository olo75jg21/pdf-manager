using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf_manager
{
    public class ResultItem
    {
        private int _id;
        private string _path;
        private int _page;
        private int _line;
        private string _data;
        private bool _isChecked;
        public event PropertyChangedEventHandler PropertyChanged;

        public ResultItem(int id, string path, int page, int line, string data)
        {
            _id = id;
            _path = path;
            _page = page;
            _line = line;
            _data = data;
        }

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (value != _isChecked)
                {
                    _isChecked = value;
                    this.OnPropertyChanged("IsChecked");
                }
            }
        }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Filename { get { return System.IO.Path.GetFileName(_path); } }
        public int Id { get { return _id; } }
        public string Path { get { return _path; } }
        public int Page { get { return _page; } }
        public string NamedPage { get { return "Page " + _page; } }
        public int Line { get { return _line; } }
        public string Data { get { return _data; } }
        public string Helper { get { return _id + "\t" + _page + "\t" + _line; } }
        public static string HelperTitle { get { return "ID\tPage\tLine"; } }
    }


}
