namespace BlockBreaking
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Gameover_lbl = new System.Windows.Forms.Label();
            this.point_lbl = new System.Windows.Forms.Label();
            this.score_lbl = new System.Windows.Forms.Label();
            this.groundBottom = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.메뉴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새로운게임ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.나가기ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.picPaddle = new System.Windows.Forms.PictureBox();
            this.picBall = new System.Windows.Forms.PictureBox();
            this.groundBottom.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPaddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBall)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Gameover_lbl
            // 
            this.Gameover_lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Gameover_lbl.AutoSize = true;
            this.Gameover_lbl.BackColor = System.Drawing.Color.Transparent;
            this.Gameover_lbl.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Gameover_lbl.Location = new System.Drawing.Point(346, 289);
            this.Gameover_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Gameover_lbl.Name = "Gameover_lbl";
            this.Gameover_lbl.Size = new System.Drawing.Size(154, 96);
            this.Gameover_lbl.TabIndex = 6;
            this.Gameover_lbl.Text = "Game Over\r\n\r\nF1 -> Restart\r\nEsc -> Exit\r\n";
            this.Gameover_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // point_lbl
            // 
            this.point_lbl.AutoSize = true;
            this.point_lbl.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.point_lbl.Location = new System.Drawing.Point(428, 10);
            this.point_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.point_lbl.Name = "point_lbl";
            this.point_lbl.Size = new System.Drawing.Size(22, 22);
            this.point_lbl.TabIndex = 8;
            this.point_lbl.Text = "0";
            // 
            // score_lbl
            // 
            this.score_lbl.AutoSize = true;
            this.score_lbl.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.score_lbl.Location = new System.Drawing.Point(338, 10);
            this.score_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.score_lbl.Name = "score_lbl";
            this.score_lbl.Size = new System.Drawing.Size(82, 22);
            this.score_lbl.TabIndex = 7;
            this.score_lbl.Text = "Score :";
            // 
            // groundBottom
            // 
            this.groundBottom.Controls.Add(this.score_lbl);
            this.groundBottom.Controls.Add(this.point_lbl);
            this.groundBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groundBottom.Location = new System.Drawing.Point(0, 641);
            this.groundBottom.Name = "groundBottom";
            this.groundBottom.Size = new System.Drawing.Size(856, 41);
            this.groundBottom.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메뉴ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(856, 33);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 메뉴ToolStripMenuItem
            // 
            this.메뉴ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새로운게임ToolStripMenuItem,
            this.나가기ToolStripMenuItem1});
            this.메뉴ToolStripMenuItem.Name = "메뉴ToolStripMenuItem";
            this.메뉴ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.메뉴ToolStripMenuItem.Size = new System.Drawing.Size(91, 29);
            this.메뉴ToolStripMenuItem.Text = "메뉴(&M)";
            // 
            // 새로운게임ToolStripMenuItem
            // 
            this.새로운게임ToolStripMenuItem.Name = "새로운게임ToolStripMenuItem";
            this.새로운게임ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.새로운게임ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.새로운게임ToolStripMenuItem.Text = "새로운 게임";
            this.새로운게임ToolStripMenuItem.Click += new System.EventHandler(this.새로운게임ToolStripMenuItem_Click);
            // 
            // 나가기ToolStripMenuItem1
            // 
            this.나가기ToolStripMenuItem1.Name = "나가기ToolStripMenuItem1";
            this.나가기ToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.나가기ToolStripMenuItem1.Text = "나가기";
            this.나가기ToolStripMenuItem1.Click += new System.EventHandler(this.나가기ToolStripMenuItem1_Click);
            // 
            // picPaddle
            // 
            this.picPaddle.BackColor = System.Drawing.Color.RoyalBlue;
            this.picPaddle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPaddle.Image = global::BlockBreaking.Properties.Resources._3bb303c76f55866af2dfdc95aa040105;
            this.picPaddle.Location = new System.Drawing.Point(300, 601);
            this.picPaddle.Name = "picPaddle";
            this.picPaddle.Size = new System.Drawing.Size(200, 30);
            this.picPaddle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPaddle.TabIndex = 5;
            this.picPaddle.TabStop = false;
            // 
            // picBall
            // 
            this.picBall.BackColor = System.Drawing.Color.Gold;
            this.picBall.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBall.Location = new System.Drawing.Point(375, 375);
            this.picBall.Name = "picBall";
            this.picBall.Size = new System.Drawing.Size(25, 25);
            this.picBall.TabIndex = 4;
            this.picBall.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(856, 682);
            this.Controls.Add(this.groundBottom);
            this.Controls.Add(this.Gameover_lbl);
            this.Controls.Add(this.picPaddle);
            this.Controls.Add(this.picBall);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Block Breaking";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Initialize);
            this.groundBottom.ResumeLayout(false);
            this.groundBottom.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPaddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picPaddle;
        private System.Windows.Forms.PictureBox picBall;
        private System.Windows.Forms.Label Gameover_lbl;
        private System.Windows.Forms.Label point_lbl;
        private System.Windows.Forms.Label score_lbl;
        private System.Windows.Forms.Panel groundBottom;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메뉴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새로운게임ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 나가기ToolStripMenuItem1;
    }
}

