namespace Snekla
{
    partial class Snekla
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
            this.verticalSizeInput = new System.Windows.Forms.TextBox();
            this.horizontalSizeInput = new System.Windows.Forms.TextBox();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.speedInput = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.controlsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // verticalSizeInput
            // 
            this.verticalSizeInput.Location = new System.Drawing.Point(63, 17);
            this.verticalSizeInput.Name = "verticalSizeInput";
            this.verticalSizeInput.Size = new System.Drawing.Size(40, 26);
            this.verticalSizeInput.TabIndex = 0;
            this.verticalSizeInput.Text = "10";
            // 
            // horizontalSizeInput
            // 
            this.horizontalSizeInput.Location = new System.Drawing.Point(131, 17);
            this.horizontalSizeInput.Name = "horizontalSizeInput";
            this.horizontalSizeInput.Size = new System.Drawing.Size(40, 26);
            this.horizontalSizeInput.TabIndex = 1;
            this.horizontalSizeInput.Text = "10";
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(12, 20);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(44, 20);
            this.sizeLabel.TabIndex = 2;
            this.sizeLabel.Text = "Size:";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(109, 23);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(16, 20);
            this.xLabel.TabIndex = 3;
            this.xLabel.Text = "x";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(12, 60);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(60, 20);
            this.speedLabel.TabIndex = 4;
            this.speedLabel.Text = "Speed:";
            // 
            // speedInput
            // 
            this.speedInput.Location = new System.Drawing.Point(85, 57);
            this.speedInput.Name = "speedInput";
            this.speedInput.Size = new System.Drawing.Size(40, 26);
            this.speedInput.TabIndex = 5;
            this.speedInput.Text = "2";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(97, 144);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(95, 38);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // controlsLabel
            // 
            this.controlsLabel.AutoSize = true;
            this.controlsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.controlsLabel.Location = new System.Drawing.Point(12, 98);
            this.controlsLabel.Name = "controlsLabel";
            this.controlsLabel.Size = new System.Drawing.Size(283, 32);
            this.controlsLabel.TabIndex = 7;
            this.controlsLabel.Text = "Controls are W,A,S,D";
            // 
            // Snekla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(298, 194);
            this.Controls.Add(this.controlsLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.speedInput);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.horizontalSizeInput);
            this.Controls.Add(this.verticalSizeInput);
            this.MaximumSize = new System.Drawing.Size(320, 250);
            this.MinimumSize = new System.Drawing.Size(320, 250);
            this.Name = "Snekla";
            this.ShowIcon = false;
            this.Text = "Snekla";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Snekla_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Snekla_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.TextBox verticalSizeInput;
        private System.Windows.Forms.TextBox horizontalSizeInput;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.TextBox speedInput;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label controlsLabel;
    }
}

