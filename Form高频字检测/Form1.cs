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
        long totalTImes = 0;
        double num100 = 0;
        double num500 = 0;
        double num1000 = 0;
        double num1500 = 0;
        double num2000 = 0;
        double num3000 = 0;
        double num4000 = 0;
        double num5000 = 0;
        string _fileName = "";
        Dictionary<char, int> _dict_ofNewFile;
        List<char> _listWord;
        List<int> _listWordTimes;
        Dictionary<char, int> _dict_ofChineseCharacterFrequencyFile;
        string _encoding = "UTF-8";
        bool _isDetected = false;
        public Form1() {
            InitializeComponent();
            label2.Text = _encoding;
          
        }
        private void Init_dictOfChineseCharacterFrequency() {
            if (File.Exists("ChineseCharacterFrequency.txt") == false) {
                File.WriteAllText("ChineseCharacterFrequency.txt", "");
            }
            if (File.Exists("oldChineseCharacterFrequency.txt")) {
                File.Delete("oldChineseCharacterFrequency.txt");
            }
            File.Copy("ChineseCharacterFrequency.txt", "oldChineseCharacterFrequency.txt");
            _dict_ofChineseCharacterFrequencyFile = new Dictionary<char, int>();



            string[] arr_string = File.ReadAllLines("ChineseCharacterFrequency.txt");
            int index = 0;
            foreach (var line in arr_string) {
                index++;
                char word = line[0];
                int times = Convert.ToInt32(line.Substring(1));
                totalTImes += times;
                _dict_ofChineseCharacterFrequencyFile.Add(word, times);
                if (index == 100) {
                    num100 = totalTImes;
                }
                else if(index == 500) {
                    num500 = totalTImes;
                }
                else if (index == 1000) {
                    num1000 = totalTImes;
                }
                else if (index == 1500) {
                    num1500 = totalTImes;
                }
                else if (index == 2000) {
                    num2000 = totalTImes;
                }
                else if (index == 3000) {
                    num3000 = totalTImes;
                }
                else if (index == 4000) {
                    num4000 = totalTImes;
                }
                else if (index == 5000) {
                    num5000 = totalTImes;
                }
            }
            num100 /= totalTImes ;
            num500 /= totalTImes;
            num1000 /= totalTImes;
            num1500 /= totalTImes;
            num2000 /= totalTImes;
            num3000 /= totalTImes;
            num4000 /= totalTImes;
            num5000 /= totalTImes;

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e) {
            Init_dictOfChineseCharacterFrequency();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                int fileLen = openFileDialog.FileName.LastIndexOf(@"\");
                _fileName = openFileDialog.FileName;
                label4.Text = openFileDialog.FileName.Substring(fileLen + 1);
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
                case '【':
                    return true;
                case '】':
                    return true;
                case '〗':
                    return true;
                case '〖':
                    return true;
                case ')':
                    return true;
                case '(':
                    return true;
                case '≧':
                    return true;
                case '﹐':
                    return true;
                case '♂':
                    return true;
                case '╮':
                    return true;
                case '╯':
                    return true;
                case '．':
                    return true;
                case '＜':
                    return true;
                case 'Ｃ':
                    return true;
                case '⊥':
                    return true;
                case 'ｔ':
                    return true;
                case '▽':
                    return true;
                case '３':
                    return true;
                case '┟':
                    return true;
                case '※':
                    return true;
                case '╪':
                    return true;
                case '┞':
                    return true;
                case 'Ｂ':
                    return true;
                case '○':
                    return true;
                case '﹖':
                    return true;
                case '■':
                    return true;
                case 'ㄟ':
                    return true;
                case 'ˇ':
                    return true;
                case 'ˋ':
                    return true;
                case '〈':
                    return true;
                case '┝':
                    return true;
                case '＝':
                    return true;
                case '╭':
                    return true;
                case 'ｈ':
                    return true;
                case '＇':
                    return true;
                case 'Ａ':
                    return true;
                case 'ォ':
                    return true;
                case '‘':
                    return true;
                case '’':
                    return true;
                case '★':
                    return true;
                case '］':
                    return true;
                case '［':
                    return true;
                case '︹':
                    return true;
                case ':':
                    return true;
                case '"':
                    return true;
                case '@':
                    return true;
                case '〕':
                    return true;
                case '‖':
                    return true;
                case 'ē':
                    return true;
                case 'л':
                    return true;
                case '☆':
                    return true;
                case '≦':
                    return true;
                case '▲':
                    return true;
                case '┌':
                    return true;
                case '〓':
                    return true;
                case '─':
                    return true;
                case '〔':
                    return true;
                case '┐':
                    return true;
                case '「':
                    return true;
                case '」':
                    return true;
                case '　':
                    return true;
                case '└':
                    return true;
                case '┘':
                    return true;
                case '《':
                    return true;
                case '㈠':
                    return true;
                case 'ω':
                    return true;
                case '⊙':
                    return true;
                case '℃':
                    return true;
                case '９':
                    return true;
                case 'щ':
                    return true;
                case 'Ⅱ':
                    return true;
                case 'Ｘ':
                    return true;
                case 'ю':
                    return true;
                case 'ъ':
                    return true;
                case '②':
                    return true;
                case '８':
                    return true;
                case 'ˊ':
                    return true;
                case 'ｅ':
                    return true;
                case '１':
                    return true;
                case '｀':
                    return true;
                case 'д':
                    return true;
                case 'ж':
                    return true;
                case '①':
                    return true;
                case '═':
                    return true;
                case '－':
                    return true;
                case '％':
                    return true;
                case '◎':
                    return true;
                case 'в':
                    return true;
                case 'ь':
                    return true;
                case 'м':
                    return true;
                case '）':
                    return true;
                case '（':
                    return true;
                case '～':
                    return true;
                case '':
                    return true;
                case '□':
                    return true;
                case 'ｍ':
                    return true;
                case 'ǎ':
                    return true;
                case 'ā':
                    return true;
                case '*':
                    return true;
                case '&':
                    return true;
                case '!':
                    return true;
                case '#':
                    return true;
                case '$':
                    return true;
                case '?':
                    return true;
                case '`':
                    return true;
                case '-':
                    return true;
                case '^':
                    return true;
                case '》':
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
            if (Is_choseFile() == false) {
                MessageBox.Show("请选择文件！");
                return;
            }
            _isDetected = true;
            _dict_ofNewFile = new Dictionary<char, int>();
            _listWord = new List<char>();
            _listWordTimes = new List<int>();

            string Chinese = File.ReadAllText(_fileName, Encoding.GetEncoding(_encoding));
            foreach (var word in Chinese) {
                if (ContainSymbol(word) == false) {
                    if (_dict_ofNewFile.ContainsKey(word) == false) {

                        _dict_ofNewFile.Add(word, 1);
                    }
                    else {

                        _dict_ofNewFile[word]++;
                    }
                }
            }
            foreach (var keyAndValue in _dict_ofNewFile) {
                _listWord.Add(keyAndValue.Key);
                _listWordTimes.Add(keyAndValue.Value);
            }
            QuickSort(0, _listWord.Count - 1,_listWord,_listWordTimes);
            MessageBox.Show("检测完成！");
        }
        private void QuickSort(int leftIndex, int rightIndex, List<char> list_word, List<int> list_times) {
            if (leftIndex >= rightIndex) {
                return;
            }
            int baseValue = list_times[leftIndex];
            char baseWord = list_word[leftIndex];
            int i = leftIndex;
            int j = rightIndex;
            int temp = 0;
            char tempWord = ' ';
            while (i < j) {
                while (list_times[j] <= baseValue && i < j) j--;
                while (list_times[i] >= baseValue && i < j) i++;
                if (i < j) {
                    temp = list_times[i];
                    tempWord = list_word[i];
                    list_times[i] = list_times[j];
                    list_word[i] = list_word[j];
                    list_times[j] = temp;
                    list_word[j] = tempWord;
                }
                else {
                    list_word[leftIndex] = list_word[i];
                    list_word[i] = baseWord;
                    list_times[leftIndex] = list_times[i];
                    list_times[i] = baseValue;


                }

            }
            QuickSort(leftIndex, i - 1,list_word,list_times);
            QuickSort(i + 1, rightIndex,list_word, list_times);


        }

        private void button1_Click(object sender, EventArgs e) {
            if (Is_choseFile() == false) {
                MessageBox.Show("请选择文件！");
                return;
            }
            if(_isDetected == false) {
                MessageBox.Show("请先检测文件！");
                return;
            }
            int len = _listWord.Count * 3;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _listWord.Count; i++) {
                sb.Append(_listWord[i]);
                sb.Append(_listWordTimes[i].ToString());
                sb.Append("\n");

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

        }
        private bool Is_choseFile() {
            if (_fileName == "") {

                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e) {
            if (Is_choseFile() == false) {
                MessageBox.Show("请选择文件！");
                return;
            }
            if (_isDetected == false) {
                MessageBox.Show("请先检测文件！");
                return;
            }
            _listWord = new List<char>();
            _listWordTimes = new List<int>();
            foreach (var wordAndTimes in _dict_ofNewFile) {
                if (_dict_ofChineseCharacterFrequencyFile.ContainsKey(wordAndTimes.Key)) {
                    _dict_ofChineseCharacterFrequencyFile[wordAndTimes.Key] += wordAndTimes.Value;
                }
                else {
                    _dict_ofChineseCharacterFrequencyFile.Add(wordAndTimes.Key, wordAndTimes.Value);
                }
            }
            foreach (var wordAndTimes in _dict_ofChineseCharacterFrequencyFile) {
                _listWord.Add(wordAndTimes.Key);
                _listWordTimes.Add(wordAndTimes.Value);
            }
            QuickSort(0, _listWord.Count - 1, _listWord, _listWordTimes);
            int len = _listWord.Count * 3;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _listWord.Count; i++) {
                sb.Append(_listWord[i]);
                sb.Append(_listWordTimes[i].ToString());
                sb.Append("\n");
            }
            File.WriteAllText("ChineseCharacterFrequency.txt", sb.ToString());
            MessageBox.Show("输出完成！");
        }

        private void 说明ToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("作者：桂南鄙士\n初版完成时间：2022年10月28日23:12\n小贴士：\n1、如果检测文件时发现编码搞错了，可以重新选好编码再检测一次。之前的乱码检测记录不会被保存。\n2、ChineseCharacterFrequency.txt可以被手动删除。\n3、GB18030编码兼容GBK编码");
        }

        private void button4_Click(object sender, EventArgs e) {
            if (File.Exists("ChineseCharacterFrequency.txt") == false) {
                File.WriteAllText("ChineseCharacterFrequency.txt", "");
            }
           
            StringBuilder sb = new StringBuilder();
            string[] arr_string = File.ReadAllLines("ChineseCharacterFrequency.txt");
            
            foreach (var line in arr_string) {
                char word = line[0];
                sb.Append(word);
            }
            File.WriteAllText("字频集合.txt", sb.ToString());
            MessageBox.Show("输出完成！");
        }

        private void 字频比例显示ToolStripMenuItem_Click(object sender, EventArgs e) {
            Init_dictOfChineseCharacterFrequency();
            MessageBox.Show($"当前ChineseCharacterFrequency.txt文件中，\n前100字频率占所有汉字频率的比例为：{num100 * 100}%" +
    $"\n前500字频率占所有汉字频率的比例为：{num500 * 100}%" +
    $"\n前1000字频率占所有汉字频率的比例为：{num1000 * 100}%" +
    $"\n前1500字频率占所有汉字频率的比例为：{num1500 * 100}%" +
    $"\n前2000字频率占所有汉字频率的比例为：{num2000 * 100}%" +
    $"\n前3000字频率占所有汉字频率的比例为：{num3000 * 100}%" +
    $"\n前4000字频率占所有汉字频率的比例为：{num4000 * 100}%" +
    $"\n前5000字频率占所有汉字频率的比例为：{num5000 * 100}%");
        }
    }
}
