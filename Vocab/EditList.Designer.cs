namespace Vocab
{
    partial class EditList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WordCB = new System.Windows.Forms.ComboBox();
            this.Word = new System.Windows.Forms.Label();
            this.Syn = new System.Windows.Forms.Label();
            this.Def = new System.Windows.Forms.Label();
            this.SynTB = new System.Windows.Forms.TextBox();
            this.DefTB = new System.Windows.Forms.TextBox();
            this.SynCB = new System.Windows.Forms.ComboBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.WordTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // WordCB
            // 
            this.WordCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.WordCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.WordCB.Location = new System.Drawing.Point(94, 12);
            this.WordCB.Name = "WordCB";
            this.WordCB.Size = new System.Drawing.Size(121, 21);
            this.WordCB.TabIndex = 0;
            this.WordCB.SelectedIndexChanged += new System.EventHandler(this.WordCB_SelectedIndexChanged);
            // 
            // Word
            // 
            this.Word.AutoSize = true;
            this.Word.Location = new System.Drawing.Point(14, 15);
            this.Word.Name = "Word";
            this.Word.Size = new System.Drawing.Size(33, 13);
            this.Word.TabIndex = 1;
            this.Word.Text = "Word";
            // 
            // Syn
            // 
            this.Syn.AutoSize = true;
            this.Syn.Location = new System.Drawing.Point(14, 42);
            this.Syn.Name = "Syn";
            this.Syn.Size = new System.Drawing.Size(50, 13);
            this.Syn.TabIndex = 2;
            this.Syn.Text = "Synonym";
            // 
            // Def
            // 
            this.Def.AutoSize = true;
            this.Def.Location = new System.Drawing.Point(14, 69);
            this.Def.Name = "Def";
            this.Def.Size = new System.Drawing.Size(51, 13);
            this.Def.TabIndex = 3;
            this.Def.Text = "Definition";
            // 
            // SynTB
            // 
            this.SynTB.Location = new System.Drawing.Point(94, 39);
            this.SynTB.Name = "SynTB";
            this.SynTB.Size = new System.Drawing.Size(100, 20);
            this.SynTB.TabIndex = 3;
            // 
            // DefTB
            // 
            this.DefTB.Location = new System.Drawing.Point(94, 66);
            this.DefTB.Name = "DefTB";
            this.DefTB.Size = new System.Drawing.Size(100, 20);
            this.DefTB.TabIndex = 4;
            // 
            // SynCB
            // 
            this.SynCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.SynCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.SynCB.FormattingEnabled = true;
            this.SynCB.Location = new System.Drawing.Point(94, 39);
            this.SynCB.Name = "SynCB";
            this.SynCB.Size = new System.Drawing.Size(121, 21);
            this.SynCB.TabIndex = 2;
            this.SynCB.SelectedIndexChanged += new System.EventHandler(this.SynCB_SelectedIndexChanged);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(36, 92);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 5;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(119, 92);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // WordTB
            // 
            this.WordTB.Location = new System.Drawing.Point(94, 12);
            this.WordTB.Name = "WordTB";
            this.WordTB.Size = new System.Drawing.Size(100, 20);
            this.WordTB.TabIndex = 1;
            // 
            // EditList
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 120);
            this.Controls.Add(this.WordTB);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.DefTB);
            this.Controls.Add(this.SynTB);
            this.Controls.Add(this.Def);
            this.Controls.Add(this.Syn);
            this.Controls.Add(this.Word);
            this.Controls.Add(this.WordCB);
            this.Controls.Add(this.SynCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "EditList";
            this.ShowIcon = false;
            this.Text = "Edit List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox WordCB;
        private System.Windows.Forms.Label Word;
        private System.Windows.Forms.Label Syn;
        private System.Windows.Forms.Label Def;
        private System.Windows.Forms.TextBox SynTB;
        private System.Windows.Forms.TextBox DefTB;
        private System.Windows.Forms.ComboBox SynCB;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TextBox WordTB;
    }
}