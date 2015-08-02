namespace DecVarianceProject.Forms
{
    partial class MatchDayResultsDialog
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
            this.dataGridViewMatchDayResults = new System.Windows.Forms.DataGridView();
            this.OkBTN = new System.Windows.Forms.Button();
            this.AutomaticallyRdBtn = new System.Windows.Forms.RadioButton();
            this.ManuallyRdBtn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatchDayResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMatchDayResults
            // 
            this.dataGridViewMatchDayResults.AllowUserToAddRows = false;
            this.dataGridViewMatchDayResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatchDayResults.Location = new System.Drawing.Point(24, 97);
            this.dataGridViewMatchDayResults.Name = "dataGridViewMatchDayResults";
            this.dataGridViewMatchDayResults.RowHeadersVisible = false;
            this.dataGridViewMatchDayResults.Size = new System.Drawing.Size(223, 151);
            this.dataGridViewMatchDayResults.TabIndex = 0;
            // 
            // OkBTN
            // 
            this.OkBTN.Location = new System.Drawing.Point(370, 241);
            this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(75, 23);
            this.OkBTN.TabIndex = 1;
            this.OkBTN.Text = "OK";
            this.OkBTN.UseVisualStyleBackColor = true;
            this.OkBTN.Click += new System.EventHandler(this.OkBTN_Click);
            // 
            // AutomaticallyRdBtn
            // 
            this.AutomaticallyRdBtn.AutoSize = true;
            this.AutomaticallyRdBtn.Checked = true;
            this.AutomaticallyRdBtn.Location = new System.Drawing.Point(24, 34);
            this.AutomaticallyRdBtn.Name = "AutomaticallyRdBtn";
            this.AutomaticallyRdBtn.Size = new System.Drawing.Size(87, 17);
            this.AutomaticallyRdBtn.TabIndex = 2;
            this.AutomaticallyRdBtn.TabStop = true;
            this.AutomaticallyRdBtn.Text = "Automatically";
            this.AutomaticallyRdBtn.UseVisualStyleBackColor = true;
            this.AutomaticallyRdBtn.Click += new System.EventHandler(this.AutomaticallyRdBtn_Click);
            // 
            // ManuallyRdBtn
            // 
            this.ManuallyRdBtn.AutoSize = true;
            this.ManuallyRdBtn.Location = new System.Drawing.Point(24, 58);
            this.ManuallyRdBtn.Name = "ManuallyRdBtn";
            this.ManuallyRdBtn.Size = new System.Drawing.Size(67, 17);
            this.ManuallyRdBtn.TabIndex = 3;
            this.ManuallyRdBtn.Text = "Manually";
            this.ManuallyRdBtn.UseVisualStyleBackColor = true;
            this.ManuallyRdBtn.Click += new System.EventHandler(this.ManuallyRdBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "FullFillTheTable:";
            // 
            // MatchDayResultsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 287);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ManuallyRdBtn);
            this.Controls.Add(this.AutomaticallyRdBtn);
            this.Controls.Add(this.OkBTN);
            this.Controls.Add(this.dataGridViewMatchDayResults);
            this.Name = "MatchDayResultsDialog";
            this.Text = "MatchDayResultsDialog";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatchDayResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMatchDayResults;
        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.RadioButton AutomaticallyRdBtn;
        private System.Windows.Forms.RadioButton ManuallyRdBtn;
        private System.Windows.Forms.Label label1;
    }
}