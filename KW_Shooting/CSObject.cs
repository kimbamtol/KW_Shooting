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
     * 몬스터나 물체 같은 객체를 화면에 출력할 때 이 CSObject클래스를 상속받아서 사용하시면 됩니다.
     * 만약 출력할려는 객체에 애니메이션을 추가하고자 한다면 이 클래스의 CreatAnimator함수를 생성자에 사용해서 CSAnimator클래스를 추가해준 뒤에 CSAnimator 클래스의
     * 메소드를 사용해 애니메이션을 생성하시면 됩니다.
     * 객체당 하나의 CSAnimator 클래스를 배정해주시면 됩니다.(애니메이션이 필요없는 객체라면 CSAnimator 클래스를 할당하지 않아도 됩니다.)
     */
    internal class CSObject
    {
        protected Vec2 m_pos;
        protected Vec2 m_scale;
        protected CSAnimator m_animator;

        public Vec2 Position { get { return m_pos; } set { m_pos = value; } }
        public CSObject(Vec2 pos)
        {
            m_pos = pos;
            m_scale = new Vec2();
            m_animator = null;
        }

        public virtual void Render(Graphics g)
        {
        }

        public virtual void Update()
        {
        }
        public void CreateAnimator()
        {
            m_animator = new CSAnimator();
            m_animator.Owner = this;
        }

        public void ComponentRender(Graphics g, params Vec2[] optional)
        {

            if (null != m_animator)
            {
                try
                {
                    m_animator.Render(g, optional);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            }
        }
    }
}