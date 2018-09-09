namespace QuizzApp
{
    partial class Play
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Play));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btNext = new System.Windows.Forms.Button();
            this.btQuit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbC = new System.Windows.Forms.Label();
            this.lbD = new System.Windows.Forms.Label();
            this.lbB = new System.Windows.Forms.Label();
            this.lbA = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pResult = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbCorrect = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.qNumber = new System.Windows.Forms.Label();
            this.lbScore = new System.Windows.Forms.Label();
            this.lbMax = new System.Windows.Forms.Label();
            this.lbResultScore = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(261, 213);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(383, 28);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 7;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox1.Location = new System.Drawing.Point(225, 39);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(460, 146);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // btNext
            // 
            this.btNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(0)))));
            this.btNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNext.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btNext.ForeColor = System.Drawing.Color.White;
            this.btNext.Location = new System.Drawing.Point(323, 443);
            this.btNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(281, 45);
            this.btNext.TabIndex = 9;
            this.btNext.Text = "Next";
            this.btNext.UseVisualStyleBackColor = false;
            this.btNext.Click += new System.EventHandler(this.nextQuestion_click);
            // 
            // btQuit
            // 
            this.btQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQuit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btQuit.ForeColor = System.Drawing.Color.White;
            this.btQuit.Location = new System.Drawing.Point(323, 492);
            this.btQuit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btQuit.Name = "btQuit";
            this.btQuit.Size = new System.Drawing.Size(281, 45);
            this.btQuit.TabIndex = 10;
            this.btQuit.Text = "Quit";
            this.btQuit.UseVisualStyleBackColor = false;
            this.btQuit.Click += new System.EventHandler(this.quitQuiz_click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.lbC);
            this.panel1.Controls.Add(this.lbD);
            this.panel1.Controls.Add(this.lbB);
            this.panel1.Controls.Add(this.lbA);
            this.panel1.Location = new System.Drawing.Point(0, 272);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 153);
            this.panel1.TabIndex = 12;
            // 
            // lbC
            // 
            this.lbC.BackColor = System.Drawing.Color.White;
            this.lbC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbC.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbC.Location = new System.Drawing.Point(118, 88);
            this.lbC.Name = "lbC";
            this.lbC.Size = new System.Drawing.Size(301, 34);
            this.lbC.TabIndex = 13;
            this.lbC.Click += new System.EventHandler(this.lbC_Click);
            // 
            // lbD
            // 
            this.lbD.BackColor = System.Drawing.Color.White;
            this.lbD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbD.Location = new System.Drawing.Point(509, 86);
            this.lbD.Name = "lbD";
            this.lbD.Size = new System.Drawing.Size(301, 34);
            this.lbD.TabIndex = 12;
            this.lbD.Click += new System.EventHandler(this.lbD_Click);
            // 
            // lbB
            // 
            this.lbB.BackColor = System.Drawing.Color.White;
            this.lbB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbB.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbB.Location = new System.Drawing.Point(509, 30);
            this.lbB.Name = "lbB";
            this.lbB.Size = new System.Drawing.Size(301, 34);
            this.lbB.TabIndex = 11;
            this.lbB.Click += new System.EventHandler(this.lbB_Click);
            // 
            // lbA
            // 
            this.lbA.BackColor = System.Drawing.Color.White;
            this.lbA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbA.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbA.Location = new System.Drawing.Point(118, 30);
            this.lbA.Name = "lbA";
            this.lbA.Size = new System.Drawing.Size(301, 34);
            this.lbA.TabIndex = 10;
            this.lbA.Click += new System.EventHandler(this.lbA_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.pResult);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.qNumber);
            this.panel2.Controls.Add(this.lbScore);
            this.panel2.Controls.Add(this.lbMax);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 275);
            this.panel2.TabIndex = 13;
            // 
            // pResult
            // 
            this.pResult.Controls.Add(this.lbTotal);
            this.pResult.Controls.Add(this.lbCorrect);
            this.pResult.Controls.Add(this.label2);
            this.pResult.Controls.Add(this.label1);
            this.pResult.Location = new System.Drawing.Point(353, 187);
            this.pResult.Name = "pResult";
            this.pResult.Size = new System.Drawing.Size(200, 79);
            this.pResult.TabIndex = 14;
            this.pResult.Visible = false;
            // 
            // lbTotal
            // 
            this.lbTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbTotal.ForeColor = System.Drawing.Color.White;
            this.lbTotal.Location = new System.Drawing.Point(112, 25);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(88, 54);
            this.lbTotal.TabIndex = 3;
            // 
            // lbCorrect
            // 
            this.lbCorrect.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbCorrect.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbCorrect.ForeColor = System.Drawing.Color.White;
            this.lbCorrect.Location = new System.Drawing.Point(0, 25);
            this.lbCorrect.Name = "lbCorrect";
            this.lbCorrect.Size = new System.Drawing.Size(88, 54);
            this.lbCorrect.TabIndex = 2;
            this.lbCorrect.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 54);
            this.label2.TabIndex = 1;
            this.label2.Text = "/";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = " Score:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.Location = new System.Drawing.Point(751, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 218);
            this.panel3.TabIndex = 11;
            // 
            // qNumber
            // 
            this.qNumber.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.qNumber.ForeColor = System.Drawing.Color.White;
            this.qNumber.Location = new System.Drawing.Point(31, 56);
            this.qNumber.Name = "qNumber";
            this.qNumber.Size = new System.Drawing.Size(169, 120);
            this.qNumber.TabIndex = 10;
            this.qNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbScore.Location = new System.Drawing.Point(220, 213);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(0, 28);
            this.lbScore.TabIndex = 9;
            // 
            // lbMax
            // 
            this.lbMax.AutoSize = true;
            this.lbMax.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbMax.Location = new System.Drawing.Point(651, 213);
            this.lbMax.Name = "lbMax";
            this.lbMax.Size = new System.Drawing.Size(0, 28);
            this.lbMax.TabIndex = 8;
            // 
            // lbResultScore
            // 
            this.lbResultScore.AutoSize = true;
            this.lbResultScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbResultScore.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbResultScore.Location = new System.Drawing.Point(51, 466);
            this.lbResultScore.Name = "lbResultScore";
            this.lbResultScore.Size = new System.Drawing.Size(0, 52);
            this.lbResultScore.TabIndex = 14;
            this.lbResultScore.Visible = false;
            // 
            // Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 551);
            this.Controls.Add(this.lbResultScore);
            this.Controls.Add(this.btQuit);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Play";
            this.Text = "KVIZ";
            this.Load += new System.EventHandler(this.Play_load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btQuit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Label lbMax;
        private System.Windows.Forms.Label lbC;
        private System.Windows.Forms.Label lbD;
        private System.Windows.Forms.Label lbB;
        private System.Windows.Forms.Label lbA;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label qNumber;
        private System.Windows.Forms.Panel pResult;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbCorrect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbResultScore;
    }
}