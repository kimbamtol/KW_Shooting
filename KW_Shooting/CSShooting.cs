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
    enum Skill
    {
        AUTOATTACK,
        Skill_Q,
        END,
    }
    internal class CSShooting : CSObject
    {
        public CSShooting(Vec2 pos) : base(pos) 
        {

            //GunShot[AUTOAT] = new SoundPlayer(Properties.Resources.GUNSHOT);
            effectSound = new SoundPlayer[]
            {
                new SoundPlayer(Properties.Resources.AutoAttackSound),
                new SoundPlayer(Properties.Resources.SkillQSound)
            };
            CreateAnimator();
            m_animator.CreateAnimation("AutoAttack", Properties.Resources.gunEffect, new Vec2(0, 0), new Vec2(192, 192), new Vec2(192, 0), 5, 0.1f);
            m_animator.CreateAnimation("SkillQ", Properties.Resources.explosion, new Vec2(0, 0), new Vec2(402, 519), new Vec2(402, 0), 17, 0.1f);
        }

        private SoundPlayer[] effectSound;
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

        public void AutoAttack()
        {
            effectSound[(int)Skill.AUTOATTACK].Play();
            m_animator.PlayAnimation("AutoAttack", 1);
        }

        public void SkillQ()
        {
            effectSound[(int)Skill.Skill_Q].Play();
            m_animator.PlayAnimation("SkillQ", 1);
        }
    }
}
