using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace Vocab
{
    public partial class Form1 : Form
    {
        #region Global Variables
        static int _numWords = 500;//number of words in _fileName
        static int _mostSyns = 100;//most synonyms any word in _fileName has
        string[] _words = new string[_numWords];
        string[] _defs = new string[_numWords];
        string[,] _sWords = new string[_numWords, _mostSyns];
        string[,] _sDefs = new string[_numWords, _mostSyns];
        int[] _numSyn = new int[_numWords];
        int[] _correctAnswers = new int[3];
        int _vars = 0;
        string _fileName = System.Environment.CurrentDirectory + "\\words.dat";
        string _tempName = System.Environment.CurrentDirectory + "\\temp.dat";
        StreamReader _fileR;
        int _r;
        bool _play = true;
        #endregion
        public Form1()
        {
            if (!File.Exists(_fileName))
            {
                FileStream file = new FileStream(_fileName, FileMode.OpenOrCreate);
                file.Close();
            }
            WriteWordArray();
            InitializeComponent();
            WordGB.Width = ClientSize.Width - 20;
            WordGB.Height = ClientSize.Height - 55;
            Answer1.Top = WordGB.Top;
            Answer5.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6;
            Answer2.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 2;
            Answer6.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 3;
            Answer3.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 4;
            Answer7.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 5;
            Answer4.Top = WordGB.Bottom - 55;
            Def1.Top = WordGB.Top;
            Def5.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6;
            Def2.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 2;
            Def6.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 3;
            Def3.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 4;
            Def7.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 5;
            Def4.Top = WordGB.Bottom - 55;
            Word.Text = "";
            WordGB.Text = "";
            Answer1.Text = "";
            Answer2.Text = "";
            Answer3.Text = "";
            Answer4.Text = "";
            Answer5.Text = "";
            Answer6.Text = "";
            Answer7.Text = "";
            Answer5.Visible = false;
            Answer6.Visible = false;
            Answer7.Visible = false;
            Def1.Visible = false;
            Def2.Visible = false;
            Def3.Visible = false;
            Def4.Visible = false;
            Def5.Visible = false;
            Def6.Visible = false;
            Def7.Visible = false;
            wordDef.Visible = false;
            OkB.Left = ClientSize.Width / 2 - 25;
            OkB.Top = WordGB.Bottom + 2;
            NewWordD();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            WordGB.Width = ClientSize.Width - 20;
            WordGB.Height = ClientSize.Height - 55;
            Answer1.Top = WordGB.Top;
            Answer5.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6;
            Answer2.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 2;
            Answer6.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 3;
            Answer3.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 4;
            Answer7.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 5;
            Answer4.Top = WordGB.Bottom - 55;
            Def1.Top = WordGB.Top;
            Def5.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6;
            Def2.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 2;
            Def6.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 3;
            Def3.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 4;
            Def7.Top = WordGB.Top + (WordGB.Bottom - 55 - WordGB.Top) / 6 * 5;
            Def4.Top = WordGB.Bottom - 55;
            OkB.Left = ClientSize.Width / 2 - 25;
            OkB.Top = WordGB.Bottom + 2;
        }
        private void WriteWordArray()
        {
            _vars = 0;
            _fileR = new StreamReader(_fileName);
            _fileR.ReadLine();
            while (!_fileR.EndOfStream && _vars < _numWords)
            {
                _words[_vars] = _fileR.ReadLine();
                _defs[_vars] = _fileR.ReadLine();
                int j = 0;
                string k = _fileR.ReadLine(); ;
                while (!_fileR.EndOfStream && j < _mostSyns && k != "/")
                {
                    _sWords[_vars, j] = k;
                    _sDefs[_vars, j] = _fileR.ReadLine();
                    k = _fileR.ReadLine();
                    j++;
                }
                _numSyn[_vars] = j;
                _vars++;
            }
            _fileR.Close();
            
        }
        private void WordB_Click(object sender, EventArgs e)
        {
            if (definitionsToolStripMenuItem.Checked)
            {
                NewWordD();
            }
            else
            {
                NewWordS();
            }
        }
        private void Answer1_Click(object sender, EventArgs e)
        {
            if (_play)
            {
                if (definitionsToolStripMenuItem.Checked)
                {
                    Answer2.ForeColor = Color.Black;
                    Answer3.ForeColor = Color.Black;
                    Answer4.ForeColor = Color.Black;
                    Answer5.ForeColor = Color.Black;
                    Answer6.ForeColor = Color.Black;
                    Answer7.ForeColor = Color.Black;
                }
                if (Answer1.ForeColor == Color.Black)
                {
                    Answer1.ForeColor = Color.Blue;
                }
                else
                {
                    Answer1.ForeColor = Color.Black;
                }
            }
        }
        private void Answer2_Click(object sender, EventArgs e)
        {
            if (_play)
            {
                if (definitionsToolStripMenuItem.Checked)
                {
                    Answer1.ForeColor = Color.Black;
                    Answer3.ForeColor = Color.Black;
                    Answer4.ForeColor = Color.Black;
                    Answer5.ForeColor = Color.Black;
                    Answer6.ForeColor = Color.Black;
                    Answer7.ForeColor = Color.Black;
                }
                if (Answer2.ForeColor == Color.Black)
                {
                    Answer2.ForeColor = Color.Blue;
                }
                else
                {
                    Answer2.ForeColor = Color.Black;
                }
            }
        }
        private void Answer3_Click(object sender, EventArgs e)
        {
            if (_play)
            {
                if (definitionsToolStripMenuItem.Checked)
                {
                    Answer1.ForeColor = Color.Black;
                    Answer2.ForeColor = Color.Black;
                    Answer4.ForeColor = Color.Black;
                    Answer5.ForeColor = Color.Black;
                    Answer6.ForeColor = Color.Black;
                    Answer7.ForeColor = Color.Black;
                }
                if (Answer3.ForeColor == Color.Black)
                {
                    Answer3.ForeColor = Color.Blue;
                }
                else
                {
                    Answer3.ForeColor = Color.Black;
                }
            }
        }
        private void Answer4_Click(object sender, EventArgs e)
        {
            if (_play)
            {
                if (definitionsToolStripMenuItem.Checked)
                {
                    Answer1.ForeColor = Color.Black;
                    Answer2.ForeColor = Color.Black;
                    Answer3.ForeColor = Color.Black;
                    Answer5.ForeColor = Color.Black;
                    Answer6.ForeColor = Color.Black;
                    Answer7.ForeColor = Color.Black;
                }
                if (Answer4.ForeColor == Color.Black)
                {
                    Answer4.ForeColor = Color.Blue;
                }
                else
                {
                    Answer4.ForeColor = Color.Black;
                }
            }
        }
        private void Answer5_Click(object sender, EventArgs e)
        {
            if (_play)
            {
                if (definitionsToolStripMenuItem.Checked)
                {
                    Answer1.ForeColor = Color.Black;
                    Answer2.ForeColor = Color.Black;
                    Answer3.ForeColor = Color.Black;
                    Answer4.ForeColor = Color.Black;
                    Answer6.ForeColor = Color.Black;
                    Answer7.ForeColor = Color.Black;
                }
                if (Answer5.ForeColor == Color.Black)
                {
                    Answer5.ForeColor = Color.Blue;
                }
                else
                {
                    Answer5.ForeColor = Color.Black;
                }
            }
        }
        private void Answer6_Click(object sender, EventArgs e)
        {
            if (_play)
            {
                if (definitionsToolStripMenuItem.Checked)
                {
                    Answer1.ForeColor = Color.Black;
                    Answer2.ForeColor = Color.Black;
                    Answer3.ForeColor = Color.Black;
                    Answer4.ForeColor = Color.Black;
                    Answer5.ForeColor = Color.Black;
                    Answer7.ForeColor = Color.Black;
                }
                if (Answer6.ForeColor == Color.Black)
                {
                    Answer6.ForeColor = Color.Blue;
                }
                else
                {
                    Answer6.ForeColor = Color.Black;
                }
            }
        }
        private void Answer7_Click(object sender, EventArgs e)
        {
            if (_play)
            {
                if (definitionsToolStripMenuItem.Checked)
                {
                    Answer1.ForeColor = Color.Black;
                    Answer2.ForeColor = Color.Black;
                    Answer3.ForeColor = Color.Black;
                    Answer4.ForeColor = Color.Black;
                    Answer5.ForeColor = Color.Black;
                    Answer6.ForeColor = Color.Black;
                }
                if (Answer7.ForeColor == Color.Black)
                {
                    Answer7.ForeColor = Color.Blue;
                }
                else
                {
                    Answer7.ForeColor = Color.Black;
                }
            }
        }
        private void Def1_VisibleChanged(object sender, EventArgs e)
        {
            Def1.Left = Answer1.Right + 10;
        }
        private void Def2_VisibleChanged(object sender, EventArgs e)
        {
            Def2.Left = Answer2.Right + 10;
        }
        private void Def3_VisibleChanged(object sender, EventArgs e)
        {
            Def3.Left = Answer3.Right + 10;
        }
        private void Def4_VisibleChanged(object sender, EventArgs e)
        {
            Def4.Left = Answer4.Right + 10;
        }
        private void Def5_VisibleChanged(object sender, EventArgs e)
        {
            Def5.Left = Answer5.Right + 10;
        }
        private void Def6_VisibleChanged(object sender, EventArgs e)
        {
            Def6.Left = Answer6.Right + 10;
        }
        private void Def7_VisibleChanged(object sender, EventArgs e)
        {
            Def7.Left = Answer7.Right + 10;
        }
        private void wordDef_VisibleChanged(object sender, EventArgs e)
        {
            wordDef.Left = Word.Right + 10;
        }
        private void NewWordD()
        {
            OkB.Text = "OK";
            if (_vars >= 4)
            {
                Def1.Visible = false;
                Def2.Visible = false;
                Def3.Visible = false;
                Def4.Visible = false;
                Def5.Visible = false;
                Def6.Visible = false;
                Def7.Visible = false;
                wordDef.Visible = false;
                Answer5.Visible = false;
                Answer6.Visible = false;
                Answer7.Visible = false;
                _play = true;
                _r = -1;
                Answer1.ForeColor = Color.Black;
                Answer2.ForeColor = Color.Black;
                Answer3.ForeColor = Color.Black;
                Answer4.ForeColor = Color.Black;
                Random rand = new Random((int)DateTime.Now.Ticks);
                if (WordTB.Text != "")
                {
                    string word = WordTB.Text;
                    WordTB.Text = "";
                    for (int i = 0; i < _words.Length; i++)
                    {
                        if (_words[i] != null && _words[i].ToLower() == word.ToLower())
                        {
                            _r = i;
                        }
                    }
                }
                if (_r == -1)
                {
                    _r = rand.Next(_vars);
                }
                int w1 = 0;
                int w2 = 0;
                int w3 = 0;
                while (w1 == w2 || w1 == w3 || w2 == w3 || w1 == _r || w2 == _r || w3 == _r)
                {
                    w1 = rand.Next(_vars);
                    w2 = rand.Next(_vars);
                    w3 = rand.Next(_vars);
                }
                Word.Text = _words[_r];
                int ans = rand.Next(_vars) % 4 + 1;
                switch (ans)
                {
                    case 1:
                        Answer1.Text = _defs[_r];
                        Answer2.Text = _defs[w1];
                        Answer3.Text = _defs[w2];
                        Answer4.Text = _defs[w3];
                        break;
                    case 2:
                        Answer2.Text = _defs[_r];
                        Answer1.Text = _defs[w1];
                        Answer3.Text = _defs[w2];
                        Answer4.Text = _defs[w3];
                        break;
                    case 3:
                        Answer3.Text = _defs[_r];
                        Answer2.Text = _defs[w1];
                        Answer1.Text = _defs[w2];
                        Answer4.Text = _defs[w3];
                        break;
                    default:
                        Answer4.Text = _defs[_r];
                        Answer2.Text = _defs[w1];
                        Answer3.Text = _defs[w2];
                        Answer1.Text = _defs[w3];
                        break;

                }
            }
            else
            {

                MessageBox.Show("There are not enough words.\n\nGo to Edit List and add more words.");
            }
        }
        private void NewWordS()
        {
            OkB.Text = "OK";
            int j = 0;
            for (int i = 0; i < _numWords; i++)
            {
                if (_numSyn[i] >= 3)
                    j++;
            }
            if (_vars >= 3 && j >= 3)
            {
                Def1.Visible = false;
                Def2.Visible = false;
                Def3.Visible = false;
                Def4.Visible = false;
                Def5.Visible = false;
                Def6.Visible = false;
                Def7.Visible = false;
                wordDef.Visible = false;
                Answer5.Visible = true;
                Answer6.Visible = true;
                Answer7.Visible = true;
                _play = true;
                _r = -1;
                Answer1.ForeColor = Color.Black;
                Answer2.ForeColor = Color.Black;
                Answer3.ForeColor = Color.Black;
                Answer4.ForeColor = Color.Black;
                Answer5.ForeColor = Color.Black;
                Answer6.ForeColor = Color.Black;
                Answer7.ForeColor = Color.Black;
                Random rand = new Random((int)DateTime.Now.Ticks);
                if (WordTB.Text != "")
                {
                    string word = WordTB.Text;
                    WordTB.Text = "";
                    for (int i = 0; i < _words.Length; i++)
                    {
                        if (_words[i] != null && _words[i].ToLower() == word.ToLower())
                        {
                            _r = i;
                        }
                    }
                }
                if (_r == -1)
                {
                    _r = rand.Next(_vars);
                }
                while (_numSyn[_r] < 3)
                {
                    _r = rand.Next(_vars);
                }
                int rw1 = 0;
                int rw2 = 0;
                int rw3 = 0;
                int ww1 = 0;
                int ww2 = 0;
                int ww3 = 0;
                int ww4 = 0;
                int ws1 = 0;
                int ws2 = 0;
                int ws3 = 0;
                int ws4 = 0;
                int ans1 = 0;
                int ans2 = 0;
                int ans3 = 0;
                int ans4 = 0;
                int ans5 = 0;
                int ans6 = 0;
                int ans7 = 0;
                do
                {
                    rw1 = rand.Next(_numSyn[_r]);
                    rw2 = rand.Next(_numSyn[_r]);
                    rw3 = rand.Next(_numSyn[_r]);
                } while (rw1 == rw2 || rw1 == rw3 || rw2 == rw3 || _sWords[_r, rw1] == null || _sWords[_r, rw2] == null || _sWords[_r, rw3] == null);
                do
                {
                    do
                    {
                        ww1 = rand.Next(_vars);
                    } while (_numSyn[ww1] == 0);
                    ws1 = rand.Next(_numSyn[ww1]);
                    do
                    {
                        ww2 = rand.Next(_vars);
                    } while (_numSyn[ww2] == 0);
                    ws2 = rand.Next(_numSyn[ww2]);
                    do
                    {
                        ww3 = rand.Next(_vars);
                    } while (_numSyn[ww3] == 0);
                    ws3 = rand.Next(_numSyn[ww3]);
                    do
                    {
                        ww4 = rand.Next(_vars);
                    } while (_numSyn[ww4] == 0);
                    ws4 = rand.Next(_numSyn[ww4]);
                } while (_sWords[ww1, ws1] == _sWords[ww2, ws2] || _sWords[ww1, ws1] == _sWords[ww3, ws3] || _sWords[ww1, ws1] == _sWords[ww4, ws4] || _sWords[ww2, ws2] == _sWords[ww3, ws3] || _sWords[ww2, ws2] == _sWords[ww4, ws4] || _sWords[ww3, ws3] == _sWords[ww4, ws4] || _sWords[ww1, ws1] == _sWords[_r, rw1] || _sWords[ww1, ws1] == _sWords[_r, rw2] || _sWords[ww1, ws1] == _sWords[_r, rw3] || _sWords[ww2, ws2] == _sWords[_r, rw1] || _sWords[ww2, ws2] == _sWords[_r, rw2] || _sWords[ww2, ws2] == _sWords[_r, rw3] || _sWords[ww3, ws3] == _sWords[_r, rw1] || _sWords[ww3, ws3] == _sWords[_r, rw2] || _sWords[ww3, ws3] == _sWords[_r, rw3] || _sWords[ww4, ws4] == _sWords[_r, rw1] || _sWords[ww4, ws4] == _sWords[_r, rw2] || _sWords[ww4, ws4] == _sWords[_r, rw3]);
                Word.Text = _words[_r];
                wordDef.Text = _defs[_r];
                int[] anss = new int[7];
                int num;
                for (num = 0; num < 7; )
                {
                    anss[num] = ++num;
                }
                num = rand.Next(7);
                ans1 = anss[num];
                for (; num < 6; num++)
                {
                    anss[num] = anss[num + 1];
                }
                num = rand.Next(6);
                ans2 = anss[num];
                for (; num < 5; num++)
                {
                    anss[num] = anss[num + 1];
                }
                num = rand.Next(5);
                ans3 = anss[num];
                for (; num < 4; num++)
                {
                    anss[num] = anss[num + 1];
                }
                num = rand.Next(4);
                ans4 = anss[num];
                for (; num < 3; num++)
                {
                    anss[num] = anss[num + 1];
                }
                num = rand.Next(3);
                ans5 = anss[num];
                for (; num < 2; num++)
                {
                    anss[num] = anss[num + 1];
                }
                num = rand.Next(2);
                ans6 = anss[num];
                for (; num < 1; num++)
                {
                    anss[num] = anss[num + 1];
                }
                ans7 = anss[0];
                _correctAnswers[0] = ans1;
                _correctAnswers[1] = ans2;
                _correctAnswers[2] = ans3;
                whichAnswer(ans1, _r, rw1);
                whichAnswer(ans2, _r, rw2);
                whichAnswer(ans3, _r, rw3);
                whichAnswer(ans4, ww1, ws1);
                whichAnswer(ans5, ww2, ws2);
                whichAnswer(ans6, ww3, ws3);
                whichAnswer(ans7, ww4, ws4);
            }
            else if (_vars < 3)
            {
                MessageBox.Show("There are not enough words.\n\nGo to Edit List and add more words.");
            }
            else
            {
                MessageBox.Show("Not enough words have 3 or more synonyms.\n\nGo to Edit List and add more synonyms.");
            }
        }
        private void whichAnswer(int ans, int w, int s)
        {
            switch (ans)
            {
                case 1:
                    Answer1.Text = _sWords[w, s];
                    Def1.Text = _sDefs[w, s];
                    break;
                case 2:
                    Answer2.Text = _sWords[w, s];
                    Def2.Text = _sDefs[w, s];
                    break;
                case 3:
                    Answer3.Text = _sWords[w, s];
                    Def3.Text = _sDefs[w, s];
                    break;
                case 4:
                    Answer4.Text = _sWords[w, s];
                    Def4.Text = _sDefs[w, s];
                    break;
                case 5:
                    Answer5.Text = _sWords[w, s];
                    Def5.Text = _sDefs[w, s];
                    break;
                case 6:
                    Answer6.Text = _sWords[w, s];
                    Def6.Text = _sDefs[w, s];
                    break;
                case 7:
                    Answer7.Text = _sWords[w, s];
                    Def7.Text = _sDefs[w, s];
                    break;
            }
        }
        private void FindCorrectAnswerD(int clicked)
        {
            OkB.Text = "Next";
            Answer1.ForeColor = Color.Black;
            Answer2.ForeColor = Color.Black;
            Answer3.ForeColor = Color.Black;
            Answer4.ForeColor = Color.Black;
            if (Answer1.Text == _defs[_r])
            {
                if (clicked == 1)
                {
                    Answer1.ForeColor = Color.Green;
                }
                else
                {
                    Answer1.ForeColor = Color.Red;
                }
            }
            else if (Answer2.Text == _defs[_r])
            {
                if (clicked == 2)
                {
                    Answer2.ForeColor = Color.Green;
                }
                else
                {
                    Answer2.ForeColor = Color.Red;
                }
            }
            else if (Answer3.Text == _defs[_r])
            {
                if (clicked == 3)
                {
                    Answer3.ForeColor = Color.Green;
                }
                else
                {
                    Answer3.ForeColor = Color.Red;
                }
            }
            else if (Answer4.Text == _defs[_r])
            {
                if (clicked == 4)
                {
                    Answer4.ForeColor = Color.Green;
                }
                else
                {
                    Answer4.ForeColor = Color.Red;
                }
            }
            _play = false;
        }
        private void FindCorrectAnswerS(bool[] clicked)
        {
            OkB.Text = "Next";
            Answer1.ForeColor = Color.Black;
            Answer2.ForeColor = Color.Black;
            Answer3.ForeColor = Color.Black;
            Answer4.ForeColor = Color.Black;
            Answer5.ForeColor = Color.Black;
            Answer6.ForeColor = Color.Black;
            Answer7.ForeColor = Color.Black;
            Def1.Visible = true;
            Def2.Visible = true;
            Def3.Visible = true;
            Def4.Visible = true;
            Def5.Visible = true;
            Def6.Visible = true;
            Def7.Visible = true;
            wordDef.Visible = true;
            Def1.ForeColor = Color.Black;
            Def2.ForeColor = Color.Black;
            Def3.ForeColor = Color.Black;
            Def4.ForeColor = Color.Black;
            Def5.ForeColor = Color.Black;
            Def6.ForeColor = Color.Black;
            Def7.ForeColor = Color.Black;
            if (_correctAnswers[0] == 1 || _correctAnswers[1] == 1 || _correctAnswers[2] == 1)
            {
                if (clicked[0])
                {
                    Answer1.ForeColor = Color.Green;
                    Def1.ForeColor = Color.Green;
                }
                else
                {
                    Answer1.ForeColor = Color.Red;
                    Def1.ForeColor = Color.Red;
                }
            }
            if (_correctAnswers[0] == 2 || _correctAnswers[1] == 2 || _correctAnswers[2] == 2)
            {
                if (clicked[1])
                {
                    Answer2.ForeColor = Color.Green;
                    Def2.ForeColor = Color.Green;
                }
                else
                {
                    Answer2.ForeColor = Color.Red;
                    Def2.ForeColor = Color.Red;
                }
            }
            if (_correctAnswers[0] == 3 || _correctAnswers[1] == 3 || _correctAnswers[2] == 3)
            {
                if (clicked[2])
                {
                    Answer3.ForeColor = Color.Green;
                    Def3.ForeColor = Color.Green;
                }
                else
                {
                    Answer3.ForeColor = Color.Red;
                    Def3.ForeColor = Color.Red;
                }
            }
            if (_correctAnswers[0] == 4 || _correctAnswers[1] == 4 || _correctAnswers[2] == 4)
            {
                if (clicked[3])
                {
                    Answer4.ForeColor = Color.Green;
                    Def4.ForeColor = Color.Green;
                }
                else
                {
                    Answer4.ForeColor = Color.Red;
                    Def4.ForeColor = Color.Red;
                }
            }
            if (_correctAnswers[0] == 5 || _correctAnswers[1] == 5 || _correctAnswers[2] == 5)
            {
                if (clicked[4])
                {
                    Answer5.ForeColor = Color.Green;
                    Def5.ForeColor = Color.Green;
                }
                else
                {
                    Answer5.ForeColor = Color.Red;
                    Def5.ForeColor = Color.Red;
                }
            }
            if (_correctAnswers[0] == 6 || _correctAnswers[1] == 6 || _correctAnswers[2] == 6)
            {
                if (clicked[5])
                {
                    Answer6.ForeColor = Color.Green;
                    Def6.ForeColor = Color.Green;
                }
                else
                {
                    Answer6.ForeColor = Color.Red;
                    Def6.ForeColor = Color.Red;
                }
            }
            if (_correctAnswers[0] == 7 || _correctAnswers[1] == 7 || _correctAnswers[2] == 7)
            {
                if (clicked[6])
                {
                    Answer7.ForeColor = Color.Green;
                    Def7.ForeColor = Color.Green;
                }
                else
                {
                    Answer7.ForeColor = Color.Red;
                    Def7.ForeColor = Color.Red;
                }
            }
            _play = false;
        }
        private void OkB_Click(object sender, EventArgs e)
        {
            if (WordTB.Text != "" || !_play)
            {
                if (definitionsToolStripMenuItem.Checked)
                {
                    NewWordD();
                }
                else
                {
                    NewWordS();
                }
            }
            else
            {
                if (definitionsToolStripMenuItem.Checked)
                {
                    if (Answer1.ForeColor == Color.Blue)
                    {
                        FindCorrectAnswerD(1);
                    }
                    else if (Answer2.ForeColor == Color.Blue)
                    {
                        FindCorrectAnswerD(2);
                    }
                    else if (Answer3.ForeColor == Color.Blue)
                    {
                        FindCorrectAnswerD(3);
                    }
                    else if (Answer4.ForeColor == Color.Blue)
                    {
                        FindCorrectAnswerD(4);
                    }
                    else
                    {
                        MessageBox.Show("Pick An Answer");
                    }
                }
                else
                {
                    bool[] clicked = new bool[7];
                    int numClicked = 0;
                    if (Answer1.ForeColor == Color.Blue)
                    {
                        clicked[0] = true;
                        numClicked++;
                    }
                    if (Answer2.ForeColor == Color.Blue)
                    {
                        clicked[1] = true;
                        numClicked++;
                    }
                    if (Answer3.ForeColor == Color.Blue)
                    {
                        clicked[2] = true;
                        numClicked++;
                    }
                    if (Answer4.ForeColor == Color.Blue)
                    {
                        clicked[3] = true;
                        numClicked++;
                    }
                    if (Answer5.ForeColor == Color.Blue)
                    {
                        clicked[4] = true;
                        numClicked++;
                    }
                    if (Answer6.ForeColor == Color.Blue)
                    {
                        clicked[5] = true;
                        numClicked++;
                    }
                    if (Answer7.ForeColor == Color.Blue)
                    {
                        clicked[6] = true;
                        numClicked++;
                    }
                    if (numClicked == 3)
                    {
                        FindCorrectAnswerS(clicked);
                    }
                    else
                    {
                        MessageBox.Show("Pick 3 Answers");
                    }


                }
            }
        }
        private void definitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            definitionsToolStripMenuItem.Checked = true;
            synonymsToolStripMenuItem.Checked = false;
            NewWordD();
        }
        private void synonymsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            definitionsToolStripMenuItem.Checked = false;
            synonymsToolStripMenuItem.Checked = true;
            NewWordS();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("             Vocab" +
                        "\n\n          Created By" +
                        "\n\n           Tony Brix" +
                        "\n\n        UziTech.com");
        }
        private void addWord_Click(object sender, EventArgs e)
        {
            EditList addWord = new EditList(true, true, false, _fileName, _tempName);
            addWord.ShowDialog();
            WriteWordArray();
            if (definitionsToolStripMenuItem.Checked)
            {
                NewWordD();
            }
            else
            {
                NewWordS();
            }
        }
        private void addSynonym_Click(object sender, EventArgs e)
        {
            EditList addSyn = new EditList(true, false, false, _fileName, _tempName);
            addSyn.ShowDialog();
            WriteWordArray();
            if (definitionsToolStripMenuItem.Checked)
            {
                NewWordD();
            }
            else
            {
                NewWordS();
            }
        }
        private void changeWord_Click(object sender, EventArgs e)
        {
            EditList changeWord = new EditList(false, true, true, _fileName, _tempName);
            changeWord.ShowDialog();
            WriteWordArray();
            if (definitionsToolStripMenuItem.Checked)
            {
                NewWordD();
            }
            else
            {
                NewWordS();
            }
        }
        private void changeSynonym_Click(object sender, EventArgs e)
        {
            EditList changeSyn = new EditList(false, false, true, _fileName, _tempName);
            changeSyn.ShowDialog();
            WriteWordArray();
            if (definitionsToolStripMenuItem.Checked)
            {
                NewWordD();
            }
            else
            {
                NewWordS();
            }
        }
        private void eraseWord_Click(object sender, EventArgs e)
        {
            EditList eraseWord = new EditList(false, true, false, _fileName, _tempName);
            eraseWord.ShowDialog();
            WriteWordArray();
            if (definitionsToolStripMenuItem.Checked)
            {
                NewWordD();
            }
            else
            {
                NewWordS();
            }
        }
        private void eraseSynonym_Click(object sender, EventArgs e)
        {
            EditList eraseSyn = new EditList(false, false, false, _fileName, _tempName);
            eraseSyn.ShowDialog();
            WriteWordArray();
            if (definitionsToolStripMenuItem.Checked)
            {
                NewWordD();
            }
            else
            {
                NewWordS();
            }
        }
        private void showListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter fileW = new StreamWriter(_tempName, false);
            for (int i = 0; i < _vars; i++)
            {
                fileW.WriteLine("W" + (i + 1).ToString() + ". " + _words[i] + ": " + _defs[i]);
                fileW.WriteLine();
                for (int j = 0; j < _numSyn[i]; j++)
                {
                    fileW.WriteLine("   S" + (j + 1).ToString() + ". " + _sWords[i, j] + ": " + _sDefs[i, j]);
                }
                fileW.WriteLine();
            }
            fileW.Close();
            System.Diagnostics.Process.Start(_tempName);
        }
    }
}