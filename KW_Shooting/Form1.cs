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
        List<object> objects = new List<object>();
        public List<object> GameObjs
        {
            get { return objects; }
        }

        CSPlayer player;

        public Form1()
        {
            InitializeComponent();
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
    }
}