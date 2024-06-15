using Numerics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KW_Shooting
{
    internal class CSPanel : CSObject
    {
        public CSPanel(Vec2 pos, Skill skill):base(pos)
        {
            CreateAnimator();

            m_scale.x = 75;
            m_scale.y = 75;

            switch (skill) 
            {
                case Skill.SKILL_Q:
                    m_animator.DefaultImg = Properties.Resources.DefaultQ;
                    m_animator.CreateAnimation("charge", Properties.Resources.SkillPanel, new Vec2(0, 0), new Vec2(75, 75), new Vec2(75, 0), 4, 1.66f);
                    break;
                case Skill.SKILL_W:
                    m_animator.DefaultImg = Properties.Resources.DefaultW;
                    m_animator.CreateAnimation("charge", Properties.Resources.SkillPanel, new Vec2(0, 75), new Vec2(75, 75), new Vec2(75, 0), 4, 1.66f);
                    break;

            }
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

        public void Charging()
        {
            m_animator.PlayAnimation("charge", 1);
        }
    }
}
