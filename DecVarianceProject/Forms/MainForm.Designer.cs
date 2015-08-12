namespace DecVarianceProject.Forms
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
            this.RaiseSumPercentTBX = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RaiseSumTBX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AllBetsSumTBX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TestEvaluationBTN = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EvBeforeTBX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.EvAfterTBX = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.AnalysisBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProbsCoefs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllBets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatchDayResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatchesToRaise)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MatchesNumTxtBx
            // 
            this.MatchesNumTxtBx.Location = new System.Drawing.Point(115, 46);
            this.MatchesNumTxtBx.Name = "MatchesNumTxtBx";
            this.MatchesNumTxtBx.Size = new System.Drawing.Size(100, 20);
            this.MatchesNumTxtBx.TabIndex = 2;
            this.MatchesNumTxtBx.Text = "8";
            this.MatchesNumTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MatchesNumTxtBx_KeyPress);
            // 
            // MatchesNumLbl
            // 
            this.MatchesNumLbl.AutoSize = true;
            this.MatchesNumLbl.Location = new System.Drawing.Point(13, 49);
            this.MatchesNumLbl.Name = "MatchesNumLbl";
            this.MatchesNumLbl.Size = new System.Drawing.Size(99, 13);
            this.MatchesNumLbl.TabIndex = 3;
            this.MatchesNumLbl.Text = "Number of matches";
            // 
            // BetsNumLbl
            // 
            this.BetsNumLbl.AutoSize = true;
            this.BetsNumLbl.Location = new System.Drawing.Point(276, 49);
            this.BetsNumLbl.Name = "BetsNumLbl";
            this.BetsNumLbl.Size = new System.Drawing.Size(80, 13);
            this.BetsNumLbl.TabIndex = 4;
            this.BetsNumLbl.Text = "Number of Bets";
            // 
            // BetsNumTxtBx
            // 
            this.BetsNumTxtBx.Location = new System.Drawing.Point(372, 46);
            this.BetsNumTxtBx.Name = "BetsNumTxtBx";
            this.BetsNumTxtBx.Size = new System.Drawing.Size(100, 20);
            this.BetsNumTxtBx.TabIndex = 5;
            this.BetsNumTxtBx.Text = "100";
            this.BetsNumTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BetsNumTxtBx_KeyPress);
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(970, 42);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(75, 23);
            this.RunBtn.TabIndex = 6;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.AllowUserToAddRows = false;
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Location = new System.Drawing.Point(599, 118);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.ReadOnly = true;
            this.dataGridViewResults.RowHeadersVisible = false;
            this.dataGridViewResults.Size = new System.Drawing.Size(637, 475);
            this.dataGridViewResults.TabIndex = 2;
            // 
            // dataGridViewProbsCoefs
            // 
            this.dataGridViewProbsCoefs.AllowUserToAddRows = false;
            this.dataGridViewProbsCoefs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProbsCoefs.Location = new System.Drawing.Point(15, 118);
            this.dataGridViewProbsCoefs.Name = "dataGridViewProbsCoefs";
            this.dataGridViewProbsCoefs.ReadOnly = true;
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
            this.dataGridViewBets.AllowUserToAddRows = false;
            this.dataGridViewBets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBets.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dataGridViewBets.Location = new System.Drawing.Point(15, 315);
            this.dataGridViewBets.Name = "dataGridViewBets";
            this.dataGridViewBets.ReadOnly = true;
            this.dataGridViewBets.RowHeadersVisible = false;
            this.dataGridViewBets.Size = new System.Drawing.Size(561, 278);
            this.dataGridViewBets.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(785, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Rake";
            // 
            // RakeTBX
            // 
            this.RakeTBX.Location = new System.Drawing.Point(836, 45);
            this.RakeTBX.Mask = "0.000";
            this.RakeTBX.Name = "RakeTBX";
            this.RakeTBX.Size = new System.Drawing.Size(100, 20);
            this.RakeTBX.TabIndex = 18;
            this.RakeTBX.Text = "0050";
            this.RakeTBX.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.RakeTBX_MaskInputRejected);
            // 
            // GenMatchDayResultsBTN
            // 
            this.GenMatchDayResultsBTN.Location = new System.Drawing.Point(1064, 42);
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
            this.label3.Location = new System.Drawing.Point(18, 598);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "MatchDay Results";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 598);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Matches to raise";
            // 
            // dataGridViewMatchDayResults
            // 
            this.dataGridViewMatchDayResults.AllowUserToAddRows = false;
            this.dataGridViewMatchDayResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatchDayResults.Location = new System.Drawing.Point(21, 614);
            this.dataGridViewMatchDayResults.Name = "dataGridViewMatchDayResults";
            this.dataGridViewMatchDayResults.RowHeadersVisible = false;
            this.dataGridViewMatchDayResults.Size = new System.Drawing.Size(215, 221);
            this.dataGridViewMatchDayResults.TabIndex = 24;
            // 
            // dataGridViewMatchesToRaise
            // 
            this.dataGridViewMatchesToRaise.AllowUserToAddRows = false;
            this.dataGridViewMatchesToRaise.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatchesToRaise.Location = new System.Drawing.Point(413, 614);
            this.dataGridViewMatchesToRaise.Name = "dataGridViewMatchesToRaise";
            this.dataGridViewMatchesToRaise.ReadOnly = true;
            this.dataGridViewMatchesToRaise.RowHeadersVisible = false;
            this.dataGridViewMatchesToRaise.Size = new System.Drawing.Size(266, 221);
            this.dataGridViewMatchesToRaise.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(785, 707);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Marathon matchday result before raising";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(785, 742);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Marathon matchday result after raising";
            // 
            // NetWonBeforeRaisingTBX
            // 
            this.NetWonBeforeRaisingTBX.Location = new System.Drawing.Point(1024, 704);
            this.NetWonBeforeRaisingTBX.Name = "NetWonBeforeRaisingTBX";
            this.NetWonBeforeRaisingTBX.ReadOnly = true;
            this.NetWonBeforeRaisingTBX.Size = new System.Drawing.Size(100, 20);
            this.NetWonBeforeRaisingTBX.TabIndex = 28;
            // 
            // NetWonAfterRaisingTBX
            // 
            this.NetWonAfterRaisingTBX.Location = new System.Drawing.Point(1024, 735);
            this.NetWonAfterRaisingTBX.Name = "NetWonAfterRaisingTBX";
            this.NetWonAfterRaisingTBX.ReadOnly = true;
            this.NetWonAfterRaisingTBX.Size = new System.Drawing.Size(100, 20);
            this.NetWonAfterRaisingTBX.TabIndex = 29;
            // 
            // RaiseSumPercentTBX
            // 
            this.RaiseSumPercentTBX.Location = new System.Drawing.Point(639, 46);
            this.RaiseSumPercentTBX.Mask = "0.00";
            this.RaiseSumPercentTBX.Name = "RaiseSumPercentTBX";
            this.RaiseSumPercentTBX.Size = new System.Drawing.Size(100, 20);
            this.RaiseSumPercentTBX.TabIndex = 31;
            this.RaiseSumPercentTBX.Text = "005";
            this.RaiseSumPercentTBX.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.RaiseSumTBX_MaskInputRejected);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(521, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Raise matches sum,%";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // RaiseSumTBX
            // 
            this.RaiseSumTBX.Location = new System.Drawing.Point(1024, 667);
            this.RaiseSumTBX.Name = "RaiseSumTBX";
            this.RaiseSumTBX.ReadOnly = true;
            this.RaiseSumTBX.Size = new System.Drawing.Size(100, 20);
            this.RaiseSumTBX.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(905, 670);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Raise sum";
            // 
            // AllBetsSumTBX
            // 
            this.AllBetsSumTBX.Location = new System.Drawing.Point(1024, 629);
            this.AllBetsSumTBX.Name = "AllBetsSumTBX";
            this.AllBetsSumTBX.ReadOnly = true;
            this.AllBetsSumTBX.Size = new System.Drawing.Size(100, 20);
            this.AllBetsSumTBX.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(900, 629);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "All bets summ";
            // 
            // TestEvaluationBTN
            // 
            this.TestEvaluationBTN.Location = new System.Drawing.Point(970, 75);
            this.TestEvaluationBTN.Name = "TestEvaluationBTN";
            this.TestEvaluationBTN.Size = new System.Drawing.Size(94, 23);
            this.TestEvaluationBTN.TabIndex = 36;
            this.TestEvaluationBTN.Text = "Test Evaluation";
            this.TestEvaluationBTN.UseVisualStyleBackColor = true;
            this.TestEvaluationBTN.Click += new System.EventHandler(this.TestEvaluationBTN_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1248, 24);
            this.menuStrip.TabIndex = 37;
            this.menuStrip.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // EvBeforeTBX
            // 
            this.EvBeforeTBX.Location = new System.Drawing.Point(1024, 769);
            this.EvBeforeTBX.Name = "EvBeforeTBX";
            this.EvBeforeTBX.ReadOnly = true;
            this.EvBeforeTBX.Size = new System.Drawing.Size(100, 20);
            this.EvBeforeTBX.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(785, 776);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "EV before";
            // 
            // EvAfterTBX
            // 
            this.EvAfterTBX.Location = new System.Drawing.Point(1024, 795);
            this.EvAfterTBX.Name = "EvAfterTBX";
            this.EvAfterTBX.ReadOnly = true;
            this.EvAfterTBX.Size = new System.Drawing.Size(100, 20);
            this.EvAfterTBX.TabIndex = 41;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(785, 802);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "EV after";
            // 
            // AnalysisBTN
            // 
            this.AnalysisBTN.Location = new System.Drawing.Point(1083, 75);
            this.AnalysisBTN.Name = "AnalysisBTN";
            this.AnalysisBTN.Size = new System.Drawing.Size(94, 23);
            this.AnalysisBTN.TabIndex = 42;
            this.AnalysisBTN.Text = "Analysis";
            this.AnalysisBTN.UseVisualStyleBackColor = true;
            this.AnalysisBTN.Click += new System.EventHandler(this.AnalysisBTN_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 866);
            this.Controls.Add(this.AnalysisBTN);
            this.Controls.Add(this.EvAfterTBX);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.EvBeforeTBX);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TestEvaluationBTN);
            this.Controls.Add(this.AllBetsSumTBX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.RaiseSumTBX);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.RaiseSumPercentTBX);
            this.Controls.Add(this.label7);
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
            this.Controls.Add(this.dataGridViewBets);
            this.Controls.Add(this.MatchesNumLbl);
            this.Controls.Add(this.dataGridViewProbsCoefs);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.RunBtn);
            this.Controls.Add(this.BetsNumTxtBx);
            this.Controls.Add(this.BetsNumLbl);
            this.Controls.Add(this.MatchesNumTxtBx);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Marathon";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProbsCoefs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllBets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatchDayResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatchesToRaise)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
        private System.Windows.Forms.MaskedTextBox RaiseSumPercentTBX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox RaiseSumTBX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox AllBetsSumTBX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button TestEvaluationBTN;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.TextBox EvBeforeTBX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox EvAfterTBX;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button AnalysisBTN;
    }
}

