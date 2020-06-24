﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockBreaking
{
    public partial class Form1 : Form
    {
        public int vSpeed;
        public int hSpeed;
        public const int row = 5;
        public const int col = 6;
        public int points = 0;
        public PictureBox[,] blocks;

        public Form1()
        {
            InitializeComponent();
            vSpeed = 5;
            hSpeed = 5;
            setBlocks();
            Cursor.Hide();
            

            this.FormBorderStyle = FormBorderStyle.None; //remove any border
            this.TopMost = true; // bring the form to the front

            picPaddle.Top = groundBottom.Top - 40;
            Gameover_lbl.Visible = false;
        }
        private void setBlocks()
        {
            int blockHeight = 25;
            int blockWidth = 100;

            blocks = new PictureBox[row, col];

            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < col; y++)
                {
                    blocks[x, y] = new PictureBox();

                    blocks[x, y].Width = blockWidth;
                    blocks[x, y].Height = blockHeight;
                    blocks[x, y].Top = blockHeight * x;
                    blocks[x, y].Left = blockWidth * y;
                    blocks[x, y].BackColor = Color.Green;
                    blocks[x, y].BorderStyle = BorderStyle.Fixed3D;

                    this.Controls.Add(blocks[x, y]);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            picPaddle.Left = Cursor.Position.X - (picPaddle.Width / 2);
            picBall.Top += vSpeed;
            picBall.Left += hSpeed;

            // ball collides with wall
            if (picBall.Bottom > this.ClientSize.Height)
            {
                vSpeed = -vSpeed;
            }
            if (picBall.Top < 0)
            {
                vSpeed = -vSpeed;
            }
            if (picBall.Right > this.ClientSize.Width)
            {
                hSpeed = -hSpeed;
            }
            if (picBall.Left < 0)
            {
                hSpeed = -hSpeed;
            }
            // ball falls down
            if(picBall.Bottom >= groundBottom.Bottom)
            {
                timer1.Enabled = false; //stop the game
                Gameover_lbl.Visible = true;
            }

            // ball collides with paddle
            if (picBall.Bounds.IntersectsWith(picPaddle.Bounds) == true)
            {
                vSpeed += 1;
                vSpeed = -vSpeed;
                //hSpeed = -hSpeed;
                Random rnd = new Random();
                groundBottom.BackColor = Color.FromArgb(rnd.Next(150, 250), rnd.Next(150, 255), rnd.Next(150, 255));
            }

            //detect collision with blocks
            for(int x = 0; x< row; x++)
            {
                for(int y = 0; y < col; y++)
                {
                    if (picBall.Bounds.IntersectsWith(blocks[x, y].Bounds) && blocks[x,y].Visible == true)
                    {
                        blocks[x, y].Visible = false;
                        vSpeed = -vSpeed;
                        points += 1;
                        point_lbl.Text = points.ToString();
                    }
                }
            }
        }

        private void Initialize(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); } //press Excape to quit
            if (e.KeyCode == Keys.F1)
            {
                picBall.Top = 200;
                picBall.Left = 200;
                vSpeed = 5;
                hSpeed = 5;
                Gameover_lbl.Visible = false;
                points = 0;
                point_lbl.Text = points.ToString();

                for (int x = 0; x < row; x++)
                {
                    for (int y = 0; y < col; y++)
                    {
                        blocks[x, y].Visible = true;
                    }
                }

                timer1.Enabled = true;
            }
        }
    }
}
