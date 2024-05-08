using Numerics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
        private int m_playTime;
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
            Vec2 startPos = playObj.Position - m_vecFrm[m_currentIdx].scale * 0.5f;
            RectangleF srcRect = new RectangleF(m_vecFrm[m_currentIdx].pos.x, m_vecFrm[m_currentIdx].pos.y
                , m_vecFrm[m_currentIdx].scale.x, m_vecFrm[m_currentIdx].scale.y);
            RectangleF dstRect = new RectangleF(new PointF(startPos.x,startPos.y),new SizeF(srcRect.Width,srcRect.Height));
            
            //startPos = playObj.Position;
            g.DrawImage(m_image, dstRect, srcRect, GraphicsUnit.Pixel);

        }
        public void Update()
        {
            if(m_animator.PlayCount != 0)
            {
                if (m_animator.PlayCount == m_playTime)
                {
                    m_animator.StopAnimation();
                }
            }

            Action UpdateFrm = () =>
            {
                m_currentIdx++;
                m_currentIdx %= m_vecFrm.Count;
                if (m_currentIdx == m_vecFrm.Count - 1)
                {
                    m_playTime++;
                }
            };

            float current_time = CSTimeManager.GetInstance().GetFDT();
            float elapsed_time = current_time - m_time;
            if (elapsed_time > m_vecFrm[m_currentIdx].time)
            {
                UpdateFrm();
                m_time = current_time;
            }
            else if (elapsed_time < 0) //out of bound
            {
                if (elapsed_time + 1000f > m_vecFrm[m_currentIdx].time)
                {
                    UpdateFrm();
                    m_time = current_time;
                }
            }
        }
        public void Initialize()
        {
            m_currentIdx = 0;
            m_time = 0;
            m_playTime = 0;
        }
    }
}
