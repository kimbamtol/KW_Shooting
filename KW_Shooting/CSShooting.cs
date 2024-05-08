using Numerics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;

namespace KW_Shooting
{
    internal class CSShooting : CSObject
    {
        public CSShooting(Vec2 pos) : base(pos) 
        {
            GunShot = new SoundPlayer(Properties.Resources.GUNSHOT);
            CreateAnimator();
            m_animator.CreateAnimation("Shooting1", Properties.Resources.gunEffect, new Vec2(0, 0), new Vec2(192, 192), new Vec2(192, 0), 5, 0.1f);       
        }

        private SoundPlayer GunShot;
        public override void Update()
        {
            if (null != m_animator)
            {
                m_animator.Update();
            }

        }
        public override void Render(Graphics g)
        {
            if (null != m_animator)
            {
                ComponentRender(g);
            }

        }

        public void Shoot(string name)
        {
            Thread SoundThread = new Thread(()=> GunShot.Play());
            SoundThread.Start();
            m_animator.PlayAnimation(name, 1);
        }
    }
}
