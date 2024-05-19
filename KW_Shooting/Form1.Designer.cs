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
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.Skill_Left_Time = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Skill_Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(972, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Time";
            // 
            // Point
            // 
            this.Point.AutoSize = true;
            this.Point.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Point.Location = new System.Drawing.Point(40, 49);
            this.Point.Name = "Point";
            this.Point.Size = new System.Drawing.Size(29, 27);
            this.Point.TabIndex = 2;
            this.Point.Text = "0";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Time.Location = new System.Drawing.Point(998, 49);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(29, 27);
            this.Time.TabIndex = 3;
            this.Time.Text = "0";
            // 
            // Movement
            // 
            this.Movement.Tick += new System.EventHandler(this.Movement_Tick);
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
            // Skill_Left_Time
            // 
            this.Skill_Left_Time.AutoSize = true;
            this.Skill_Left_Time.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Skill_Left_Time.Location = new System.Drawing.Point(40, 536);
            this.Skill_Left_Time.Name = "Skill_Left_Time";
            this.Skill_Left_Time.Size = new System.Drawing.Size(29, 27);
            this.Skill_Left_Time.TabIndex = 5;
            this.Skill_Left_Time.Text = "0";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label4.Location = new System.Drawing.Point(22, 499);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(67, 27);
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Skill";
            // 
            // Skill_Timer
            // 
            this.Skill_Timer.Interval = 1000;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1077, 572);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Skill_Left_Time);
            this.Controls.Add(this.MediaPlayer);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.Point);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Render);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_Update);
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
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
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Timer Skill_Timer;
    }
}

