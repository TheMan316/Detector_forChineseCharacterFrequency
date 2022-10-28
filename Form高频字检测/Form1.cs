using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form高频字检测 {
    public partial class Form1 : Form {
        string _fileName;
        Dictionary<char, int> _dict = new Dictionary<char, int>();
        List<char> _listWord = new List<char>();
        List<int> _ListWordTimes = new List<int>();
        string _encoding = "GB18030";
        public Form1() {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                int fileLen = openFileDialog.FileName.LastIndexOf(@"/");
                _fileName = openFileDialog.FileName.Substring(fileLen + 1);
            }
        }
        private bool ContainSymbol(char word) {
            if ((int)word <= 255) {
                return true;
            }
            switch (word) {
                case '。':
                    return true;
                case '，':
                    return true;
                case ' ':
                    return true;
                case '：':
                    return true;
                case '”':
                    return true;
                case '“':
                    return true;
                case '·':
                    return true;
                case '●':
                    return true;
                case '│':
                    return true;
                case '┌':
                    return true;
                case '─':
                    return true;
                case '┐':
                    return true;
                case '└':
                    return true;
                case '┘':
                    return true;
                case '；':
                    return true;
                case '、':
                    return true;
                case '？':
                    return true;
                case '！':
                    return true;
                case '\r':
                    return true;
                case '\n':
                    return true;
                default:
                    return false;
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            string Chinese = File.ReadAllText(_fileName, Encoding.GetEncoding(_encoding));
            int a = 0;
            foreach (var word in Chinese) {
                if (ContainSymbol(word) == false) {
                    if (_dict.ContainsKey(word) == false) {
                       
                        _dict.Add(word, 1);
                    }
                    else {
                      
                        _dict[word]++;
                    }
                }
            }
            foreach (var keyAndValue in _dict) {
                if (keyAndValue.Key == '史') {
                    a++;
                }
                _listWord.Add(keyAndValue.Key);
                _ListWordTimes.Add(keyAndValue.Value);
            }
            QuickSort(0, _listWord.Count - 1);
            MessageBox.Show("检测完成！");
        }
        private void QuickSort(int leftIndex, int rightIndex) {
            if (leftIndex >= rightIndex) {
                return;
            }
            int baseValue = _ListWordTimes[leftIndex];
            char baseWord = _listWord[leftIndex];
            int i = leftIndex;
            int j = rightIndex;
            int temp = 0;
            char tempWord = ' ';
            while (i < j) {
                while (_ListWordTimes[j] <= baseValue && i < j) j--;
                while (_ListWordTimes[i] >= baseValue && i < j) i++;
                if (i < j) {
                    temp = _ListWordTimes[i];
                    tempWord = _listWord[i];
                    _ListWordTimes[i] = _ListWordTimes[j];
                    _listWord[i] = _listWord[j];
                    _ListWordTimes[j] = temp;
                    _listWord[j] = tempWord;
                }
                else {
                    _listWord[leftIndex] = _listWord[i];
                    _listWord[i] = baseWord;
                    _ListWordTimes[leftIndex] = _ListWordTimes[i];
                    _ListWordTimes[i] = baseValue;
                    

                }

            }
            QuickSort(leftIndex,i-1);
            QuickSort(i+1,rightIndex);


        }

        private void button1_Click(object sender, EventArgs e) {
           
            int len = _listWord.Count * 3;
            StringBuilder sb = new StringBuilder(len);

            int index = 0;
            for (int i = 0; i < _listWord.Count; i++) {
                sb.Append(_listWord[index]);
                sb.Append(_ListWordTimes[index].ToString());
                sb.Append("\n");
                index++;
            }
            File.WriteAllText("tempFile.txt", sb.ToString());
            MessageBox.Show("输出完成！");

        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void gB18030ToolStripMenuItem_Click(object sender, EventArgs e) {
            _encoding = "GB18030";
            label2.Text = _encoding;

        }

        private void uTF8ToolStripMenuItem_Click(object sender, EventArgs e) {
            _encoding = "UTF-8";
            label2.Text = _encoding;

        }

        private void Form1_Load(object sender, EventArgs e) {
            label2.Text = _encoding;
        }
    }
}
