using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.player
{

    /// <summary>
    /// 概念，范围消息
    /// </summary>
    public class RangeMes
    {
        //底部
        private int low;
        private int up;
        private String[] outMes;

        public RangeMes(int low0, int up0, string[] outMes0)
        {
            low = low0;
            up = up0;
            outMes = outMes0;
        }
        public bool Contain(int i)
        {
            if(i>=low&&i<=up)
            {
                return true;
            }
            else
                return false;
        }

        public string SendRan()
        {
            return outMes[(new Random()).Next(outMes.Length)];
        }
    }
}
