using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace Vocab
{
    public partial class EditList : Form
    {
        #region global variables
        StreamReader _fileR;
        StreamWriter _fileW;
        string cbWord;
        string cbSyn;
        string tbDef;
        bool _add;
        bool _word;
        bool _change;
        string _fileName;
        string _tempName;
        #endregion
        public EditList(bool add,bool word, bool change, string file, string tempName)
        {
            _add = add;
            _word = word;
            _change = change;
            _fileName = file;
            _tempName = tempName;
            InitializeComponent();
            if (_add)
            {
                if(_word)
                {
                    this.Text = "Add Word";
                    WordCB.Visible = false;
                    SynCB.Visible = false;
                    SynTB.Visible = false;
                    Syn.Visible = false;
                }
                else
                {
                    this.Text = "Add Synonym";
                    WordTB.Visible = false;
                    SynCB.Visible = false;
                    _fileR = new StreamReader(_fileName);
                    while (!_fileR.EndOfStream)
                    {
                        string temp = _fileR.ReadLine();
                        if (temp == "/")
                            WordCB.Items.Add(_fileR.ReadLine());
                    }
                    _fileR.Close();
                    WordCB.Sorted = true;
                    WordCB.Update();
                }
            }
            else if (_change)
            {
                if (_word)
                {
                    this.Text = "Change Word";
                    WordTB.Visible = false;
                    SynCB.Visible = false;
                    SynTB.Visible = false;
                    Syn.Visible = false;
                    _fileR = new StreamReader(_fileName);
                    while (!_fileR.EndOfStream)
                    {
                        string temp = _fileR.ReadLine();
                        if (temp == "/")
                            WordCB.Items.Add(_fileR.ReadLine());
                    }
                    _fileR.Close();
                    WordCB.Sorted = true;
                    WordCB.Update();
                }
                else
                {
                    this.Text = "Change Synonym";
                    WordTB.Visible = false;
                    SynTB.Visible = false;
                    _fileR = new StreamReader(_fileName);
                    while (!_fileR.EndOfStream)
                    {
                        string temp = _fileR.ReadLine();
                        if (temp == "/")
                            WordCB.Items.Add(_fileR.ReadLine());
                    }
                    _fileR.Close();
                    WordCB.Sorted = true;
                    WordCB.Update();
                }
            }
            else
            {
                if (_word)
                {
                    this.Text = "Erase Word";
                    WordTB.Visible = false;
                    SynTB.Visible = false;
                    SynCB.Visible = false;
                    _fileR = new StreamReader(_fileName);
                    while (!_fileR.EndOfStream)
                    {
                        string temp = _fileR.ReadLine();
                        if (temp == "/")
                            WordCB.Items.Add(_fileR.ReadLine());
                    }
                    _fileR.Close();
                    WordCB.Sorted = true;
                    WordCB.Update();
                }
                else
                {
                    this.Text = "Erase Synonym";
                    WordTB.Visible = false;
                    SynTB.Visible = false;
                    _fileR = new StreamReader(_fileName);
                    while (!_fileR.EndOfStream)
                    {
                        string temp = _fileR.ReadLine();
                        if (temp == "/")
                            WordCB.Items.Add(_fileR.ReadLine());
                    }
                    _fileR.Close();
                    WordCB.Sorted = true;
                    WordCB.Update();
                }
            }
        }
        private void WordCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SynCB.Items.Clear();
            cbWord = WordCB.Text;
            _fileR = new StreamReader(_fileName);
            if (SynCB.Visible == true)
            {
                while (!_fileR.EndOfStream)
                {
                    string temp = _fileR.ReadLine();
                    if (temp == WordCB.Text)
                    {
                        _fileR.ReadLine();
                        temp = _fileR.ReadLine();
                        while (temp != "/")
                        {
                            SynCB.Items.Add(temp);
                            _fileR.ReadLine();
                            temp = _fileR.ReadLine();
                        }
                    }
                }
            }
            else if (SynTB.Visible == false)
            {
                while (!_fileR.EndOfStream)
                {
                    string temp = _fileR.ReadLine();
                    if (temp == WordCB.Text)
                    {
                        DefTB.Text = _fileR.ReadLine();
                        break;
                    }
                }
            }
            _fileR.Close();
            SynCB.Sorted = true;
            SynCB.Update();
        }
        private void SynCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSyn = SynCB.Text;
            _fileR = new StreamReader(_fileName);
            while (!_fileR.EndOfStream)
            {
                string temp = _fileR.ReadLine();
                if (temp == SynCB.Text)
                {
                    DefTB.Text = _fileR.ReadLine();
                    break;
                }
            }
            _fileR.Close();
            SynCB.Update();
            tbDef = DefTB.Text;
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ok_Click(object sender, EventArgs e)
        {
            if (_add)
            {
                if (_word)
                {
                    addWordOk();
                }
                else
                {
                    addSynOk();
                }
            }
            else if (_change)
            {
                if (_word)
                {
                    changeWordOk();
                }
                else
                {
                    changeSynOk();
                }
            }
            else
            {
                if (_word)
                {
                    eraseWordOk();
                }
                else
                {
                    eraseSynOk(sender, e);
                }
            }
        }
        private void addWordOk()
        {
            if (WordTB.Text != "")
            {
                if (DefTB.Text == "")
                {
                    MessageBox.Show("You must enter a definition!", "No Definition", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _fileR = new StreamReader(_fileName);
                    _fileW = new StreamWriter(_tempName, false);
                    bool slash = false;
                    bool exists = false;
                    while (!_fileR.EndOfStream)
                    {
                        string temp = _fileR.ReadLine();
                        if (slash && temp.ToLower() == WordTB.Text.ToLower())
                        {
                            MessageBox.Show("That word already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            exists = true;
                        }
                        slash = (temp == "/") ? true : false;
                        _fileW.WriteLine(temp);
                    }
                    if (!exists)
                    {
                        _fileW.WriteLine("/");
                        _fileW.WriteLine(WordTB.Text);
                        _fileW.WriteLine(DefTB.Text);
                        WordTB.Text = "";
                        DefTB.Text = "";
                        cbSyn = "";
                        cbWord = "";
                        tbDef = "";
                    }
                    WordTB.Focus();
                    _fileR.Close();
                    _fileW.Close();
                    _fileR = new StreamReader(_tempName);
                    _fileW = new StreamWriter(_fileName, false);
                    while (!_fileR.EndOfStream)
                    {
                        _fileW.WriteLine(_fileR.ReadLine());
                    }
                    _fileR.Close();
                    _fileW.Close();
                }
            }
        }
        private void addSynOk()
        {
            if (cbWord != "" && SynTB.Text != "")
            {
                if (DefTB.Text == "")
                {
                    MessageBox.Show("You must enter a definition!", "No Definition", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _fileR = new StreamReader(_fileName);
                    _fileW = new StreamWriter(_tempName, false);
                    while (!_fileR.EndOfStream)
                    {
                        string temp = _fileR.ReadLine();
                        if (temp == cbWord)
                        {
                            _fileW.WriteLine(temp);
                            _fileW.WriteLine(_fileR.ReadLine());
                            _fileW.WriteLine(SynTB.Text);
                            _fileW.WriteLine(DefTB.Text);
                            while (!_fileR.EndOfStream)
                            {
                                _fileW.WriteLine(_fileR.ReadLine());
                            }
                            _fileR.Close();
                            _fileW.Close();
                            _fileR = new StreamReader(_tempName);
                            _fileW = new StreamWriter(_fileName, false);
                            while (!_fileR.EndOfStream)
                            {
                                _fileW.WriteLine(_fileR.ReadLine());
                            }
                        }
                        else
                        {
                            _fileW.WriteLine(temp);
                        }
                    }
                    SynTB.Text = "";
                    DefTB.Text = "";
                    cbSyn = "";
                    tbDef = "";
                    SynTB.Focus();
                    _fileR.Close();
                    _fileW.Close();
                }
            }
        }
        private void changeWordOk()
        {
            if (WordCB.Text != "")
            {
                if (DefTB.Text == "")
                {
                    MessageBox.Show("You must enter a definition!", "No Definition", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _fileR = new StreamReader(_fileName);
                    _fileW = new StreamWriter(_tempName, false);
                    while (!_fileR.EndOfStream)
                    {
                        string temp = _fileR.ReadLine();
                        if (temp == cbWord)
                        {
                            _fileR.ReadLine();
                            _fileW.WriteLine(WordCB.Text);
                            _fileW.WriteLine(DefTB.Text);
                            while (!_fileR.EndOfStream)
                            {
                                _fileW.WriteLine(_fileR.ReadLine());
                            }
                            _fileR.Close();
                            _fileW.Close();
                            _fileR = new StreamReader(_tempName);
                            _fileW = new StreamWriter(_fileName, false);
                            while (!_fileR.EndOfStream)
                            {
                                _fileW.WriteLine(_fileR.ReadLine());
                            }
                            _fileR.Close();
                            _fileW.Close();

                        }
                        else
                        {
                            _fileW.WriteLine(temp);
                        }
                    }
                    WordCB.Text = "";
                    DefTB.Text = "";
                    cbSyn = "";
                    cbWord = "";
                    tbDef = "";
                    WordCB.Focus();
                    _fileR.Close();
                    _fileW.Close();
                }
            }
        }
        private void changeSynOk()
        {
            if (cbWord != "" && cbSyn != "" && SynCB.Text != "")
            {
                if (DefTB.Text == "")
                {
                    MessageBox.Show("You must enter a definition!", "No Definition", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _fileR = new StreamReader(_fileName);
                    _fileW = new StreamWriter(_tempName, false);
                    while (!_fileR.EndOfStream)
                    {
                        string temp = _fileR.ReadLine();
                        if (temp == cbWord)
                        {
                            _fileW.WriteLine(temp);
                            _fileW.WriteLine(_fileR.ReadLine());

                            while (!_fileR.EndOfStream)
                            {
                                temp = _fileR.ReadLine();
                                if (temp == cbSyn)
                                {
                                    _fileR.ReadLine();
                                    _fileW.WriteLine(SynCB.Text);
                                    _fileW.WriteLine(DefTB.Text);
                                    while (!_fileR.EndOfStream)
                                    {
                                        _fileW.WriteLine(_fileR.ReadLine());
                                    }
                                }
                                else
                                {
                                    _fileW.WriteLine(temp);
                                }
                            }
                            _fileR.Close();
                            _fileW.Close();
                            _fileR = new StreamReader(_tempName);
                            _fileW = new StreamWriter(_fileName, false);
                            while (!_fileR.EndOfStream)
                            {
                                _fileW.WriteLine(_fileR.ReadLine());
                            }
                        }
                        else
                        {
                            _fileW.WriteLine(temp);
                        }
                    }
                    WordCB.Text = "";
                    SynCB.Text = "";
                    DefTB.Text = "";
                    cbSyn = "";
                    cbWord = "";
                    tbDef = "";
                    WordCB.Focus();
                    _fileR.Close();
                    _fileW.Close();
                }
            }
        }
        private void eraseWordOk()
        {
            if (cbWord != "")
            {
                _fileR = new StreamReader(_fileName);
                _fileW = new StreamWriter(_tempName, false);
                while (!_fileR.EndOfStream)
                {
                    string temp = _fileR.ReadLine();
                    if (temp == "/")
                    {
                        temp = _fileR.ReadLine();
                        if (temp == cbWord)
                        {
                            while (!_fileR.EndOfStream)
                            {
                                temp = _fileR.ReadLine();
                                if (temp == "/")
                                {
                                    while (!_fileR.EndOfStream)
                                    {
                                        _fileW.WriteLine(_fileR.ReadLine());
                                    }
                                }
                            }
                            _fileR.Close();
                            _fileW.Close();
                            _fileR = new StreamReader(_tempName);
                            _fileW = new StreamWriter(_fileName, false);
                            while (!_fileR.EndOfStream)
                            {
                                _fileW.WriteLine(_fileR.ReadLine());
                            }
                        }
                        else
                        {
                            _fileW.WriteLine("/");
                            _fileW.WriteLine(temp);
                        }
                    }
                    else
                    {
                        _fileW.WriteLine(temp);
                    }
                }
                WordCB.Text = "";
                DefTB.Text = "";
                cbSyn = "";
                cbWord = "";
                tbDef = "";
                WordCB.Focus();
                _fileR.Close();
                _fileW.Close();
            }
        }
        private void eraseSynOk(object sender, EventArgs e)
        {
            if (cbWord != "" && cbSyn != "")
            {
                _fileR = new StreamReader(_fileName);
                _fileW = new StreamWriter(_tempName, false);
                while (!_fileR.EndOfStream)
                {
                    string temp = _fileR.ReadLine();
                    if (temp == cbWord)
                    {
                        _fileW.WriteLine(temp);
                        while (!_fileR.EndOfStream)
                        {
                            temp = _fileR.ReadLine();
                            if (temp == cbSyn)
                            {
                                _fileR.ReadLine();
                                while (!_fileR.EndOfStream)
                                {
                                    _fileW.WriteLine(_fileR.ReadLine());
                                }
                            }
                            else
                            {
                                _fileW.WriteLine(temp);
                            }
                        }
                        _fileR.Close();
                        _fileW.Close();
                        _fileR = new StreamReader(_tempName);
                        _fileW = new StreamWriter(_fileName, false);
                        while (!_fileR.EndOfStream)
                        {
                            _fileW.WriteLine(_fileR.ReadLine());
                        }
                    }
                    else
                    {
                        _fileW.WriteLine(temp);
                    }
                }
                _fileR.Close();
                _fileW.Close();
                WordCB.Text = cbWord;
                WordCB_SelectedIndexChanged(sender, e);
                SynCB.Text = "";
                DefTB.Text = "";
                SynCB.Focus();
                cbSyn = "";
                tbDef = "";
            }
        }
    }
}