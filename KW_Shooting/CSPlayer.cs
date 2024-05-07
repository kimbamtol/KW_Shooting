using Numerics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KW_Shooting
{
    /*
     * 테스트를 위해서 임시로 만든 클래스입니다.
     */
    internal class CSPlayer : CSObject
    {
        public CSPlayer(Vec2 pos) : base(pos)
        {
            CreatAnimator();
            m_animator.CreateAnimation("Generate", Properties.Resources.Monster, new Vec2(80, 0), new Vec2(80, 80), new Vec2(80, 0), 5, 0.2f);
            m_animator.CreateAnimation("Default", Properties.Resources.Monster, new Vec2(168, 86), new Vec2(80, 80), new Vec2(80, 0), 4, 0.2f);
            m_animator.PlayAnimation("Generate");
        }
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

        private int m_hp;
        private float m_speed;



    }
}
