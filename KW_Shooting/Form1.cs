using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Numerics; //사용자 자료형
using Utils; //사용자 인터페이스

namespace KW_Shooting
{
    public partial class Form1 : Form, IRenderer
    {
        private List<PictureBox> targets = new List<PictureBox>();
        private Dictionary<PictureBox, Location> velocities = new Dictionary<PictureBox, Location>();
        private Random random = new Random();
        private Timer movementTimer;
        private Timer examTimer;

        private int RemainTime = 2;
        private int score = 0;
        private int speed = 1;

        private Skill currentSkill = Skill.AUTOATTACK;
        private Timer WTimer;

        private int heart = 5;
        private PictureBox[] heart_indicator;

        //라운드 변수
        private int Round = 1;

        //게임 상태 관리
        enum GameState
        {
            Normal,
            Midterm,
            Final
        }

        private GameState currentGameState = GameState.Normal;

        // 시험 타이머와 지속 시간 변수
        private int examDuration = 10; // 시험 라운드 지속 시간 (예: 10초)

        // <summary>
        // 김태훈
        List<object> objects = new List<object>();
        public List<object> GameObjs
        {
            get { return objects; }
        }

        CSShooting gun;
        CSBG backgroundImg;
        CSPanel panelQ;
        CSPanel panelW;

        public Form1()
        {
            InitializeComponent();
            InitializeTargets(10);
            InitializeMovementTimer();
            InitializeCountdownTimer();
            InitializeSkillTimer();
            InitializeHeart(); // 추가된 코드
            InitializeExamTimer(); // 추가된 코드
            Movement.Interval = 50; // 타이머 간격을 50ms로 설정
            Movement.Tick += Movement_Tick; // 타이머 이벤트 핸들러
            Movement.Start(); // 타이머 시작 !

            round_txt.Text = "1"; // 초기 라운드를 1로 설정
            RemainTime = 30; // 초기 남은 시간을 30초로 설정

            this.DoubleBuffered = true;

            gun = new CSShooting(new Vec2(0f, 0f));
            backgroundImg = new CSBG(new Vec2(0, 0), new Vec2(this.Width, this.Height));
            panelQ = new CSPanel(new Vec2(this.Width / 2 - 40, this.Height - 80), Skill.SKILL_Q);
            panelW = new CSPanel(new Vec2(this.Width / 2 + 40, this.Height - 80), Skill.SKILL_W);
            objects.Add(backgroundImg);
            objects.Add(gun);
            objects.Add(panelQ);
            objects.Add(panelW);

            CSTimeManager.GetInstance();

            CSRTRenderer.GetInstance().Current = this;
            MediaPlayer.Visible = false;
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string startDirectory = "";
            int count = 3;
            for (int i = currentDirectory.Length - 1; i >= 0; i--)
            {
                if (currentDirectory[i] == '\\')
                {
                    count--;
                    if (count == 0)
                    {
                        startDirectory = currentDirectory.Substring(0, i);
                        break;
                    }
                }
            }
            MediaPlayer.URL =
                startDirectory + "\\Resources\\Musics\\BGM.wav";
            MediaPlayer.settings.volume = 70;

            WTimer = new Timer();
            WTimer.Interval = 5000;
            WTimer.Tick += movementStart;

            this.KeyDown += new KeyEventHandler(Form1_KeyDown); // 키 이벤트 핸들러 추가
            this.MouseMove += new MouseEventHandler(Mouse_Move); // 마우스 옆에 스킬 쿨타임 표시
        }

        public void Render(object sender, PaintEventArgs e)
        {
            CSRTRenderer.GetInstance().Form_Paint(sender, e);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MediaPlayer.Ctlcontrols.play();
        }

        struct Location
        {
            public double X, Y;

            public Location(double x, double y)
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
                    Name = $"Target1_HW{i}",
                    Size = new Size(100, 100),
                    BackColor = Color.Transparent,
                    Image = Properties.Resources.Book1,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                target.Location = GetRandomLocation(target.Size);
                target.Click += Target_Click; // 클릭 이벤트 핸들러
                this.Controls.Add(target);
                targets.Add(target);

                // 초기 속도와 방향 설정
                Location velocity = new Location(random.NextDouble() * 4 - 2, random.NextDouble() * 4 - 2);

                velocities[target] = velocity;
            }

            //타겟2 생성
            for (int i = 0; i < 3; i++)
            {
                PictureBox target2 = new PictureBox
                {
                    Name = $"Target2_HW{i}",
                    Size = new Size(50, 50),
                    BackColor = Color.Transparent,
                    Image = Properties.Resources.Book2,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                target2.Location = GetRandomLocation(target2.Size);
                target2.Click += Target_Click; // 클릭 이벤트 핸들러
                this.Controls.Add(target2);
                targets.Add(target2);

                // 초기 속도와 방향 설정
                Location velocity = new Location(random.NextDouble() * 20 - 10, random.NextDouble() * 20 - 10);
                velocities[target2] = velocity;
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
            Location velocity = velocities[target];
            velocity.X += random.NextDouble() * 0.2 - 0.1;
            velocity.Y += random.NextDouble() * 0.2 - 0.1;
            velocities[target] = velocity;
        }

        private Point GetRandomLocation(Size size)
        {
            int maxX = ClientSize.Width - size.Width;
            int minY = 120; // 최소 Y 위치를 120으로 설정
            int maxY = ClientSize.Height - size.Height;
            return new Point(random.Next(maxX), random.Next(minY, maxY));
        }

        private void InitializeExamTimer()
        {
            examTimer = new Timer();
            examTimer.Interval = 1000; // 1초 간격
            examTimer.Tick += ExamTimer_Tick;
        }

        private void ExamTimer_Tick(object sender, EventArgs e)
        {
            examDuration--;

            if (examDuration <= 0)
            {
                examTimer.Stop();
                currentGameState = GameState.Normal;
                RemainTime = 30; // 일반 라운드로 돌아가면서 타이머 재설정
                round_txt.Text = $"{Round}";
                CountDownTimer.Start(); // 일반 라운드 타이머 다시 시작
                examDuration = 10; // 시험 라운드 지속 시간 재설정
            }
            else
            {
                RemainTime = examDuration;
                Time.Text = RemainTime.ToString();
            }
        }

        private void Movement_Tick(object sender, EventArgs e)
        {
            foreach (var target in targets)
            {
                if (target.Visible)
                {
                    Location velocity = velocities[target];
                    // 새 위치 계산
                    Point newPosition = new Point(
                        target.Location.X + (int)velocity.X,
                        target.Location.Y + (int)velocity.Y
                    );

                    // 화면 경계에 도달하면 튕겨지도록 처리
                    if (newPosition.X < 0 || newPosition.X > ClientSize.Width - target.Width)
                    {
                        velocity.X = -velocity.X;
                    }
                    if (newPosition.Y < 120 || newPosition.Y > ClientSize.Height - target.Height)
                    {
                        velocity.Y = -velocity.Y;
                    }

                    target.Location = newPosition;

                    // 속도 업데이트
                    velocities[target] = velocity;

                    // 지속적으로 타겟의 Location 변경
                    AdjustVelocityRandomly(target);
                }
            }
        }

        private Vec2 TargetCenterPos(PictureBox target)
        {
            return new Vec2(target.Location.X + target.Size.Width / 2, target.Location.Y + target.Size.Height / 2);
        }

        private void SkillPlay()
        {
            switch (currentSkill)
            {
                case Skill.AUTOATTACK:
                    gun.AutoAttack();
                    break;
                case Skill.SKILL_Q:
                    gun.SkillQ();
                    break;
            }
        }
        private void Target_Click(object sender, EventArgs e)
        {
            PictureBox clickedTarget = sender as PictureBox;

            if (currentSkill == Skill.AUTOATTACK)
            {
                gun.Position = TargetCenterPos(clickedTarget);
                SkillPlay();
            }

            if (clickedTarget != null && clickedTarget.Visible)
            {
                if (clickedTarget.Name.StartsWith("Target1"))
                {
                    // 타겟1을 클릭시
                    clickedTarget.Visible = false; // 클릭한 타겟 숨기기 or 새로운 효과
                    score += 10; // 타겟1은 10점 증가, 2는 30 , 3은 .. , 교수님, 조교님은 - x 점

                    Point.Text = score.ToString();

                    // 새로운 타겟1 추가
                    PictureBox newTarget1 = new PictureBox
                    {
                        Name = $"Target1_HW{targets.Count}",
                        Size = new Size(100, 100),
                        BackColor = Color.Transparent,
                        Image = Properties.Resources.Book1,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    newTarget1.Location = GetRandomLocation(newTarget1.Size);
                    newTarget1.Click += Target_Click; // 클릭 이벤트 핸들러
                    this.Controls.Add(newTarget1);
                    targets.Add(newTarget1);

                    // 새로 생성된 타겟1의 초기 속도와 방향 설정
                    Location velocity = new Location(random.NextDouble() * 2 - 1, random.NextDouble() * 2 - 1);
                    velocities[newTarget1] = velocity;
                }
                else if (clickedTarget.Name.StartsWith("Target2"))
                {
                    // 타겟2를 클릭한 경우
                    clickedTarget.Visible = false; // 클릭한 타겟 숨기기 faeout 효과 같은거 추가 할 수 있으면 추가
                    score += 30;
                    Point.Text = score.ToString();

                    // 새로운 타겟2 추가
                    PictureBox newTarget2 = new PictureBox
                    {
                        Name = $"Target2_HW{targets.Count}",
                        Size = new Size(50, 50), // 새로운 타겟2의 크기 설정 50,50은 너무 작나? 싶기도 함
                        BackColor = Color.Transparent,
                        Image = Properties.Resources.Book2, // 새로운 타겟2의 이미지 설정 우선은.. 책 이미지로
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    newTarget2.Location = GetRandomLocation(newTarget2.Size);
                    newTarget2.Click += Target_Click; // 클릭 이벤트 핸들러 추가
                    this.Controls.Add(newTarget2);
                    targets.Add(newTarget2);

                    // 초기 속도와 방향 설정
                    Location velocity2 = new Location(random.NextDouble() * 20 - 10, random.NextDouble() * 20 - 10);
                    velocities[newTarget2] = velocity2;
                }
                else if (clickedTarget.Name.StartsWith("SpecialMonster"))
                {
                    clickedTarget.Visible = false; // 클릭한 타겟 숨기기
                    score += 100; // 특별한 몬스터는 더 많은 점수를 줌
                    Point.Text = score.ToString();
                    AddSpecialMonster(); // 새로운 특별한 몬스터 추가
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            gun.Position = new Vec2(e.X, e.Y);
            SkillPlay();
        }

        private void InitializeCountdownTimer()
        {
            CountDownTimer = new Timer();
            CountDownTimer.Interval = 1000; // 1초 간격
            CountDownTimer.Tick += CountdownTimer_Tick; // 타이머 이벤트 핸들러
            CountDownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            RemainTime--; // 시간 감소
            if (RemainTime <= 0)
            {
                CountDownTimer.Stop(); // 타이머를 멈춤

                // 라운드 증가를 올바르게 처리
                Round++; // 라운드 증가
                round_txt.Text = $"{Round}"; // 라벨 값 갱신
                RemainTime = 30; // 타이머 재설정

                if (Round % 6 == 0)
                {
                    currentGameState = GameState.Final;
                    StartFinalExamRound(); // 기말고사 라운드 시작
                }
                else if (Round % 3 == 0)
                {
                    currentGameState = GameState.Midterm;
                    StartMidtermRound(); // 중간고사 라운드 시작
                }
                else
                {
                    CountDownTimer.Start(); // 일반 라운드 타이머 다시 시작
                }
            }
            Time.Text = RemainTime.ToString();
        }

        private void StartMidtermRound()
        {
            // 중간고사 라운드 타이머 시작
            examTimer.Start();
            round_txt.Text = "중간고사";

            // 중간고사 라운드에 대한 추가 로직 (특별한 몬스터 추가 등)
            //AddMidMonster();
        }

        private void StartFinalExamRound()
        {
            // 기말고사 라운드 타이머 시작
            examTimer.Start();
            round_txt.Text = "기말고사";

            // 기말고사 라운드에 대한 추가 로직 (더 강력한 몬스터 추가 등)
            //AddFinalMonster();
        }

        private void InitializeSkillTimer()
        {
            Skill_Timer = new Timer();
            Skill_Timer.Interval = 1000;
            Skill_Timer.Tick += SkillTimer_Tick;
        }

        private void SkillTimer_Tick(object sender, EventArgs e)
        {
            int remainingTime = int.Parse(Skill_Left_Time.Text);
            remainingTime--;

            if (remainingTime <= 0)
            {
                Skill_Timer.Stop();
                Skill_Left_Time.Text = "0";
            }
            else
            {
                Skill_Left_Time.Text = remainingTime.ToString();
            }
        }

        // Q 키를 눌렀을 때의 이벤트 핸들러
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q && Skill_Left_Time.Text == "0")
            {
                // Q 키를 눌렀을 때의 동작 추가
                // 스킬 발동
                currentSkill = Skill.SKILL_Q;
                ActivateSkill();
                currentSkill = Skill.AUTOATTACK;
                panelQ.Charging();
                panelW.Charging();


            }
            if (e.KeyCode == Keys.W && Skill_Left_Time.Text == "0")
            {
                // W 키를 눌렀을 때의 동작 추가
                // 스킬 발동
                currentSkill = Skill.SKILL_W;
                timeSkill();
                currentSkill = Skill.AUTOATTACK;
                panelQ.Charging();
                panelW.Charging();

            }
        }

        // 스킬 발동 메서드
        private void ActivateSkill()
        {
            int clickRadius = 200; // 클릭 반경 . 우선은 200 나중에 100*x(스킬 레벨업으로 설정)

            // 마우스 클릭 위치
            Point clickPosition = Cursor.Position;
            clickPosition = PointToClient(clickPosition);

            //스킬 애니메이션
            gun.Position = new Vec2(clickPosition.X, clickPosition.Y);
            SkillPlay();

            // 주변에 있는 타겟을 감지하고 클릭한 것으로 처리
            for (int i = 0; i < targets.Count; i++)
            {
                var target = targets[i];
                Point targetCenter = new Point(target.Location.X + target.Width / 2, target.Location.Y + target.Height / 2);
                double distance = DistanceBetweenPoints(clickPosition, targetCenter);

                if (distance <= clickRadius && target.Visible)
                {
                    // 타겟이 클릭 반경 내에 있고 보이는 상태인 경우 클릭 처리
                    Target_Click(target, EventArgs.Empty);
                }
                //큰 이펙트 하나 추가가 되면 좋을 듯
            }
            // 스킬 쿨타임 타이머 시작
            Skill_Timer.Start();
            Skill_Left_Time.Text = "5"; // 스킬 쿨타임 초기화 (5초)

            panelQ.Charging();
        }

        private void timeSkill()
        {
            movementTimer.Stop();
            Movement.Stop();
            gun.SkillW();
            WTimer.Start();
        }

        private void movementStart(object sender, EventArgs e)
        {
            movementTimer.Start();
            Movement.Start();
            WTimer.Stop();
        }
        // 두 점 사이의 거리 계산
        private double DistanceBetweenPoints(Point point1, Point point2)
        {
            int dx = point2.X - point1.X;
            int dy = point2.Y - point1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            // 마우스 위치에 따라 라벨 위치 업데이트
            UpdateSkillLabelPosition(e.Location);
        }
        private void UpdateSkillLabelPosition(Point mousePosition)
        {
            int offset = 10; // 마우스 커서에서 라벨까지의 거리
            Skill_Left_Time.Location = new Point(mousePosition.X + offset, mousePosition.Y + offset);
        }

        private void InitializeHeart()
        {
            heart_indicator = new PictureBox[] { life1, life2, life3, life4, life5 };

            foreach (var Left_life in heart_indicator)
            {
                Left_life.Image = Properties.Resources.pixelheart;
                Left_life.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            UpdateHeartDisplay();
        }

        private void UpdateHeartDisplay()
        {
            for (int i = 0; i < heart_indicator.Length; i++)
            {
                heart_indicator[i].Visible = i < heart;
            }
        }

        private void DecreaseLife()
        {
            if (heart > 0)
            {
                heart--;
                UpdateHeartDisplay();

                if (heart == 0)
                {
                    GameOver();
                }
            }
        }

        private void GameOver()
        {
            // 게임 오버 처리 로직 추가
            MessageBox.Show("Game Over");
        }

        // 게임 로직에 따라 목숨이 줄어드는 이벤트 발생 시 DecreaseLife 메서드 호출해서 라이프 감소
        private void DecreaseLif()
        {
            DecreaseLife();
        }


        public class SpecialMonster
        {
            public PictureBox PictureBox { get; set; }
            public Timer Timer { get; set; }
            public Timer ColorChangeTimer { get; set; }
            public int CurrentImageIndex { get; set; }

            public SpecialMonster(PictureBox pictureBox, Timer timer, Timer colorChangeTimer)
            {
                PictureBox = pictureBox;
                Timer = timer;
                ColorChangeTimer = colorChangeTimer;
                CurrentImageIndex = 0;
            }
        }

        private Image[] monsterImages;
        private int currentImageIndex = 0;

        private void LoadMonsterImages()
        {
            monsterImages = new Image[]
            {
                Properties.Resources.s1,
                Properties.Resources.s2,
                Properties.Resources.s3,
                Properties.Resources.s4,
                Properties.Resources.s5
            };
        }

        private List<SpecialMonster> specialMonsters = new List<SpecialMonster>();
        private void AddSpecialMonster()
        {
            // 특별한 몬스터를 생성하고 설정
            PictureBox specialMonster = new PictureBox
            {
                Name = $"SpecialMonster{targets.Count}",
                Size = new Size(100, 100), 
                BackColor = Color.Transparent,
                Image = monsterImages[0], // 회색의 책으로 설정
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            specialMonster.Location = GetRandomLocation(specialMonster.Size);
            specialMonster.Click += SpecialMonster_Click;
            this.Controls.Add(specialMonster);
            targets.Add(specialMonster);

            // 속도 설정
            Location velocity = new Location(random.NextDouble() * speed - 2, random.NextDouble() * speed - 2);
            velocities[specialMonster] = velocity;

            // 타이머 설정
            Timer specialMonsterTimer = new Timer();
            specialMonsterTimer.Interval = 5000; // 5초
            specialMonsterTimer.Tick += (s, e) => SpecialMonsterTimeout(s, e, specialMonster);
            specialMonsterTimer.Start();

            // 색상 변경 타이머 설정
            Timer colorChangeTimer = new Timer();
            colorChangeTimer.Interval = 700; // 0.7초 간격으로 이미지 변경
            colorChangeTimer.Tick += (s, e) =>
            {
                var sm = specialMonsters.FirstOrDefault(monster => monster.PictureBox == specialMonster);
                if (sm != null && sm.CurrentImageIndex < monsterImages.Length)
                {
                    sm.PictureBox.Image = monsterImages[sm.CurrentImageIndex];
                    sm.CurrentImageIndex++;
                }
            };
            colorChangeTimer.Start();

            specialMonsters.Add(new SpecialMonster(specialMonster, specialMonsterTimer, colorChangeTimer));
        }
        private void SpecialMonsterTimeout(object sender, EventArgs e, PictureBox specialMonster)
        {
            // 타이머가 만료되면 Herat 감소
            if (specialMonster.Visible)
            {
                specialMonster.Visible = false; //
                DecreaseLife();
            }

            // 타이머 정지 및 제거
            var specialMonsterData = specialMonsters.FirstOrDefault(sm => sm.PictureBox == specialMonster);
            if (specialMonsterData != null)
            {
                specialMonsterData.Timer.Stop();
                specialMonsterData.ColorChangeTimer.Stop();
                specialMonsters.Remove(specialMonsterData);
            }

        }



        private void SpecialMonster_Click(object sender, EventArgs e)
        {
            PictureBox clickedMonster = sender as PictureBox;

            if (currentSkill == Skill.AUTOATTACK)
            {
                gun.Position = TargetCenterPos(clickedMonster);
                SkillPlay();
            }

            if (clickedMonster != null && clickedMonster.Visible)
            {
                clickedMonster.Visible = false;
                score += 100; // 한 100점?...
                Point.Text = score.ToString();

                // 타이머 정지 및 제거
                var specialMonster = specialMonsters.FirstOrDefault(sm => sm.PictureBox == clickedMonster);
                if (specialMonster != null)
                {
                    specialMonster.Timer.Stop();
                    specialMonster.ColorChangeTimer.Stop();
                    specialMonsters.Remove(specialMonster);
                }

                // 새로 추가(계속 하나씩은 있도록)
                AddSpecialMonster();
            }
        }

    }
}
