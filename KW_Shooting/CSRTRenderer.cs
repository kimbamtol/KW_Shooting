using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Utils;

namespace KW_Shooting
{
    /*
    * CObject를 실시간으로 렌더링하는 클래스입니다.
    */

    internal class CSRTRenderer
    {
        private CSRTRenderer() 
        {
            m_timer = new System.Windows.Forms.Timer();
            m_timer.Interval = 1;
            m_timer.Tick += Update;
            m_timer.Start();
        }

        private IRenderer m_current;
        private Control m_screen;

        private static CSRTRenderer instance;

        private System.Windows.Forms.Timer m_timer;
        public static CSRTRenderer GetInstance()
        {
            if(null == instance)
            {
                instance = new CSRTRenderer();
                return instance;
            }
            return instance;
        }
        
        public IRenderer Current
        { set { m_current = value;m_screen = (Control)m_current; } }

        private void Update(object sender, EventArgs e)
        {
            m_screen.Invalidate();
        }

        public void Form_Paint(object sender, PaintEventArgs e)
        {
            foreach (CSObject obj in m_current.GameObjs)
            {
                obj.Update();
                obj.Render(e.Graphics);
            }
        }

    }
}
