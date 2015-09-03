namespace DecVarianceProject.Forms
{
    partial class AnalysisForm
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
            this.OpenFolderBTN = new System.Windows.Forms.Button();
            this.RunBTN = new System.Windows.Forms.Button();
            this.PathTBX = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OpenFolderBTN
            // 
            this.OpenFolderBTN.Location = new System.Drawing.Point(12, 60);
            this.OpenFolderBTN.Name = "OpenFolderBTN";
            this.OpenFolderBTN.Size = new System.Drawing.Size(75, 23);
            this.OpenFolderBTN.TabIndex = 0;
            this.OpenFolderBTN.Text = "Open folder";
            this.OpenFolderBTN.UseVisualStyleBackColor = true;
            this.OpenFolderBTN.Click += new System.EventHandler(this.OpenFolderBTN_Click);
            // 
            // RunBTN
            // 
            this.RunBTN.Location = new System.Drawing.Point(335, 97);
            this.RunBTN.Name = "RunBTN";
            this.RunBTN.Size = new System.Drawing.Size(75, 23);
            this.RunBTN.TabIndex = 1;
            this.RunBTN.Text = "Run";
            this.RunBTN.UseVisualStyleBackColor = true;
            this.RunBTN.Click += new System.EventHandler(this.RunBTN_Click);
            // 
            // PathTBX
            // 
            this.PathTBX.Location = new System.Drawing.Point(122, 62);
            this.PathTBX.Name = "PathTBX";
            this.PathTBX.Size = new System.Drawing.Size(146, 20);
            this.PathTBX.TabIndex = 2;
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 132);
            this.Controls.Add(this.PathTBX);
            this.Controls.Add(this.RunBTN);
            this.Controls.Add(this.OpenFolderBTN);
            this.Name = "AnalysisForm";
            this.Text = "AnalysisForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFolderBTN;
        private System.Windows.Forms.Button RunBTN;
        private System.Windows.Forms.TextBox PathTBX;
    }
}