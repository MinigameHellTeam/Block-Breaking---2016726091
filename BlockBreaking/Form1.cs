﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
        private Random randBlock;

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
            
            // random으로 벽돌 이미지를 선택
            DateTime now = DateTime.Now;
         
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < col; y++)
                {
                    this.randBlock = new Random(now.Millisecond+x+y);
                    int num1 = this.randBlock.Next(1, 4);
                    switch (num1)
                    {
                        case 1:
                            blocks[x, y].Image = Properties.Resources.Artboard_1;
                            break;
                        case 2:
                            blocks[x, y].Image = Properties.Resources.Artboard_2;
                            break;
                        case 3:
                            blocks[x, y].Image = Properties.Resources.Artboard_3;
                            break;
                        case 4:
                            blocks[x, y].Image = Properties.Resources.Artboard_4;
                            break;
                    }
                }
            }
        }
        
        // 초기 block 설정
        private void setBlocks()
        {
            int blockHeight = 30;
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
                    blocks[x, y].BackColor = Color.Transparent;
                    blocks[x, y].BorderStyle = BorderStyle.Fixed3D;
                    blocks[x, y].SizeMode = PictureBoxSizeMode.StretchImage;

                    this.Controls.Add(blocks[x, y]);
                }
            }
        }
        
        // 공에 따른 action  
        private void timer1_Tick(object sender, EventArgs e)
        {
            picPaddle.Left = Cursor.Position.X - (picPaddle.Width / 2);
            picBall.Top += vSpeed;
            picBall.Left += hSpeed;

            // 공이 벽면에 부딪힌 경우
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
            
            // 공이 떨어진 뒤에 게임 종료
            if(picBall.Bottom >= groundBottom.Bottom)
            {
                timer1.Enabled = false; //stop the game
                Gameover_lbl.Visible = true;
            }

            // 공이 막대에 부딪힌 경우
            if (picBall.Bounds.IntersectsWith(picPaddle.Bounds) == true)
            {
                vSpeed += 1;
                vSpeed = -vSpeed;
                //hSpeed = -hSpeed;
                Random rnd = new Random();
                groundBottom.BackColor = Color.FromArgb(rnd.Next(150, 250), rnd.Next(150, 255), rnd.Next(150, 255));
            }

            // 공이 벽돌에 부딪힌 경우
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
        
        // 게임 초기화
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
