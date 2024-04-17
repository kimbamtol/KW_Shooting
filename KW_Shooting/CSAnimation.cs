using Numerics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KW_Shooting
{
    struct AnimFrm
    {
        public float time;
        public Vec2 scale;
        public Vec2 pos;

        public AnimFrm(float _time, Vec2 _scale, Vec2 _pos)
        {
            this.time = _time;
            this.scale = _scale;
            this.pos = _pos;
        }
    }

    internal class CSAnimation
    {
        private CSAnimator m_animator;
        public CSAnimator Animator { get { return m_animator; } set { m_animator = value; } }

        private List<AnimFrm> m_vecFrm;
        private Bitmap m_image;
        private int m_currentIdx;
        private float m_time;

        public CSAnimation()
        {
            m_animator = null;
            m_vecFrm = new List<AnimFrm>();
            m_image = null;
            m_currentIdx = 0;
            m_time = 0;
        }
        public void Create(Bitmap image, Vec2 start, Vec2 scale, Vec2 step, int num, float time)
        {
            m_image = image;
            for (int i = 0; i < num; i++)
            {
                m_vecFrm.Add(new AnimFrm(time, scale, start + step * i));
            }
        }
        public void Render(Graphics g)
        {
            CSObject playObj = m_animator.Owner;
            Vec2 objPos = playObj.Position;
            m_currentIdx %= m_vecFrm.Count;
            RectangleF srcRect = new RectangleF(m_vecFrm[m_currentIdx].pos.x, m_vecFrm[m_currentIdx].pos.y
                , m_vecFrm[m_currentIdx].scale.x, m_vecFrm[m_currentIdx].scale.y);
            Vec2 startPos = objPos - m_vecFrm[m_currentIdx].scale * 0.5f;
            g.DrawImage(m_image, startPos.x, startPos.y, srcRect, GraphicsUnit.Pixel);
        }
        public void Update()
        {
            float current_time = CSTimeManager.GetInstance().GetFDT();
            if (current_time - m_time > m_vecFrm[m_currentIdx].time)
            {
                m_currentIdx++;

                m_currentIdx %= m_vecFrm.Count;
                m_time = current_time;
            }
            else if (current_time - m_time < 0)
            {
                if (current_time - m_time + 1000f > m_vecFrm[m_currentIdx].time)
                {
                    m_currentIdx++;
                    m_currentIdx %= m_vecFrm.Count;
                    m_time = current_time;
                }
            }
        }
    }
}
