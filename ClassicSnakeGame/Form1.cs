﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging; // add this for the JPG compressor

namespace ClassicSnakeGame
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        int maxWidth;
        int maxHeight;

        int score;
        int highScore;

        Random rand = new Random();

        bool goLeft, goRight, goDown, goUp;

        
        public Form1()
        {
            InitializeComponent();
            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            if(e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            } 
            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void TakeSnapShot(object sender, EventArgs e)
        {
            Label caption = new Label();
            caption.Text = "I scored: " + score + "and my Highscore is " + highScore + "on the Snake Game";
            caption.Font = new Font("Arial", 12, FontStyle.Bold);
            caption.ForeColor = Color.Purple;
            caption.AutoSize = false;
            caption.Width = PicCanvas.Width;
            caption.TextAlign = ContentAlignment.MiddleCenter;
            PicCanvas.Controls.Add(caption);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Snake Game SnapShot";
            dialog.DefaultExt = "jpg";
            dialog.Filter = "JPG Image File | *.jpg";
            dialog.ValidateNames = true;

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(PicCanvas.Width);
                int height = Convert.ToInt32(PicCanvas.Height);
                Bitmap bmp = new Bitmap(width, height);
                PicCanvas.DrawToBitmap(bmp, new Rectangle(0,0 ,width,height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                PicCanvas.Controls.Remove(caption);
         
            }

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            //settting the directions

            if(goLeft)
            {
                Settings.directions = "left";
            }
            if(goRight)
            {
                Settings.directions = "right";
            }
            if (goDown)
            {
                Settings.directions = "down";
            }
            if (goUp)
            {
                Settings.directions = "up";
            }
           
            //end of directions

            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if(i==0)
                {
                    switch(Settings.directions)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y--;
                            break;
                        case "up":
                            Snake[i].Y++;
                            break;             
                    }

                    if(Snake[i].X<0)
                    {
                        Snake[i].X = maxWidth;
                    }
                    if(Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }
                    if(Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }
                    if(Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }

                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if(Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }

            PicCanvas.Invalidate();

        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColour;

            for(int i=0; i< Snake.Count; i++)
            {
                if(i == 0)
                {
                    snakeColour = Brushes.Black;
                }
                else
                {
                    snakeColour = Brushes.DarkGreen;
                }

                canvas.FillEllipse(snakeColour, new Rectangle
                    (
                      Snake[i].X * Settings.Width, 
                      Snake[i].Y * Settings.Height,
                      Settings.Width,Settings.Height
                     ));
            }

            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
                   (
                     food.X * Settings.Width,
                     food.Y * Settings.Height,
                     Settings.Width, Settings.Height
                    ));

        }

        private void PicCanvas_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void RestartGame()
        {
            maxWidth = PicCanvas.Width / Settings.Width - 1;
            maxHeight = PicCanvas.Height / Settings.Height - 1;

            Snake.Clear();

            StartBtn.Enabled = false;
            SnapBtn.Enabled = false;
            score = 0;
            TxtScore.Text = "Score: " + score;

            Circle head = new Circle { X = 10,Y = 5 };
            Snake.Add(head);// adding the head part of the snake to the list

            for(int i=0 ;i<10 ;i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            food = new Circle { X=rand.Next(2,maxWidth), Y = rand.Next(2,maxHeight)};

            GameTimer.Start();

        }

        private void EatFood()
        {
            score += 1;

            TxtScore.Text = "Score: " + score;

            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };

            Snake.Add(body);

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

        }

        private void GameOver()
        {
            GameTimer.Stop();
            StartBtn.Enabled = true;
            SnapBtn.Enabled = true;

            if(score> highScore)
            {
                highScore = score;
                TxtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                TxtHighScore.ForeColor = Color.Maroon;
                TxtHighScore.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
    }
}
