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
        public int level = 1;
        public PictureBox[,] blocks;
        private Random randBlock;

        public Form1()
        {
            InitializeComponent();
            vSpeed = 2; // 공의 수평 속도 설정
            hSpeed = 2; // 공의 수직 속도 설정
            setBlocks();
            Cursor.Hide();

            this.FormBorderStyle = FormBorderStyle.None; 
            this.TopMost = true; 

            picPaddle.Top = groundBottom.Top - 40; // paddle 위치 지정
            Gameover_lbl.Visible = false;
            AboutLevel.Visible = false;

            DateTime now = DateTime.Now;
         
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < col; y++)
                {
                    this.randBlock = new Random(now.Millisecond+x+y); //random 함수 원리 이용해서 블록 이미지 지정
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
        private void setBlocks() // 블록 setting
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
                    blocks[x, y].Top = blockHeight * x + 25;
                    blocks[x, y].Left = blockWidth * y;
                    blocks[x, y].BackColor = Color.Transparent;
                    blocks[x, y].BorderStyle = BorderStyle.Fixed3D;
                    blocks[x, y].SizeMode = PictureBoxSizeMode.StretchImage;

                    this.Controls.Add(blocks[x, y]);
                }
            }
        }
        // 초기화
        private void Initialize(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); } //Esc 버튼을 누르면 게임 종료
            if (e.KeyCode == Keys.F1) // F1을 누르면 게임 재시작
            {
                picBall.Top = 200;
                picBall.Left = 200;
                vSpeed = 3;
                hSpeed = 3;
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
        private static DateTime Delay(int MS) // 시간 지연 함수
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            picPaddle.Left = Cursor.Position.X - (picPaddle.Width / 2);
            picBall.Top += vSpeed;
            picBall.Left += hSpeed;

            // 공이 벽에 부딪혔을 경우
            if (picBall.Bottom > this.ClientSize.Height)
            {
                vSpeed = -vSpeed;
            }
            if (picBall.Top < 25)
            {
                vSpeed = -vSpeed;
            }
            if (picBall.Right > this.ClientSize.Width + 1)
            {
                hSpeed = -hSpeed;
            }
            if (picBall.Left < 0)
            {
                hSpeed = -hSpeed;
            }
            // 공이 떨어진 경우
            if(picBall.Bottom >= groundBottom.Bottom)
            {
                timer1.Enabled = false; //stop the game
                Gameover_lbl.Visible = true;
            }

            // 공이 paddle에 부딪힌 경우
            if (picBall.Bounds.IntersectsWith(picPaddle.Bounds) == true)
            {
                vSpeed += 1;
                vSpeed = -vSpeed;
                //hSpeed = -hSpeed;
                Random rnd = new Random();
                groundBottom.BackColor = Color.FromArgb(rnd.Next(150, 250), rnd.Next(150, 255), rnd.Next(150, 255));
            }

            //공이 block 에 부딪힌 경우
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

                        if (points == 30) // 다음 단계로 이동
                        {
                            level += 1;
                            level_lbl.Text = level.ToString();

                            picBall.Visible = false;
                            AboutLevel.Visible = true;
                            Delay(5000);
                            AboutLevel.Visible = false;
                            Delay(3000);

                            picBall.Visible = true;
                            picBall.Top = 200;
                            picBall.Left = 200;
                            vSpeed = 5;
                            hSpeed = 5;
                            Gameover_lbl.Visible = false;
                            points = 0;

                            point_lbl.Text = points.ToString();

                            for (int x1 = 0; x1 < row; x1++)
                            {
                                for (int y1 = 0; y1 < col; y1++)
                                {
                                    blocks[x1, y1].Visible = true;
                                }
                            }

                            timer1.Enabled = true;
                        }
                    }
                }
            }
        }
        
        // 메뉴창에서 "새로운 게임"을 누른 경우
        private void 새로운게임ToolStripMenuItem_Click(object sender, EventArgs e)
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
        
        // 메뉴창에서 "나가기"를 누른 경우
        private void 나가기ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
