using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainGame
{
    public partial class Form1 : Form
    {
        private string[] changingTexts = { "3월 2일", "3월 3일", "3월 4일", "3월 5일", "3월 6일", "3월 7일", "3월 8일", 
                                           "3월 9일", "3월 10일","3월 11일", "3월 12일", "3월 13일", "3월 14일", "3월 15일",
                                           "3월 16일", "3월 17일", "3월 18일", "3월 19일", "3월 20일", "3월 21일", "3월 22일",
                                           "3월 23일", "3월 24일","3월 25일", "3월 26일", "3월 27일", "3월 28일", "3월 29일",
                                           "3월 30일", "3월 31일", "4월 1일", "4월 2일", "4월 3일", "4월 4일", "4월 5일", "4월 6일",
                                           "4월 7일", "4월 8일", "4월 9일", "4월 10일", "4월 11일", "4월 12일", "4월 13일", "4월 14일",
                                           "4월 15일","4월 16일", "4월 17일", "4월 18일", "4월 19일", "4월 20일", "4월 21일", "4월 22일\n중간고사",
                                           "4월 22일\n중간고사","4월 22일\n중간고사","4월 22일\n중간고사"};
        private int changingTextIndex = 0;

        private string[] changingTexts2 = {"4월 23일", "4월 23일", "4월 23일", "4월 24일", "4월 25일", "4월 26일", "4월 27일", "4월 28일", "4월 29일",
                                           "4월 30일", "5월 1일","5월 2일", "5월 3일", "5월 4일", "5월 5일", "5월 6일",
                                           "5월 7일", "5월 8일", "5월 9일", "5월 10일", "5월 11일", "5월 12일", "5월 13일",
                                           "5월 14일", "5월 15일","5월 16일", "5월 17일", "5월 18일", "5월 19일", "5월 20일",
                                           "5월 21일", "5월 22일", "5월 23일", "5월 24일", "5월 25일", "5월 26일", "5월 27일", "5월 28일",
                                           "5월 29일", "5월 30일", "5월 31일", "6월 1일", "6월 2일", "6월 3일", "6월 4일", "6월 5일",
                                           "6월 6일","6월 7일", "6월 8일", "6월 9일", "6월 10일\n기말고사",
                                           "6월 10일\n기말고사","6월 10일\n기말고사","6월 10일\n기말고사"};
        private int changingTextIndex2 = 0;

        private bool isMExamFinished = false;
        private bool isFExamFinished = false;

        public Form1()
        {
            InitializeComponent();

            // 타이머 초기화
            bossSpawnTimer = new Timer();
            bossSpawnTimer.Interval = 52000; // 52초
            bossSpawnTimer.Tick += bossSpawnTimer_Tick;

            // 타이머2 초기화
            bossSpawnTimer2 = new Timer();
            bossSpawnTimer2.Interval = 52000; // 52초
            bossSpawnTimer2.Tick += bossSpawnTimer2_Tick;

            textTimer = new Timer();
            textTimer.Interval = 3000; // 3초
            textTimer.Tick += textTimer_Tick;

            // 시작 텍스트 타이머 초기화
            StartTextTimer = new Timer();
            StartTextTimer.Interval = 1000; // 1초
            StartTextTimer.Tick += StartTextTimer_Tick;

            // 중간고사 타이머
            MiddleExamTimer = new Timer();
            MiddleExamTimer.Interval = 10000; // 10초
            MiddleExamTimer.Tick += MiddleExamTimer_Tick;

            //중간고사 이후 텍스트 변경 타이머
            ChangeTextTimer = new Timer() { Interval = 1000 };
            ChangeTextTimer.Tick += ChangeTextTimer_Tick;

            // 기말고사 타이머
            FinalExamTimer = new Timer();
            FinalExamTimer.Interval = 10000; // 10초
            FinalExamTimer.Tick += FinalExamTimer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 게임 시작 시 타이머는 작동되지 않음
            bossSpawnTimer.Stop();
            textTimer.Stop();
            StartTextTimer.Stop();
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            bossSpawnTimer.Start(); //50초 세는중

            buttonStart.Visible = false;

            // 시작 텍스트 타이머 시작
            StartTextTimer.Start(); // 텍스트 바뀌는중
        }
        private void bossSpawnTimer_Tick(object sender, EventArgs e)
        {
            // 보스 몬스터 생성 전에 '중간고사 시작' 텍스트 출력
            ShowText("중간고사 시작", 3000);
            bossSpawnTimer.Stop();
        }

        private void textTimer_Tick(object sender, EventArgs e)
        {
            // TextTimer가 시작되면 StartTextTimer를 멈춤
            StartTextTimer.Stop();
            labelChangingText.Visible = true;
            // 3초 후에 텍스트 숨기기
            textLabel.Visible = false;
            textTimer.Stop();

            MiddleExamTimer.Start();
   

        }

        private void StartTextTimer_Tick(object sender, EventArgs e)
        {
            labelChangingText.Text = changingTexts[changingTextIndex];
            changingTextIndex = (changingTextIndex + 1) % changingTexts.Length;

        }

        private void MiddleExamTimer_Tick(object sender, EventArgs e)
        {
            if (!isMExamFinished)
            {
                ShowText("중간고사 종료", 3000);
                isMExamFinished = true;
                bossSpawnTimer2.Start();

                // 중간고사 종료 후에 텍스트 변경 타이머 시작
                ChangeTextTimer.Start();
            }
        }
        private void ChangeTextTimer_Tick(object sender, EventArgs e)
        {
            labelChangingText.Text = changingTexts2[changingTextIndex2];
            changingTextIndex2 = (changingTextIndex2 + 1) % changingTexts2.Length;
        }

        private void ShowText(string text, int duration)
        {
            textLabel.Text = text;
            textLabel.Font = new System.Drawing.Font("Arial", 40, System.Drawing.FontStyle.Bold);
            textLabel.ForeColor = System.Drawing.Color.Black;
            textLabel.AutoSize = true;
            textLabel.Left = (ClientSize.Width - textLabel.Width) / 2;
            textLabel.Top = (ClientSize.Height - textLabel.Height) / 2;
            textLabel.Visible = true;

            textTimer.Start();
        }

        private void bossSpawnTimer2_Tick(object sender, EventArgs e)
        {
            // 보스 몬스터 생성 전에 '기말고사 시작' 텍스트 출력
            ShowText("기말고사 시작", 3000);
            FinalExamTimer.Start();
            bossSpawnTimer2.Stop();
            ChangeTextTimer.Stop();
        }
        private void FinalExamTimer_Tick(object sender, EventArgs e)
        {
            // 종강 텍스트 출력
            ShowText("종강", 3000);
            FinalExamTimer.Stop();
        }

       
    }
}
