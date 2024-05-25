using Numerics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KW_Shooting
{
    internal class CSBG :CSObject
    {
        public CSBG(Vec2 pos, Vec2 scale):base(pos) 
        {
            m_pos = new Vec2(619, 247)*0.5f;
            m_scale = scale;
            CreateAnimator();
            m_animator.CreateAnimation("default", Properties.Resources.background1, new Vec2(0, 0), new Vec2(619, 247), new Vec2(1,0), 600, 0.1f);
            m_animator.PlayAnimation("default");
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
            if(null != m_animator) 
            {
                ComponentRender(g, m_scale);
            }
        }

    }
}
