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
            this.RTB_Info.Location = new System.Drawing.Point(12, 46);
            this.RTB_Info.Name = "RTB_Info";
            this.RTB_Info.Size = new System.Drawing.Size(565, 496);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 573);
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
    }
}

