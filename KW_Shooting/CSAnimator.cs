using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Numerics;

namespace KW_Shooting
{
    /*
     * CreatAnimation메소드로 애니메이션을 생성하고 PlayAnimation함수를 실행하시면 애니메이션이 출력됩니다.
     */
    internal class CSAnimator
    {
        public CSAnimator()
        {
            m_owner = null;
            m_curAnim = null;
            m_dicAnim = new Dictionary<string, CSAnimation>();
        }
        private CSObject m_owner;
        private CSAnimation m_curAnim;
        public CSObject Owner { get { return m_owner; } set { m_owner = value; } }

        private Dictionary<string, CSAnimation> m_dicAnim;

        public void CreateAnimation(string animation_name, Bitmap image, Vec2 start, Vec2 scale, Vec2 step, int num, float time)
        {
            if (m_dicAnim.ContainsKey(animation_name))
            {
                return;
            }
            CSAnimation animation = new CSAnimation();
            animation.Animator = this;
            animation.Create(image, start, scale, step, num, time);
            m_dicAnim.Add(animation_name, animation);
        }

        public void PlayAnimation(string animation_name)
        {
            if (!m_dicAnim.ContainsKey(animation_name))
            {
                return;
            }
            m_curAnim = m_dicAnim[animation_name];
        }

        public void Render(Graphics g)
        {
            if (m_curAnim != null)
            {
                m_curAnim.Render(g);
            }
        }
        public void Update()
        {
            if (m_curAnim != null)
            {
                m_curAnim.Update();
            }
        }
    }
}