namespace MainGame
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bossSpawnTimer = new System.Windows.Forms.Timer(this.components);
            this.textLabel = new System.Windows.Forms.Label();
            this.textTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonStart = new System.Windows.Forms.Button();
            this.StartTextTimer = new System.Windows.Forms.Timer(this.components);
            this.labelChangingText = new System.Windows.Forms.Label();
            this.MiddleExamTimer = new System.Windows.Forms.Timer(this.components);
            this.ChangeTextTimer = new System.Windows.Forms.Timer(this.components);
            this.FinalExamTimer = new System.Windows.Forms.Timer(this.components);
            this.bossSpawnTimer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MainGame.Properties.Resources.새빛관_1_600x400__1_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1485, 872);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bossSpawnTimer
            // 
            this.bossSpawnTimer.Interval = 52000;
            this.bossSpawnTimer.Tick += new System.EventHandler(this.bossSpawnTimer_Tick);
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textLabel.Location = new System.Drawing.Point(210, 338);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(990, 72);
            this.textLabel.TabIndex = 1;
            this.textLabel.Text = "대충 보스몹 뜨기전 플레이 중";
            // 
            // textTimer
            // 
            this.textTimer.Interval = 3000;
            this.textTimer.Tick += new System.EventHandler(this.textTimer_Tick);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(591, 678);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(128, 64);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "시작";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // StartTextTimer
            // 
            this.StartTextTimer.Interval = 1000;
            this.StartTextTimer.Tick += new System.EventHandler(this.StartTextTimer_Tick);
            // 
            // labelChangingText
            // 
            this.labelChangingText.AutoSize = true;
            this.labelChangingText.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelChangingText.Location = new System.Drawing.Point(12, 9);
            this.labelChangingText.Name = "labelChangingText";
            this.labelChangingText.Size = new System.Drawing.Size(97, 40);
            this.labelChangingText.TabIndex = 3;
            this.labelChangingText.Text = "날짜";
            // 
            // MiddleExamTimer
            // 
            this.MiddleExamTimer.Interval = 10000;
            this.MiddleExamTimer.Tick += new System.EventHandler(this.MiddleExamTimer_Tick);
            // 
            // ChangeTextTimer
            // 
            this.ChangeTextTimer.Interval = 1000;
            this.ChangeTextTimer.Tick += new System.EventHandler(this.ChangeTextTimer_Tick);
            // 
            // FinalExamTimer
            // 
            this.FinalExamTimer.Interval = 10000;
            this.FinalExamTimer.Tick += new System.EventHandler(this.FinalExamTimer_Tick);
            // 
            // bossSpawnTimer2
            // 
            this.bossSpawnTimer2.Interval = 52000;
            this.bossSpawnTimer2.Tick += new System.EventHandler(this.bossSpawnTimer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 869);
            this.Controls.Add(this.labelChangingText);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer bossSpawnTimer;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Timer textTimer;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer StartTextTimer;
        private System.Windows.Forms.Label labelChangingText;
        private System.Windows.Forms.Timer MiddleExamTimer;
        private System.Windows.Forms.Timer ChangeTextTimer;
        private System.Windows.Forms.Timer FinalExamTimer;
        private System.Windows.Forms.Timer bossSpawnTimer2;
    }
}

