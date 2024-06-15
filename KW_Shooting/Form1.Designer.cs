namespace KW_Shooting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Point = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.CountDownTimer = new System.Windows.Forms.Timer(this.components);
            this.Target_Respawn = new System.Windows.Forms.Timer(this.components);
            this.Movement = new System.Windows.Forms.Timer(this.components);
            this.Skill_Left_Time = new System.Windows.Forms.Label();
            this.Skill_Timer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.round_txt = new System.Windows.Forms.Label();
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.life1 = new System.Windows.Forms.PictureBox();
            this.life2 = new System.Windows.Forms.PictureBox();
            this.life3 = new System.Windows.Forms.PictureBox();
            this.life4 = new System.Windows.Forms.PictureBox();
            this.life5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.life1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(987, 483);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Time";
            // 
            // Point
            // 
            this.Point.AutoSize = true;
            this.Point.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Point.Location = new System.Drawing.Point(40, 42);
            this.Point.Name = "Point";
            this.Point.Size = new System.Drawing.Size(29, 27);
            this.Point.TabIndex = 2;
            this.Point.Text = "0";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Time.Location = new System.Drawing.Point(1013, 521);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(29, 27);
            this.Time.TabIndex = 3;
            this.Time.Text = "0";
            // 
            // Movement
            // 
            this.Movement.Tick += new System.EventHandler(this.Movement_Tick);
            // 
            // Skill_Left_Time
            // 
            this.Skill_Left_Time.AutoSize = true;
            this.Skill_Left_Time.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Skill_Left_Time.Location = new System.Drawing.Point(40, 521);
            this.Skill_Left_Time.Name = "Skill_Left_Time";
            this.Skill_Left_Time.Size = new System.Drawing.Size(29, 27);
            this.Skill_Left_Time.TabIndex = 5;
            this.Skill_Left_Time.Text = "0";
            // 
            // Skill_Timer
            // 
            this.Skill_Timer.Interval = 1000;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(483, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "Round";
            // 
            // round_txt
            // 
            this.round_txt.AutoSize = true;
            this.round_txt.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.round_txt.Location = new System.Drawing.Point(516, 42);
            this.round_txt.Name = "round_txt";
            this.round_txt.Size = new System.Drawing.Size(29, 27);
            this.round_txt.TabIndex = 8;
            this.round_txt.Text = "0";
            // 
            // MediaPlayer
            // 
            this.MediaPlayer.Enabled = true;
            this.MediaPlayer.Location = new System.Drawing.Point(470, 29);
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.Size = new System.Drawing.Size(75, 23);
            this.MediaPlayer.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.life5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.life4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.life3);
            this.panel1.Controls.Add(this.round_txt);
            this.panel1.Controls.Add(this.life2);
            this.panel1.Controls.Add(this.life1);
            this.panel1.Controls.Add(this.Point);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 76);
            this.panel1.TabIndex = 9;
            // 
            // life1
            // 
            this.life1.Location = new System.Drawing.Point(886, 17);
            this.life1.Name = "life1";
            this.life1.Size = new System.Drawing.Size(34, 35);
            this.life1.TabIndex = 10;
            this.life1.TabStop = false;
            // 
            // life2
            // 
            this.life2.Location = new System.Drawing.Point(917, 17);
            this.life2.Name = "life2";
            this.life2.Size = new System.Drawing.Size(34, 35);
            this.life2.TabIndex = 11;
            this.life2.TabStop = false;
            // 
            // life3
            // 
            this.life3.Location = new System.Drawing.Point(950, 17);
            this.life3.Name = "life3";
            this.life3.Size = new System.Drawing.Size(34, 35);
            this.life3.TabIndex = 12;
            this.life3.TabStop = false;
            // 
            // life4
            // 
            this.life4.Location = new System.Drawing.Point(983, 17);
            this.life4.Name = "life4";
            this.life4.Size = new System.Drawing.Size(34, 35);
            this.life4.TabIndex = 13;
            this.life4.TabStop = false;
            // 
            // life5
            // 
            this.life5.Location = new System.Drawing.Point(1016, 17);
            this.life5.Name = "life5";
            this.life5.Size = new System.Drawing.Size(34, 35);
            this.life5.TabIndex = 14;
            this.life5.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1077, 572);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Skill_Left_Time);
            this.Controls.Add(this.MediaPlayer);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Render);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mouse_Move);
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.life1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Point;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Timer CountDownTimer;
        private System.Windows.Forms.Timer Target_Respawn;
        private System.Windows.Forms.Timer Movement;
        private AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
        private System.Windows.Forms.Label Skill_Left_Time;
        private System.Windows.Forms.Timer Skill_Timer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label round_txt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox life5;
        private System.Windows.Forms.PictureBox life4;
        private System.Windows.Forms.PictureBox life3;
        private System.Windows.Forms.PictureBox life2;
        private System.Windows.Forms.PictureBox life1;
    }
}

