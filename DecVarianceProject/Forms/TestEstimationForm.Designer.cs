namespace DecVarianceProject.Forms
{
    partial class TestEstimationForm
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
            this.dataGridViewTest = new System.Windows.Forms.DataGridView();
            this.TestResultsLBL = new System.Windows.Forms.Label();
            this.OKBTN = new System.Windows.Forms.Button();
            this.MarathonEVBeforeTBX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MarathonEVAfterTBX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.VarianceAfterTBX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VarianceBeforeTBX = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.EvProfitTBX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.VarianceDifferenceTBX = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTest)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTest
            // 
            this.dataGridViewTest.AllowUserToAddRows = false;
            this.dataGridViewTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTest.Location = new System.Drawing.Point(31, 152);
            this.dataGridViewTest.Name = "dataGridViewTest";
            this.dataGridViewTest.RowHeadersVisible = false;
            this.dataGridViewTest.Size = new System.Drawing.Size(729, 437);
            this.dataGridViewTest.TabIndex = 0;
            // 
            // TestResultsLBL
            // 
            this.TestResultsLBL.AutoSize = true;
            this.TestResultsLBL.Location = new System.Drawing.Point(37, 123);
            this.TestResultsLBL.Name = "TestResultsLBL";
            this.TestResultsLBL.Size = new System.Drawing.Size(61, 13);
            this.TestResultsLBL.TabIndex = 1;
            this.TestResultsLBL.Text = "Test results";
            // 
            // OKBTN
            // 
            this.OKBTN.Location = new System.Drawing.Point(685, 595);
            this.OKBTN.Name = "OKBTN";
            this.OKBTN.Size = new System.Drawing.Size(75, 23);
            this.OKBTN.TabIndex = 2;
            this.OKBTN.Text = "OK";
            this.OKBTN.UseVisualStyleBackColor = true;
            this.OKBTN.Click += new System.EventHandler(this.OKBTN_Click);
            // 
            // MarathonEVBeforeTBX
            // 
            this.MarathonEVBeforeTBX.Location = new System.Drawing.Point(100, 26);
            this.MarathonEVBeforeTBX.Name = "MarathonEVBeforeTBX";
            this.MarathonEVBeforeTBX.ReadOnly = true;
            this.MarathonEVBeforeTBX.Size = new System.Drawing.Size(100, 20);
            this.MarathonEVBeforeTBX.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "EV Before";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "EV After";
            // 
            // MarathonEVAfterTBX
            // 
            this.MarathonEVAfterTBX.Location = new System.Drawing.Point(294, 26);
            this.MarathonEVAfterTBX.Name = "MarathonEVAfterTBX";
            this.MarathonEVAfterTBX.ReadOnly = true;
            this.MarathonEVAfterTBX.Size = new System.Drawing.Size(100, 20);
            this.MarathonEVAfterTBX.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Variance After";
            // 
            // VarianceAfterTBX
            // 
            this.VarianceAfterTBX.Location = new System.Drawing.Point(377, 64);
            this.VarianceAfterTBX.Name = "VarianceAfterTBX";
            this.VarianceAfterTBX.ReadOnly = true;
            this.VarianceAfterTBX.Size = new System.Drawing.Size(100, 20);
            this.VarianceAfterTBX.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Variance Before";
            // 
            // VarianceBeforeTBX
            // 
            this.VarianceBeforeTBX.Location = new System.Drawing.Point(139, 67);
            this.VarianceBeforeTBX.Name = "VarianceBeforeTBX";
            this.VarianceBeforeTBX.ReadOnly = true;
            this.VarianceBeforeTBX.Size = new System.Drawing.Size(100, 20);
            this.VarianceBeforeTBX.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "%EV profit";
            // 
            // EvProfitTBX
            // 
            this.EvProfitTBX.Location = new System.Drawing.Point(501, 22);
            this.EvProfitTBX.Name = "EvProfitTBX";
            this.EvProfitTBX.ReadOnly = true;
            this.EvProfitTBX.Size = new System.Drawing.Size(100, 20);
            this.EvProfitTBX.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(518, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "%Variance diff";
            // 
            // VarianceDifferenceTBX
            // 
            this.VarianceDifferenceTBX.Location = new System.Drawing.Point(598, 60);
            this.VarianceDifferenceTBX.Name = "VarianceDifferenceTBX";
            this.VarianceDifferenceTBX.ReadOnly = true;
            this.VarianceDifferenceTBX.Size = new System.Drawing.Size(100, 20);
            this.VarianceDifferenceTBX.TabIndex = 14;
            // 
            // TestEstimationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 638);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.VarianceDifferenceTBX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EvProfitTBX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VarianceAfterTBX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.VarianceBeforeTBX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MarathonEVAfterTBX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MarathonEVBeforeTBX);
            this.Controls.Add(this.OKBTN);
            this.Controls.Add(this.TestResultsLBL);
            this.Controls.Add(this.dataGridViewTest);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TestEstimationForm";
            this.Text = "TestEstimationForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TestEstimationForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTest)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTest;
        private System.Windows.Forms.Label TestResultsLBL;
        private System.Windows.Forms.Button OKBTN;
        private System.Windows.Forms.TextBox MarathonEVBeforeTBX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MarathonEVAfterTBX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox VarianceAfterTBX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox VarianceBeforeTBX;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EvProfitTBX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox VarianceDifferenceTBX;
    }
}