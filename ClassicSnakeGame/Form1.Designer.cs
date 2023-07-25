
namespace ClassicSnakeGame
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
            this.components = new System.ComponentModel.Container();
            this.StartBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SnapBtn = new System.Windows.Forms.Button();
            this.PicCanvas = new System.Windows.Forms.PictureBox();
            this.TxtScore = new System.Windows.Forms.Label();
            this.TxtHighScore = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PicCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.Color.SkyBlue;
            this.StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartBtn.Location = new System.Drawing.Point(657, 30);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(144, 51);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartGame);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(613, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 8);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SnapBtn
            // 
            this.SnapBtn.BackColor = System.Drawing.Color.PaleGreen;
            this.SnapBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SnapBtn.Location = new System.Drawing.Point(657, 101);
            this.SnapBtn.Name = "SnapBtn";
            this.SnapBtn.Size = new System.Drawing.Size(144, 51);
            this.SnapBtn.TabIndex = 2;
            this.SnapBtn.Text = "Snap";
            this.SnapBtn.UseVisualStyleBackColor = false;
            this.SnapBtn.Click += new System.EventHandler(this.TakeSnapShot);
            // 
            // PicCanvas
            // 
            this.PicCanvas.BackColor = System.Drawing.Color.Silver;
            this.PicCanvas.Location = new System.Drawing.Point(12, 30);
            this.PicCanvas.Name = "PicCanvas";
            this.PicCanvas.Size = new System.Drawing.Size(639, 775);
            this.PicCanvas.TabIndex = 3;
            this.PicCanvas.TabStop = false;
            this.PicCanvas.Click += new System.EventHandler(this.PicCanvas_Click);
            this.PicCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGraphics);
            // 
            // TxtScore
            // 
            this.TxtScore.AutoSize = true;
            this.TxtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtScore.Location = new System.Drawing.Point(657, 181);
            this.TxtScore.Name = "TxtScore";
            this.TxtScore.Size = new System.Drawing.Size(110, 29);
            this.TxtScore.TabIndex = 4;
            this.TxtScore.Text = "Score: 0";
            // 
            // TxtHighScore
            // 
            this.TxtHighScore.AutoSize = true;
            this.TxtHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHighScore.Location = new System.Drawing.Point(657, 237);
            this.TxtHighScore.Name = "TxtHighScore";
            this.TxtHighScore.Size = new System.Drawing.Size(143, 29);
            this.TxtHighScore.TabIndex = 5;
            this.TxtHighScore.Text = "High Score";
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 50;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 817);
            this.Controls.Add(this.TxtHighScore);
            this.Controls.Add(this.TxtScore);
            this.Controls.Add(this.PicCanvas);
            this.Controls.Add(this.SnapBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.StartBtn);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "ClassicSnakeGame";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.PicCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SnapBtn;
        private System.Windows.Forms.PictureBox PicCanvas;
        private System.Windows.Forms.Label TxtScore;
        private System.Windows.Forms.Label TxtHighScore;
        private System.Windows.Forms.Timer GameTimer;
    }
}

