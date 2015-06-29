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
            this.MatchesNumTxtBx = new System.Windows.Forms.TextBox();
            this.MatchesNumLbl = new System.Windows.Forms.Label();
            this.BetsNumLbl = new System.Windows.Forms.Label();
            this.BetsNumTxtBx = new System.Windows.Forms.TextBox();
            this.RunBtn = new System.Windows.Forms.Button();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.dataGridViewProbsCoefs = new System.Windows.Forms.DataGridView();
            this.dataGridViewAllBets = new System.Windows.Forms.DataGridView();
            this.dataGridViewBets = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProbsCoefs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllBets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBets)).BeginInit();
            this.SuspendLayout();
            // 
            // MatchesNumTxtBx
            // 
            this.MatchesNumTxtBx.Location = new System.Drawing.Point(115, 10);
            this.MatchesNumTxtBx.Name = "MatchesNumTxtBx";
            this.MatchesNumTxtBx.Size = new System.Drawing.Size(100, 20);
            this.MatchesNumTxtBx.TabIndex = 2;
            this.MatchesNumTxtBx.Text = "8";
            this.MatchesNumTxtBx.TextChanged += new System.EventHandler(this.MatchesNumTxtBx_TextChanged);
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
            this.BetsNumTxtBx.TextChanged += new System.EventHandler(this.BetsNumTxtBx_TextChanged);
            this.BetsNumTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BetsNumTxtBx_KeyPress);
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(836, 7);
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
            this.dataGridViewBets.Location = new System.Drawing.Point(16, 262);
            this.dataGridViewBets.Name = "dataGridViewBets";
            this.dataGridViewBets.RowHeadersVisible = false;
            this.dataGridViewBets.Size = new System.Drawing.Size(561, 278);
            this.dataGridViewBets.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 550);
            this.Controls.Add(this.dataGridViewBets);
            this.Controls.Add(this.MatchesNumLbl);
            this.Controls.Add(this.dataGridViewProbsCoefs);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.RunBtn);
            this.Controls.Add(this.BetsNumTxtBx);
            this.Controls.Add(this.BetsNumLbl);
            this.Controls.Add(this.MatchesNumTxtBx);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProbsCoefs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllBets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBets)).EndInit();
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
    }
}

