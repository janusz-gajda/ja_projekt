namespace ja_projekt
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
            this.libC = new System.Windows.Forms.RadioButton();
            this.libAsm = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.sourceFileChooseButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.sourceFilePath = new System.Windows.Forms.TextBox();
            this.targetFilePath = new System.Windows.Forms.TextBox();
            this.targetFileChooseButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.threadsSlider = new System.Windows.Forms.TrackBar();
            this.threadsCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadsSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // libC
            // 
            this.libC.AutoSize = true;
            this.libC.Checked = true;
            this.libC.Location = new System.Drawing.Point(6, 40);
            this.libC.Name = "libC";
            this.libC.Size = new System.Drawing.Size(44, 17);
            this.libC.TabIndex = 7;
            this.libC.TabStop = true;
            this.libC.Text = "C++";
            this.libC.UseVisualStyleBackColor = true;
            this.libC.CheckedChanged += new System.EventHandler(this.libC_CheckedChanged);
            // 
            // libAsm
            // 
            this.libAsm.AutoSize = true;
            this.libAsm.Location = new System.Drawing.Point(111, 40);
            this.libAsm.Name = "libAsm";
            this.libAsm.Size = new System.Drawing.Size(89, 17);
            this.libAsm.TabIndex = 8;
            this.libAsm.Text = "x86 Assembly";
            this.libAsm.UseVisualStyleBackColor = true;
            this.libAsm.CheckedChanged += new System.EventHandler(this.libAsm_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.libC);
            this.groupBox1.Controls.Add(this.libAsm);
            this.groupBox1.Location = new System.Drawing.Point(89, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // sourceFileChooseButton
            // 
            this.sourceFileChooseButton.Location = new System.Drawing.Point(615, 37);
            this.sourceFileChooseButton.Name = "sourceFileChooseButton";
            this.sourceFileChooseButton.Size = new System.Drawing.Size(173, 23);
            this.sourceFileChooseButton.TabIndex = 10;
            this.sourceFileChooseButton.Text = "Choose Source File";
            this.sourceFileChooseButton.UseVisualStyleBackColor = true;
            this.sourceFileChooseButton.Click += new System.EventHandler(this.sourceFileChooseButton_Click);
            // 
            // sourceFilePath
            // 
            this.sourceFilePath.Location = new System.Drawing.Point(89, 37);
            this.sourceFilePath.Name = "sourceFilePath";
            this.sourceFilePath.Size = new System.Drawing.Size(496, 20);
            this.sourceFilePath.TabIndex = 11;
            // 
            // targetFilePath
            // 
            this.targetFilePath.Location = new System.Drawing.Point(89, 73);
            this.targetFilePath.Name = "targetFilePath";
            this.targetFilePath.Size = new System.Drawing.Size(496, 20);
            this.targetFilePath.TabIndex = 12;
            // 
            // targetFileChooseButton
            // 
            this.targetFileChooseButton.Location = new System.Drawing.Point(615, 73);
            this.targetFileChooseButton.Name = "targetFileChooseButton";
            this.targetFileChooseButton.Size = new System.Drawing.Size(173, 23);
            this.targetFileChooseButton.TabIndex = 13;
            this.targetFileChooseButton.Text = "Choose Target File";
            this.targetFileChooseButton.UseVisualStyleBackColor = true;
            this.targetFileChooseButton.Click += new System.EventHandler(this.targetFileChooseButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(352, 376);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 14;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // threadsSlider
            // 
            this.threadsSlider.Location = new System.Drawing.Point(363, 160);
            this.threadsSlider.Name = "threadsSlider";
            this.threadsSlider.Size = new System.Drawing.Size(425, 45);
            this.threadsSlider.TabIndex = 16;
            this.threadsSlider.Scroll += new System.EventHandler(this.threadsSlider_Scroll);
            // 
            // threadsCountLabel
            // 
            this.threadsCountLabel.AutoSize = true;
            this.threadsCountLabel.Location = new System.Drawing.Point(559, 212);
            this.threadsCountLabel.Name = "threadsCountLabel";
            this.threadsCountLabel.Size = new System.Drawing.Size(35, 13);
            this.threadsCountLabel.TabIndex = 17;
            this.threadsCountLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(518, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Choose Threads Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Choose Liblary";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(360, 338);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(64, 13);
            this.timeLabel.TabIndex = 20;
            this.timeLabel.Text = "00:00:00.00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.threadsCountLabel);
            this.Controls.Add(this.threadsSlider);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.targetFileChooseButton);
            this.Controls.Add(this.targetFilePath);
            this.Controls.Add(this.sourceFilePath);
            this.Controls.Add(this.sourceFileChooseButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadsSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton libC;
        private System.Windows.Forms.RadioButton libAsm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button sourceFileChooseButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox sourceFilePath;
        private System.Windows.Forms.TextBox targetFilePath;
        private System.Windows.Forms.Button targetFileChooseButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TrackBar threadsSlider;
        private System.Windows.Forms.Label threadsCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label timeLabel;
    }
}

