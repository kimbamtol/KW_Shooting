using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Numerics; //사용자 자료형
using Utils; //사용자 인터페이스
namespace KW_Shooting
{
    public partial class Form1 : Form, IRenderer
    {

        // <summary>
        // 김태훈
        private List<PictureBox> targets = new List<PictureBox>();
        private Dictionary<PictureBox, Vector> velocities = new Dictionary<PictureBox, Vector>();
        private Random random = new Random();
        private Timer movementTimer;
        private int score = 0;
        // </summary>
        List<object> objects = new List<object>();
        public List<object> GameObjs
        {
            get { return objects; }
        }

        CSPlayer player;

        public Form1()
        {
            InitializeComponent();
            InitializeTargets(10);
            InitializeMovementTimer();
            Movement.Interval = 50; // 타이머 간격을 50ms로 설정
            Movement.Tick += Movement_Tick; // 타이머 이벤트 핸들러 연결
            Movement.Start(); // 타이머 시작

            this.DoubleBuffered = true;

            player = new CSPlayer(new Vec2(200f, 200f));
            objects.Add(player);

            CSTimeManager.GetInstance();

            CSRTRenderer.GetInstance().Current = this;
        }

        public void Render(object sender,PaintEventArgs e)
        {
            CSRTRenderer.GetInstance().Form_Paint(sender, e);
        }

        private void Form1_Update(object sender, MouseEventArgs e)
        {
            player.Position = new Vec2(e.X, e.Y);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 김태훈
        /// </summary>
        /// 

        struct Vector
        {
            public double X, Y;

            public Vector(double x, double y)
            {
                X = x;
                Y = y;
            }
        }
        private void InitializeTargets(int count)
        {
            for (int i = 0; i < count; i++)
            {
                PictureBox target = new PictureBox
                {
                    Name = $"Target_HW{i}",
                    Size = new Size(100, 100),
                    BackColor = Color.Empty,
                    Image = Properties.Resources.Book1,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                target.Location = GetRandomLocation(target.Size);
                target.Click += Target_Click; // 클릭 이벤트 핸들러 추가
                this.Controls.Add(target);
                targets.Add(target);

                // 초기 속도와 방향 설정
                Vector velocity = new Vector(random.NextDouble() * 2 - 1, random.NextDouble() * 2 - 1);
                velocities[target] = velocity;
            }
        }

        private void InitializeMovementTimer()
        {
            movementTimer = new Timer();
            movementTimer.Interval = 50; // 50 ms 간격으로 위치 업데이트
            movementTimer.Tick += Movement_Tick;
            movementTimer.Start();
        }

        private void AdjustVelocityRandomly(PictureBox target)
        {
            Vector velocity = velocities[target];
            velocity.X += random.NextDouble() * 0.2 - 0.1; // 속도 조정
            velocity.Y += random.NextDouble() * 0.2 - 0.1;
            velocities[target] = velocity;
        }

        private Point GetRandomLocation(Size size)
        {
            int maxX = ClientSize.Width - size.Width;
            int maxY = ClientSize.Height - size.Height;
            return new Point(random.Next(maxX), random.Next(maxY));
        }

        private void Movement_Tick(object sender, EventArgs e)
        {
            foreach (var target in targets)
            {
                if (target.Visible)
                {
                    Vector velocity = velocities[target];
                    // 예상되는 새 위치 계산
                    Point newPosition = new Point(target.Location.X + (int)velocity.X, target.Location.Y + (int)velocity.Y);

                    // 맵 밖으로 못나가게 설정
                    newPosition.X = Math.Max(0, Math.Min(newPosition.X, ClientSize.Width - target.Width));
                    newPosition.Y = Math.Max(0, Math.Min(newPosition.Y, ClientSize.Height - target.Height));

                    target.Location = newPosition;

                    // 바람 효과로 속도 랜덤 조정
                    AdjustVelocityRandomly(target);
                }
            }
        }
        private void Target_Click(object sender, EventArgs e)
        {
            PictureBox clickedTarget = sender as PictureBox;
            if (clickedTarget != null && clickedTarget.Visible)
            {
                clickedTarget.Visible = false; // 타겟 숨기기
                score += 10; // 점수 증가
                Point.Text = score.ToString();
            }
        }
    }
}