using Numerics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace KW_Shooting
{
    enum Skill
    {
        AUTOATTACK,
        SKILL_Q,
        SKILL_W,
    }
    internal class CSShooting : CSObject
    {
        public CSShooting(Vec2 pos) : base(pos) 
        {
            m_timerSound = new System.Windows.Forms.Timer();
            m_timerSound.Interval = 5000;
            m_timerSound.Tick += Wait5Sec;

            m_effectSound = new SoundPlayer[]
            {
                new SoundPlayer(Properties.Resources.AutoAttackSound),
                new SoundPlayer(Properties.Resources.SkillQSound),
                new SoundPlayer(Properties.Resources.SkillWSound)
            };
            CreateAnimator();
            m_animator.CreateAnimation("AutoAttack", Properties.Resources.gunEffect, new Vec2(0, 0), new Vec2(192, 192), new Vec2(192, 0), 5, 0.1f);
            m_animator.CreateAnimation("SkillQ", Properties.Resources.explosion, new Vec2(0, 0), new Vec2(402, 519), new Vec2(402, 0), 17, 0.1f);
        }

        private SoundPlayer[] m_effectSound;
        private System.Windows.Forms.Timer m_timerSound;
        private Skill m_skill;
        private void Wait5Sec(object o, EventArgs e)
        {
            m_effectSound[(int)m_skill].Stop();
            m_timerSound.Stop();
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

        public void Play()
        {
            m_effectSound[(int)m_skill].Play();
            m_timerSound.Start();
            switch(m_skill) 
            {
                case Skill.AUTOATTACK:
                    m_animator.PlayAnimation("AutoAttack", 1);
                    break;
                case Skill.SKILL_Q:
                    m_animator.PlayAnimation("SkillQ", 1);
                    break;
            }

        }
        public void AutoAttack()
        {
            m_skill = Skill.AUTOATTACK;
            Play();
        }

        public void SkillQ()
        {
            m_skill = Skill.SKILL_Q;
            Play();
        }

        public void SkillW()
        {
            m_skill = Skill.SKILL_W;
            Play();
        }
    }
}
