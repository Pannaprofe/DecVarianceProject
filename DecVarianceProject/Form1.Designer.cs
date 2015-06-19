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
            this.SuspendLayout();
            // 
            // RTB_rez
            // 
            this.RTB_rez.Location = new System.Drawing.Point(583, 12);
            this.RTB_rez.Name = "RTB_rez";
            this.RTB_rez.Size = new System.Drawing.Size(686, 530);
            this.RTB_rez.TabIndex = 0;
            this.RTB_rez.Text = "";
            // 
            // RTB_Info
            // 
            this.RTB_Info.Location = new System.Drawing.Point(12, 12);
            this.RTB_Info.Name = "RTB_Info";
            this.RTB_Info.Size = new System.Drawing.Size(565, 530);
            this.RTB_Info.TabIndex = 1;
            this.RTB_Info.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 573);
            this.Controls.Add(this.RTB_Info);
            this.Controls.Add(this.RTB_rez);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTB_rez;
        private System.Windows.Forms.RichTextBox RTB_Info;
    }
}

