namespace DecVarianceProject
{
    partial class MainForm
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
            this.MatchesNumTxtBx = new System.Windows.Forms.TextBox();
            this.MatchesNumLbl = new System.Windows.Forms.Label();
            this.BetsNumLbl = new System.Windows.Forms.Label();
            this.BetsNumTxtBx = new System.Windows.Forms.TextBox();
            this.RunBtn = new System.Windows.Forms.Button();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.dataGridViewProbsCoefs = new System.Windows.Forms.DataGridView();
            this.dataGridViewAllBets = new System.Windows.Forms.DataGridView();
            this.dataGridViewBets = new System.Windows.Forms.DataGridView();
            this.ReraiseMatchesTBX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RakeTBX = new System.Windows.Forms.MaskedTextBox();
            this.GenMatchDayResultsBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewMatchDayResults = new System.Windows.Forms.DataGridView();
            this.dataGridViewMatchesToRaise = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NetWonBeforeRaisingTBX = new System.Windows.Forms.TextBox();
            this.NetWonAfterRaisingTBX = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProbsCoefs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllBets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatchDayResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatchesToRaise)).BeginInit();
            this.SuspendLayout();
            // 
            // MatchesNumTxtBx
            // 
            this.MatchesNumTxtBx.Location = new System.Drawing.Point(115, 10);
            this.MatchesNumTxtBx.Name = "MatchesNumTxtBx";
            this.MatchesNumTxtBx.Size = new System.Drawing.Size(100, 20);
            this.MatchesNumTxtBx.TabIndex = 2;
            this.MatchesNumTxtBx.Text = "8";
            this.MatchesNumTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MatchesNumTxtBx_KeyPress);
            // 
            // MatchesNumLbl
            // 
            this.MatchesNumLbl.AutoSize = true;
            this.MatchesNumLbl.Location = new System.Drawing.Point(13, 13);
            this.MatchesNumLbl.Name = "MatchesNumLbl";
            this.MatchesNumLbl.Size = new System.Drawing.Size(99, 13);
            this.MatchesNumLbl.TabIndex = 3;
            this.MatchesNumLbl.Text = "Number of matches";
            // 
            // BetsNumLbl
            // 
            this.BetsNumLbl.AutoSize = true;
            this.BetsNumLbl.Location = new System.Drawing.Point(276, 13);
            this.BetsNumLbl.Name = "BetsNumLbl";
            this.BetsNumLbl.Size = new System.Drawing.Size(80, 13);
            this.BetsNumLbl.TabIndex = 4;
            this.BetsNumLbl.Text = "Number of Bets";
            // 
            // BetsNumTxtBx
            // 
            this.BetsNumTxtBx.Location = new System.Drawing.Point(372, 10);
            this.BetsNumTxtBx.Name = "BetsNumTxtBx";
            this.BetsNumTxtBx.Size = new System.Drawing.Size(100, 20);
            this.BetsNumTxtBx.TabIndex = 5;
            this.BetsNumTxtBx.Text = "100";
            this.BetsNumTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BetsNumTxtBx_KeyPress);
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(970, 6);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(75, 23);
            this.RunBtn.TabIndex = 6;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Location = new System.Drawing.Point(600, 65);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.RowHeadersVisible = false;
            this.dataGridViewResults.Size = new System.Drawing.Size(637, 475);
            this.dataGridViewResults.TabIndex = 2;
            // 
            // dataGridViewProbsCoefs
            // 
            this.dataGridViewProbsCoefs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProbsCoefs.Location = new System.Drawing.Point(16, 65);
            this.dataGridViewProbsCoefs.Name = "dataGridViewProbsCoefs";
            this.dataGridViewProbsCoefs.RowHeadersVisible = false;
            this.dataGridViewProbsCoefs.Size = new System.Drawing.Size(561, 191);
            this.dataGridViewProbsCoefs.TabIndex = 11;
            // 
            // dataGridViewAllBets
            // 
            this.dataGridViewAllBets.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAllBets.Name = "dataGridViewAllBets";
            this.dataGridViewAllBets.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewAllBets.TabIndex = 0;
            // 
            // dataGridViewBets
            // 
            this.dataGridViewBets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBets.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dataGridViewBets.Location = new System.Drawing.Point(16, 262);
            this.dataGridViewBets.Name = "dataGridViewBets";
            this.dataGridViewBets.RowHeadersVisible = false;
            this.dataGridViewBets.Size = new System.Drawing.Size(561, 278);
            this.dataGridViewBets.TabIndex = 13;
            // 
            // ReraiseMatchesTBX
            // 
            this.ReraiseMatchesTBX.Location = new System.Drawing.Point(657, 9);
            this.ReraiseMatchesTBX.Name = "ReraiseMatchesTBX";
            this.ReraiseMatchesTBX.Size = new System.Drawing.Size(100, 20);
            this.ReraiseMatchesTBX.TabIndex = 15;
            this.ReraiseMatchesTBX.Text = "3";
            this.ReraiseMatchesTBX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReraiseMatchesTBX_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(518, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Number of raise matches";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(785, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Rake";
            // 
            // RakeTBX
            // 
            this.RakeTBX.Location = new System.Drawing.Point(836, 9);
            this.RakeTBX.Name = "RakeTBX";
            this.RakeTBX.Size = new System.Drawing.Size(100, 20);
            this.RakeTBX.TabIndex = 18;
            this.RakeTBX.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.RakeTBX_MaskInputRejected);
            // 
            // GenMatchDayResultsBTN
            // 
            this.GenMatchDayResultsBTN.Location = new System.Drawing.Point(1064, 6);
            this.GenMatchDayResultsBTN.Name = "GenMatchDayResultsBTN";
            this.GenMatchDayResultsBTN.Size = new System.Drawing.Size(136, 23);
            this.GenMatchDayResultsBTN.TabIndex = 19;
            this.GenMatchDayResultsBTN.Text = "Gen MatchDay Results";
            this.GenMatchDayResultsBTN.UseVisualStyleBackColor = true;
            this.GenMatchDayResultsBTN.Click += new System.EventHandler(this.GenMatchDayResultsBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 562);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "MatchDay Results";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 562);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Matches to raise";
            // 
            // dataGridViewMatchDayResults
            // 
            this.dataGridViewMatchDayResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatchDayResults.Location = new System.Drawing.Point(21, 578);
            this.dataGridViewMatchDayResults.Name = "dataGridViewMatchDayResults";
            this.dataGridViewMatchDayResults.RowHeadersVisible = false;
            this.dataGridViewMatchDayResults.Size = new System.Drawing.Size(215, 221);
            this.dataGridViewMatchDayResults.TabIndex = 24;
            // 
            // dataGridViewMatchesToRaise
            // 
            this.dataGridViewMatchesToRaise.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatchesToRaise.Location = new System.Drawing.Point(413, 578);
            this.dataGridViewMatchesToRaise.Name = "dataGridViewMatchesToRaise";
            this.dataGridViewMatchesToRaise.RowHeadersVisible = false;
            this.dataGridViewMatchesToRaise.Size = new System.Drawing.Size(217, 221);
            this.dataGridViewMatchesToRaise.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(793, 589);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Marathon matchday result before raising";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(793, 624);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Marathon matchday result after raising";
            // 
            // NetWonBeforeRaisingTBX
            // 
            this.NetWonBeforeRaisingTBX.Location = new System.Drawing.Point(1032, 586);
            this.NetWonBeforeRaisingTBX.Name = "NetWonBeforeRaisingTBX";
            this.NetWonBeforeRaisingTBX.ReadOnly = true;
            this.NetWonBeforeRaisingTBX.Size = new System.Drawing.Size(100, 20);
            this.NetWonBeforeRaisingTBX.TabIndex = 28;
            // 
            // NetWonAfterRaisingTBX
            // 
            this.NetWonAfterRaisingTBX.Location = new System.Drawing.Point(1032, 617);
            this.NetWonAfterRaisingTBX.Name = "NetWonAfterRaisingTBX";
            this.NetWonAfterRaisingTBX.ReadOnly = true;
            this.NetWonAfterRaisingTBX.Size = new System.Drawing.Size(100, 20);
            this.NetWonAfterRaisingTBX.TabIndex = 29;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 811);
            this.Controls.Add(this.NetWonAfterRaisingTBX);
            this.Controls.Add(this.NetWonBeforeRaisingTBX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridViewMatchesToRaise);
            this.Controls.Add(this.dataGridViewMatchDayResults);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GenMatchDayResultsBTN);
            this.Controls.Add(this.RakeTBX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ReraiseMatchesTBX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewBets);
            this.Controls.Add(this.MatchesNumLbl);
            this.Controls.Add(this.dataGridViewProbsCoefs);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.RunBtn);
            this.Controls.Add(this.BetsNumTxtBx);
            this.Controls.Add(this.BetsNumLbl);
            this.Controls.Add(this.MatchesNumTxtBx);
            this.Name = "MainForm";
            this.Text = "Marathon";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProbsCoefs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllBets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatchDayResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatchesToRaise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MatchesNumTxtBx;
        private System.Windows.Forms.Label MatchesNumLbl;
        private System.Windows.Forms.Label BetsNumLbl;
        private System.Windows.Forms.TextBox BetsNumTxtBx;
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.DataGridView dataGridViewProbsCoefs;
        private System.Windows.Forms.DataGridView dataGridViewAllBets;
        private System.Windows.Forms.DataGridView dataGridViewBets;
        private System.Windows.Forms.TextBox ReraiseMatchesTBX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox RakeTBX;
        private System.Windows.Forms.Button GenMatchDayResultsBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewMatchDayResults;
        private System.Windows.Forms.DataGridView dataGridViewMatchesToRaise;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NetWonBeforeRaisingTBX;
        private System.Windows.Forms.TextBox NetWonAfterRaisingTBX;
    }
}

