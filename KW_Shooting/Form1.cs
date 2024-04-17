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
using Numerics;

namespace KW_Shooting
{
    public partial class Form1 : Form
    {
        CSPlayer player;
        Timer timer;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            player = new CSPlayer(new Vec2(200f, 200f));
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += update;
            timer.Start();
            CSTimeManager.GetInstance();
        }

        private void Form1_Update(object sender, MouseEventArgs e)
        {
            player.Position = new Vec2(e.X, e.Y);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //player부모 객체인 CSObject의 update함수를 사용해도 무방하다.
            player.Update();
            player.Render(e.Graphics);
        }
        private void update(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}