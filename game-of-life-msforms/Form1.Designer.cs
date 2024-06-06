namespace game_of_life_msforms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            startButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            numericUpDown1 = new NumericUpDown();
            randomButton = new Button();
            clearButton = new Button();
            colorDialog1 = new ColorDialog();
            kolorButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Location = new Point(1179, 784);
            startButton.Margin = new Padding(2);
            startButton.Name = "startButton";
            startButton.Size = new Size(112, 34);
            startButton.TabIndex = 1;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(15, 15);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1275, 712);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(990, 785);
            numericUpDown1.Margin = new Padding(4);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(132, 31);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // randomButton
            // 
            randomButton.Location = new Point(814, 748);
            randomButton.Margin = new Padding(4);
            randomButton.Name = "randomButton";
            randomButton.Size = new Size(118, 36);
            randomButton.TabIndex = 4;
            randomButton.Text = "Losowo";
            randomButton.UseVisualStyleBackColor = true;
            randomButton.Click += randomButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(814, 804);
            clearButton.Margin = new Padding(4);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(118, 36);
            clearButton.TabIndex = 5;
            clearButton.Text = "Czysc";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // kolorButton
            // 
            kolorButton.Location = new Point(670, 806);
            kolorButton.Name = "kolorButton";
            kolorButton.Size = new Size(112, 34);
            kolorButton.TabIndex = 6;
            kolorButton.Text = "Kolor";
            kolorButton.UseVisualStyleBackColor = true;
            kolorButton.Click += kolorButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(699, 759);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1305, 866);
            Controls.Add(label1);
            Controls.Add(kolorButton);
            Controls.Add(clearButton);
            Controls.Add(randomButton);
            Controls.Add(numericUpDown1);
            Controls.Add(pictureBox1);
            Controls.Add(startButton);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button startButton;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
        private NumericUpDown numericUpDown1;
        private Button randomButton;
        private Button clearButton;
        private ColorDialog colorDialog1;
        private Button kolorButton;
        private Label label1;
    }
}