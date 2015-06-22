namespace DecVarianceProject
{
    partial class Form1
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
            this.RTB_rez = new System.Windows.Forms.RichTextBox();
            this.RTB_Info = new System.Windows.Forms.RichTextBox();
            this.MatchesNumTxtBx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BetsNumTxtBx = new System.Windows.Forms.TextBox();
            this.RunBtn = new System.Windows.Forms.Button();
            this.ProbsCoefsTable = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RTB_rez
            // 
            this.RTB_rez.Location = new System.Drawing.Point(583, 46);
            this.RTB_rez.Name = "RTB_rez";
            this.RTB_rez.Size = new System.Drawing.Size(686, 496);
            this.RTB_rez.TabIndex = 0;
            this.RTB_rez.Text = "";
            // 
            // RTB_Info
            // 
            this.RTB_Info.Location = new System.Drawing.Point(12, 238);
            this.RTB_Info.Name = "RTB_Info";
            this.RTB_Info.Size = new System.Drawing.Size(565, 304);
            this.RTB_Info.TabIndex = 1;
            this.RTB_Info.Text = "";
            // 
            // MatchesNumTxtBx
            // 
            this.MatchesNumTxtBx.Location = new System.Drawing.Point(115, 10);
            this.MatchesNumTxtBx.Name = "MatchesNumTxtBx";
            this.MatchesNumTxtBx.Size = new System.Drawing.Size(100, 20);
            this.MatchesNumTxtBx.TabIndex = 2;
            this.MatchesNumTxtBx.TextChanged += new System.EventHandler(this.MatchesNumTxtBx_TextChanged);
            this.MatchesNumTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MatchesNumTxtBx_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of matches";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of Bets";
            // 
            // BetsNumTxtBx
            // 
            this.BetsNumTxtBx.Location = new System.Drawing.Point(372, 10);
            this.BetsNumTxtBx.Name = "BetsNumTxtBx";
            this.BetsNumTxtBx.Size = new System.Drawing.Size(100, 20);
            this.BetsNumTxtBx.TabIndex = 5;
            this.BetsNumTxtBx.TextChanged += new System.EventHandler(this.BetsNumTxtBx_TextChanged);
            this.BetsNumTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BetsNumTxtBx_KeyPress);
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(1092, 13);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(75, 23);
            this.RunBtn.TabIndex = 6;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // ProbsCoefsTable
            // 
            this.ProbsCoefsTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.ProbsCoefsTable.ColumnCount = 7;
            this.ProbsCoefsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.ProbsCoefsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.ProbsCoefsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.ProbsCoefsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.ProbsCoefsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.ProbsCoefsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.ProbsCoefsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.ProbsCoefsTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.ProbsCoefsTable.Location = new System.Drawing.Point(13, 9);
            this.ProbsCoefsTable.Name = "ProbsCoefsTable";
            this.ProbsCoefsTable.RowCount = 22;
            this.ProbsCoefsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.29412F));
            this.ProbsCoefsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.82354F));
            this.ProbsCoefsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.ProbsCoefsTable.Size = new System.Drawing.Size(512, 143);
            this.ProbsCoefsTable.TabIndex = 7;
            this.ProbsCoefsTable.Paint += new System.Windows.Forms.PaintEventHandler(this.ProbsCoefsTable_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Matches";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Probabilities";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Coefs";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ProbsCoefsTable);
            this.groupBox1.Controls.Add(this.vScrollBar1);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 163);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(528, 9);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 143);
            this.vScrollBar1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 573);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RunBtn);
            this.Controls.Add(this.BetsNumTxtBx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MatchesNumTxtBx);
            this.Controls.Add(this.RTB_Info);
            this.Controls.Add(this.RTB_rez);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTB_rez;
        private System.Windows.Forms.RichTextBox RTB_Info;
        private System.Windows.Forms.TextBox MatchesNumTxtBx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BetsNumTxtBx;
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.TableLayoutPanel ProbsCoefsTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}

