using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
            m_playCount = 0;
        }
        private CSObject m_owner;
        private CSAnimation m_curAnim;
        public CSObject Owner { get { return m_owner; } set { m_owner = value; } }

        private Dictionary<string, CSAnimation> m_dicAnim;

        private int m_playCount;
        public int PlayCount { get { return m_playCount; }}

        public void CreateAnimation(string animation_name, Bitmap image, Vec2 start, Vec2 scale, Vec2 step, int num, float time)
        {
            if (m_dicAnim.ContainsKey(animation_name))
            {
                return;
            }
            Action RemoveBg = () =>
            {
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        Color pixelColor = image.GetPixel(x, y);
                        if (pixelColor == Color.FromArgb(255, 0, 255))
                        {
                            image.SetPixel(x, y, Color.FromArgb(0, 0, 0, 0)); // 투명 픽셀로 설정
                        }
                    }

                };
            };
            RemoveBg();
            CSAnimation animation = new CSAnimation();
            animation.Animator = this;
            animation.Create(image, start, scale, step, num, time);
            m_dicAnim.Add(animation_name, animation);
        }

        public void PlayAnimation(string animation_name, int play_time=0)
        {
            if (!m_dicAnim.ContainsKey(animation_name))
            {
                return;
            }
            m_curAnim = m_dicAnim[animation_name];
            m_playCount = play_time;
        }
        public void StopAnimation()
        {
            m_curAnim.Initialize();
            m_curAnim = null;
        }
        public void Render(Graphics g, params Vec2[] optional)
        {
            if (m_curAnim != null)
            {
                try
                {
                    m_curAnim.Render(g,optional);
                }
                catch(Exception e) 
                {
                    Console.WriteLine(e.ToString());
                } 
                
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