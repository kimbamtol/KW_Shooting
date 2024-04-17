using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KW_Shooting
{
    /*
     * 싱글톤 패턴으로 타임매니저를 구현하였습니다.
     * 시간동기화를 위한 클래스이고 경과시간을 얻고 싶을때 사용하는 클래스입니다.
     */
    internal class CSTimeManager
    {
        private CSTimeManager()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }
        private static CSTimeManager Instance;
        private static Stopwatch stopwatch;
        public static CSTimeManager GetInstance()
        {
            if (null == Instance)
            {
                Instance = new CSTimeManager();
                return Instance;
            }
            return Instance;
        }

        public int GetDT()
        {
            return stopwatch.Elapsed.Seconds;
        }
        public float GetFDT()
        {
            return stopwatch.Elapsed.Milliseconds / 1000f;
        }
    }
}
